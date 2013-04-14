using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using System.Xml;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.slices;
using Buscador.Services.com.clarin.services;
using Buscador.Services.com.clarin.services.impl;
using Newtonsoft.Json.Linq;
using VersionCatalogInfo = Buscador.Domain.com.clarin.entities.VersionCatalogInfo;

namespace Buscador.Web.Controllers.Controllers
{
    [HandleError]
    public class AutosController : SearcherController
    {
        public IBannerService BannerService { get; set; }
        public int MaxSimilarResult { get; set; }
        public string BaseImageUrl { get; set; }
        public string ApiUrl { get; set; }
        public string IframeUrl { get; set; }
        public string ImageUrl { get; set; }
        public IRequestCreatorService RequestCreatorService { get; set; }
        public IIndexService<Agency> AgencyIndexService { get; set; }
        public IIndexService<Publication> IndexService { get; set; }
        public IIndexService<VersionCatalogInfo> VersionCatalogInfoIndexService { get; set; }
        public IIndexService<SegmentCatalogInfo> SegmentCatalogInfoIndexService { get; set; }
        public bool ConfigShowCatalogInfo { get; set; }

        Func<Publication, string> priceDescriptionOf = (p) => p.VehiclePrice != 0
                                                                   ? p.VehiclePrice.WithThousandsSeparator().AsPrice(p.CVehiclePriceCurrency)
                                                                   : "Consultar";

        public ActionResult Index()
        {
            //Sacar esto solo para pruebas
            //ViewData["bannerHeaderHtml"] = BannerService.GetHtmlBanner("resultadoheaderderecha");
            //ViewData["bannerBottomHtml"] = BannerService.GetHtmlBanner("resultadobottom");
            //ViewData["bannerDerecha1"] = BannerService.GetHtmlBanner("fichaderecha1");
            //ViewData["bannerDerecha2"] = BannerService.GetHtmlBanner("fichaderecha2");
            //ViewData["bannerDerecha3"] = BannerService.GetHtmlBanner("fichaderecha3");
            //ViewData["bannerDerecha4"] = BannerService.GetHtmlBanner("fichaderecha4");
            //ViewData["bannerDerecha5"] = BannerService.GetHtmlBanner("fichaderecha5");
            //ViewData["bannerIzquierda1"] = BannerService.GetHtmlBanner("fichaizquierda1");
            //ViewData["bannerIzquierda2"] = BannerService.GetHtmlBanner("fichaizquierda2");
            //ViewData["bannerIzquierda3"] = BannerService.GetHtmlBanner("fichaizquierda3");
            //fin sacar
         
            ViewData["breadcumbs"] = new List<Slice>();
            ViewData["Title"] = "DeAutos";
            ViewData["bannerHeaderHtml"] = "";
            ViewData["vehicleTypeText"] = "nuevos";
            ViewData["bannerMainHtml"] = "";
            ViewData["urlCertifica"] = "";


            //Publication publication = GetAgencyUserPublication();

            //Publication publication = GetEndUserPublication();

            return View();
            //return View("NewDetails", publication);
            
        }

        [CacheFilter(Duration = 3600)]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ShowDetails(int? year, int id)
        {
            var query = QueryOver<Publication>.Property(x => x.PublicationId).WithValue(id.ToString())
                                              .AndProperty(x=>x.Visible).WithValue("true")
                                              .Build();

            var results = IndexService.Query(query);

            if (results.Count() == 0)
            {
                SetBanners();
                var sStringSeo = Request.Url.ToString().Split('/')[3].Replace('-', ' ');
                ViewData["URLSeo"] = sStringSeo;
                return View("PublicationNotAvailable");
            }

            var publication = results.First();

            if(publication.ShowCatalogInfo && ConfigShowCatalogInfo)
            {
                var querySegmentCatalog = QueryOver<SegmentCatalogInfo>.Property(s => s.SegmentId).WithValue(publication.VehicleSegment.ToString())
                                                                       .AndProperty(s => s.ModelId).WithValue(publication.VehicleModel.ToString())
                                                                       .Build();
                                                                       
                var queryVersionCatalog = QueryOver<VersionCatalogInfo>.Property(v => v.Version_id)
                                                                       .WithValue(publication.VehicleVersion.ToString())
                                                                       .Build();
                                        
                publication.LoadCatalogInfoWith(SegmentCatalogInfoIndexService.Query(querySegmentCatalog), VersionCatalogInfoIndexService.Query(queryVersionCatalog));
            }
            // var versionCatalogQuery = QueryOver<VersionCatalogInfo>.Property(x => x.VersionID).WithValue(publication.VehicleVersion.ToString())
            // var catalogInfo = versionCatalogIndexService.Query(versionCatalogQuery);

            

            var querySimilarByModel = QueryOver<Publication>.Property(x => x.VehicleModel).WithValue(publication.VehicleModel.ToString())
                                                            .AndProperty(x => x.VehicleVersion).WithValue(publication.VehicleVersion.ToString())
                                                            .AndProperty(x=>x.State).WithValue("Active")
                                                            .AndProperty(x => x.Visible).WithValue("true")
                                                            .Build();

            var similarByModel = IndexService.Query(querySimilarByModel, MaxSimilarResult);

            var querySimilars = QueryOver<Publication>.Property(x => x.VehicleYear).WithValue(publication.VehicleYear.ToString())
                                                      .AndProperty(x => x.VehiclePriceAbsolute).WithValue("[" + (publication.VehiclePriceAbsolute - (publication.VehiclePriceAbsolute * 10 / 100)).ToString().Replace(",", ".") + " TO " +
                                                                             (publication.VehiclePriceAbsolute + (publication.VehiclePriceAbsolute * 10 / 100)).ToString().Replace(",", ".") + "]")
                                                      .AndProperty(x => x.VehicleSegment).WithValue(publication.VehicleSegment.ToString())
                                                      .AndProperty(x => x.State).WithValue("Active") //agregado 02/08/2011
                                                      .AndProperty(x => x.Visible).WithValue("true")
                                                      .Build();

            ViewData["BaseImagesUrl"] = BaseImageUrl;

            var similars = IndexService.Query(querySimilars, MaxSimilarResult);

            ViewData["ComparableByModel"] = similars;

            ViewData["SimilarByModel"] = similarByModel;

            ViewData["PublicationId"] = publication.PublicationId;

            var selectedFilters = IndexService.SelectedFiltersFor(publication);

            var newOrUsed = publication.VehicleType == 1 ? "usados" : "nuevos";

            SetBanners(selectedFilters,newOrUsed);

            ViewData["MetaDescription"] = MetaDescription(publication, selectedFilters);
            ViewData["Title"] = Title(publication).Trim();
            ViewData["urlCertifica"] = string.Format("{0}", publication.VehicleMakeText);
            ViewData["IframeUrl"] = IframeUrl;

            ViewData["ImagesUrl"] = ImageUrl;
            publication.ConfigShowCatalogInfo = ConfigShowCatalogInfo;

            var firstImageUrl = RequestCreatorService.CreateRequest(ImageUrl + "/PublishableItemImage/390x300/" + publication.PublishableItemId + "_1.jpg");
            publication.FirstImageExists = firstImageUrl != null && firstImageUrl.GetResponseHeader("original-response-code").Equals("200");

            //*url example: http://www.deautos.com/autos-usados-fiat-idea/VTYY1WWMAYY370WWMOYY2774WWVEYY47859WWYEYY2000-2010 */

            var selectedFilters2 = new List<SelectedFilter>
                                      {
                                          new SelectedFilter("vehicle_make_id",publication.VehicleMake.ToString(), true, 1),
                                          new SelectedFilter("vehicle_model_id",publication.VehicleModel.ToString(), true, 1)
                                      };

            
            ViewData["SimilarByModelSearchUrl"] = "http://www.deautos.com/autos-" +
                                                    ((publication.VehicleType == 1 ? "usados" : "nuevos")) 
                                                    + "-"
                                                    + publication.VehicleMakeText.ToLower() 
                                                    + "-"
                                                    + publication.VehicleModelText.ToLower().Replace(' ', '-') 
                                                    + "/" 
                                                    + "VTYY"
                                                    + publication.VehicleType 
                                                    + "WWMAYY"
                                                    + publication.VehicleMake 
                                                    + "WWMOYY"
                                                    + publication.VehicleModel 
                                                    + "WWVEYY"
                                                    + publication.VehicleVersion;


            //*url example http://www.deautos.com/autos-usados/VTYY1WWYEYY2008-2008WWPRYY20000-80000 */
            ViewData["SimilarSearchUrl"] = "http://www.deautos.com/autos-" + (publication.VehicleType == 1 ? "usados" : "nuevos") + "/" + "VTYY" + publication.VehicleType + "WWYEYY" + publication.VehicleYear + "-" + publication.VehicleYear + "WWPRYY" + (publication.VehiclePriceAbsolute - (publication.VehiclePriceAbsolute * 10 / 100)) + "-" + (publication.VehiclePriceAbsolute + (publication.VehiclePriceAbsolute * 10 / 100));
            var responseRequest = RequestCreatorService.CreateRequest(ImageUrl+ "/CatalogImage/640x480/" + publication.VehicleMake + "_" + publication.VehicleModel + "_" + publication.VehicleSegment + "_measure.jpg");
            if (responseRequest != null)
            {
                if (responseRequest.Headers["original-response-code"] == "200")
                    publication.SegmentCatalogInfo.TechnicalMeasureImage = ImageUrl + "/CatalogImage/640x480/" + publication.VehicleMake + "_" + publication.VehicleModel +
                                                        "_" +
                                                        publication.VehicleSegment + "_measure.jpg";
            }
            Session["Publication"] = publication;
            return View("NewDetails", publication);
        }

        private void SetBanners()
        {
            SetBanners(null,string.Empty);
        }

        private void SetBanners(List<SelectedFilter> selectedFilters, string newOrUsed)
        {
            if(selectedFilters==null && string.IsNullOrEmpty(newOrUsed))
            {
                ViewData["bannerHeaderHtml"] = BannerService.GetHtmlBanner("resultadoheaderderecha");
                ViewData["bannerBottomHtml"] = BannerService.GetHtmlBanner("resultadobottom");
                ViewData["bannerDerecha1"] = BannerService.GetHtmlBanner("fichaderecha1");
                ViewData["bannerDerecha2"] = BannerService.GetHtmlBanner("fichaderecha2");
                ViewData["bannerDerecha3"] = BannerService.GetHtmlBanner("fichaderecha3");
                ViewData["bannerIzquierda1"] = BannerService.GetHtmlBanner("fichaizquierda1");
                ViewData["bannerIzquierda2"] = BannerService.GetHtmlBanner("fichaizquierda2");
                ViewData["bannerIzquierda3"] = BannerService.GetHtmlBanner("fichaizquierda3");
            }
            else
            {
                ViewData["bannerHeaderHtml"] = BannerService.GetHtmlBanner(selectedFilters, "resultadoheaderderecha", newOrUsed);
                ViewData["bannerBottomHtml"] = BannerService.GetHtmlBanner(selectedFilters, "resultadobottom", newOrUsed);
                ViewData["bannerDerecha1"] = BannerService.GetHtmlBanner(selectedFilters, "fichaderecha1", newOrUsed);
                ViewData["bannerDerecha2"] = BannerService.GetHtmlBanner(selectedFilters, "fichaderecha2", newOrUsed);
                ViewData["bannerDerecha3"] = BannerService.GetHtmlBanner(selectedFilters, "fichaderecha3", newOrUsed);
                ViewData["bannerIzquierda1"] = BannerService.GetHtmlBanner(selectedFilters, "fichaizquierda1", newOrUsed);
                ViewData["bannerIzquierda2"] = BannerService.GetHtmlBanner(selectedFilters, "fichaizquierda2", newOrUsed);
                ViewData["bannerIzquierda3"] = BannerService.GetHtmlBanner(selectedFilters, "fichaizquierda3", newOrUsed);
            }
        }

        private string Title(Publication publication)
        {
            return string.Format("{0} {1} {2} {3} {4}{5}",
                                 publication.VehicleMakeText.Trim(),
                                 publication.VehicleModelText.Trim(),
                                 publication.VehicleVersionText.Trim(),
                                 publication.VehicleTypeText,
                                 publication.VehicleYear != 0 ? publication.VehicleYear + " " : string.Empty,
                                 publication.PublicationId);
        }

        private string MetaDescription(Publication publication, List<SelectedFilter> selectedFilters)
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} en {10}", publication.VehicleMakeText, 
                                                                   publication.VehicleModelText, 
                                                                   publication.VehicleVersionText,
                                                                   GetVehicleTypeDescription(selectedFilters), 
                                                                   publication.VehicleYear == 0 ? DateTime.Now.Year : publication.VehicleYear,
                                                                   priceDescriptionOf(publication),
                                                                   publication.VehicleKm.WithThousandsSeparator() + " km",
                                                                   publication.VehicleSegmentText,  
                                                                   publication.VehicleFuelTypeText,
                                                                   publication.PublicationId,
                                                                   publication.VehicleLocLocText);
        }

        public string GetVehicleTypeDescription(List<SelectedFilter> selectedFilters)
        {
            var vehicleTypeText = string.Empty;
            if ((selectedFilters != null) && selectedFilters.Exists(x => x.Name == "vehicle_type_id"))
                vehicleTypeText = selectedFilters.Where(x => x.Name == "vehicle_type_id").First().Value == "1" ? "usados" : selectedFilters.Where(x => x.Name == "vehicle_type_id").First().Value == "2" ? "nuevos" : string.Empty;
            return vehicleTypeText;
        }

        [CacheFilter(Duration = 3600)]
        [AcceptVerbs("Post", "Get")]
        public ActionResult Search(SearchParameters<Publication> searchParameters)
        {
            if (searchParameters == null)
            {
                throw new NotImplementedException("no entra aca");
            }

            var result = IndexService.Query(searchParameters);

            ViewData["result"] = result;
            ViewData["urlCertifica"] = "/buscador/" + (result.VisibleAppliedFilters.Where(appliedFilter => appliedFilter.Name == "vehicle_make_id")
                                                                                  .Count()>0?result.VisibleAppliedFilters.Where(appliedFilter => appliedFilter.Name == "vehicle_make_id").Select(certificaFilter => certificaFilter.Value).First()
                                                                                  :string.Empty);
            
            ViewData["breadcumbs"] = result.Breadcrumbs != null ? result.Breadcrumbs.OrderBy(x => x.Priority).ToList() : new List<Slice>();

            ViewData["TotalResult"] = result.TotalResults;

            ViewData["Title"] = (result.VisibleAppliedFilters.Exists(appliedFilter => appliedFilter.Name == "vehicle_type_id") ? result.VisibleAppliedFilters.Where(appliedFilter => appliedFilter.Name == "vehicle_type_id").First().Value.Localize() : string.Empty)
                                + " " +
                                string.Join(" ", result.VisibleAppliedFilters.Where(appliedFilter => appliedFilter.Name == "vehicle_make_id" || appliedFilter.Name == "vehicle_model_id").Select(titlePart => titlePart.Value).ToArray())
                                + " " +
                                (result.VisibleAppliedFilters.Exists(filter => filter.Name == "vehicle_loc_loc_id") ? " en " + result.VisibleAppliedFilters.Where(filter => filter.Name == "vehicle_loc_loc_id").First().Value : result.VisibleAppliedFilters.Exists(filter => filter.Name == "vehicle_loc_prov_id") ?
                                                           " en " + result.VisibleAppliedFilters.Where(filter => filter.Name == "vehicle_loc_prov_id").First().Value : string.Empty);

            var vehicleTypeText = searchParameters.GetVehicleTypeDescription();

            ViewData["bannerMainHtml"] = BannerService.GetHtmlBanner(searchParameters.SelectedFilters, "resultadomain", vehicleTypeText);
            ViewData["bannerHeaderHtml"] = BannerService.GetHtmlBanner(searchParameters.SelectedFilters, "resultadoheaderderecha", vehicleTypeText);
            ViewData["bannerRightHtml"] = BannerService.GetHtmlBanner(searchParameters.SelectedFilters, "resultadoderecha", vehicleTypeText);
            ViewData["bannerBottomHtml"] = BannerService.GetHtmlBanner(searchParameters.SelectedFilters, "resultadobottom", vehicleTypeText);
            ViewData["vehicleTypeText"] = vehicleTypeText;
            ViewData["ImagesUrl"] = ImageUrl;
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SaveSearch(SaveSearchParameters saveSearchParameters)
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Print()
        {
            ViewData["ImagesUrl"] = ImageUrl;
            return View("PublicationPrint", (Publication)Session["Publication"]);
        }

        public JsonResult GetVehiclesBrands()
        {
            String data = RequestCreatorService.CreateRequest(ApiUrl + "GetVehiclesBrands", "apitest", "123456");

            JsonResult jsonResult = new JsonResult() { Data = TransformStringToJsonResultData(data, "GetVehiclesBrandsResult") };
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        public JsonResult GetVehiclesModels(string id)
        {
            String data = RequestCreatorService.CreateRequest(ApiUrl + "GetVehiclesModels/" + id, "apitest", "123456");

            JsonResult jsonResult = new JsonResult() { Data = TransformStringToJsonResultData(data, "GetVehiclesModelsResult") };
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        public JsonResult GetVehiclesVersions(string id)
        {
            String data = RequestCreatorService.CreateRequest(ApiUrl + "GetVehiclesVersions/" + id, "apitest", "123456");

            JsonResult jsonResult = new JsonResult() { Data = TransformStringToJsonResultData(data, "GetVehiclesVersionsResult") };
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        private static string TransformStringToJsonResultData(string data, string resultsName)
        {
            // DE ESTO:        '{ "Result": "[{\"Name\":\"Volkswagen\",\"ResultsFound\":\"2942\",\"Url\":\"\/autos-volkswagen\/MAYY395\",\"SliceKey\":\"MA\",\"SliceValue\":\"395\",\"_type\":\"HierarchicalFacet\",\"Value\":null},{\"Name\":\"Renault\",\"ResultsFound\":\"2063\",\"Url\":\"\/autos-renault\/MAYY388\",\"SliceKey\":\"MA\",\"SliceValue\":\"388\",\"_type\":\"HierarchicalFacet\",\"Value\":null},{\"Name\":\"Ford\",\"ResultsFound\":\"1900\",\"Url\":\"\/autos-ford\/MAYY371\",\"SliceKey\":\"MA\",\"SliceValue\":\"371\",\"_type\":\"HierarchicalFacet\",\"Value\":null}" }')
            //PASARLO A ESTO:  '{ "Result": [{"Name":"Volkswagen","ResultsFound":"2942","Url":"/autos-volkswagen/MAYY395","SliceKey":"MA","SliceValue":"395","_type":"HierarchicalFacet","Value":null},{"Name":"Volkswagen","ResultsFound":"2942","Url":"/autos-volkswagen/MAYY395","SliceKey":"MA","SliceValue":"395","_type":"HierarchicalFacet","Value":null}]}'
            data = data.Replace("\\", "");
            data = data.Replace("\"[", "[");
            data = data.Replace("]\"", "]");
            data = data.Replace(resultsName, "Results");
            return data;
        }

        private Publication GetAgencyUserPublication()
        {
            Publication publication = new Publication();
            publication.PublicationId = 954345;
            publication.VehicleType = 2; //1:usado , 2:nuevo
            publication.VehicleMake = 395;
            publication.VehicleModel = 2988;
            publication.VehicleVersion = 49791;
            publication.VehicleMakeText = "Volkswagen";
            publication.VehicleModelText = "Gol Trend";
            publication.VehicleVersionText = "1.6 Pack 3 i Motion";
            publication.VehicleFuelTypeText = "Nafta";
            publication.PaymentMethodText = "Financiado";
            publication.VehicleSegmentText = "HatchBack 5P";
            publication.FundingAdvance = 1200;
            publication.VehiclePrice = 20200;
            publication.CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "u$s" };
            publication.FromQuote = 450;
            publication.VehicleLocProvText = "Buenos Aires";
            publication.VehicleLocPartText = "Vicente Lopez";
            publication.VehicleLocLocText = "La Lucila";
            publication.VehicleColorText = "Azul";
            //publication.FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" };
            publication.ConfortRanking = 2;
            publication.DesignRanking = 2;
            publication.PriceRanking = 0;
            publication.SecurityRanking = 5;
            publication.VehiclePicQty = 5;
            publication.ExpertReview = "La versión Trend del Gol llegó en 2008 para ampliar la familia de este auto record de la industria en Sudamérica, con más de veinte años de permanencia en los mercados, líder en ventas en 9 de los últimos 12 años y con casi 450.000 unidades patentadas en Argentina.Este nuevo Gol, marcadamente actualizado en su diseño, lleva la denominación Trend para diferenciarlo del Power, la generación anterior que se sigue comercializando.Está equipado con una única motorización, un naftero 1.6 de 101 CV que le otorga interesantes prestaciones. Junto a la pick up Amarok, fue el lanzamiento más importante para la marca en los últimos años.";
            publication.Positives = new List<string>() { "Diseño", "Espacio interior", "Calidad de las terminaciones" };
            publication.Negatives = new List<string>() { "Sin versión diesel ni ABS" };
            publication.ExpertReviewDate = DateTime.Now;
            publication.PublicationDate = DateTime.Now;
            publication.Specs = new List<EquipmentAttr>()
                                    {
                                        new EquipmentAttr() {AttrValue = "Alarma antirrobo", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores eléctricos con memorias", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Apertura de baul desde el interior", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores rebatibles eléctricamente Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento conductor con ajuste lumbar Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en aluminio", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asientos traseros reclinables Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en madera Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Dirección asistida adaptable a la velocidad Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Sistema de aviso de cambio de carril Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla delanteros y traseros", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Sistema de frenado automático mediante detección de obstáculo Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Faros de Xenon Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Sistema de iluminación inteligente Opcional", AttrType = "Confort"},

                                        new EquipmentAttr() {AttrValue = "Alarma antirrobo", AttrType = "Exterior"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores eléctricos con memorias", AttrType = "Exterior"},
                                        new EquipmentAttr() {AttrValue = "Sistema de iluminación inteligente Opcional", AttrType = "Exterior"},

                                        new EquipmentAttr() {AttrValue = "Alarma antirrobo", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores eléctricos con memorias", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Apertura de baul desde el interior", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores rebatibles eléctricamente Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Asiento conductor con ajuste lumbar Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en aluminio", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Asientos traseros reclinables Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en madera Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Dirección asistida adaptable a la velocidad Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de aviso de cambio de carril Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla delanteros y traseros", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de frenado automático mediante detección de obstáculo Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros de Xenon Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de iluminación inteligente Opcional", AttrType = "Seguridad"}
                                    };

            publication.SellerComment = "Destacado por su gran habitabilidad y versatilidad en su interior ha tenido buena aceptación en el público por su moderno diseño, bajo consumo de combustible y garantía extendida. Su motores son dos: 1,4L y 1,5L iVtec.";

            publication.EquipmentAttributes = new List<EquipmentAttr>() 
                                    {
                                        new EquipmentAttr() {AttrValue = "Aire acondicionado", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Apertura remota de baul", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Apoyabrazos central delantero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Apoyabrazos central trasero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento acompañante regulable en altura manual", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en aluminio", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asientos traseros reclinables Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento conductor regulable en altura manual", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento acompañante regulable en altura electronico", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento conductor regulable en altura electronico", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento trasero rebatible", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Butaca de conductor eléctrica", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Tapizado de cuero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Butaca delantera termica", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Butaca regulable con memoria", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Cargador de CD", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "central de informacion /computadora de abordo", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Cierre centralizado", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Climatizador automatico", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Comando satelital stereo", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Control de velocidad crucero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "direccion Asistida", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "doble traccion", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores regulables desde el interior manual", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores regulables desde el interior electrico", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Faros regulables desde el interior", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Levantavidrios eléctricos delanteros", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Levantavidrios eléctricos traseros", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Radio AM/FM", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Radio AM/FM c/pasacassette", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Stereo con CD", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Stereo con CD - MP3", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Stereo con DVD", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Stereo con mp3", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Volante de cuero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Volante regulable", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Sensor de lluvia", AttrType = "Confort"},

                                        new EquipmentAttr() {AttrValue = "Airbag acompañante desactivable", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Ganchos ISOFIX para ajustar silla de niños", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Airbags (6) delanteros, laterales delanteros y de cortina", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Indicador de presión de neumáticos Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Asistente sonoro para el estacionamiento Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Luces adaptativas en curvas Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Control de estabilidad (ESP)", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Luces de posición tipo LED Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Dirección asistida adaptable a la velocidad Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de aviso de cambio de carril Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla delanteros y traseros", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de frenado automático mediante detección de obstáculo Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros de Xenon Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de iluminación inteligente Opcional", AttrType = "Seguridad"},

                                        new EquipmentAttr() {AttrValue = "Barra porta equipaje", AttrType = "Exterior"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores electricos", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla delanteros", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla traseros", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros de xenon", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Limpia/ lava luneta", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Llantas de aleación", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Paragolpes color carroceria", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Techo descapotable", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Techo solar", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Vidrios tonalizados", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Limpia lava/faros", AttrType = "Seguridad"}

                                    };

            //publication.UserDescription = "Pestelli Suc. San Martin";
            //publication.UserDescription = "(Claudio Civello) CITROEN BANZANO www.citroenbanzano.com.ar";
            publication.UserDescription = "Francisco Osvaldo Diaz s.a.";
            publication.UserPhone = "(011) 154-305-4965 // (011) 154-905-4465";
            publication.UserEmail = "info@pestelli.com.ar";
            publication.UserUid = 388109;
            publication.LogoId = 388109;
            publication.UserType = "AgencyUser";
            publication.PublicationEndDate = DateTime.Today.AddDays(-1);
            publication.SegmentCatalogInfo.TechnicalMeasureImage = "\\Content\\images\\img_ficha_imprimir_croquis_chico.gif";
            publication.CatalogDescription = "La versión Trend del Gol llegó en 2008 para ampliar la familia de este auto record de la industria en Sudamérica, con más de veinte años de permanencia en los mercados, líder en ventas en 9 de los últimos 12 años y con casi 450.000 unidades patentadas en Argentina.Este nuevo Gol, marcadamente actualizado en su diseño, leva la denominación Trend para diferenciarlo del Power. Está equipado con una única motorización, un naftero 1.6 de 101 CV que le otorga interesantes prestaciones. Junto a la pick up Amarok, fue el lanzamiento más importante para la marca en los últimos años.";
            publication.UserMicrosite = "Pestelli";
            publication.UserViewContactData = true;
            publication.State = PublicationOrderState.Active.ToString();
            publication.LinkToVideo = "~/Content/images/img_fichas_solapa_video_video.jpg";
            publication.Colours = new List<string>{ "Rojo", "Gris Plata","Almendra", "Amarillo","Anis","Arena","Azul","Beige","Berenjena","Bicolor","Blanco","Bordo","Bronce","Celeste","Champagne","Cobre","Crema","Dorado","Gris","Gris Intermedio","Gris Oscuro","Gris Plata","Gris Verdoso","Marron","Mostaza","Naranja","Negro","Ocre","Perlado","Rojo","Rosado","Turquesa","Verde","Violeta"};
            publication.SegmentCatalogInfo.TechnicalMeasureImage = "~/img/newpag/img_fichas_reemplazable_croquis.jpg";

            publication.Alimentation = "Inyección directa turbo";
            publication.Motor = "1,8L";
            publication.Combustible = "Nafta";
            publication.Position = "Dealntera";
            publication.Cylinder = "4";
            publication.Displacement = "98 cc";
            publication.Power = "160 cv";
            publication.Torque = "250/1500-4500 nm/rpm";
            publication.Transmisions = "Manual";
            publication.Marches = "6";
            publication.FrontBrakes = "Discos Ventilados";
            publication.BackBrakes = "Discos";
            publication.FrontSuspension = "Independiente de 5 brazos";
            publication.BackSuspension = "Independiente de 5 brazos neumaticos";
            publication.Tires = "225/55 R16";
            publication.MaximumSpeed = "225 km/h";
            publication.Acceleration = "8.6 seg";
            publication.ConsumptionCombined = "7.1 lts/100 kms";
            publication.Doors = "4";
            publication.Squares = "5";
            publication.RowsSeats = "2";
            //new TechnicalAttr{AttrKey = "Largo / Ancho / Alto / Distancia entre ejes", AttrValue = "ejes", AttrType = "Dimension"},
            publication.UnladenWeight = "1410 kg";
            publication.FuelTank = "65 lts";


            IList<string> lista = new List<string>();
            for (var i = 0; i < 37; i++)
                lista.Add("Confort");
            for (var i = 0; i < 25; i++)
                lista.Add("Seguridad");
            lista.Add("Exterior");
            publication.EquipmentTypes = lista;
            
            IList<Publication> similarByModel = new List<Publication>()
                                                    {
                                                        new Publication()
                                                            {
                                                                VehicleType = 2,
                                                                VehicleMakeText = "Volkswagen",
                                                                VehicleModelText = "Gol Trend",
                                                                VehicleVersionText =  "1.6 Pack 3 i Motion",
                                                                VehicleFuelTypeText = "Nafta",
                                                                VehicleYear = 2006,
                                                                PaymentMethodText = "Financiado",
                                                                VehicleSegmentText = "HatchBack 5P",
                                                                FundingAdvance = 1200,
                                                                VehicleKm = 80000,
                                                                VehiclePrice = 20200,
                                                                CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "U$S" },
                                                                FromQuote = 450,
                                                                VehicleLocProvText = "Buenos Aires",
                                                                VehicleLocPartText = "Vicente Lopez",
                                                                VehicleLocLocText = "La Lucila",
                                                                VehicleColorText = "Azul",
                                                                //FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" }
                                                            },
                                                        new Publication()
                                                            {
                                                                VehicleType = 2,
                                                                VehicleMakeText = "Volkswagen",
                                                                VehicleModelText = "Gol Trend",
                                                                VehicleVersionText =  "1.6 Pack 3 i Motion",
                                                                VehicleFuelTypeText = "Nafta",
                                                                PaymentMethodText = "Financiado",
                                                                VehicleSegmentText = "HatchBack 5P",
                                                                FundingAdvance = 1200,
                                                                VehicleYear = 2006,
                                                                VehicleKm = 80000,
                                                                VehiclePrice = 20200,
                                                                CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "U$S" },
                                                                FromQuote = 450,
                                                                VehicleLocProvText = "Buenos Aires",
                                                                VehicleLocPartText = "Vicente Lopez",
                                                                VehicleLocLocText = "La Lucila",
                                                                VehicleColorText = "Azul",
                                                                //FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" }
                                                            }
                                                    };

            ViewData["SimilarByModel"] = similarByModel;

            IList<Publication> comparableByModel = new List<Publication>()
                                                    {
                                                        new Publication()
                                                            {
                                                                VehicleType = 2,
                                                                VehicleMakeText = "Volkswagen",
                                                                VehicleModelText = "Gol Trend",
                                                                VehicleVersionText =  "1.6 Pack 3 i Motion",
                                                                VehicleFuelTypeText = "Nafta",
                                                                VehicleYear = 2006,
                                                                PaymentMethodText = "Financiado",
                                                                VehicleSegmentText = "HatchBack 5P",
                                                                FundingAdvance = 1200,
                                                                VehicleKm = 80000,
                                                                VehiclePrice = 20200,
                                                                CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "U$S" },
                                                                FromQuote = 450,
                                                                VehicleLocProvText = "Buenos Aires",
                                                                VehicleLocPartText = "Vicente Lopez",
                                                                VehicleLocLocText = "La Lucila",
                                                                VehicleColorText = "Azul",
                                                                //FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" }
                                                            },
                                                        new Publication()
                                                            {
                                                                VehicleType = 2,
                                                                VehicleMakeText = "Volkswagen",
                                                                VehicleModelText = "Gol Trend",
                                                                VehicleVersionText =  "1.6 Pack 3 i Motion",
                                                                VehicleFuelTypeText = "Nafta",
                                                                PaymentMethodText = "Financiado",
                                                                VehicleSegmentText = "HatchBack 5P",
                                                                FundingAdvance = 1200,
                                                                VehicleYear = 2006,
                                                                VehicleKm = 80000,
                                                                VehiclePrice = 20200,
                                                                CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "U$S" },
                                                                FromQuote = 450,
                                                                VehicleLocProvText = "Buenos Aires",
                                                                VehicleLocPartText = "Vicente Lopez",
                                                                VehicleLocLocText = "La Lucila",
                                                                VehicleColorText = "Azul",
                                                                //FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" }
                                                                
                                                            }
                                                    };

            publication.ShowCatalogInfo = true;

            ViewData["ComparableByModel"] = comparableByModel;
            Session["Publication"] = publication;

            /*var query = QueryOver<Agency>.Property(x => x.Id).WithValue(agencyName).Build();
            var agency = AgencyIndexService.Query(query).First();
            return new JsonResult() { Data = agency.LocationCoordinates };*/

            ViewData["AgencyLocationCoordinates"] = "-34.610538,-58.427463";



            return publication;
        }

        private Publication GetEndUserPublication()
        {
            Publication publication = new Publication();
            publication.PublicationId = 265;
            publication.VehicleYear = 2007;
            publication.VehicleType = 1; //1:usado , 2:nuevo
            publication.VehicleMake = 395;
            publication.VehicleMakeText = "Volkswagen";
            publication.VehicleModel = 2988;
            publication.VehicleModelText = "Gol Trend";
            publication.VehicleVersion = 49791;
            publication.VehicleVersionText = "1.6 Pack 3 i Motion";
            publication.VehicleFuelTypeText = "Nafta";
            publication.PaymentMethodText = "Financiado";
            publication.VehicleSegmentText = "HatchBack 5P";
            publication.FundingAdvance = 1200;
            publication.VehiclePrice = 50200;
            publication.VehiclePriceAbsolute = 50200;
            publication.VehicleKm = 55000;
            publication.CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "u$s" };
            publication.FromQuote = 450;
            publication.VehicleLocProvText = "Buenos Aires";
            publication.VehicleLocPartText = "Vicente Lopez";
            publication.VehicleLocLocText = "La Lucila";
            publication.VehicleColorText = "Azul";
            
            //publication.FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" };
            publication.ConfortRanking = 2;
            publication.DesignRanking = 2;
            publication.PriceRanking = 0;
            publication.SecurityRanking = 5;
            publication.VehiclePicQty = 5;
            publication.ExpertReview = "La versión Trend del Gol llegó en 2008 para ampliar la familia de este auto record de la industria en Sudamérica, con más de veinte años de permanencia en los mercados, líder en ventas en 9 de los últimos 12 años y con casi 450.000 unidades patentadas en Argentina.Este nuevo Gol, marcadamente actualizado en su diseño, lleva la denominación Trend para diferenciarlo del Power, la generación anterior que se sigue comercializando.Está equipado con una única motorización, un naftero 1.6 de 101 CV que le otorga interesantes prestaciones. Junto a la pick up Amarok, fue el lanzamiento más importante para la marca en los últimos años.";
            publication.Positives = new List<string>() { "Diseño", "Espacio interior", "Calidad de las terminaciones" };
            publication.Negatives = new List<string>() { "Sin versión diesel ni ABS" };
            publication.ExpertReviewDate = DateTime.Now;
            publication.PublicationDate = DateTime.Now.AddMonths(-1);
            publication.Specs = new List<EquipmentAttr>()
                                    {
                                        new EquipmentAttr() {AttrValue = "Alarma antirrobo", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores eléctricos con memorias", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Apertura de baul desde el interior", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores rebatibles eléctricamente Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento conductor con ajuste lumbar Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en aluminio", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asientos traseros reclinables Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en madera Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Dirección asistida adaptable a la velocidad Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Sistema de aviso de cambio de carril Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla delanteros y traseros", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Sistema de frenado automático mediante detección de obstáculo Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Faros de Xenon Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Sistema de iluminación inteligente Opcional", AttrType = "Confort"},

                                        new EquipmentAttr() {AttrValue = "Alarma antirrobo", AttrType = "Exterior"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores eléctricos con memorias", AttrType = "Exterior"},
                                        new EquipmentAttr() {AttrValue = "Sistema de iluminación inteligente Opcional", AttrType = "Exterior"},

                                        new EquipmentAttr() {AttrValue = "Alarma antirrobo", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores eléctricos con memorias", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Apertura de baul desde el interior", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores rebatibles eléctricamente Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Asiento conductor con ajuste lumbar Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en aluminio", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Asientos traseros reclinables Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en madera Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Dirección asistida adaptable a la velocidad Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de aviso de cambio de carril Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla delanteros y traseros", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de frenado automático mediante detección de obstáculo Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros de Xenon Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de iluminación inteligente Opcional", AttrType = "Seguridad"}
                                    };

            publication.SellerComment = "Destacado por su gran habitabilidad y versatilidad en su interior ha tenido buena aceptación en el público por su moderno diseño, bajo consumo de combustible y garantía extendida. Su motores son dos: 1,4L y 1,5L iVtec.";

            publication.EquipmentAttributes = new List<EquipmentAttr>() 
                                    {
                                        new EquipmentAttr() {AttrValue = "Aire acondicionado", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Apertura remota de baul", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Apoyabrazos central delantero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Apoyabrazos central trasero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento acompañante regulable en altura manual", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Inserciones en aluminio", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asientos traseros reclinables Opcional", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento conductor regulable en altura manual", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento acompañante regulable en altura electronico", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento conductor regulable en altura electronico", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Asiento trasero rebatible", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Butaca de conductor eléctrica", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Tapizado de cuero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Butaca delantera termica", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Butaca regulable con memoria", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Cargador de CD", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "central de informacion /computadora de abordo", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Cierre centralizado", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Climatizador automatico", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Comando satelital stereo", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Control de velocidad crucero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "direccion Asistida", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "doble traccion", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores regulables desde el interior manual", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores regulables desde el interior electrico", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Faros regulables desde el interior", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Levantavidrios eléctricos delanteros", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Levantavidrios eléctricos traseros", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Radio AM/FM", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Radio AM/FM c/pasacassette", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Stereo con CD", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Stereo con CD - MP3", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Stereo con DVD", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Stereo con mp3", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Volante de cuero", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Volante regulable", AttrType = "Confort"},
                                        new EquipmentAttr() {AttrValue = "Sensor de lluvia", AttrType = "Confort"},

                                        new EquipmentAttr() {AttrValue = "Airbag acompañante desactivable", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Ganchos ISOFIX para ajustar silla de niños", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Airbags (6) delanteros, laterales delanteros y de cortina", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Indicador de presión de neumáticos Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Asistente sonoro para el estacionamiento Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Luces adaptativas en curvas Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Control de estabilidad (ESP)", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Luces de posición tipo LED Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Dirección asistida adaptable a la velocidad Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de aviso de cambio de carril Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla delanteros y traseros", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de frenado automático mediante detección de obstáculo Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros de Xenon Opcional", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Sistema de iluminación inteligente Opcional", AttrType = "Seguridad"},

                                        new EquipmentAttr() {AttrValue = "Barra porta equipaje", AttrType = "Exterior"},
                                        new EquipmentAttr() {AttrValue = "Espejos exteriores electricos", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla delanteros", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros antiniebla traseros", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Faros de xenon", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Limpia/ lava luneta", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Llantas de aleación", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Paragolpes color carroceria", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Techo descapotable", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Techo solar", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Vidrios tonalizados", AttrType = "Seguridad"},
                                        new EquipmentAttr() {AttrValue = "Limpia lava/faros", AttrType = "Seguridad"}

                                    };

            publication.UserDescription = "Homero Simpsons";
            publication.UserPhone = "(011) 4865-9878 // (011) 154-906-2244";
            publication.UserEmail = "hsimpsons@simpsons.com.ar";
            publication.UserUid = 391198;

            publication.UserType = "EndUser";
            publication.PublicationEndDate = DateTime.Today.AddDays(-1);
            publication.SegmentCatalogInfo.TechnicalMeasureImage = "\\Content\\images\\img_ficha_imprimir_croquis_chico.gif";
            publication.CatalogDescription = "La versión Trend del Gol llegó en 2008 para ampliar la familia de este auto record de la industria en Sudamérica, con más de veinte años de permanencia en los mercados, líder en ventas en 9 de los últimos 12 años y con casi 450.000 unidades patentadas en Argentina.Este nuevo Gol, marcadamente actualizado en su diseño, leva la denominación Trend para diferenciarlo del Power. Está equipado con una única motorización, un naftero 1.6 de 101 CV que le otorga interesantes prestaciones. Junto a la pick up Amarok, fue el lanzamiento más importante para la marca en los últimos años.";

            publication.UserViewContactData = true;
            publication.State = PublicationOrderState.Active.ToString();



            IList<Publication> similarByModel = new List<Publication>()
                                                    {
                                                        new Publication()
                                                            {
                                                                VehicleType = 2,
                                                                VehicleMakeText = "Volkswagen",
                                                                VehicleModelText = "Gol Trend",
                                                                VehicleVersionText =  "1.6 Pack 3 i Motion",
                                                                VehicleFuelTypeText = "Nafta",
                                                                VehicleYear = 2006,
                                                                PaymentMethodText = "Financiado",
                                                                VehicleSegmentText = "HatchBack 5P",
                                                                FundingAdvance = 1200,
                                                                VehicleKm = 80000,
                                                                VehiclePrice = 20200,
                                                                CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "U$S" },
                                                                FromQuote = 450,
                                                                VehicleLocProvText = "Buenos Aires",
                                                                VehicleLocPartText = "Vicente Lopez",
                                                                VehicleLocLocText = "La Lucila",
                                                                VehicleColorText = "Azul",
                                                                //FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" }
                                                            },
                                                        new Publication()
                                                            {
                                                                VehicleType = 2,
                                                                VehicleMakeText = "Volkswagen",
                                                                VehicleModelText = "Gol Trend",
                                                                VehicleVersionText =  "1.6 Pack 3 i Motion",
                                                                VehicleFuelTypeText = "Nafta",
                                                                PaymentMethodText = "Financiado",
                                                                VehicleSegmentText = "HatchBack 5P",
                                                                FundingAdvance = 1200,
                                                                VehicleYear = 2006,
                                                                VehicleKm = 80000,
                                                                VehiclePrice = 20200,
                                                                CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "U$S" },
                                                                FromQuote = 450,
                                                                VehicleLocProvText = "Buenos Aires",
                                                                VehicleLocPartText = "Vicente Lopez",
                                                                VehicleLocLocText = "La Lucila",
                                                                VehicleColorText = "Azul",
                                                                //FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" }
                                                            }
                                                    };

            ViewData["SimilarByModel"] = similarByModel;

            IList<Publication> comparableByModel = new List<Publication>()
                                                    {
                                                        new Publication()
                                                            {
                                                                VehicleType = 2,
                                                                VehicleMakeText = "Volkswagen",
                                                                VehicleModelText = "Gol Trend",
                                                                VehicleVersionText =  "1.6 Pack 3 i Motion",
                                                                VehicleFuelTypeText = "Nafta",
                                                                VehicleYear = 2006,
                                                                PaymentMethodText = "Financiado",
                                                                VehicleSegmentText = "HatchBack 5P",
                                                                FundingAdvance = 1200,
                                                                VehicleKm = 80000,
                                                                VehiclePrice = 20200,
                                                                CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "U$S" },
                                                                FromQuote = 450,
                                                                VehicleLocProvText = "Buenos Aires",
                                                                VehicleLocPartText = "Vicente Lopez",
                                                                VehicleLocLocText = "La Lucila",
                                                                VehicleColorText = "Azul",
                                                                //FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" }
                                                            },
                                                        new Publication()
                                                            {
                                                                VehicleType = 2,
                                                                VehicleMakeText = "Volkswagen",
                                                                VehicleModelText = "Gol Trend",
                                                                VehicleVersionText =  "1.6 Pack 3 i Motion",
                                                                VehicleFuelTypeText = "Nafta",
                                                                PaymentMethodText = "Financiado",
                                                                VehicleSegmentText = "HatchBack 5P",
                                                                FundingAdvance = 1200,
                                                                VehicleYear = 2006,
                                                                VehicleKm = 80000,
                                                                VehiclePrice = 20200,
                                                                CVehiclePriceCurrency = new Currency() { Name = "Dolares", Symbol = "U$S" },
                                                                FromQuote = 450,
                                                                VehicleLocProvText = "Buenos Aires",
                                                                VehicleLocPartText = "Vicente Lopez",
                                                                VehicleLocLocText = "La Lucila",
                                                                VehicleColorText = "Azul",
                                                                //FundingAdvanceCurrency = new Currency() { Name = "Pesos", Symbol = "$" }
                                                            }
                                                    };

            ViewData["ComparableByModel"] = comparableByModel;
            Session["Publication"] = publication;

            /*var query = QueryOver<Agency>.Property(x => x.Id).WithValue(agencyName).Build();
            var agency = AgencyIndexService.Query(query).First();
            return new JsonResult() { Data = agency.LocationCoordinates };*/

            return publication;
        }


    }
}
