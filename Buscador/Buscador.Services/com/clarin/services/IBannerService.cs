using System.Collections.Generic;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Services.com.clarin.services
{
    public interface IBannerService
    {
        string GetHtmlBanner(List<SelectedFilter> selectedFilters, string codigo, string seccion);
        string GetHtmlBanner(List<SelectedFilter> selectedFilters, string resultadoheaderderecha, string vehicleTypeText, string eSection);
        string GetHtmlBanner(string codigo);
    }
}
