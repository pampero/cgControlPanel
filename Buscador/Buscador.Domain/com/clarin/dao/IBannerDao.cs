using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Spring.Data.NHibernate.Generic;


namespace Buscador.Domain.com.clarin.dao
{
    public interface IBannerDao
    {
        string GetAttribute(string attribute, string seccion, string codigo);
    }

    public class BannerDao : IBannerDao
    {
        public HibernateTemplate HibernateTemplate { get; set; }
        public IXmlDocumentWrapper XmlDocumentWrapper { get; set; }

        public string GetAttribute(string attribute, string seccion, string codigo)
        {
            return XmlDocumentWrapper.GetAttribute(attribute, seccion, codigo);
        }
    }

    public interface IXmlDocumentWrapper
    {
        string GetAttribute(string attribute, string seccion, string codigo);
    }

    public class XmlDocumentWrapper : IXmlDocumentWrapper
    {
        private XmlDocument _document;
        
        public XmlDocumentWrapper(string pathXml)
        {
            _document = new XmlDocument();
            _document.Load(pathXml);
        }

        public string GetAttribute(string attribute, string seccion, string codigo)
        {
            var node = _document.SelectSingleNode("//" + (seccion==string.Empty?"usados":seccion) + "/" + codigo);
            return node.Attributes.GetNamedItem(attribute).Value;
        }
    }
}
