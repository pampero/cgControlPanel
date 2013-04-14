using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using CassiniDev;
using NUnit.Framework;
using Spring.Context.Support;
using Spring.Testing.NUnit;

namespace Buscador.Web.Controllers.Test
{
    public abstract class WebIntegrationTestBase : AbstractTransactionalSpringContextTests
    {
        protected Server WebServer;
        protected WebClient WebClient;

        protected override string[] ConfigLocations
        {
            get
            {
                return new[]
                           {
                               "assembly://Buscador.Domain/Buscador.Domain/hibernate-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/dao-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/facets-config.xml",
                               "assembly://Buscador.Services/Buscador.Services/services-config.xml",
                               "testenv-config.xml"
                           };
            }
        }

        [SetUp]
        public void TestFixtureSetup()
        {
            WebServer = (Server)ContextRegistry.GetContext().GetObject("testWebServer");
            var isRunning = default(bool);

            try
            {
                isRunning = ((HttpWebResponse)(WebRequest.Create(BuildTestUrl("/")).GetResponse())).StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
               
            }
            

            if(!isRunning)
                WebServer.Start();

            WebClient = new WebClient();
        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            if (WebServer != null)
            {
                WebServer.ShutDown();
            }
        }

        protected string BuildTestUrl(string path)
        {
            return string.Format("http://localhost:{0}{1}{2}", WebServer.Port, path.StartsWith("/") ? string.Empty : "/", path);
        }

        protected string GetRequestResultString(string url)
        {
            using (var reader = new StreamReader(WebClient.OpenRead(url)))
            {
                return reader.ReadToEnd();
            }
        }
    }
}