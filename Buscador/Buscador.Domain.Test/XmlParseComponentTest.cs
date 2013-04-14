using System.IO;
using System.Xml.Linq;
using NUnit.Framework;
using System.Configuration;

namespace Buscador.Domain.Test
{
    [TestFixture]
    public class XmlParseComponentTest
    {
        [Test]
        public void XmlParseComponent_Should_Could_Get_New_Title()
        {
            var xmlParseDocument = new XmlParseComponent();
            string xmlData;
            var path = ConfigurationManager.AppSettings["RssPath"]; 
            using (StreamReader reader = new StreamReader(path))
            {
                xmlData = reader.ReadToEnd();
            }
            var xDocument = XDocument.Parse(xmlData);
            var news = xmlParseDocument.ParseFileXml(xDocument, 3);
            Assert.IsNotNull(news);
        }
    }
}
