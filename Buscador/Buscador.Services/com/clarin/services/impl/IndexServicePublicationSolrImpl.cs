using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Buscador.Domain;
using Buscador.Domain.com.clarin.dao;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.utils;
using Buscador.Services.com.clarin.services.builders;
using Buscador.Services.com.clarin.services.builders.solr;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Attributes;
using SolrNet.Commands.Parameters;
using Order = Buscador.Domain.com.clarin.filters.Order;

namespace Buscador.Services.com.clarin.services.impl
{
    public class IndexServicePublicationSolrImpl : MarshalByRefObject, IIndexService<Publication>
    {
        public IFacetConfiguration FacetConfiguration { get; set; }
        public ICurrencyDao CurrencyDao { get; set; }
        public IPublicationDao PublicationDao { get; set; }
        public IDetailUrlBuilder DetailUrlBuilder { get; set; }
        private Action<Publication> _onPostLoadPublication;
        private IDictionary<Expression<Func<Publication, int>>, Expression<Func<Publication, string>>> _propertiesToLoad;
        private ISolrSearchService<Publication> _solrService;

        public ISolrSearchService<Publication> SolrService
        {
            get
            {
                return _solrService ??
                       (_solrService = new SolrSearchService<Publication>(_onPostLoadPublication, _propertiesToLoad));
            }

            set
            {
                _solrService = value;
            }
        }

        public ISolrOperations<Publication> Solr
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Publication>>(); }
        }

        public IndexServicePublicationSolrImpl(string serverUrl)
        {
            _onPostLoadPublication = delegate(Publication publication)
                                         {
                                             publication.CPublicationType = PublicationTypeFactory.Get(publication.PublicationType);
                                             publication.CVehiclePriceCurrency = CurrencyDao.GetById(publication.VehiclePriceCurrency);
                                             publication.UrlDetails = DetailUrlBuilder.BuildFor(publication);
                                         };

            _propertiesToLoad = new Dictionary<Expression<Func<Publication,int>>, Expression<Func<Publication,string>>>
                                 {
                                     { x=>x.VehicleMake, x=>x.VehicleMakeText },
                                     { x=>x.VehicleModel, x=>x.VehicleModelText },
                                     { x=>x.VehicleVersion, x=>x.VehicleVersionText },
                                     { x=>x.VehicleFuelType, x=>x.VehicleFuelTypeText },
                                     { x=>x.VehicleSegment, x=>x.VehicleSegmentText },
                                     { x=>x.VehicleColor, x=>x.VehicleColorText },
                                     { x=>x.VehicleLocProv, x=>x.VehicleLocProvText },
                                     { x=>x.VehicleLocPart, x=>x.VehicleLocPartText },
                                     { x=>x.VehicleLocLoc, x=>x.VehicleLocLocText },
                                     { x=>x.PaymentMethod, x=>x.PaymentMethodText }
                                 };

            try
            {

            InitializeSolrServer(serverUrl);
            }
            catch (Exception ex)
            {
                Startup.Init<Publication>(serverUrl);
            }
        }

        private void InitializeSolrServer(string serverUrl)
        {
            try
            {
                if (ServiceLocator.Current.GetInstance<ISolrOperations<Publication>>() == null)
                    Startup.Init<Publication>(serverUrl);
            }
            catch (Exception ex)
            {
                Startup.Init<Publication>(serverUrl);
            }
        }

        public IList<Publication> Query(IList<KeyValuePair<Expression<Func<Publication, object>>, string>> query, int maxResult)
        {
            ISolrQueryResults<Publication> solrResult;

            if (maxResult == default(int))
                solrResult = Solr.Query(SolrQueryBuilder<Publication>.BuildQuery(query));
            else
                solrResult = Solr.Query(SolrQueryBuilder<Publication>.BuildQuery(query), new QueryOptions { Rows = maxResult });

            // var solrService = new SolrSearchService<Publication>(_onPostLoadPublication, _propertiesToLoad);

            return SolrService.ConvertFrom(solrResult);
        }

        public IList<Publication> Query(IList<KeyValuePair<Expression<Func<Publication, object>>, string>> query)
        {
            return Query(query, default(int));
        }

        public IResults<Publication> Query(ISearchParameters<Publication> searchParameters)
        {
            var solrQueryBuilder = new SolrQueryBuilder<Publication>(searchParameters);
            var solrQuery = solrQueryBuilder.BuildQuery();

            if (solrQuery.IsEmpty())
            {
                return QueryAll(searchParameters.Page, searchParameters.SortField);
            }
            
            var order = searchParameters.SortField != null ? FacetConfiguration.FacetHierarchy.ByKey(searchParameters.SortField.OrderField).Name : string.Empty;
            var direction = searchParameters.SortField != null ? searchParameters.SortField.Direction : string.Empty;
            var solrOptions = solrQueryBuilder.BuildQueryOptions(searchParameters.PageSize == 0 ? FacetConfiguration.PageSize : searchParameters.PageSize, 
                                                                 searchParameters.Page == 0 ? 1 : searchParameters.Page,
                                                                 order,direction);
            var solrResult = Solr.Query(solrQuery, solrOptions);

            return SolrService.ConvertFrom(solrResult, 
                                           searchParameters.Page == 0 ? 1 : searchParameters.Page,
                                           searchParameters.PageSize == 0 ? FacetConfiguration.PageSize : searchParameters.PageSize,
                                           searchParameters.SelectedFilters, 
                                           order, 
                                           direction);
        }

        public IResults<Publication> QueryAll(int page, OrderInfo orderInfo)
        {
            //var _resultConverter = new ResultConverter();
            var order = orderInfo != null ? FacetConfiguration.FacetHierarchy.ByKey(orderInfo.OrderField).Name : string.Empty;
            var direction = orderInfo != null ? orderInfo.Direction:string.Empty;

            //_resultConverter.CleanFilters();
            var solrOptions = SolrQueryBuilder<Publication>.BuildAllQueryOptions(FacetConfiguration.FacetHierarchy
                                                                                      .Facets
                                                                                      .Where(facet=>facet.Level==1)
                                                                                      .ToList(),
                                                                    FacetConfiguration.PageSize,
                                                                    page==0?1:page, order,direction);
            var solrResults = Solr.Query(SolrQuery.All.OnlyActives(), solrOptions);

            // var solrService = new SolrSearchService<Publication>(_onPostLoadPublication, _propertiesToLoad);
            return SolrService.ConvertFrom(solrResults, page, FacetConfiguration.PageSize, null, order, direction);

            //return solrResults.ToResult(_resultConverter.Page(page).OrderBy(order, direction));
        }

        public List<SelectedFilter> SelectedFiltersFor(Publication publication)
        {
            var selectedFilters = new List<SelectedFilter>();

            foreach (var facet in FacetConfiguration.FacetHierarchy.Seoable())
            {
                var propertyInfo = publication.GetType().GetProperties().Where
                    (
                        x => x.GetCustomAttributes(true).FirstOrDefault() != null &&
                             ((SolrFieldAttribute)x.GetCustomAttributes(true).FirstOrDefault()).FieldName == facet.Name
                    ).FirstOrDefault();

                if(propertyInfo!=null)
                selectedFilters.Add(new SelectedFilter
                                        {
                                            Name = facet.Name,
                                            Value = propertyInfo.GetValue(publication, null).ToString()
                                        });   
            }
            return selectedFilters;
        }

        public IResults<Publication> QueryResults(ISearchParameters<Publication> searchParameters)
        {
            //var _resultConverter = new ResultConverter();
            var solrQueryBuilder = new SolrQueryBuilder<Publication>(searchParameters);
            var solrQuery = solrQueryBuilder.BuildQuery();
            if (solrQuery.IsEmpty())
            {
                return QueryAll(searchParameters.Page, searchParameters.SortField);
            }

            var order = searchParameters.SortField != null ? FacetConfiguration.FacetHierarchy.ByKey(searchParameters.SortField.OrderField).Name : string.Empty;
            var direction = searchParameters.SortField != null ? searchParameters.SortField.Direction : string.Empty;
            var solrOptions = solrQueryBuilder.BuildQueryOptions(FacetConfiguration.PageSize,
                                                                 searchParameters.Page == 0 ? 1 : searchParameters.Page,
                                                                 order, direction);
            var solrResult = Solr.Query(solrQuery, solrOptions);

            // var solrService = new SolrSearchService<Publication>(_onPostLoadPublication, _propertiesToLoad);

            return SolrService.ConvertFrom(solrResult, 
                                           searchParameters.Page == 0 ? 1 : searchParameters.Page,
                                           searchParameters.PageSize == 0 ? FacetConfiguration.PageSize : searchParameters.PageSize,
                                           searchParameters.SelectedFilters, 
                                           order, 
                                           direction);

            //return solrResult.ToResult(_resultConverter.WithFilters(searchParameters.SelectedFilters)
            //                                           .Page(searchParameters.Page == 0 ? 1 : searchParameters.Page)
            //                                           .OrderBy(order,direction));
        }

        public IList<Publication> Query(List<KeyValuePair<Expression<Func<Publication, object>>, string>> query, int maxsize, OrderInfo orderInfo)
        {
            var direction = orderInfo.Direction == "DESC" ? SolrNet.Order.DESC : SolrNet.Order.ASC;
            var solrResult = Solr.Query(SolrQueryBuilder<Publication>.BuildQuery(query), new QueryOptions { Rows = maxsize, OrderBy = new List<SortOrder> { new SortOrder(orderInfo.OrderField, direction)}});
            return SolrService.ConvertFrom(solrResult);
        }
    }
}
