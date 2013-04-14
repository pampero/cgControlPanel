using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using Buscador.Domain;
using Buscador.Domain.com.clarin.dao;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.slices;
using Buscador.Domain.com.clarin.utils;
using SolrNet;
using Spring.Context.Support;
using IUrlOfuscator = Buscador.Domain.com.clarin.filters.IUrlOfuscator;
using UrlOfuscator = Buscador.Domain.com.clarin.filters.UrlOfuscator;

namespace Buscador.Services.com.clarin.services.impl
{
    public interface ISolrSearchService<T>
    {
        IFacetConfiguration FacetConfiguration { get; set; }
        //IFilterUrlBuilder FilterUrlBuilder { get; set; }
        ISliceCacheProvider CacheProvider { get; set; }
        IUrlOfuscator UrlOfuscator { get; set; }
        IPublicationTypeDao PublicationTypeDao { get; set; }
        IEntityLoader<T> EntityLoader { get; set; }
        IList<T> ConvertFrom(ISolrQueryResults<T> solrQueryResults);
        IResults<T> ConvertFrom(ISolrQueryResults<T> solrQueryResults, int actualPage, int pageSize, List<SelectedFilter> selectedFilters, string orderField, string orderDirection);

        IResults<T> Merge(IList<ISolrQueryResults<T>> results, int actualPage, int pageSize,
                          List<SelectedFilter> selectedFilters, string orderField, string orderDirection);
    }

    public class SolrSearchService<T> : ISolrSearchService<T>
    {
        private Action<T> _postLoadEntityAction;
        private IDictionary<Expression<Func<T, int>>, Expression<Func<T, string>>> _propertiesToLoad;
        public IFacetConfiguration FacetConfiguration { get; set; }
        //public IFilterUrlBuilder FilterUrlBuilder { get; set; }
        public ISliceCacheProvider CacheProvider { get; set; }
        public IUrlOfuscator UrlOfuscator { get; set; }
        public IPublicationTypeDao PublicationTypeDao { get; set; }
        public IEntityLoader<T> EntityLoader { get; set; }

        public SolrSearchService(Action<T> postLoadEntityAction, IDictionary<Expression<Func<T, int>>, Expression<Func<T, string>>> properties)
        {
            if (FacetConfiguration == null)
                FacetConfiguration = (IFacetConfiguration)ContextRegistry.GetContext().GetObject("facetConfiguration");

            if (UrlOfuscator == null)
                UrlOfuscator = (UrlOfuscator)ContextRegistry.GetContext().GetObject("urlOfuscator");

            //if (FilterUrlBuilder == null)
            //    FilterUrlBuilder = (FilterUrlBuilder)ContextRegistry.GetContext().GetObject("filterUrlBuilder");

            if (CacheProvider == null)
                CacheProvider = (SliceCacheProvider)ContextRegistry.GetContext().GetObject("cacheProvider");

            if (PublicationTypeDao == null)
                PublicationTypeDao = (IPublicationTypeDao)ContextRegistry.GetContext().GetObject("publicationTypeDao");

            EntityLoader = new PostSolrEntityLoader<T>();

            _postLoadEntityAction = postLoadEntityAction;
            _propertiesToLoad = properties;
        }

        public IList<T> ConvertFrom(ISolrQueryResults<T> solrQueryResults)
        {
            var publications = new List<T>();
            foreach (var solrQueryResult in solrQueryResults)
            {
                publications.Add(EntityLoader.LoadEntity(solrQueryResult, CacheProvider, _propertiesToLoad, _postLoadEntityAction));
            }
            return publications;
        }

        public IResults<T> ConvertFrom(ISolrQueryResults<T> solrQueryResults, int actualPage, int pageSize, List<SelectedFilter> selectedFilters, string orderField, string orderDirection)
        {
            IResults<T> result = new Results<T>(solrQueryResults.NumFound, pageSize);

            result.SetActualPage(actualPage);

           // result.Order = solrQueryResults.Header.Params.Where(x => x.Key == "sort").First().Value.Split(',')[0];

            string orderKey = "SO";
            IDictionary<string, string> availableOrderOptions= new Dictionary<string, string>();
             if (!availableOrderOptions.ContainsKey("PRD"))
            {
                availableOrderOptions.Add("PRD", "SO");
            }
            if (!availableOrderOptions.ContainsKey("YEA"))
            {
                availableOrderOptions.Add("YEA", "SO");
            }
            if (!availableOrderOptions.ContainsKey("YED"))
            {
                availableOrderOptions.Add("YED", "SO");
            }

            result.SetOrder(solrQueryResults.Header.Params.Where(x => x.Key == "sort").First().Value.Split(',')[0], 
                orderKey,
                availableOrderOptions);

            result.TotalResults = solrQueryResults.NumFound;

            bool hasSelectedFilters = false;
            if(selectedFilters != null && selectedFilters.Count != 0)
            {
                hasSelectedFilters = true;
            }

            if (pageSize != 0)
            {
                var topPage = (solrQueryResults.NumFound/pageSize) +
                    ((solrQueryResults.NumFound%pageSize)>0?1:0);

                for (var i = 1; i <= topPage; i++)
                {
                    string filterUrl = new FilterUrlBuilder(FacetConfiguration.FacetHierarchy, UrlOfuscator)
                                                            .BuildFrom(FacetConfiguration.FacetHierarchy, CacheProvider)
                                                            .WithFilters(selectedFilters)
                                                            .ExceptFilter(null)
                                                            .OrderBy(orderField, orderDirection)
                                                            .GetUrl();

                    PageInfo pageInfo = new PageInfo(i, filterUrl, hasSelectedFilters, UrlOfuscator);

                    result.AddPage(pageInfo);
                }
            }

            //No lo revisamos por bug de sesion
            foreach (var solrQueryResult in solrQueryResults)
            {
                result.AddResult(EntityLoader.LoadEntity(solrQueryResult, CacheProvider, _propertiesToLoad, _postLoadEntityAction));
            }

            //Hasta aca deberia ir ok porque trae ok los resultados

            foreach (var facetField in solrQueryResults.FacetFields)
            {
                var facetByName = FacetConfiguration.FacetHierarchy.ByName(facetField.Key);

                facetByName.Accept(new FacetResultConverterVisitor<T>(facetField,
                                                                   selectedFilters,
                                                                   result,
                                                                   FacetConfiguration.FacetHierarchy,
                                                                   new FilterUrlBuilder(FacetConfiguration.FacetHierarchy, UrlOfuscator), 
                                                                   CacheProvider
                                                                   ));
            }

            if (selectedFilters != null)
            {
                selectedFilters.ForEach(filter =>
                {
                    result.AddAppliedFilter(new Slice
                                                {
                                                    Name = filter.Name,
                                                    Value = FacetConfiguration.FacetHierarchy.ByName(filter.Name).Visible ? 
                                                            CacheProvider.GetName(filter.Name, filter.Value) 
                                                            : filter.Value,
                                                    Url = new FilterUrlBuilder(FacetConfiguration.FacetHierarchy, UrlOfuscator).BuildFrom(
                                                            FacetConfiguration.FacetHierarchy, CacheProvider)
                                                        .WithFilters(selectedFilters)
                                                        .ExceptFilter(filter)
                                                        .GetUrl(),
                                                    SliceKey =
                                                        FacetConfiguration.FacetHierarchy.ByName(filter.Name).Key,
                                                    Visible = FacetConfiguration.FacetHierarchy.ByName(filter.Name).Visible

                                                });

                    if (filter.UseForSeo)
                        result.Breadcrumbs.Add(new Slice
                        {
                            Name = filter.Name,
                            Priority = filter.Priority,
                            Value = CacheProvider.GetName(filter.Name, filter.Value),
                            Url = new FilterUrlBuilder(FacetConfiguration.FacetHierarchy, UrlOfuscator)
                                                  .BuildFrom(FacetConfiguration.FacetHierarchy, CacheProvider)
                                                  .WithFilters(new List<SelectedFilter> { filter })
                                                  .ExceptFilter(null)
                                                  .GetUrl(),
                                                  SliceKey = FacetConfiguration.FacetHierarchy.ByName(filter.Name).Key,
                        });
                }
                );
            }

            return result;
        }

        public IResults<T> Merge(IList<ISolrQueryResults<T>> resultsList, int actualPage, int pageSize, List<SelectedFilter> selectedFilters, string orderField, string orderDirection)
        {
            var result = new SolrQueryResults<T>
                             {
                                 NumFound = resultsList.Sum(x => x.NumFound)
                             };

            foreach (var i in resultsList.SelectMany(r => r))
            {
                result.Add(i);
            }

            if (resultsList.Count > 0)
            {
                var mainResults = resultsList.First();

                result.Header = mainResults.Header;
                result.FacetQueries = mainResults.FacetQueries;
                result.FacetFields = mainResults.FacetFields;
                result.SpellChecking = mainResults.SpellChecking;
                result.SimilarResults = mainResults.SimilarResults;
                result.Stats = mainResults.Stats;
                result.Collapsing = mainResults.Collapsing;
            }

            return ConvertFrom(result, actualPage, pageSize, selectedFilters, orderField,
                               orderDirection);
        }
    }

    internal static class PublicationTypeFactory
    {
        public static PublicationType Get(string publicationType)
        {
            switch (publicationType)
            {
                case "A":
                    return new PublicationSuperPremiumType();
                case "B":
                    return new PublicationPremiumType();    
                case "C":
                    return new PublicationSimpleType();
                case "C2":
                    return new PublicationDemoType();
                case "D":
                    return new PublicationLinealType();
                default:
                    break;
            }
            return null;
        }
    }
}
