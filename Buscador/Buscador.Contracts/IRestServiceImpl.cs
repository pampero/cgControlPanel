using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Buscador.Contracts
{
    
    [ServiceContract]
    public interface IRestServiceImpl
    {
        [OperationContract]
        //void DoWork();
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/JSONData/{id}")]
        string JSONData(string id);

    }
}
