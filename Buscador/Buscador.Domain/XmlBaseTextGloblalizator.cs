using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

namespace Buscador.Domain
{
    public interface ITextGlobalizator
    {
        string Localize(string name);
        ITextGlobalizator ForSite(string currentSite);
    }

    public class XmlBaseTextGloblalizator : ITextGlobalizator
    {
        private string _currentSite;
        public string BaseDirectory { get; set; }

        public string Localize(string source)
        {
            return Localize(source, Thread.CurrentThread.CurrentCulture);
        }

        public ITextGlobalizator ForSite(string currentSite)
        {
            _currentSite = currentSite;
            return this;
        }

        private string Localize(string name, CultureInfo currentCulture)
        {
            var dictionaryPath = string.Format("Views/Home/{0}/dictionary.xml",_currentSite);

            var xDocument = XDocument.Load(Path.Combine(BaseDirectory,dictionaryPath));

            var nodeAdd = xDocument.Descendants("add")
                .Where(nodo => nodo.Parent.FirstAttribute.Value == currentCulture.Name)
                .Where(nodo=>nodo.FirstAttribute.Value==name)
                .FirstOrDefault();

            return nodeAdd == null ? null : nodeAdd.LastAttribute.Value;

            //return nodeAdd != null ? nodeAdd.LastAttribute.Value : name;
        }
    }
}