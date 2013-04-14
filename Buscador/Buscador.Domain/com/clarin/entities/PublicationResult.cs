using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.slices;
using Buscador.Domain.com.clarin.utils;
using Buscador.Services.com.clarin.services;

namespace Buscador.Domain.com.clarin.entities
{
    [DataContract]
    public class PublicationResult
    {
        [DataMember]
        public Dictionary<string, ItemData> PublishableItemData { get; set; }
        [DataMember]
        public Dictionary<string, ItemData> UserData { get; set; }
        [DataMember]
        public Dictionary<string, ItemData> PublicationData { get; set; }
        public IJsonSerializer JsonSerializer { get; set; }
       
        private PublicationResult(IJsonSerializer jsonSerializer)
        {
            JsonSerializer = jsonSerializer;
        }

        public PublicationResult()
        {
            
        }

        private Dictionary<string, ItemData> GetPublishableItemData(Publication publication)
        {
            GeoLocation location = new GeoLocation();

            var publishableItemData = new Dictionary<string, ItemData>
                                          {
                                              {"PUBLISHABLE_ITEM_DATA_ID", new ItemData(publication.PublishableItemId.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_TYPE_ID",new ItemData(publication.VehicleType.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_TYPE_DESCRIPTION", new ItemData(publication.VehicleType==1?"Used":"New",typeof(string).Name) },
                                              {"PUBLISHABLE_ITEM_DATA_PICTURES_QUANTITY",new ItemData(publication.VehiclePicQty.ToString(),typeof(int).Name) },
                                              {"PUBLISHABLE_ITEM_CONTACTS_QUANTITY",new ItemData(publication.PublicationContactsQty.ToString(),typeof(int).Name) },
                                              {"PUBLISHABLE_ITEM_DATA_VEHICLE_MAKE_ID", new ItemData(publication.VehicleMake.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_VEHICLE_MAKE_DESCRIPTION", new ItemData(publication.VehicleMakeText, typeof(string).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_VEHICLE_MODEL_ID",new ItemData(publication.VehicleModel.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_VEHICLE_MODEL_DESCRIPTION",new ItemData(publication.VehicleModelText, typeof(string).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_VEHICLE_VERSION_ID",new ItemData(publication.VehicleVersion.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_VEHICLE_VERSION_DESCRIPTION",new ItemData(publication.VehicleVersionText, typeof(string).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_VEHICLE_SEGMENT_ID",new ItemData(publication.VehicleSegment.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_VEHICLE_SEGMENT_DESCRIPTION",new ItemData(publication.VehicleSegmentText, typeof(string).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_GEOLOCATION",new ItemData((JsonSerializer.Serialize((location.GetLocation(publication, location)),  GetKnownTypes())), typeof(string).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_PRICE",new ItemData(publication.VehiclePrice.ToString(), typeof(decimal).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_PRICE_CURRENCY_SYMBOL",new ItemData(publication.CVehiclePriceCurrency.Symbol, typeof(decimal).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_PRICE_CURRENCY_ID",new ItemData(publication.VehiclePriceCurrency.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_YEAR",new ItemData(publication.VehicleYear.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_MILEAGE",new ItemData(publication.VehicleKm.ToString(),typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_FUEL_TYPE_ID",new ItemData(publication.VehicleFuelType.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_FUEL_TYPE_DESCRIPTION",new ItemData(publication.VehicleFuelTypeText, typeof(string).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_IS_FIRST_OWNER",new ItemData(publication.VehicleFirstOwner.ToString(),typeof(bool).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_COLOUR_ID",new ItemData(publication.VehicleColor.ToString(), typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_COLOUR_DESCRIPTION",new ItemData(publication.VehicleColorText, typeof(int).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_ACCEPTED_PAYMENT_METHOD_ID",new ItemData(publication.PaymentMethod.ToString(), typeof(string).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_ACCEPTED_PAYMENT_METHOD_DESCRIPTION",new ItemData(publication.PaymentMethodText, typeof(string).Name)},
                                              {"PUBLISHABLE_ITEM_DATA_COMMENTS",new ItemData(publication.SellerComment,typeof(string).Name) }

                                            };


            //EQUIPMENT
            for (int i = 0; i < publication.EquipmentAttributes.Count; i++)
            {
                if (publishableItemData.ContainsKey(publication.EquipmentAttributesKeys[i]))
                    continue;

                publishableItemData.Add(publication.EquipmentAttributesKeys[i],
                                        new ItemData(publication.EquipmentAttributes[i].ToString(), typeof(string).Name));
            }
           
            return publishableItemData;
        }

       private Dictionary<string, ItemData> GetUserData(Publication publication)
        {
            return new Dictionary<string, ItemData>
                       {
                           {"USER_DATA_USER_ID",new ItemData(publication.UserUid.ToString(),typeof(int).Name) },
                           {"USER_DATA_USER_TYPE_ID",new ItemData(publication.UserType,typeof(string).Name) },
                           {"USER_DATA_USER_TYPE_DESCRIPTION",new ItemData(publication.UserType=="1"?"AgencyUser":"EndUser",typeof(string).Name) },
                           {"USER_DATA_BRAND_NAME",new ItemData(publication.UserDescription, typeof(string).Name)},
                           {"USER_DATA_CONTACT_NAME",new ItemData(publication.UserDescription, typeof(string).Name)},
                           {"USER_DATA_CONTACT_LASTNAME",new ItemData(publication.UserDescription, typeof(string).Name)},
                           {"USER_DATA_CONTACT_EMAIL",new ItemData(publication.UserEmail, typeof(string).Name)},
                           {"USER_DATA_PRIMARY_PHONE",new ItemData(publication.UserPhone, typeof(string).Name)},
                           {"USER_DATA_SECONDARY_PHONE",new ItemData(publication.UserPhone, typeof(string).Name)},//no esta en el soler.
                           {"USER_DATA_ADDRESS",new ItemData(publication.UserAddress, typeof(string).Name)},
                           {"USER_DATA_HAS_MICROSITE",new ItemData((!string.IsNullOrEmpty(publication.UserMicrosite)).ToString(),typeof(bool).Name) },
                           {"USER_DATA_MICROSITE_URL",new ItemData(((!string.IsNullOrEmpty(publication.UserMicrosite)).ToString()).ToLower()=="false"?string.Empty:publication.UserMicrosite,typeof(string).Name) },
                           {"USER_DATA_HAS_LOGO",new ItemData((publication.LogoId)==0?"False":"True",typeof(bool).Name) },
                           {"USER_DATA_LOGO_URL",new ItemData((publication.LogoId)==0?string.Empty:"http://static1.deautos.com/images/directorio/" + publication.LogoId + "_logo.jpg",typeof(string).Name) },
                           {"USER_DATA_GEOLOC_COORD",new ItemData(((!string.IsNullOrEmpty(publication.UserMicrosite)).ToString()).ToLower()=="false"?string.Empty:publication.GmapCoord,typeof(string).Name) },
                       };
        }

        private Dictionary<string, ItemData> GetPublicationData(Publication publication, string trafficTag, string trafficTagName)
        {
            return new Dictionary<string, ItemData>
                       {
                           {"PUBLICATION_DATA_ID",new ItemData(publication.PublicationId.ToString(),typeof(int).Name) },
                           {"PUBLICATION_DATA_PUBLICATION_URL",new ItemData(publication.UrlDetails + (string.IsNullOrEmpty(trafficTag)?string.Empty:"#" + trafficTagName + "=" + trafficTag),typeof(string).Name) },
                           {"PUBLICATION_DATA_HIGHLIGHT",new ItemData(publication.PublicationHighLight,typeof(string).Name) },
                           {"PUBLICATION_DATA_SORT_WEIGHT",new ItemData(publication.IndexWeight.ToString(),typeof(string).Name) },
                           {"PUBLICATION_DATA_STATE",new ItemData(publication.PublicationDeleted?"Finalizada":"Active",typeof(string).Name) },
                           {"PUBLICATION_DATA_START_DATE",new ItemData(publication.PublicationStartDate.ToShortDateString(),typeof(DateTime).Name) },
                           {"PUBLICATION_DATA_END_DATE",new ItemData(publication.PublicationEndDate.ToShortDateString(),typeof(DateTime).Name) },
                           {"PUBLICATION_DATA_EXPIRATION_DATE",new ItemData(publication.PublicationEndDate.ToShortDateString(),typeof(DateTime).Name) },//expiration date
                           {"PUBLICATION_DATA_VISITS_QUANTITY",new ItemData(publication.PublicationVisitorsQty.ToString(),typeof(int).Name) },
                           {"PUBLICATION_DATA_SHOW_CONTACTS_COUNTER_IN_SEARCH_RESULTS",new ItemData(true.ToString(),typeof(bool).Name) },
                           {"PUBLICATION_DATA_SHOW_VISITS_COUNTER_IN_SEARCH_RESULTS",new ItemData(true.ToString(),typeof(bool).Name) },
                           {"PUBLICATION_DATA_SHOW_CLICK_TO_CALL_LOGO_IN_SEARCH_RESULTS",new ItemData(false.ToString(),typeof(bool).Name) },
                           {"PUBLICATION_DATA_TITLE",new ItemData(publication.PublicationSubtitle==null?String.Empty:publication.PublicationSubtitle,typeof(string).Name) },
                          //{"PUBLICATION_DATA_SUBTITLE",new ItemData(publication.PublicationSubtitle,typeof(string).Name) }

                          };
        }

        
        public PublicationResult BuildFrom(Publication publication, IJsonSerializer jsonSerializer, string trafficTag, string trafficTagName)
        {
            var publicationResult = new PublicationResult(jsonSerializer);

            publicationResult.PublishableItemData = publicationResult.GetPublishableItemData(publication);
            publicationResult.PublicationData = publicationResult.GetPublicationData(publication, trafficTag,trafficTagName);
            publicationResult.UserData = publicationResult.GetUserData(publication);

            return publicationResult;
        }

        private List<Type> GetKnownTypes()
        {
            return new List<Type>
                       {
                           typeof (AvaiableSlice),
                           typeof (DynamicRangeSlice),
                           typeof (Results<Publication>),
                           typeof (Slice),
                           typeof (PublicationSuperPremiumType),
                           typeof (PublicationPremium45HighlighDaysType),
                           typeof (PublicationSimpleType),
                           typeof (Order),
                           typeof (PublicationPremiumType)
                       };
        }
    }
}
