using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.slices;

namespace Buscador.Web.Views.Home.Helpers
{
    public static class FilterHtmlHelper
    {
        public static string CreateFilter(ISlice filter)
        {
            var visitor = new RenderFilterVisitor();
            filter.Accept(visitor);
            return visitor.Html;
        }
    }
}