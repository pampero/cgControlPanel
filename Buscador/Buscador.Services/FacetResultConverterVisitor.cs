using System;
using System.Collections.Generic;
using System.Linq;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.slices;
using Buscador.Services.com.clarin.services;

namespace Buscador.Services
{
    public class FacetResultConverterVisitor<T> : IFacetVisitor
    {
        private KeyValuePair<string, ICollection<KeyValuePair<string, int>>> _facetField;
        private readonly List<SelectedFilter> _selectedFilters;
        private readonly IResults<T> _result;
        private IFacetHierarchy _facetHierarchy;
        private IFilterUrlBuilder _filterUrlBuilder;
        public ISliceCacheProvider _cacheProvider;

        public FacetResultConverterVisitor(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facetField, List<SelectedFilter> selectedFilters, IResults<T> result, IFacetHierarchy facetHierarchy, IFilterUrlBuilder filterUrlBuilder, ISliceCacheProvider cacheProvider)
        {
            _facetField = facetField;
            _selectedFilters = selectedFilters;
            _result = result;
            _facetHierarchy = facetHierarchy;
            _filterUrlBuilder = filterUrlBuilder;
            _cacheProvider = cacheProvider;
        }

        public void Visit(SimpleFacet simpleFacet)
        {
            if (!simpleFacet.Visible) return;
            var filterGroup = BuildFilterGroup();

            if (filterGroup != null)
                _result.AddFilterGroup(filterGroup);
        }

        public void Visit(HierarchicalFacet hierarchicalFacet)
        {
            if (!hierarchicalFacet.Visible) return;
            var filterGroup = BuildFilterGroup();
            if (filterGroup != null)
                _result.AddFilterGroup(filterGroup);
        }

        public void Visit(RangedFacet rangedFacet)
        {
            if (!rangedFacet.Visible) return;

            var filterGroup = new FilterGroup(_facetField.Key);
            foreach (var facet in _facetField.Value.Where(facet => facet.Value != 0))
            {
                var rangeFinded = rangedFacet.Ranges.Where(range => range.From <= int.Parse(facet.Key) &&
                                                                    range.To >= int.Parse(facet.Key)).First();

                var filterToShow = filterGroup.FiltersToShow
                                              .Where(filter => filter.Name == string.Format("{0} - {1}", rangeFinded.From, rangeFinded.To))
                                              .FirstOrDefault();

                if (filterToShow == null)
                {
                    filterGroup.FiltersToShow.Add(new Slice
                                                      {
                                                          Name = rangeFinded.ToString(),
                                                          Value = facet.Value.ToString(),
                                                          Url = _filterUrlBuilder.BuildFrom(_facetHierarchy,_cacheProvider)
                                                                                .WithFilters(_selectedFilters)
                                                                                .Faceted(_facetField)
                                                                                .Sliced(rangeFinded.ToString())
                                                                                .GetUrl(),
                                                          SliceKey = _facetHierarchy.ByName(_facetField.Key).Key,
                                                      });
                }
                else
                {
                    filterToShow.Value = (int.Parse(filterToShow.Value) + facet.Value).ToString();
                }
            }
            _result.AddFilterGroup(filterGroup);
        }

        public void Visit(InputRangedFacet simpleFacet)
        {
            if (!simpleFacet.Visible) return;
            
            var filterGroup = BuildFilterGroupInputRange();
            if (filterGroup != null)
                _result.AddFilterGroup(filterGroup);
        }

        private FilterGroup BuildFilterGroupInputRange()
        {
            var filterGroup = new FilterGroup(_facetField.Key);


            filterGroup.FiltersToShow.Add(new DynamicRangeSlice
            {
                Name = _facetField.Key,
                CodifiedName = _facetHierarchy.Codified(_facetField.Key),
                Value = _facetField.Value.ToString(),
                Url = _filterUrlBuilder.BuildFrom(_facetHierarchy, _cacheProvider)
                                        .WithFilters(_selectedFilters)
                                        .Faceted(_facetField)
                                        .Sliced(_facetField.Key)
                                        .GetUrl()
            });

            return filterGroup;
        }

        private FilterGroup BuildFilterGroup()
        {
            var filterGroup = new FilterGroup(_facetField.Key);
            var facets = _facetField.Value.Where(facet => facet.Value != 0);

            if (_facetField.Key.Contains("year"))
                facets = _facetField.Value.Where(facet => facet.Value != 0).OrderByDescending(x => x.Key);

            foreach (var facet in facets)
            {
                var filterName = default(string);

                if (_facetField.Key == "user_type")
                {
                    filterName = facet.Key.Localize();
                }
                else
                {
                    filterName = _cacheProvider.GetName(_facetField.Key, facet.Key);
                }


                if (!IsExcludedFilter(_facetField,filterName))
                {

                    filterGroup.FiltersToShow.Add(new Slice
                                                      {
                                                          Name = filterName,
                                                          Value = facet.Value.ToString(),
                                                          Url =
                                                              _filterUrlBuilder.BuildFrom(_facetHierarchy,
                                                                                          _cacheProvider)
                                                              .WithFilters(_selectedFilters)
                                                              .Faceted(_facetField)
                                                              .Sliced(facet.Key)
                                                              .GetUrl(),
                                                          SliceKey = _facetHierarchy.ByName(_facetField.Key).Key,
                                                  });
            }
        }
            return filterGroup;
        }

        private bool IsExcludedFilter(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facets,string filterName)
        {
            bool bExcluded = false;
            if (facets.Key.Contains("version") || facets.Key.Contains("segment") || facets.Key.Contains("prov_id") || facets.Key.Contains("part_id") || facets.Key.Contains("loc_id") || facets.Key.Contains("fuel_type"))
            {
                if (filterName =="No Especifica" )
                {
                     bExcluded = true;
                }
            }

            return bExcluded;
        }

    }
}