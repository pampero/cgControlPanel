using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using NUnit.Framework;

namespace Buscador.Web.Controllers.Test
{
    [TestFixture]
    public class AutosControllersTest : WebIntegrationTestBase
    {
        private string _viewPath;
        private string _certificaCallScript;
        private string _analyticsScript1;
        private string _analyticsScript2;
        private string _analyticsScript3;
        private string _analyticsScript4;
        private string _analyticsScript5;

        private RouteCollection _routes;

        Mock<HttpSessionStateBase> _session = new Mock<HttpSessionStateBase>();

        [SetUp]
        public void SetUp()
        {
            _certificaCallScript = "<script type=\"text/javascript\">hitCertifica";
            _analyticsScript1 = "var _gaq = _gaq || [];";
            _analyticsScript2 = "_gaq.push([\"_setAccount\", \"UA-1254112-1\"]);";
            _analyticsScript3 = "_gaq.push([\"_setAllowAnchor\", true]);";
            _analyticsScript4 = "_gaq.push([\"_setDomainName\", \".deautos.com\"]);";
            _analyticsScript5 = "_gaq.push([\"_trackPageview\"]);";

            ViewEngines.Engines.Add(new MultipleSiteViewEngine());
        }

        [Test]
        public void Home_Result_Should_Hit_Certifica_Tag()
        {
            var result = GetRequestResultString(BuildTestUrl("/"));
            Assert.IsTrue(result.Contains(_certificaCallScript));
            Assert.IsTrue(result.Contains("hitCertifica('200150', '/home/inicio', '/home/inicio');"));
        }

        [Test]
        public void Search_Result_Should_Hit_Certifica_Tag()
        {
            var result = GetRequestResultString(BuildTestUrl("/autos-usados/VTYY1"));
            Assert.IsTrue(result.Contains(_certificaCallScript));
            Assert.IsTrue(result.Contains("hitCertifica('200150', '/buscador/', '/buscador/');"));
        }

        [Test]
        public void Search_Result_With_Model_Should_Not_Hit_Certifica_Tag_With_Model()
        {
            var result = GetRequestResultString(BuildTestUrl("/autos-usados-volkswagen-gol/VTYY1WWMAYY395WWMOYY1950"));
            Assert.IsFalse(result.Contains("hitCertifica('200150', '/buscador/Volkswagen-Gol', '/buscador/Volkswagen-Gol');"));
        }

        [Test]
        public void Publication_Details_Should_Hit_Certifica_Tag()
        {
            var result = GetRequestResultString(BuildTestUrl("/autos-nuevos/519790"));
            Assert.IsTrue(result.Contains(_certificaCallScript));
            Assert.IsFalse(result.Contains("hitCertifica('200150', '/ficha/Fiat-"));
        }

        [Test]
        public void Microsite_Should_Hit_Certifica_Tag()
        {
            var result = GetRequestResultString(BuildTestUrl("/Agency/Details/abrahamautomotores"));
            Assert.IsTrue(result.Contains(_certificaCallScript));
            Assert.IsTrue(result.Contains("hitCertifica('200150', '/concesionaria"));
        }

        [Test]
        public void Search_Result_Should_Render_Analytics_Tag()
        {
            //var streamReader = new StreamReader(string.Format("{0}{1}", _viewPath, "Site.Master"));
            //var stringView = streamReader.ReadToEnd();

            var result = GetRequestResultString(BuildTestUrl("/"));

            Assert.IsTrue(result.Contains(_analyticsScript1));
            Assert.IsTrue(result.Contains(_analyticsScript2));
            Assert.IsTrue(result.Contains(_analyticsScript3));
            Assert.IsTrue(result.Contains(_analyticsScript4));
            Assert.IsTrue(result.Contains(_analyticsScript5));
        }

        [Test]
        public void Details_Result_Should_Render_Certifica_Tag()
        {
            var result = GetRequestResultString(BuildTestUrl("/autos-nuevos/519790"));

            Assert.IsTrue(result.Contains(_certificaCallScript));
        }

        [Test]
        public void Details_Result_Should_Render_Analytics_Tag()
        {
            var result = GetRequestResultString(BuildTestUrl("/autos-nuevos/519790"));

            Assert.IsTrue(result.Contains(_analyticsScript1));
            Assert.IsTrue(result.Contains(_analyticsScript2));
            Assert.IsTrue(result.Contains(_analyticsScript3));
            Assert.IsTrue(result.Contains(_analyticsScript4));
            Assert.IsTrue(result.Contains(_analyticsScript5));
        }

        [Test]
        public void Details_Should_Render_Title_Ok()
        {
            var result = GetRequestResultString(BuildTestUrl("/usados-Chevrolet-Meriva-GL-1.8Plus/2005_915289"));
            var title = result.Substring(result.IndexOf("<title>"), result.IndexOf("</title>") - result.IndexOf("<title>") + "<title>".Length);
            Assert.IsTrue(title.Contains("915289"));
            Assert.IsTrue(title.Contains("usado"));
            Assert.IsTrue(title.Contains("2005"));
        }

        [Test]
        public void Details_Should_Render_MetaDescription_Ok()
        {
            var result = GetRequestResultString(BuildTestUrl("/usados-Chevrolet-Meriva-GL-1.8Plus/2005_915289"));
            Assert.IsTrue(result.Contains("<meta name=\"Description\" content=\"Chevrolet Meriva GL 1.8 Plus usados 2005 $29.800 86.000 km Hatchback 5P Nafta 915289 en Lanus\""));
        }

        [Test]
        public void Details_Without_Equipment_Should_Not_Render_Equipments_Headers()
        {
            //    var publicationIndexServiceMock = new Mock<IIndexService<Publication>>();
            //    var bannerService = new Mock<IBannerService>();

            //    #region agency
            //    var agency = new Agency
            //                     {
            //                         Address = "Direccion",
            //                         Name = "agencia prueba",
            //                         UserId = 1
            //                     };

            //    var agencysPublication1 = new Publication
            //                                  {
            //                                      VehicleMakeText = "Ford",
            //                                      VehicleModelText = "Focus",
            //                                      VehicleVersionText = "1.0",
            //                                      VehicleSegmentText = "Sedan",
            //                                      VehicleYear = 2010,
            //                                      UserUid = agency.UserId
            //                                  };

            //    var agencysPublication2 = new Publication
            //                                  {
            //                                      VehicleMakeText = "Peugeot",
            //                                      VehicleModelText = "Focus",
            //                                      VehicleVersionText = "1.0",
            //                                      VehicleSegmentText = "Sedan",
            //                                      VehicleYear = 2010,
            //                                      UserUid = agency.UserId
            //                                  };

            //    var listPublications = new List<Publication>
            //                               {
            //                                   agencysPublication1,
            //                                   agencysPublication2
            //                               };
            //    #endregion
            //    #region Otras Yerbas
            //    var expr = new KeyValuePair<Expression<Func<Publication, object>>, string>(x => x.VehicleSegmentText,
            //                                                                               string.Empty);

            //    var queryStub = new List<KeyValuePair<Expression<Func<Publication, object>>, string>> {expr};

            //    publicationIndexServiceMock.Setup(x => x.Query(queryStub)).Returns(listPublications);
            //    bannerService.Setup(x => x.GetHtmlBanner(It.IsAny<string>())).Returns("htmlbanner");

            //    _session.Setup(x => x.SessionID).Returns("1");

            //    _routes = new RouteCollection();

            //    _request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            //    _request.SetupGet(x => x.ApplicationPath).Returns("/");
            //    _request.SetupGet(x => x.Url).Returns(new Uri("http://localhost/a", UriKind.Absolute));
            //    _request.SetupGet(x => x.ServerVariables).Returns(new NameValueCollection());

            //    var response = new Mock<HttpResponseBase>(MockBehavior.Strict);
            //    response.Setup(x => x.ApplyAppPathModifier("/post1")).Returns("http://localhost/post1");

            //    var serverUtility = new Mock<HttpServerUtilityBase>(MockBehavior.Strict);
            //    serverUtility.Setup(x => x.MapPath(It.IsAny<String>())).Returns(@"c:\");

            //    _context = new Mock<HttpContextBase>(MockBehavior.Strict);
            //    _context.SetupGet(x => x.Request).Returns(_request.Object);
            //    _context.SetupGet(x => x.Response).Returns(response.Object);
            //    _context.SetupGet(x => x.Session).Returns(_session.Object);
            //    _context.SetupGet(x => x.Server).Returns(serverUtility.Object);
            //    _context.SetupGet(x => x.Items).Returns(new HybridDictionary()
            //                                                {{"clientValidationEnabled", true}, {"formContext", new FormContext{FormId = "", ValidationSummaryId = "", ReplaceValidationSummary= false}}}
            //);


            //    var controllerContext = new ControllerContext(_context.Object, new RouteData(), new AutosController());
            //    var routeData = new RouteData();
            //    routeData.Values.Add("controller", "autos");
            //    routeData.Values.Add("action", "ShowDetails");
            //    controllerContext.RouteData = routeData;
            //    #endregion

            //    var autosController = new AutosController
            //                              {
            //                                  IndexService = publicationIndexServiceMock.Object,
            //                                  BannerService = bannerService.Object,
            //                                  ControllerContext = controllerContext,
            //                                  SiteName = "clarin",
            //                              };


            //    autosController.ControllerContext.Controller = autosController;
            //    //var result = autosController.ShowDetails(2009, 192);
            //    // var viewRendered = autosController.RenderViewToString("NewDetails", null);

            //var solrOperations = new Mock<ISolrOperations<Publication>>();

            //ServiceLocator.SetLocatorProvider(() => new SolrNet.Utils.Container());

            //var container = ServiceLocator.Current as SolrNet.Utils.Container;
            //container.Register<ISolrOperations<Publication>>(c => solrOperations.Object);
        }
    }
}