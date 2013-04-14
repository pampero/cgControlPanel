using System;
using System.Linq;
using System.Collections.Generic;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Iesi.Collections.Generic;

namespace Buscador.Domain
{
    public class SearchParameters<T> : ISearchParameters<T>
    {
        private List<SelectedFilter> _selectedFilters;
        private List<IFacet> _facetWith;
        public string FreeText { get; set; }
        public int Page { get; private set; }
        public int PageSize { get; set; }

        public OrderInfo SortField { get; set; }

        public SearchParameters(string freeText,SelectedFilterContext selectedFiltersContext, IFacet facet, List<IFacet> facetsNotInBranchOf)
        {
            Page = selectedFiltersContext.Page;
            PageSize = selectedFiltersContext.PageSize;
            SortField = selectedFiltersContext.SortField;
            FreeText = freeText;
            _selectedFilters = selectedFiltersContext.SelectedFilters;
            var visitor = new FacetWithVisitor(facetsNotInBranchOf, _selectedFilters);
            facet.Accept(visitor);
            _facetWith = visitor.FacetWith;
        }

        public SearchParameters(string freeText)
        {
            FreeText = freeText;
        }

        public SearchParameters(string freeText, int page, OrderInfo sortField) : this(freeText)
        {
            Page = page;
            SortField = sortField;
        }

        public List<SelectedFilter> SelectedFilters
        {
            get { return _selectedFilters; }
        }

        public List<IFacet> FacetWith
        {
            get { return _facetWith; }
        }

        public string GetVehicleTypeDescription()
        {
            var vehicleTypeText = string.Empty;
            if ((SelectedFilters != null) && SelectedFilters.Exists(x => x.Name == "vehicle_type_id"))
                vehicleTypeText = SelectedFilters.Where(x => x.Name == "vehicle_type_id").First().Value == "1" ? "usados" : SelectedFilters.Where(x => x.Name == "vehicle_type_id").First().Value == "2" ? "nuevos" : string.Empty;
            return vehicleTypeText;
        }
    }

    public class FacetWithVisitor : IFacetVisitor
    {
        private List<IFacet> _facetsNotInBranch;
        private List<SelectedFilter> _selectedFilters;

        public FacetWithVisitor(List<IFacet> facetsNotInBranchOf, List<SelectedFilter> selectedFilters)
        {
            _facetsNotInBranch = facetsNotInBranchOf;
            _selectedFilters = selectedFilters;
        }

        public List<IFacet> FacetWith { get; private set; }

        public void Visit(SimpleFacet simpleFacet)
        {
            FacetWith = _facetsNotInBranch;
        }

        public void Visit(HierarchicalFacet hierarchicalFacet)
        {
            if (_selectedFilters.Where(x => x.Name == hierarchicalFacet.Child.Name).Count()==0)
            {
                _facetsNotInBranch.Add(hierarchicalFacet.Child);
                FacetWith = _facetsNotInBranch;
            }
        }

        public void Visit(RangedFacet rangedFacet)
        {
            FacetWith = _facetsNotInBranch;
        }

        public void Visit(InputRangedFacet simpleFacet)
        {
            FacetWith = _facetsNotInBranch;
        }
    }

    public interface IFacetVisitor
    {
        void Visit(SimpleFacet simpleFacet);
        void Visit(HierarchicalFacet hierarchicalFacet);
        void Visit(RangedFacet rangedFacet);
        void Visit(InputRangedFacet simpleFacet);
    }
}