using System.Linq;
using System.Web.Mvc;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Web
{
    public class SearchParametersBinder : DefaultModelBinder
    {
        public FacetConfiguration FacetConfiguration { get; set; }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var freeText = controllerContext.HttpContext.Request.Form["freetext"];
            if(controllerContext.RouteData.Values["query"]!=null)
            {
                var query = controllerContext.RouteData.Values["query"].ToString();
                var selectedFilters = QueryUrlParser.Parse(query).GetSelectedFilters();
                return new SearchParameters<Publication>(freeText,
                                                         selectedFilters,
                                                         FacetConfiguration.FacetHierarchy.ByName(selectedFilters.Last().Name),
                                                         FacetConfiguration.FacetHierarchy.FacetsNotInBranchOf(selectedFilters.Last().Name));
            }

            return new SearchParameters<Publication>(freeText);
        }
    }
}