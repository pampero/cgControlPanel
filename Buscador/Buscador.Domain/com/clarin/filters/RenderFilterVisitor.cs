using System;
using Buscador.Domain.com.clarin.slices;

namespace Buscador.Domain.com.clarin.filters
{
    public class RenderFilterVisitor : IFilterVisitor
    {
        public string Html { get; private set; }

        public void Visit(Slice slice)
        {
            var htmlTemplate = "<a href='{0}'>{1}<b> (</b>{2}<b>) </b></a>";
            Html = string.Format(htmlTemplate, slice.Url, slice.Name.Localize(), slice.Value);
        }

        public void Visit(DynamicRangeSlice slice)
        {
            var formHtml = string.Format("<form name='inputRangeForm' method='get' url='{0}' onSubmit='return OnSubmitRangeForm();'>", slice.Url);
            Html = formHtml +
                   "<span class='facetText'>Desde</span>" +
                        "<input type='text'  id='txtDesde'/>" +
                   "<span class='facetText'>Hasta</span>" +
                        "<input type='text' id='txtHasta'/>" +
                   "<div><input type='submit' value='Aplicar'></div></form>";
        }
    }

    public interface IFilterVisitor
    {
        void Visit(Slice slice);
        void Visit(DynamicRangeSlice slice);
    }
}