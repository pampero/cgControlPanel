using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using FluentNHibernate.Mapping;

namespace Buscador.Domain.mappings.com.clarin.entities
{
    public class PublicationMapping : ClassMap<Publication>
    {
        public PublicationMapping()
        {
            Table("INDEX_TABLE");
            Id(x => x.Id, "INDEX_ID").GeneratedBy.Identity();
            Map(x => x.IndexWeight, "INDEX_WEIGHT");
            Map(x => x.PublicationContactsQty, "PUBLICATION_CONTACTS_QTY");
            Map(x => x.PublicationDate, "PUBLICATION_DATE");
            Map(x => x.PublicationStartDate, "PUBLICATION_START_DATE");
            Map(x => x.PublicationEndDate, "PUBLICATION_END_DATE");
            Map(x => x.PublicationDeleted, "PUBLICATION_DELETED");
            Map(x => x.PublicationHighLight, "PUBLICATION_HIGHLIGHT");
            Map(x => x.PublicationId, "PUBLICATION_ID");
            Map(x => x.PublicationSubtitle, "PUBLICATION_SUBTITLE");
            Map(x => x.PublicationType, "PUBLICATION_TYPE_ID");
            Map(x => x.PublicationUrl, "PUBLICATION_URL");
            Map(x => x.PublicationVisitorsQty, "PUBLICATION_VISITOR_QTY");
            Map(x => x.VehicleLocPart, "VEHICLE_LOC_PART_ID");
            Map(x => x.VehicleLocProv, "VEHICLE_LOC_PROV_ID");
            Map(x => x.VehicleLocLoc, "VEHICLE_LOC_LOC_ID");
            Map(x => x.VehicleColor, "VEHICLE_COLOR_ID");
            Map(x => x.VehicleFirstOwner, "VEHICLE_FIRST_OWNER");
            Map(x => x.VehicleFuelType, "VEHICLE_FUEL_TYPE_ID");
            Map(x => x.VehicleKm, "VEHICLE_KM");
            Map(x => x.VehicleMake, "VEHICLE_MAKE_ID");
            Map(x => x.VehicleModel, "VEHICLE_MODEL_ID");
            Map(x => x.VehicleVersion, "VEHICLE_VERSION_ID");
            Map(x => x.VehiclePicQty, "VEHICLE_PIC_QTY");
            Map(x => x.VehiclePrice, "VEHICLE_PRICE");
            Map(x => x.VehiclePriceCurrency, "VEHICLE_PRICE_CURRENCY");
            Map(x => x.VehicleSegment, "VEHICLE_SEGMENT_ID");
            Map(x => x.VehicleStatus, "VEHICLE_STATUS_ID");
            Map(x => x.VehicleType, "VEHICLE_TYPE_ID");
            Map(x => x.VehicleYear, "VEHICLE_YEAR");
            Map(x => x.UserUid, "USER_UID");
            Map(x => x.UserType, "USER_TYPE");
            Map(x => x.PublishableItemId, "PUBLISHABLE_ITEM_ID");
            Map(x => x.UserDescription, "USER_DESCRIPTION");
            Map(x => x.UserEmail, "USER_EMAIL");
            Map(x => x.UserPhone, "USER_PHONE");
            Map(x => x.UserAddress, "USER_ADDRESS");
        
            HasMany(x => x.EquipmentAttributes).KeyColumn("INDEX_TABLE_ID").Cascade.AllDeleteOrphan().Where("ATTR_TYPE='EQUI'");
            HasMany(x => x.PublicationAttributes).KeyColumn("INDEX_TABLE_ID").Cascade.AllDeleteOrphan().Where("ATTR_TYPE='PUBLI'"); ;
        }
    }
}
