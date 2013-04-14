using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Spring.Context.Support;

namespace Buscador.Web
{
    public class SearchParametersBinder : DefaultModelBinder
    {
        public FacetConfiguration FacetConfiguration { get; set; }

        public IUrlOfuscator UrlOfuscator { get; set; }
        
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (FacetConfiguration == null)
                FacetConfiguration = (FacetConfiguration)ContextRegistry.GetContext().GetObject("facetConfiguration");

            if(UrlOfuscator == null)
                UrlOfuscator = (UrlOfuscator)ContextRegistry.GetContext().GetObject("urlOfuscator");

            var freeText = controllerContext.HttpContext.Request.Form["freetext"];
            if(controllerContext.RouteData.Values["query"]!=null)
            {
                var query = controllerContext.RouteData.Values["query"].ToString();
                if(query.Contains(UrlOfuscator.OfuscatedCharacters["="].ToString()))
                {
                    var conditions = Conditions.From(query, UrlOfuscator);
                    var selectedFiltersContext = QueryUrlParser.With(FacetConfiguration.FacetHierarchy, UrlOfuscator)
                                                               .Parse(conditions)
                                                               .GetSelectedFilters();

                    if (selectedFiltersContext.SelectedFilters.Count == 0)
                        return new SearchParameters<Publication>(freeText, selectedFiltersContext.Page, selectedFiltersContext.SortField);

                    return new SearchParameters<Publication>(freeText,
                                                             selectedFiltersContext,
                                                             FacetConfiguration.FacetHierarchy.ByName(selectedFiltersContext.SelectedFilters.Last().Name),
                                                             GetFacetsWith(selectedFiltersContext.SelectedFilters));
                }
            }

            return new SearchParameters<Publication> (freeText);
        }

        private List<IFacet> GetFacetsWith(List<SelectedFilter> selectedFilters)
        {
            var facetsNotInBranch = FacetConfiguration.FacetHierarchy.FacetsNotInBranchOf(selectedFilters.Last().Name);
            var facetWith = new List<IFacet>();

            foreach (var facetNotInBranch in facetsNotInBranch)
            {
                if(selectedFilters.Where(s=>s.Name==facetNotInBranch.Name).Count()>0)
                {
                    facetNotInBranch.Accept(new FacetWithVisitor(facetWith, selectedFilters));
                }
                else
                {
                    if(facetNotInBranch.Level==1)
                        facetWith.Add(facetNotInBranch);
                }
            }
            return facetWith;
        }
    }
}