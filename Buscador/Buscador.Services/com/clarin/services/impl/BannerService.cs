using System;
using System.Collections.Generic;
using System.Text;
using Buscador.Domain;
using Buscador.Domain.com.clarin.dao;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Services.com.clarin.services.impl
{
    public class BannerService : IBannerService
    {
        public IBannerDao BannerDao { get; set; }

        public string GetHtmlBanner(List<SelectedFilter> selectedFilters, string codigo, string seccion)
        {
            return GetHtmlBanner(selectedFilters, codigo, seccion, "eb");
        }

        public string GetHtmlBanner(List<SelectedFilter> selectedFilters, string codigo, string seccion, string eSection)
        {
            var banner = new Banner
            {
                Heigh = BannerDao.GetAttribute("alto", seccion, codigo),
                Width = BannerDao.GetAttribute("ancho", seccion, codigo),
                Provider = BannerDao.GetAttribute("proveedor", seccion, codigo).ToLower().Trim(),
                Behaviour = BannerDao.GetAttribute("comportamiento", seccion, codigo).ToLower().Trim(),
                Parameters = BannerDao.GetAttribute("parametros", seccion, codigo),
                Zone = BannerDao.GetAttribute("zona", seccion, codigo),
                Section = seccion,
                ESection =  eSection,
                Code = codigo,
                Order = BannerDao.GetAttribute("orden", seccion, codigo),
                KeywordsProvider = new SearcParameterKeywordsProvider(selectedFilters, new Dictionary<string, string>
                                                                                                        {
                                                                                                                {"id_marca", "vehicle_make_id"},
                                                                                                                {"id_model", "vehicle_model_id"},
                                                                                                                {"provinci", "vehicle_loc_prov_id"},
                                                                                                                {"localida", "vehicle_loc_loc_id"}
                                                                                                        })
            };

            return banner.GetHtml();
        }





        public string GetHtmlBanner(string codigo)
        {

            Random r = new Random(DateTime.Now.Millisecond);


            string seccion = r.Next(1,2)==1?"usados":"nuevos";


            var banner = new Banner
            {
                Heigh = BannerDao.GetAttribute("alto", seccion, codigo),
                Width = BannerDao.GetAttribute("ancho", seccion, codigo),
                Provider = BannerDao.GetAttribute("proveedor", seccion, codigo).ToLower().Trim(),
                Behaviour = BannerDao.GetAttribute("comportamiento", seccion, codigo).ToLower().Trim(),
                Parameters = BannerDao.GetAttribute("parametros", seccion, codigo),
                Zone = BannerDao.GetAttribute("zona", seccion, codigo),
                Section = seccion,
                ESection = "eb",
                Code = codigo,
                Order = BannerDao.GetAttribute("orden", seccion, codigo),
                KeywordsProvider = new SearcParameterKeywordsProvider()
            };

            return banner.GetHtml();
            
        }
    }
}
