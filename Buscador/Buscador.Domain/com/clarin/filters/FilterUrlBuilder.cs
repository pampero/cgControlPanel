using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buscador.Domain.com.clarin.facets;

namespace Buscador.Domain.com.clarin.filters
{
    public interface IFilterUrlBuilder
    {
        IExceptBuilder WithFilters(List<SelectedFilter> selectedFilters);
        IFacetedBuilder ExceptFilter(SelectedFilter filterToExcept);
        ISlicedBuilder Faceted(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facetField);
        FilterUrlBuilder Sliced(string facet);
        IWithFiltersBuilder BuildFrom(IFacetHierarchy facetHierarchy, ISliceCacheProvider cacheProvider);
        string GetUrl();
    }

    public interface IUrlOfuscator
    {
        string Ofuscate(string url);
        System.Collections.Specialized.HybridDictionary OfuscatedCharacters { get; set; }
    }

    public class UrlOfuscator : IUrlOfuscator
    {
        public System.Collections.Specialized.HybridDictionary OfuscatedCharacters { get; set; }

        public string Ofuscate(string url)
        {
            var ofuscatedUrl = url;

            foreach (var character in OfuscatedCharacters)
            {
                ofuscatedUrl = ofuscatedUrl.Replace(((DictionaryEntry)character).Key.ToString(),
                                                   ((DictionaryEntry)character).Value.ToString());
            }

            return ofuscatedUrl;
        }
    }

    public class FilterUrlBuilder : IWithFiltersBuilder, IFacetedBuilder, ISlicedBuilder, IExceptBuilder, IFilterUrlBuilder
    {
        private List<SelectedFilter> _selectedFilters;
        private KeyValuePair<string, ICollection<KeyValuePair<string, int>>> _facetField;
        private string _facet;

        private List<SelectedFilter> _exceptFilters;
        private object _exceptFiltersLock = new Object();

        private IFacetHierarchy _facetHierarchy;
        private ISliceCacheProvider _cacheProvider;
        private string _orderField;
        private string _orderDirection;

        public IUrlOfuscator UrlOfuscator{ get; set;}

        public string BaseUrl { get; set; }

        private List<SelectedFilter> ExceptFilters
        {
            get
            {
                if (_exceptFilters == null)
                {
                    lock(_exceptFiltersLock)
                    {
                        if (_exceptFilters == null)
                            _exceptFilters = new List<SelectedFilter>();
                    }
                }
                return _exceptFilters;
            }
            set { _exceptFilters = value; }
        }

        private List<SelectedFilter> SelectedFilters
        {
            get { return _selectedFilters ?? (_selectedFilters = new List<SelectedFilter>()); }
            set { _selectedFilters = value; }
        }

        private FilterUrlBuilder(List<SelectedFilter> selectedFilters, FacetHierarchy facetHierarchy)
        {
            SelectedFilters = selectedFilters;
            _facetHierarchy = facetHierarchy;
        }

        public FilterUrlBuilder(IFacetHierarchy facetHierarchy, IUrlOfuscator urlOfuscator)
        {
            _facetHierarchy = facetHierarchy;
            UrlOfuscator = urlOfuscator;
            BaseUrl = "/autos";
        }

        private FilterUrlBuilder()
        {
            
        }

        public IWithFiltersBuilder BuildFrom(IFacetHierarchy facetHierarchy, ISliceCacheProvider cacheProvider)
        {
            _facetHierarchy = facetHierarchy;
            _cacheProvider = cacheProvider;
            ExceptFilters.Clear();
            _facetField = new KeyValuePair<string, ICollection<KeyValuePair<string, int>>>();
            _facet = null;
            return this;
        }

        public IExceptBuilder WithFilters(List<SelectedFilter> selectedFilters)
        {
            _selectedFilters = selectedFilters;
            return this;
        }

        public IFacetedBuilder ExceptFilter(SelectedFilter filterToExcept)
        {
            if(filterToExcept==null) return this;
            ExceptFilters.AddRange(_facetHierarchy.GetFacetAndHisChilds(
                                   _facetHierarchy.ByName(filterToExcept.Name))
                                   .ToSelectedFilter());
            return this;
        }

        public ISlicedBuilder Faceted(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facetField)
        {
            _facetField = facetField;
            return this;
        }

        public FilterUrlBuilder Sliced(string facet)
        {
            _facet = facet;
            return this;
        }

        public string GetUrl()
        {
             return UrlOfuscator.Ofuscate(GetCleanUrl()).ReplaceUrlInvalidChars();
        }

        public IFacetedBuilder OrderBy(string orderField, string orderDirection)
        {
            _orderField = orderField;
            _orderDirection = orderDirection;
            return this;
        }

        private string GetCleanUrl()
        {
            var url = string.Empty;

            if (ExceptFilters.Count == 0 && SelectedFilters.Count != 0 && _facetField.Key != null && _facet != null)
            {
                
                url = (BaseUrl + HyphenIfApplicable()).ToLower();
                url += SeoUrlPart().ToLower() + "/";
                url += string.Join("&", SelectedFilters.Select(x => _facetHierarchy.Codified(x.Name) + "=" + x.Value).ToArray());


                if (_facetField.Key == null)
                    return string.Empty;

                url += "&" + _facetHierarchy.Codified(_facetField.Key) + "=" + _facet;
                url += (!string.IsNullOrEmpty(_orderField) ? 
                        "&" + "SO" + "=" + _facetHierarchy.Codified(_orderField) + _orderDirection : 
                        string.Empty);

                return url;
            }

            if (SelectedFilters.Count != 0)
            {
                url = BaseUrl + HyphenIfApplicable();
                var filtersWithoutExceptions = SelectedFilters.Where(x => x.UseForSeo).Except(ExceptFilters, new ExceptFiltersComparer());

                url += string.Join("-", 
                    filtersWithoutExceptions.Select(x =>_cacheProvider.GetName(x.Name,x.Value).Localize()).ToArray()).ToLower();

                url += "/" +
                       string.Join("&",
                                   SelectedFilters.Except(ExceptFilters, new ExceptFiltersComparer()).Select(
                                       x => _facetHierarchy.Codified(x.Name) + "=" + x.Value).ToArray());

                url += (!string.IsNullOrEmpty(_orderField) ? 
                        "&" + "SO" + "=" + _facetHierarchy.Codified(_orderField) + _orderDirection : 
                        string.Empty);

                return url;
            }
            if (_facetField.Key == null && _facet == null)
                return
                    BaseUrl +
                    "/" + 
                    (!string.IsNullOrEmpty(_orderField) ? "SO" + "=" + _facetHierarchy.Codified(_orderField) + _orderDirection + "&" : string.Empty);

            return
                (BaseUrl +
                (_facetHierarchy.UseForSeo(_facetField.Key) ? "-" + _cacheProvider.GetName(_facetField.Key, _facet).Localize().Replace("-", string.Empty) : string.Empty)).ToLower() +
                "/" +
                _facetHierarchy.Codified(_facetField.Key) + 
                "=" +
                _facet;
        }

        private string SeoUrlPart()
        {
            var selectedFiltersList = SelectedFilters.Where(x => x.UseForSeo).ToList();

            if(_facetHierarchy.ByName(_facetField.Key).UseForSeo)
            {
                var facet = _facetHierarchy.ByName(_facetField.Key);

                facet.Value = _facet;

                selectedFiltersList.AddRange(new List<IFacet> { facet }.ToSelectedFilter());
            }

            return string.Join("-", selectedFiltersList.Where(x => x.UseForSeo).OrderBy(x=>x.Priority).Select(x => _cacheProvider.GetName(x.Name, x.Value).Localize()).ToArray());

            //var facetFieldKey = _facetField.Key;
            //var altList = ((SelectedFilter[])selectedFiltersList.ToArray().Clone()).ToList();
            //var bla = altList.Where(x => x.UseForSeo)
            //                             .OrderBy(x => x.Priority)
            //                             .Select(x => _cacheProvider.GetName(x.Name, x.Value).Localize())
            //                             .ToArray();

            //var val = string.Join("-", bla);

            //return val;

            //return string.Join("-", SelectedFilters.Where(x=>x.UseForSeo).Select(x => _cacheProvider.GetName(x.Name,x.Value)).ToArray()) +
            //       (_facetHierarchy.UseForSeo(_facetField.Key) ? "-" + _cacheProvider.GetName(_facetField.Key, _facet).Replace("-", string.Empty) : string.Empty);
        }

        private string HyphenIfApplicable()
        {
            return (SelectedFilters.Where(x => x.UseForSeo).Except(ExceptFilters, new ExceptFiltersComparer()).Count() != 0 ? "-" : string.Empty);
        }
    }

    public class ExceptFiltersComparer : IEqualityComparer<SelectedFilter>
    {
        public bool Equals(SelectedFilter x, SelectedFilter y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(SelectedFilter obj)
        {
            return 1;
        }
    }

    public interface IWithFiltersBuilder
    {
        IExceptBuilder WithFilters(List<SelectedFilter> selectedFilters);
        ISlicedBuilder Faceted(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facetField);
        
    }

    public interface IExceptBuilder
    {
        IFacetedBuilder ExceptFilter(SelectedFilter filterToExcept);
        ISlicedBuilder Faceted(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facetField);
    }

    public interface IFacetedBuilder
    {
        ISlicedBuilder Faceted(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facetField);
        string GetUrl();
        IFacetedBuilder OrderBy(string orderField, string orderDirection);
    }

    public interface ISlicedBuilder
    {
        FilterUrlBuilder Sliced(string facet);
    }
}