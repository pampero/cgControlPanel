using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Iesi.Collections.Generic;

namespace Buscador.Domain
{
    public class QueryUrlParser
    {
        private List<SelectedFilter> _filters;
        private IFacetHierarchy _facetHierarchy;
        private int _page;
        private int _pageSize;
        private OrderInfo _sortField;
        private IUrlOfuscator _urlOfuscator;
        
        public QueryUrlParser(IFacetHierarchy facetHierarchy, IUrlOfuscator urlOfuscator)
        {
            _facetHierarchy = facetHierarchy;
            _urlOfuscator = urlOfuscator;
            _filters = new List<SelectedFilter>();
        }

        public QueryUrlParser Parse(IEnumerable<Condition> conditions)
        {
            _filters = new List<SelectedFilter>();
            
            foreach (var condition in conditions)
            {
                if (condition.Empty()) continue;

                if (condition is PageCondition)
                {
                    _page = int.Parse(condition.Value);
                    continue;
                }

                if (condition is PageSizeCondition)
                {
                    _pageSize = int.Parse(condition.Value);
                    continue;
                }

                if (condition is OrderCondition)
                {
                    _sortField = new OrderInfo
                                     {
                                         OrderField = condition.Value.Substring(0, 2),
                                         Direction = condition.Value.Last().ToString()
                                     };
                    continue;
                }

                var facetName = _facetHierarchy.ByKey(condition.ParamName).Name;
                if (_filters.Where(filter => filter.Name == facetName).Count()>0)
                    throw new Exception("El filtro aplicado está repetido");
                _filters.Add(new SelectedFilter(facetName, condition.Value, _facetHierarchy.UseForSeo(facetName),_facetHierarchy.ByName(facetName).Priority));
            }

            return this;
        }

        public SelectedFilterContext GetSelectedFilters()
        {
            return new SelectedFilterContext
                       {
                           Page = _page,
                           PageSize = _pageSize,
                           SortField = _sortField,
                           SelectedFilters = _filters
                       };
        }

        public static QueryUrlParser With(IFacetHierarchy facetHierarchy, IUrlOfuscator urlOfuscator)
        {
            return new QueryUrlParser(facetHierarchy,urlOfuscator);
        }

        public QueryUrlParser ExcludeLineals()
        {
            // Avisos lineales
            _filters.Add(new SelectedFilter 
                             {
                                 Name = "publication_type_id",
                                 Value = "D", 
                                 Deny = true
                             });

            return this;
        }
    }

    public class SelectedFilterContext
    {
        private List<SelectedFilter> _selectedFilters;
        public int Page { get; set; }
        public int PageSize { get; set; }
        public OrderInfo SortField { get; set; }

        public List<SelectedFilter> SelectedFilters
        {
            get {
                return _selectedFilters;
            }
            set {
                _selectedFilters = value;
            }
        }
    }

    public class OrderInfo
    {
        public string OrderField { get; set; }
        public string Direction { get; set; }
    }
}