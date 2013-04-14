using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Domain.com.clarin.facets
{
    public static class FacetExtensionsMethods
    {
        public static List<SelectedFilter> ToSelectedFilter(this List<IFacet> facets)
        {
            var selectedFilters = new List<SelectedFilter>();
            facets.ForEach(facet => selectedFilters.Add(new SelectedFilter(facet.Name, facet.Value, facet.UseForSeo, facet.Priority)));
            return selectedFilters;
        }
    }
}
