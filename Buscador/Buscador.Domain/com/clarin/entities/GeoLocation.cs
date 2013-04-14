using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{

    [ServiceContract]
    public interface IGeoLocation
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        GeoLocation GetLocation(Publication publication, GeoLocation geoLocation);
    }

    public class Location
    {
        private int id;
        private string name;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

   

    [DataContract]
    public class GeoLocation: IGeoLocation
    {
        
        [DataMember]
        public Location Province { get; set; }
        [DataMember]
        public Location Partido { get; set; }
        [DataMember]
        public Location Localidad { get; set; }


        public GeoLocation GetLocation(Publication publication, GeoLocation list)
        {
            list.Province = new Location();
            list.Province.Id = publication.VehicleLocProv;
            list.Province.Name = publication.VehicleLocProvText;

            list.Partido = new Location();
            list.Partido.Id = publication.VehicleLocPart;
            list.Partido.Name = publication.VehicleLocPartText;

            list.Localidad = new Location();
            list.Localidad.Id = publication.VehicleLocLoc;
            list.Localidad.Name = publication.VehicleLocLocText;
            
            
            return list;

        }
    }
}
