using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Mvc;

namespace Buscador.Contracts
{
    [ServiceContract]
    public interface ISearch
    {
       
        [OperationContract]
        [WebInvoke(Method = "GET", 
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "search/{query}", ResponseFormat = WebMessageFormat.Json)]
        string Search(string query);
        
      [OperationContract]
        [WebInvoke(Method = "GET", 
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "getslices/{query}", ResponseFormat = WebMessageFormat.Json)]
        string GetSlices(string query);

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "getpublication/{publicationId}",ResponseFormat = WebMessageFormat.Json)]
      string GetPublication(string publicationId);
        
        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetVehiclesBrands", ResponseFormat = WebMessageFormat.Json)]
        string GetVehiclesBrands();

        [OperationContract]
        [WebInvoke(Method = "GET", 
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetVehiclesModels/{vehicleBrandId}", ResponseFormat = WebMessageFormat.Json)]
        string GetVehiclesModels(string vehicleBrandId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetVehiclesVersions/{vehicleModelId}", ResponseFormat = WebMessageFormat.Json)]
        string GetVehiclesVersions(string vehicleModelId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetProvinces", ResponseFormat = WebMessageFormat.Json)]
        string GetProvinces();

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetLocality/{provinceId}", ResponseFormat = WebMessageFormat.Json)]
        string GetLocality(string provinceId);

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "GetCities/{localityId}", ResponseFormat = WebMessageFormat.Json)]
        string GetCities(string localityId);

       
    }
}
