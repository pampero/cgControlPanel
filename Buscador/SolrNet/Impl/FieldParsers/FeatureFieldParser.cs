using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SolrNet.Impl.FieldParsers
{
public class FeatureFieldParser : ISolrFieldParser
    {
        public bool CanHandleSolrType(string solrType)
        {
            return true;
        }

        public bool CanHandleType(Type t)
        {
            return t.FullName.Contains("Feature");
        }

        public object Parse(XmlNode field, Type t)
        {
            var featureAttr = Activator.CreateInstance(t);

            var featureKeyProperty = t.GetProperty("FeatureKey");
            featureKeyProperty.SetValue(featureAttr, field.InnerXml, null);

            return featureAttr;
        }
    }
}
