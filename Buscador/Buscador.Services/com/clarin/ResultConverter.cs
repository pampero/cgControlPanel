using System;
using System.Linq;
using System.Collections.Generic;
using Buscador.Domain.com.clarin.dao;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.utils;
using Buscador.Services.com.clarin.services;
using Buscador.Services.com.clarin.services.impl;
using SolrNet;
using Spring.Context.Support;

namespace Buscador.Services.com.clarin
{
    //public interface IResultConverter
    //{
    //    IResults<Publication> ConvertFrom(ISolrQueryResults<Publication> solrQueryResults);
    //    IResultConverter WithFilters(List<SelectedFilter> selectedFilters);
    //    IResultConverter Page(int page);
    //    IResultConverter OrderBy(string order, string direction);
    //    void CleanFilters();
    //}

    //public class ResultConverter : IResultConverter
    //{
    //    public FacetConfiguration FacetConfiguration { get; set; }

    //    private List<SelectedFilter> _selectedFilters;
    //    private int _actualPage;
    //    private string _orderField;
    //    private string _orderDirection;

    //    public IFilterUrlBuilder FilterUrlBuilder { get; set; }

    //    public IDetailUrlBuilder DetailUrlBuilder { get; set; }

    //    public ISliceCacheProvider CacheProvider { get; set; }

    //    public IPublicationTypeDao PublicationTypeDao { get; set; }

    //    public ICurrencyDao CurrencyDao { get; set; }

    //    //public ICompanyDirectoryDao CompanyDirectoryDao { get; set; }
        
    //    public IUrlOfuscator UrlOfuscator { get; set; }

    //    public ResultConverter()
    //    {
    //        if (FacetConfiguration == null)
    //            FacetConfiguration = (FacetConfiguration)ContextRegistry.GetContext().GetObject("facetConfiguration");

    //        if (UrlOfuscator == null)
    //            UrlOfuscator = (UrlOfuscator)ContextRegistry.GetContext().GetObject("urlOfuscator");

    //        if (FilterUrlBuilder == null)
    //            FilterUrlBuilder = (FilterUrlBuilder)ContextRegistry.GetContext().GetObject("filterUrlBuilder");

    //        if (DetailUrlBuilder == null)
    //            DetailUrlBuilder = (DetailUrlBuilder)ContextRegistry.GetContext().GetObject("publicationDetailOldSiteUrlBuilder");
    //        if (CacheProvider == null)
    //            CacheProvider = (SliceCacheProvider)ContextRegistry.GetContext().GetObject("cacheProvider");
    //        if (PublicationTypeDao == null)
    //            PublicationTypeDao = (IPublicationTypeDao)ContextRegistry.GetContext().GetObject("publicationTypeDao");
    //        if (CurrencyDao == null)
    //            CurrencyDao = (ICurrencyDao)ContextRegistry.GetContext().GetObject("currencyDao");
    //        //if (CompanyDirectoryDao == null)
    //        //    CompanyDirectoryDao = (FilterUrlBuilder)ContextRegistry.GetContext().GetObject("filterUrlBuilder");
    //    }

    //    public IResults<Publication> ConvertFrom(ISolrQueryResults<Publication> solrQueryResults)
    //    {
    //        IResults<Publication> result = new Results<Publication>(solrQueryResults.NumFound,FacetConfiguration.PageSize);

    //        result.SetActualPage(_actualPage);
    //        result.Order = solrQueryResults.Header.Params.Where(x => x.Key == "sort").First().Value.Split(',')[0];
    //        result.TotalResults = solrQueryResults.NumFound;
    //        if(FacetConfiguration.PageSize!=0)
    //            for (var i = 1; i < solrQueryResults.NumFound / FacetConfiguration.PageSize; i++)
    //            {
    //                result.AddPage(new PageInfo(i,FilterUrlBuilder.BuildFrom(FacetConfiguration.FacetHierarchy,CacheProvider)
    //                                                              .WithFilters(_selectedFilters)
    //                                                              .ExceptFilter(null)
    //                                                              .OrderBy(_orderField,_orderDirection)
    //                                                              .GetUrl(), (_selectedFilters != null && _selectedFilters.Count != 0), UrlOfuscator));
    //            }

    //        foreach (var solrQueryResult in solrQueryResults)
    //        {
    //            result.AddResult(LoadPublication(solrQueryResult, CacheProvider, DetailUrlBuilder));
    //        }

    //        foreach (var facetField in solrQueryResults.FacetFields)
    //        {
    //            var facetByName = FacetConfiguration.FacetHierarchy.ByName(facetField.Key);

    //            facetByName.Accept(new FacetResultConverterVisitor<>(facetField,
    //                                                               _selectedFilters, 
    //                                                               result,
    //                                                               FacetConfiguration.FacetHierarchy,
    //                                                               FilterUrlBuilder,
    //                                                               CacheProvider
    //                                                               ));
    //        }
            
    //        if (_selectedFilters != null)
    //        {
    //            _selectedFilters.ForEach(filter =>
    //                                         {
    //                                             result.AddAppliedFilter(new Filter
    //                                                                         {
    //                                                                             Name = filter.Name,
    //                                                                             Value = CacheProvider.GetName(filter.Name,filter.Value),
    //                                                                             Url = FilterUrlBuilder.BuildFrom(FacetConfiguration.FacetHierarchy,CacheProvider)
    //                                                                                                   .WithFilters(_selectedFilters)
    //                                                                                                   .ExceptFilter(filter)
    //                                                                                                   .GetUrl()
    //                                                                         });
    //                                             if(filter.UseForSeo)
    //                                             result.Breadcrumbs.Add(new Filter
    //                                                                         {
    //                                                                             Name = filter.Name,
    //                                                                             Value = CacheProvider.GetName(filter.Name, filter.Value),
    //                                                                             Url = FilterUrlBuilder.BuildFrom(FacetConfiguration.FacetHierarchy, CacheProvider)
    //                                                                                                   .WithFilters(new List<SelectedFilter>{filter})
    //                                                                                                   .ExceptFilter(null)
    //                                                                                                   .GetUrl()
    //                                                                         });
    //                                         }
                    
    //            );
    //        }
            
    //        return result;
    //    }

    //    private Publication LoadPublication(Publication publication, ISliceCacheProvider cacheProvider, IDetailUrlBuilder detailUrlBuilder)
    //    {
    //        var customSolrAttributeMake = publication.GetType()
    //                                             .GetProperty("VehicleMake")
    //                                             .GetCustomAttributes(false)[0];
    //        var facetMake = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttributeMake)).FieldName;
    //        publication.VehicleMakeText = cacheProvider.GetName(facetMake, publication.VehicleMake.ToString());

    //        var customSolrAttributeModel = publication.GetType()
    //                                             .GetProperty("VehicleModel")
    //                                             .GetCustomAttributes(false)[0];
    //        var facetModel = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttributeModel)).FieldName;
    //        publication.VehicleModelText = cacheProvider.GetName(facetModel, publication.VehicleModel.ToString());

    //        var customSolrAttributeVersion = publication.GetType()
    //                                             .GetProperty("VehicleVersion")
    //                                             .GetCustomAttributes(false)[0];
    //        var facetVersion = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttributeVersion)).FieldName;
    //        publication.VehicleVersionText = cacheProvider.GetName(facetVersion, publication.VehicleVersion.ToString());

    //        var customSolrAttributeFuel = publication.GetType()
    //                                             .GetProperty("VehicleFuelType")
    //                                             .GetCustomAttributes(false)[0];
    //        var facetFuel = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttributeFuel)).FieldName;
    //        publication.VehicleFuelTypeText = cacheProvider.GetName(facetFuel, publication.VehicleFuelType.ToString());

    //        var customSolrAttributeSegment = publication.GetType()
    //                                             .GetProperty("VehicleSegment")
    //                                             .GetCustomAttributes(false)[0];
    //        var facetSegment = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttributeSegment)).FieldName;

    //        var customSolrAttributeLocProv = publication.GetType()
    //                                             .GetProperty("VehicleLocProv")
    //                                             .GetCustomAttributes(false)[0];
    //        var facetLocProv = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttributeLocProv)).FieldName;
    //        publication.VehicleLocProvText = cacheProvider.GetName(facetLocProv, publication.VehicleLocProv.ToString());

    //        var customSolrAttributeLocPart = publication.GetType()
    //                                             .GetProperty("VehicleLocPart")
    //                                             .GetCustomAttributes(false)[0];
    //        var facetLocPart = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttributeLocPart)).FieldName;
    //        publication.VehicleLocPartText = cacheProvider.GetName(facetLocPart, publication.VehicleLocPart.ToString());

    //        var customSolrAttributeLocLoc = publication.GetType()
    //                                             .GetProperty("VehicleLocLoc")
    //                                             .GetCustomAttributes(false)[0];
    //        var facetLocLoc = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttributeLocLoc)).FieldName;
    //        publication.VehicleLocLocText = cacheProvider.GetName(facetLocLoc, publication.VehicleLocLoc.ToString());

    //        //publication.CPublicationType = PublicationTypeDao.GetById((publication.PublicationType == 3 || publication.PublicationType == 5) ? 1 : publication.PublicationType);
    //        publication.CPublicationType = PublicationTypeFactory.Get(publication.PublicationType);
    //        publication.CVehiclePriceCurrency = CurrencyDao.GetById(publication.VehiclePriceCurrency);
    //        publication.UrlDetails = detailUrlBuilder.BuildFor(publication);
    //        //var companyDirectory = CompanyDirectoryDao.GetById(publication.UserUid);
    //        //publication.CompanyId = companyDirectory!= null?companyDirectory.IdEmpresa:0;

    //        return publication;
    //    }

    //    public IResultConverter WithFilters(List<SelectedFilter> selectedFilters)
    //    {
    //        _selectedFilters = selectedFilters;
    //        return this;
    //    }

    //    public IResultConverter Page(int page)
    //    {
    //        _actualPage = page;
    //        return this;
    //    }

    //    public IResultConverter OrderBy(string order, string direction)
    //    {
    //        _orderField = order;
    //        _orderDirection = direction;
    //        return this;
    //    }

    //    public void CleanFilters()
    //    {
    //        if(_selectedFilters!=null)
    //            _selectedFilters.Clear();
    //    }
    //}

    public static class HashSetExtensionMethod
    {
        public static void ForEach<T>(this HashSet<T> source, Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }
    }
}


