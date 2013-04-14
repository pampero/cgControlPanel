using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Iesi.Collections.Generic;

namespace Buscador.Domain
{
    public interface ISearchParameters<T>
    {
        List<SelectedFilter> SelectedFilters { get; }
        List<IFacet> FacetWith { get; }
        string FreeText { get; set; }
        int Page { get; }
        int PageSize { get; set; }
        OrderInfo SortField { get; }
    }
}
