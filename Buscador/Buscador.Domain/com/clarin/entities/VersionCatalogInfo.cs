using System;
using System.Collections.Generic;
using SolrNet.Attributes;

namespace Buscador.Domain.com.clarin.entities
{
    public class VersionCatalogInfo
    {
        [SolrField("Id")]
        public virtual int Id { get; set; }

        [SolrUniqueKey("Version_id")]
        public virtual string Version_id { get; set; }

        [SolrField("Description")]
        public virtual string Description { get; set; }

        [SolrField("Acceleration")]
        public virtual string Acceleration { get; set;}

        [SolrField("Alimentation")]
        public virtual string Alimentation { get; set;}

        [SolrField("BackBrakes")]
        public virtual string BackBrakes { get; set;}

        [SolrField("BackSuspension")]
        public virtual string BackSuspension { get; set;}

        [SolrField("ConsumptionCity")]
        public virtual string ConsumptionCity { get; set;}

        [SolrField("ConsumptionCombined")]
        public virtual string ConsumptionCombined { get; set;}

        [SolrField("ComsuptionRoad")]
        public virtual string ConsumptionRoad { get; set;}

        [SolrField("Cylinder")]
        public virtual string Cylinder { get; set;}

        [SolrField("Displacement")]
        public virtual string Displacement { get; set;}

        [SolrField("Doors")]
        public virtual string Doors { get; set;}

        [SolrField("Engine")]
        public virtual string Engine { get; set;}

        [SolrField("FrontBrakes")]
        public virtual string FrontBrakes { get; set;}

        [SolrField("FrontSuspension")]
        public virtual string FrontSuspension { get; set;}

        [SolrField("Fuel")]
        public virtual string Fuel { get; set;}

        [SolrField("FuelTank")]
        public virtual string FuelTank { get; set;}

        [SolrField("Gearbox")]
        public virtual string Gearbox { get; set;}

        [SolrField("Height")]
        public virtual string Height { get; set;}

        [SolrField("Long")]
        public virtual string Long { get; set;}

        [SolrField("Marches")]
        public virtual string Marches { get; set;}

        [SolrField("MaximumSpeed")]
        public virtual string MaximumSpeed { get; set;}

        [SolrField("Position")]
        public virtual string Position { get; set;}

        [SolrField("Power")]
        public virtual string Power { get; set;}

        [SolrField("Price")]
        public virtual string Price { get; set;}

        [SolrField("RowSeats")]
        public virtual string RowSeats { get; set;}

        [SolrField("Squares")]
        public virtual string Squares { get; set;}

        [SolrField("Tires")]
        public virtual string Tires { get; set;}

        [SolrField("Torque")]
        public virtual string Torque { get; set;}

        [SolrField("Traction")]
        public virtual string Traction { get; set;}

        [SolrField("Trunk")]
        public virtual string Trunk { get; set;}

        [SolrField("UnladenWeight")]
        public virtual string UnladenWeight { get; set;}

        [SolrField("Wheelbase")]
        public virtual string Wheelbase { get; set;}

        [SolrField("Width")]
        public virtual string Width { get; set;}

        [SolrField("ZeroKmH")]
        public virtual string ZeroKmH { get; set;}

        [SolrField("VersionCatalogInfo_id")]
        public virtual string VersionCatalogInfo_id { get; set;}


        private IList<EquipmentAttr> _equipmentAttributes;
        [SolrField("equipments_eq")]
        public virtual IList<EquipmentAttr> EquipmentAttributes
        {
            get
            {
                if (_equipmentAttributes == null)
                    _equipmentAttributes = new List<EquipmentAttr>();

                for (var i = 0; i < _equipmentAttributes.Count; i++)
                {
                    _equipmentAttributes[i].AttrType = _equipmentTypes[i].ToString();
                }

                return _equipmentAttributes;
            }
            set { _equipmentAttributes = value; }
        }

        private IList<string> _equipmentTypes;
        [SolrField("equipments_types")]
        public virtual IList<string> EquipmentTypes
        {
            get
            {
                if (_equipmentTypes == null)
                    _equipmentTypes = new List<string>();

                return _equipmentTypes;
            }
            set { _equipmentTypes = value; }
        }

        private IList<string> _equipmentAttributesKeys;
        [SolrField("equipments_keys")]
        public virtual IList<string> EquipmentAttributesKeys
        {
            get
            {
                if (_equipmentAttributesKeys == null)
                    _equipmentAttributesKeys = new List<string>();
                return _equipmentAttributesKeys;
            }
            set { _equipmentAttributesKeys = value; }
        }
        
        //private IList<PublicationAttr> _publicationAttributes;

        //[SolrField("equipments_eq")]
        //public virtual IList<PublicationAttr> PublicationAttributes
        //{
        //    get
        //    {
        //        if (_publicationAttributes == null)
        //            _publicationAttributes = new List<PublicationAttr>();
        //        return _publicationAttributes;
        //    }
        //    set { _publicationAttributes = value; }
        //}







    }
}
