using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.Security;
using System.ServiceModel.Web;
using AopAlliance.Intercept;
using Buscador.Contracts;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.slices;
using Buscador.Domain.com.clarin.utils;
using Buscador.Services.com.clarin.services;
using Buscador.Web.Controllers.Controllers;
using IUrlOfuscator = Buscador.Domain.com.clarin.filters.IUrlOfuscator;


namespace Buscador.WCFServerWeb
{
    public class Slices
    {
        public List<Slice> AppliedSlices { get; set; }

        public List<SliceSet> AvaiableSlices { get; set; }
    }

    public class SearchService : ISearch
    {
        #region Properties

        public IIndexService<Publication> IndexService { get; set; }

        public IFacetConfiguration FacetConfiguration { get; set; }

        public IUrlOfuscator UrlOfuscator { get; set; }

        public IJsonSerializer JsonSerializer { get; set; }

        public IIndexService<Agency> AgencyIndexService { get; set; }

        public string TrafficTag { get; set; }

        public string TrafficTagName { get; set; }

        #endregion

        #region Methods

        public string Search(string query)
        {
            var publicationsResult = new List<PublicationResult>();
            var publicationSearch = new PublicationSearch();
            IResults<Publication> result = null;

            if (string.IsNullOrEmpty(query)) return string.Empty;

            if (query.ToLower().Equals("all")) //All indica un search all.
            {
                result = GetResult(string.Empty, string.Empty);
            }
            else
            {
                result = GetResult(query, string.Empty);
            }

            publicationSearch.TotalResults = result.TotalResults;

            var publicationResult = new PublicationResult();
            foreach (var publication in result.ResultList)
            {
                publicationsResult.Add(publicationResult.BuildFrom(publication, JsonSerializer, TrafficTag, TrafficTagName));
            }

            publicationSearch.Results = publicationsResult;
            publicationSearch.Slices = GetPublicationSlice(result);
            if (result.Order.CurrentOrderValue.Contains("index_weight"))
            {
                result.Order.CurrentOrderValue = String.Empty;
            }

            publicationSearch.Order = result.Order;

            publicationSearch.PaginData = new PaginData(result.ActualPage,  result.PageSize,
                                                        result.TotalPages);

            return JsonSerializer.Serialize(publicationSearch, GetKnownTypes());

        }

        public string GetSlices(string query)
        {
            if (string.IsNullOrEmpty(query)) return string.Empty;
            IResults<Publication> result = null;

            if (query.ToLower().Equals("all")) //All indica un get slices all.
            {
                result = GetResult(string.Empty, string.Empty);
            }
            else
            {
                result = GetResult(query, string.Empty);
            }

            PublicationSlice publicationSlice = GetPublicationSlice(result);

            string json = JsonSerializer.Serialize(publicationSlice, GetKnownTypes());

            return json;
        }

        public string GetPublication(string publicationId)
        {
            var query = QueryOver<Publication>.Property(x => x.PublicationId).WithValue(publicationId).Build();

            var results = IndexService.Query(query);

            var publicationResult = new PublicationResult();

            var publicationsResult = results.Select(publication => publicationResult.BuildFrom(publication, JsonSerializer, TrafficTag, TrafficTagName))
                                            .ToList();

            return JsonSerializer.Serialize(publicationsResult, GetKnownTypes());
        }

        public string GetVehiclesBrands()
        {
            var listAvailableSet = new List<AvaiableSlice>();

            var results = IndexService.Query(new SearchParameters<Publication>(string.Empty));

            foreach (var filterGroup in results.FilterGroups)
            {
                if (filterGroup.Name.Contains("vehicle_make_id"))
                {
                    listAvailableSet = GetListAvailableSlice(filterGroup, listAvailableSet).OrderBy(x => x.Name).ToList();
                }
            }

            var json = JsonSerializer.Serialize(listAvailableSet, GetKnownTypes());

            return json;
        }

        public string GetVehiclesModels(string vehicleBrandId)
        {
            var listAvailableSet = new List<AvaiableSlice>();

            var query = QueryOver<Publication>.Property(x => x.VehicleMake).WithValue(vehicleBrandId).Build();

            var member = ((MemberExpression) (((UnaryExpression) query.First().Key.Body).Operand)).Member;
            
            var propertyInfo =
                ((SolrNet.Attributes.SolrFieldAttribute)
                 (((typeof (Publication).GetProperty(member.Name).GetCustomAttributes(true)[0])))).FieldName;


            var key = ((FacetConfiguration.FacetHierarchy.ByName(propertyInfo)).Key);


            IEnumerable<Condition> conditions = Conditions.From(key + "YY" + vehicleBrandId, UrlOfuscator);

            IResults<Publication> results = GetResults(conditions, string.Empty);

            foreach (FilterGroup filterGroup in results.FilterGroups)
            {
                if (filterGroup.Name.Contains("vehicle_model_id"))
                {
                    listAvailableSet = GetListAvailableSlice(filterGroup, listAvailableSet).OrderBy(x => x.Name).ToList();
                }
            }

            string json = JsonSerializer.Serialize(listAvailableSet, GetKnownTypes());

            return json;
        }

        public string GetVehiclesVersions(string vehicleModelId)
        {
            var listAvailableSet = new List<AvaiableSlice>();

            List<KeyValuePair<Expression<Func<Publication, object>>, string>> query = QueryOver<Publication>.Property(x => x.VehicleModel).WithValue(vehicleModelId).Build();

            var member = ((MemberExpression)(((UnaryExpression)query.First().Key.Body).Operand)).Member;

            var propertyInfo =
                ((SolrNet.Attributes.SolrFieldAttribute)
                 (((typeof(Publication).GetProperty(member.Name).GetCustomAttributes(true)[0])))).FieldName;


            var key = ((FacetConfiguration.FacetHierarchy.ByName(propertyInfo)).Key);


            IEnumerable<Condition> conditions = Conditions.From(key + "YY" + vehicleModelId, UrlOfuscator);

            IResults<Publication> results = GetResults(conditions, string.Empty);

            foreach (FilterGroup filterGroup in results.FilterGroups)
            {
                if (filterGroup.Name.Contains("vehicle_version_id"))
                {
                    listAvailableSet = GetListAvailableSlice(filterGroup, listAvailableSet).OrderBy(x => x.Name).ToList();
                }
            }

            string json = JsonSerializer.Serialize(listAvailableSet, GetKnownTypes());

            return json;
        }

        public string GetProvinces()
        {
            var listAvailableSet = new List<AvaiableSlice>();

            IResults<Publication> results = IndexService.Query(new SearchParameters<Publication>(string.Empty));

            foreach (FilterGroup filterGroup in results.FilterGroups)
            {
                if (filterGroup.Name.Contains("vehicle_loc_prov_id"))
                {
                    listAvailableSet = GetListAvailableSlice(filterGroup, listAvailableSet);
                }
            }

            string json = JsonSerializer.Serialize(listAvailableSet, GetKnownTypes());

            return json;
        }

        public string GetLocality(string provinceId) // me trae los partidos por provincia ingresada por parametro.
        {

            var listAvailableSet = new List<AvaiableSlice>();

            List<KeyValuePair<Expression<Func<Publication, object>>, string>> query = QueryOver<Publication>.Property(x => x.VehicleLocProv).WithValue(provinceId).Build();

            var member = ((MemberExpression)(((UnaryExpression)query.First().Key.Body).Operand)).Member;

            var propertyInfo =
                ((SolrNet.Attributes.SolrFieldAttribute)
                 (((typeof(Publication).GetProperty(member.Name).GetCustomAttributes(true)[0])))).FieldName;


            var key = ((FacetConfiguration.FacetHierarchy.ByName(propertyInfo)).Key);


            IEnumerable<Condition> conditions = Conditions.From(key + "YY" + provinceId, UrlOfuscator);

            IResults<Publication> results = GetResults(conditions, string.Empty);

            foreach (FilterGroup filterGroup in results.FilterGroups)
            {
                if (filterGroup.Name.Contains("vehicle_loc_part_id"))
                {
                    listAvailableSet = GetListAvailableSlice(filterGroup, listAvailableSet);
                }
            }

            string json = JsonSerializer.Serialize(listAvailableSet, GetKnownTypes());

            return json;

        }

        public string GetCities(string localityId)//me trae las localidades por partido ingresado por parametro.
        {
            var listAvailableSet = new List<AvaiableSlice>();

            var query = QueryOver<Publication>.Property(x => x.VehicleLocPart).WithValue(localityId).Build();

            var member = ((MemberExpression)(((UnaryExpression)query.First().Key.Body).Operand)).Member;

            var propertyInfo =
                ((SolrNet.Attributes.SolrFieldAttribute)
                 (((typeof(Publication).GetProperty(member.Name).GetCustomAttributes(true)[0])))).FieldName;


            var key = ((FacetConfiguration.FacetHierarchy.ByName(propertyInfo)).Key);


            var conditions = Conditions.From(key + "YY" + localityId, UrlOfuscator);

            var results = GetResults(conditions, string.Empty);

            foreach (var filterGroup in results.FilterGroups)
            {
                if (filterGroup.Name.Contains("vehicle_loc_loc_id"))
                {
                    listAvailableSet = GetListAvailableSlice(filterGroup, listAvailableSet);
                }
            }

            var json = JsonSerializer.Serialize(listAvailableSet, GetKnownTypes());

            return json;
           
        }

        private PublicationSlice GetPublicationSlice(IResults<Publication> result)
        {
            var listAvailableSet = new List<AvaiableSlice>();
            var listAppliedSlice = new List<Slice>();

            foreach (Slice appliedSlice in result.VisibleAppliedFilters)
            {
                string localize = appliedSlice.Name.Localize();
                appliedSlice.Name = localize;
                listAppliedSlice.Add(appliedSlice);
            }

            foreach (FilterGroup filterGroup in result.FilterGroups)
            {
                listAvailableSet = GetListAvailableSlice(filterGroup, listAvailableSet);
            }

            return new PublicationSlice(listAppliedSlice, listAvailableSet);
        }

        private List<AvaiableSlice> GetListAvailableSlice(FilterGroup filterGroup, List<AvaiableSlice> listAvailableSet)
        {
            var str = 0;
            var id = string.Empty;
            AvaiableSlice availableSlices = null;
            var facetConfiguration = string.Empty;


            for (int i = 0; i < filterGroup.FiltersToShow.Count; i++)
            {
                if (filterGroup.FiltersToShow[i].SliceKey != null)
                {
                    bool key = filterGroup.FiltersToShow[i].Url.Contains(filterGroup.FiltersToShow[i].SliceKey);

                    if (key)
                    {
                        str = filterGroup.FiltersToShow[i].Url.IndexOf(filterGroup.FiltersToShow[i].SliceKey);
                    }

                    id = filterGroup.FiltersToShow[i].Url.Substring(str + 4);
                    //2 digitos de donde comienza el indice, mas dos digitos por el == (YY)
                }

                if (filterGroup.FiltersToShow[i].SliceKey == null)//para el caso de no traer valor, como pasa con año, precio, Km.
                {
                    id = null;
                    if (filterGroup.FiltersToShow[i].Name.Equals("vehicle_year")) //value key para año.
                    {
                        filterGroup.FiltersToShow[i].SliceKey = "YE";
                        filterGroup.FiltersToShow[i].Value = null;
                    }
                    if (filterGroup.FiltersToShow[i].Name.Equals("vehicle_price_absolute")) //value key para precio.
                    {
                        filterGroup.FiltersToShow[i].SliceKey = "PR";
                        filterGroup.FiltersToShow[i].Value = null;
                    }
                    if (filterGroup.FiltersToShow[i].Name.Equals("vehicle_km")) //value key para km.
                    {
                        filterGroup.FiltersToShow[i].SliceKey = "VK";
                        filterGroup.FiltersToShow[i].Value = null;
                    }
                }

                foreach (var facet in FacetConfiguration.FacetHierarchy.Facets)
                {
                    if (facet.Key == filterGroup.FiltersToShow[i].SliceKey)
                    {
                        facetConfiguration = facet.GetType().Name;
                        break;
                    }
                }

                availableSlices = new AvaiableSlice(filterGroup.FiltersToShow[i].Name,
                                                    filterGroup.FiltersToShow[i].SliceKey,
                                                    filterGroup.FiltersToShow[i].Value,
                                                    filterGroup.FiltersToShow[i].Url,
                                                    id,
                                                    facetConfiguration);


                listAvailableSet.Add(availableSlices);
            }

            return listAvailableSet;
        }

        private IResults<Publication> GetResult(string query, string freeText)
        {
            ISearchParameters<Publication> searchParameters;
            var conditions = Conditions.From(query, UrlOfuscator);
            return GetResults(conditions, freeText);
        }

        private IResults<Publication> GetResults(IEnumerable<Condition> conditions, string freeText)
        {
            ISearchParameters<Publication> searchParameters;
            var selectedFiltersContext = QueryUrlParser.With(FacetConfiguration.FacetHierarchy, UrlOfuscator)
                                                       .Parse(conditions)
                                                       .ExcludeLineals()
                                                       .GetSelectedFilters();

            if (selectedFiltersContext.SelectedFilters.Count == 0)
                searchParameters = new SearchParameters<Publication>(freeText, selectedFiltersContext.Page,
                                                                     selectedFiltersContext.SortField);
            else
                searchParameters = new SearchParameters<Publication>(freeText,
                                                                     selectedFiltersContext,
                                                                     FacetConfiguration.FacetHierarchy.ByName(
                                                                         selectedFiltersContext.SelectedFilters.Last().
                                                                             Name),
                                                                     FacetConfiguration.FacetHierarchy.GetFacetsWith(
                                                                         selectedFiltersContext.SelectedFilters));

            return IndexService.Query(searchParameters);
        }

        private List<Type> GetKnownTypes()
        {
            return new List<Type>
                       {
                           typeof (AvaiableSlice),
                           typeof (DynamicRangeSlice),
                           typeof (Results<Publication>),
                           typeof (Slice),
                           typeof (PublicationSuperPremiumType),
                           typeof (PublicationPremium45HighlighDaysType),
                           typeof (PublicationSimpleType),
                           typeof (Order),
                           typeof (PublicationPremiumType)
                       };
        }

        #endregion
    }

    public class SecurityInterceptor :  IMethodInterceptor
    {
        public HybridDictionary UsersAndPasswords { get; set; }

        public object Invoke(IMethodInvocation invocation)
        {
            var credential = WebOperationContext.Current.IncomingRequest.Headers.ExtractCredentials();

            if (UsersAndPasswords[credential.Key] == null || (((KeyValuePair<object, object>)UsersAndPasswords[credential.Key]).Key.ToString() != credential.Value))
                throw new SecurityAccessDeniedException("Credenciales inválidas");

            ((SearchService)(invocation.Target)).TrafficTag = ((KeyValuePair<object,object>)UsersAndPasswords[credential.Key]).Value.ToString();

            return invocation.Proceed();
        }
    }
}