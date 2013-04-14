using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;

namespace Buscador.Domain.com.clarin.entities
{
    public class PublicationHome
    {
        [SolrField("Id")]
        public virtual int Id { get; set; }
        
        [SolrUniqueKey("idPublicationOrder")]
        public virtual int idPublicationOrder { get; set; }

        [SolrField("CurrencySymbol")]
        public virtual string CurrencySymbol { get; set; }

        [SolrField("Fuel")]
        public virtual string Fuel { get; set; }
        
        [SolrField("IndexOrder")]
        public virtual int IndexOrder { get; set; }

        [SolrField("Mileage")]
        public virtual int Mileage { get; set; }

        [SolrField("Price")]
        public virtual decimal Price { get; set; }

        [SolrField("PriceCurrency")]
        public virtual string PriceCurrency { get; set; }

        [SolrField("PublishableItemType")]
        public virtual string PublishableItemType { get; set; }

        [SolrField("URL_PubDetail")]
        public virtual string URL_PubDetail { get; set; }

        [SolrField("VehicleBrand")]
        public virtual string VehicleBrand { get; set; }

        [SolrField("VehicleModel")]
        public virtual string VehicleModel { get; set; }

        [SolrField("VehicleVersion")]
        public virtual string VehicleVersion { get; set; }

        [SolrField("Year")]
        public virtual string Year { get; set; }

        [SolrField("idFuel")]
        public virtual int idFuel { get; set; }

        [SolrField("idPriceCurrency")]
        public virtual int idPriceCurrency { get; set; }

        [SolrField("idPublishableItem")]
        public virtual int idPublishableItem { get; set; }

        [SolrField("idPublishableItemType")]
        public virtual int idPublishableItemType { get; set; }

        [SolrField("idVehicleBrand")]
        public virtual int idVehicleBrand { get; set; }

        [SolrField("idVehicleModel")]
        public virtual int idVehicleModel { get; set; }

        [SolrField("idVehicleVersion")]
        public virtual int idVehicleVersion { get; set; }

        [SolrField("last_modified_date")]
        public virtual DateTime last_modified_date { get; set; }


    }
}
