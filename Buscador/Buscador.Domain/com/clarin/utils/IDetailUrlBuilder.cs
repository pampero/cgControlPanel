using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using Spring.Context.Support;

namespace Buscador.Domain.com.clarin.utils
{
    public interface IDetailUrlBuilder
    {
        string BuildFor(Publication publication);
        string BuildSearchUrlFor(Publication publication);
        IUrlOfuscator UrlOfuscator { get; }
    }

    public class DetailUrlBuilder : IDetailUrlBuilder
    {

        public DetailUrlBuilder()
        {
            
        }

        private IUrlOfuscator _urlOfuscator;
        public IUrlOfuscator UrlOfuscator
        {
            get
            {
                if (_urlOfuscator==null)
                    _urlOfuscator=(IUrlOfuscator)ContextRegistry.GetContext().GetObject("urlOfuscator");
                return _urlOfuscator;
            }
            set { _urlOfuscator = value; }
        }

        public string BaseUrl { get; set; }

        public string BuildFor(Publication publication)
        {
            var seoSection = string.Format("{0}-{1}-{2}-{3}-{4}", publication.VehicleMakeText,
                                                                  publication.VehicleModelText,
                                                                  publication.VehicleLocPartText,
                                                                  publication.VehicleSegmentText,
                                                                  publication.VehicleFuelTypeText);

            seoSection = seoSection.Replace("/","-").Replace(" ","-");

            string url;

            if(publication.VehicleType==2)
                url = BaseUrl + UrlPartForVehicleType(publication.VehicleType) + seoSection + "/" + publication.PublicationId;
            else
                url = BaseUrl + UrlPartForVehicleType(publication.VehicleType) + seoSection + "/" + publication.VehicleYear + "_" + publication.PublicationId;

            return url.Replace(" ", "-").Replace("--", "-");
        }

        private string UrlPartForVehicleType(int vehicleType)
        {
            if (vehicleType==2)
                return "nuevos-";
            return "usados-";
        }

        public string BuildSearchUrlFor(Publication publication)
        {
            var and = UrlOfuscator.OfuscatedCharacters["&"];
            var equal = UrlOfuscator.OfuscatedCharacters["="];
            string url = "autos-" + publication.VehicleTypeText + "s";
            url += "-" + publication.VehicleMakeText.ToLower() + "/VT" + equal + publication.VehicleType + and + "MA" + equal +  publication.VehicleMake + and + "MO" + equal + publication.VehicleModel;
            return url;
        }
    }
}
