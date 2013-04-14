using System;
using System.Collections.Generic;
using System.Linq;
using Buscador.Domain.com.clarin.filters;
using System.Collections.Specialized;

namespace Buscador.Domain.com.clarin.facets
{
    public interface IFacetConfiguration
    {
        IFacetHierarchy FacetHierarchy { get; set; }
        HybridDictionary IgnoredFacetsValues { get; set; }
        int PageSize { get; set; }
    }

    public class FacetConfiguration : IFacetConfiguration
    {
        public IFacetHierarchy FacetHierarchy { get; set; }
        public HybridDictionary IgnoredFacetsValues { get; set; }

        public int PageSize { get; set; }

        public FacetConfiguration()
        {

        }
    }

    public interface IFacetHierarchy
    {
        List<IFacet> Facets { get; set; }
        IFacet ByName(string facetName);
        IFacet ByKey(string facetKey);
        IFacet ParentOf(string facetName);
        List<IFacet> FacetsNotInBranchOf(string facetName);
        KeyValuePair<string, ICollection<KeyValuePair<string, int>>> Codified(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facetField);
        string Codified(string facetField);
        List<IFacet> GetFacetAndHisChilds(IFacet facet);
        List<IFacet> Seoable();
        List<IFacet> GetFacetsWith(List<SelectedFilter> selectedFilters);
        bool UseForSeo(string facetName);
    }

    public class FacetHierarchy : IFacetHierarchy
    {
        public List<IFacet> Facets { get; set; }

        public IFacet ByName(string facetName)
        {
            return Facets.Where(x => x.Name == facetName).First();
        }

        public IFacet ByKey(string facetKey)
        {
            return Facets.Where(x => x.Key == facetKey).FirstOrDefault();
        }

        public IFacet ParentOf(string facetName)
        {
            var parentFacet = Facets.OfType<HierarchicalFacet>()
                                    .Where(x => x.Child == Facets.Where(y => y.Name == facetName).First())
                                    .FirstOrDefault();
            return parentFacet;
        }

        public List<IFacet> FacetsNotInBranchOf(string facetName)
        {
            var theFacet = Facets.Where(x => x.Name == facetName).First();
            return Facets.Where(facet => facet.Branch != theFacet.Branch).ToList();
        }

        public KeyValuePair<string, ICollection<KeyValuePair<string, int>>> Codified(KeyValuePair<string, ICollection<KeyValuePair<string, int>>> facetField)
        {
            var translatedKeyValue = new List<KeyValuePair<string, int>>();
            foreach (var keyValuePair in facetField.Value)
            {
                translatedKeyValue.Add(new KeyValuePair<string, int>(Facets.Where(f=>f.Name==keyValuePair.Key).First().Key,keyValuePair.Value));
            }
            return new KeyValuePair<string, ICollection<KeyValuePair<string, int>>>(facetField.Key,translatedKeyValue);
        }

        public string Codified(string facetField)
        {
            return Facets.Where(f => f.Name == facetField).FirstOrDefault().Key;
        }

        public List<IFacet> GetFacetAndHisChilds(IFacet facet)
        {
            return Facets.Where(x => x.Branch == facet.Branch && x.Level >= facet.Level)
                         .ToList();
        }

        public bool UseForSeo(string facetName)
        {
            return Facets.Where(x => x.Name == facetName).First().UseForSeo;
        }

        public List<IFacet> Seoable()
        {
            return Facets.Where(x => x.UseForSeo).ToList();
        }

        public List<IFacet> GetFacetsWith(List<SelectedFilter> selectedFilters)
        {
            var facetsNotInBranch = FacetsNotInBranchOf(selectedFilters.Last().Name);
            var facetWith = new List<IFacet>();

            foreach (var facetNotInBranch in facetsNotInBranch)
            {
                if (selectedFilters.Where(s => s.Name == facetNotInBranch.Name).Count() > 0)
                {
                    facetNotInBranch.Accept(new FacetWithVisitor(facetWith, selectedFilters));
                }
                else
                {
                    if (facetNotInBranch.Level == 1)
                        facetWith.Add(facetNotInBranch);
                }
            }
            return facetWith;
        }
    }
}
