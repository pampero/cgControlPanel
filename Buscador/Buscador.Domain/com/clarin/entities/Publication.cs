using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;

namespace Buscador.Domain.com.clarin.entities
{
    public class Publication
    {
        public virtual int Id { get; set; }

        [SolrUniqueKey("publication_id")]
        public virtual int PublicationId { get; set; }
        [SolrField("publication_contacts_qty")]
        public virtual int PublicationContactsQty { get; set; }
        [SolrField("publication_date")]
        public virtual DateTime PublicationDate { get; set; }
        [SolrField("publication_start_date")]
        public virtual DateTime PublicationStartDate { get; set; }
        [SolrField("publication_end_date")]
        public virtual DateTime PublicationEndDate { get; set; }
        [SolrField("publication_highlight")]
        public virtual string PublicationHighLight { get; set; }
        [SolrField("publication_visitors_qty")]
        public virtual int PublicationVisitorsQty { get; set; }
        [SolrField("publication_subtitle")]
        public virtual string PublicationSubtitle { get; set; }
        [SolrField("publication_url")]
        public virtual string PublicationUrl { get; set; }
        [SolrField("publication_type_id")]
        public virtual string PublicationType { get; set; }
        public virtual PublicationType CPublicationType { get; set; }
        [SolrField("publication_deleted")]
        public virtual bool PublicationDeleted { get; set; }
        [SolrField("user_uid")]
        public virtual int UserUid { get; set; }
        [SolrField("user_type")]
        public virtual string UserType { get; set; }
        [SolrField("index_weight")]
        public virtual int IndexWeight { get; set; }
        [SolrField("vehicle_make_id")]
        public virtual int VehicleMake { get; set; }
        public virtual string VehicleMakeText { get; set; }
        [SolrField("vehicle_model_id")]
        public virtual int VehicleModel { get; set; }
        public virtual string VehicleModelText { get; set; }
        [SolrField("vehicle_version_id")]
        public virtual int VehicleVersion { get; set; }
        public virtual string VehicleVersionText { get; set; }
        [SolrField("vehicle_type_id")]
        public virtual int VehicleType { get; set; }
        [SolrField("vehicle_price")]
        public virtual double VehiclePrice { get; set; }
        [SolrField("vehicle_price_currency_id")]
        public virtual int VehiclePriceCurrency { get; set; }
        public virtual Currency CVehiclePriceCurrency { get; set; }
        [SolrField("vehicle_year")]
        public virtual int VehicleYear { get; set; }
        [SolrField("vehicle_km")]
        public virtual int VehicleKm { get; set; }
        [SolrField("vehicle_loc_prov_id")]
        public virtual int VehicleLocProv { get; set; }
        public virtual string VehicleLocProvText { get; set; }
        [SolrField("vehicle_loc_part_id")]
        public virtual int VehicleLocPart { get; set; }
        public virtual string VehicleLocPartText { get; set; }
        [SolrField("vehicle_loc_loc_id")]
        public virtual int VehicleLocLoc { get; set; }
        public virtual string VehicleLocLocText { get; set; }
        [SolrField("vehicle_status_id")]
        public virtual int VehicleStatus { get; set; }
        [SolrField("vehicle_segment_id")]
        public virtual int VehicleSegment { get; set; }
        public virtual string VehicleSegmentText { get; set; }
        [SolrField("vehicle_pic_qty")]
        public virtual int VehiclePicQty { get; set; }
        [SolrField("vehicle_fuel_type_id")]
        public virtual int VehicleFuelType { get; set; }
        public virtual string VehicleFuelTypeText { get; set; }
        [SolrField("vehicle_first_owner")]
        public virtual bool VehicleFirstOwner { get; set; }
        [SolrField("vehicle_color_id")]
        public virtual int VehicleColor { get; set; }
        public virtual string VehicleColorText { get; set; }
        [SolrField("logo_id")]
        public virtual int LogoId { get; set; }
        [SolrField("user_microsite")]
        public virtual string UserMicrosite { get; set; }
        [SolrField("vehicle_price_absolute")]
        public virtual double VehiclePriceAbsolute { get; set; }
        [SolrField("CheckPrice")]
        public virtual bool CheckPrice { get; set; }
        [SolrField("ShowCatalogInfo")]
        public virtual bool ShowCatalogInfo { get; set; }

        public virtual bool ConfigShowCatalogInfo { get; set; }
        public virtual bool FirstImageExists { get; set; }
        

        public virtual int CompanyId { get; set; }

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

        private IList<FeatureAttr> _features;
        [SolrField("feature_ft")]
        public virtual IList<FeatureAttr> Features
        {
            get
            {
                if (_features == null)
                    _features = new List<FeatureAttr>();

                return _features;
            }
            set { _features = value; }
        }

        private IList<PublicationAttr> _publicationAttributes;

        [SolrField("equipments_eq")]
        public virtual IList<PublicationAttr> PublicationAttributes
        {
            get
            {
                if (_publicationAttributes == null)
                    _publicationAttributes = new List<PublicationAttr>();
                return _publicationAttributes;
            }
            set { _publicationAttributes = value; }
        }

        public virtual string UrlDetails { get; set; }

        public virtual string VehicleDescription
        {
            get { return string.Format("{0} {1} {2}", VehicleMakeText, VehicleModelText, VehicleVersionText); }
        }

        public virtual string VehicleTypeText
        {
            get
            {
                switch (VehicleType)
                {
                    case 1:
                        return "usado";
                    case 2:
                        return "nuevo";
                    case 3:
                        return "planAhorro";
                    default:
                        return "";
                }
            }
        }

        [SolrField("funding_advance")]
        public virtual double FundingAdvance { get; set; }

        [SolrField("from_quote")]
        public virtual double FromQuote { get; set; }

        [SolrField("seller_comments")]
        public virtual string SellerComment { get; set; }

        [SolrField("payment_method")]
        public virtual int PaymentMethod { get; set; }
        public virtual string PaymentMethodText { get; set; }

        [SolrField("publishable_item_id")]
        public virtual int PublishableItemId { get; set; }

        [SolrField("user_description")]
        public virtual string UserDescription { get; set; }

        [SolrField("user_email")]
        public virtual string UserEmail { get; set; }

        [SolrField("nextelid")]
        public virtual string UserNextelId { get; set; }

        [SolrField("user_phone")]
        public virtual string UserPhone { get; set; }

        [SolrField("user_address")]
        public virtual string UserAddress { get; set; }


        [SolrField("UserViewContactData")]
        public virtual bool UserViewContactData { get; set; }

        [SolrField("publication_state_id")]
        public virtual string State { get; set; }


        [SolrField("GmapCoord")]
        public virtual string GmapCoord { get; set; }

        [SolrField("FundingAdvanceCurrency")]
        public virtual int FundingAdvanceCurrency { get; set; }
        public virtual Currency CFundingAdvanceCurrency { get; set; }

        public virtual string CatalogDescription { get; set; }

        [SolrField("publication_visible")]
        public virtual bool Visible { get; set; }

        public virtual SegmentCatalogInfo SegmentCatalogInfo { get; set; }

        public virtual VersionCatalogInfo VersionCatalogInfo { get; set; }
        
        #region VersionCatalog

        //TODO: DEFINIR MAPEOS EN SOLR

        

        public virtual string Transmisions { get; set; }

        public virtual string Descriptions { get; set; }

        public virtual int Price { get; set; }

        public virtual IList<EquipmentAttr> Specs { get; set; }

        //public virtual IList<TechnicalAttr> TechAttributes { get; set; }

        /*public virtual IList<string> MotorDescriptions { get; set; }

        public virtual IList<string> TransmisionDescriptions { get; set; }

        public virtual IList<string> PerformanceDescriptions { get; set; }

        public virtual IList<string> DimensionDescriptions { get; set; }*/

        #region MotorDescriptions

        [SolrField("Motor")]
        public virtual string Motor { get; set; }
        [SolrField("Alimentation")]
        public virtual string Alimentation { get; set; }
        [SolrField("Engine")]
        public virtual string Engine { get; set; }
        [SolrField("Position")]
        public virtual string Position { get; set; }
        [SolrField("Fuel")]
        public virtual string Fuel { get; set; }
        [SolrField("Cylinder")]
        public virtual string Cylinder { get; set; }
        [SolrField("Displacement")]
        public virtual string Displacement { get; set; }
        [SolrField("Power")]
        public virtual string Power { get; set; }
        [SolrField("Torque")]
        public virtual string Torque { get; set; }
        [SolrField("Combustible")]
        public virtual string Combustible { get; set; }

        #endregion

        #region PerformanceDescriptions

        [SolrField("MaximumSpeed")]
        public virtual string MaximumSpeed { get; set; }
        [SolrField("Acceleration")]
        public virtual string Acceleration { get; set; }
        [SolrField("ZeroKmH")]
        public virtual string ZeroKmH { get; set; }
        [SolrField("ConsumptionCity")]
        public virtual string ConsumptionCity { get; set; }
        [SolrField("ComsuptionRoad")]
        public virtual string ConsumptionRoad { get; set; }
        [SolrField("ConsumptionCombined")]
        public virtual string ConsumptionCombined { get; set; }
        
        #endregion

        #region TransmisionDescriptions

        [SolrField("Gearbox")]
        public virtual string Gearbox { get; set; }
        [SolrField("Marches")]
        public virtual string Marches { get; set; }
        [SolrField("Traction")]
        public virtual string Traction { get; set; }
        [SolrField("FrontBrakes")]
        public virtual string FrontBrakes { get; set; }
        [SolrField("BackBrakes")]
        public virtual string BackBrakes { get; set; }
        [SolrField("FrontSuspension")]
        public virtual string FrontSuspension { get; set; }
        [SolrField("BackSuspension")]
        public virtual string BackSuspension { get; set; }
        [SolrField("Tires")]
        public virtual string Tires { get; set; }
        
        #endregion

        #region DimensionDescriptions

        [SolrField("Doors")]
        public virtual string Doors { get; set; }
        [SolrField("Squares")]
        public virtual string Squares { get; set; }
        [SolrField("RowsSeats")]
        public virtual string RowsSeats { get; set; }
        [SolrField("Long")]
        public virtual string Long { get; set; }
        [SolrField("Width")]
        public virtual string Width { get; set; }
        [SolrField("Heigh")]
        public virtual string Heigh { get; set; }
        [SolrField("Wheelbase")]
        public virtual string Wheelbase { get; set; }
        [SolrField("UnladenWeight")]
        public virtual string UnladenWeight { get; set; }
        [SolrField("publication_visible")]
        public virtual string Trunk { get; set; }
        [SolrField("publication_visible")]
        public virtual string FuelTank { get; set; }

        
        #endregion*/


        #endregion

        #region SegmentCatalog
        [SolrField("ConfortRanking")]
        public virtual int ConfortRanking { get; set; }
        [SolrField("DesignRanking")]
        public virtual int DesignRanking { get; set; }
        [SolrField("PriceRanking")]
        public virtual int PriceRanking { get; set; }
        [SolrField("SecurityRanking")]
        public virtual int SecurityRanking { get; set; }
        [SolrField("ExpertReview")]
        public virtual string ExpertReview { get; set; }
        [SolrField("ExpertReviewDate")]
        public virtual DateTime ExpertReviewDate { get; set; }
        [SolrField("Positives")]
        public virtual IList<string> Positives { get; set; }
        [SolrField("Negatives")]
        public virtual IList<string> Negatives { get; set; }
        [SolrField("LinkToVideo")]
        public virtual string LinkToVideo { get; set; }
        [SolrField("Images")]
        public virtual IList<string> Images { get; set; }
        [SolrField("Colours")]
        public virtual IList<string> Colours { get; set; }

        public virtual double AverageRanking
        {
            get
            {
                int totalRanking = ConfortRanking + DesignRanking + PriceRanking + SecurityRanking;

                decimal aux = Decimal.Divide(totalRanking, 4);

                float a = float.Parse((aux).ToString());
                int integerPart = int.Parse(Math.Floor(a).ToString());
                float decimalPart = a - integerPart;

                double result = 0;

                if (decimalPart < 0.25)
                    result = integerPart;

                if (decimalPart >= 0.25 && decimalPart < 0.75)
                    result = integerPart + 0.5;

                if (decimalPart >= 0.75)
                    result = integerPart + 1;

                return result;
            }

        }
        #endregion


        //private IList<VehicleBrand> _brands;
        //public virtual IList<VehicleBrand> VehicleBrands
        //{
        //    get { return _brands ?? (_brands = new List<VehicleBrand>()); }
        //    set { _brands = value; }
        //}

        //private IList<VehicleModel> _models;
        //public virtual IList<VehicleModel> VehicleModels
        //{
        //    get { return _models ?? (_models = new List<VehicleModel>()); }
        //    set { _models = value; }
        //}

        //private IList<VehicleVersion> _versions;
        //public virtual IList<VehicleVersion> VehicleVersions
        //{
        //    get { return _versions ?? (_versions = new List<VehicleVersion>()); }
        //    set { _versions = value; }
        //}


        public virtual void LoadCatalogInfoWith(IList<SegmentCatalogInfo> segmentCatalogInfos, IList<VersionCatalogInfo> versionCatalogInfos)
        {
            SegmentCatalogInfo = segmentCatalogInfos.Count > 0 ? segmentCatalogInfos.First() : null;
            VersionCatalogInfo = versionCatalogInfos.Count() > 0 ? versionCatalogInfos.First() : null;
        }
        /*Auxiliar para listas de equipamiento y otras*/
        public virtual int ActualFeatureIndexCounter { get; set; }


        public virtual string LineFeatureValues(string catalogFeatureValue,string styleClassName)
        {
            var lineret = new StringBuilder();
            if(catalogFeatureValue!=null)
            {
                ActualFeatureIndexCounter++;

                if(ActualFeatureIndexCounter%2!=0)
                {
                    lineret.Append("class=" + "\""+ styleClassName+"\"");
                }
                else
                {
                    lineret.Append("class=" + "\"\"");
                }

            }
            else
            {
                lineret.Append("style=" + "\"display:none\"");
            }

            return lineret.ToString();

        }

        public virtual string HideFeatureCategory(string catalogFeatureCategory)
        {
            string stringOcultar = "style=" + "\"display:none\"";

            bool bTieneCategoria = false;

            if (VersionCatalogInfo == null)
                return stringOcultar;

            if(catalogFeatureCategory =="Motor")
            {
                if (VersionCatalogInfo.Alimentation != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Engine != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Fuel != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Position != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Cylinder != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Displacement != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Power != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Torque != null) bTieneCategoria = true;

            }
            if (catalogFeatureCategory == "Transmission")
            {
                if (VersionCatalogInfo.Gearbox != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Marches != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Traction != null) bTieneCategoria = true;
                if (VersionCatalogInfo.FrontBrakes != null) bTieneCategoria = true;
                if (VersionCatalogInfo.BackBrakes != null) bTieneCategoria = true;
                if (VersionCatalogInfo.FrontSuspension != null) bTieneCategoria = true;
                if (VersionCatalogInfo.BackSuspension != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Tires != null) bTieneCategoria = true;

            }
            if (catalogFeatureCategory == "Performance")
            {
                if (VersionCatalogInfo.MaximumSpeed != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Acceleration != null) bTieneCategoria = true;
                if (VersionCatalogInfo.ZeroKmH != null) bTieneCategoria = true;
                if (VersionCatalogInfo.ConsumptionCity != null) bTieneCategoria = true;
                if (VersionCatalogInfo.ConsumptionRoad != null) bTieneCategoria = true;
                if (VersionCatalogInfo.ConsumptionCombined != null) bTieneCategoria = true;

            }
            if (catalogFeatureCategory == "Dimensiones")
            {
                if (VersionCatalogInfo.Doors != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Squares != null) bTieneCategoria = true;
                if (VersionCatalogInfo.RowSeats != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Long != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Width != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Height != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Wheelbase != null) bTieneCategoria = true;
                if (VersionCatalogInfo.UnladenWeight != null) bTieneCategoria = true;
                if (VersionCatalogInfo.Trunk != null) bTieneCategoria = true;
                if (VersionCatalogInfo.FuelTank != null) bTieneCategoria = true;
            }

     

            return bTieneCategoria == true ? "": stringOcultar;

        }
        
        public virtual bool HasTechnicalFeatures()
        {
            return string.IsNullOrEmpty(HideFeatureCategory("Motor"))  || string.IsNullOrEmpty(HideFeatureCategory("Transmission")) || string.IsNullOrEmpty(HideFeatureCategory("Performance")) || string.IsNullOrEmpty(HideFeatureCategory("Dimensiones"));
        }
    }

    public class PublicationComparer : IEqualityComparer<Publication>
    {
        public bool Equals(Publication x, Publication y)
        {
            return x.VehicleModel == y.VehicleModel;
        }

        public int GetHashCode(Publication obj)
        {
            return obj.VehicleModel.GetHashCode();
        }
    }
}
