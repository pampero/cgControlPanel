using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Buscador.Web.Controllers.Controllers;
using Moq;
using NUnit.Framework;
using Spring.Context.Support;
using Spring.Testing.NUnit;

namespace Buscador.Web.Controllers.Test
{
    [TestFixture]
    public class AutosControllerIntegrationTests : AbstractTransactionalSpringContextTests
    {
        protected override string[] ConfigLocations
        {
            get
            {
                return new[]
                           {
                               "file://../../../Buscador.Web/controllers-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/hibernate-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/dao-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/facets-config.xml",
                               "assembly://Buscador.Services/Buscador.Services/services-config.xml"
                           };
            }
        }

        [Test]
        public void Details_For_Non_Existent_Publication_Should_Render_PublicationNotAvailable()
        {
            var controller = (AutosController)ContextRegistry.GetContext().GetObject("AutosController");

            var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
            request.Setup(x => x.ApplicationPath).Returns("/");
            request.Setup(x => x.Url).Returns(new Uri(string.Format("http://localhost/usados-volkswagen-gol/2000_{0}", int.MaxValue)));
            request.Setup(x => x.ServerVariables).Returns(new System.Collections.Specialized.NameValueCollection());

            var context = new Mock<HttpContextBase>(MockBehavior.Strict);
            context.SetupGet(x => x.Request).Returns(request.Object);

            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
            
            var responseView = controller.ShowDetails(2000, int.MaxValue) as ViewResult;

            Assert.IsNotNull(responseView);
            Assert.IsTrue(responseView.ViewName.Equals("PublicationNotAvailable"));
        }
    }

    public class HttpContextStub : HttpContextBase
    {
    }
}
