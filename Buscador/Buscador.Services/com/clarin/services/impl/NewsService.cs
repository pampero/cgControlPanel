using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Services.com.clarin.services.impl
{
    public class NewsService : INewsService
    {
        public virtual IXmlParseComponent XmlParseComponet { get; set; }
        public virtual int NewsLastSet { get; set; }
        public virtual IRequestCreatorService RequestCreatorService { get; set; }

        public IList<News> GetLastestFrom(string xmlstrUrl)
        {
            string xmlData = null;
            try
            {
                xmlData = RequestCreatorService.CreateRequest(xmlstrUrl, "", "");

            }
            catch (Exception e)
            {
 
            }
            
            var list = XmlParseComponet.ParseFileXml(XDocument.Parse(xmlData), NewsLastSet);

            return list;
        }
    }
}
