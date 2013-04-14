using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SolrNet.Impl.FieldParsers
{
    public class EquipmentFieldParser : ISolrFieldParser
    {
        public bool CanHandleSolrType(string solrType)
        {
            return true;
        }

        public bool CanHandleType(Type t)
        {
            return t.FullName.Contains("Equipment");
        }

        public object Parse(XmlNode field, Type t)
        {
            var equipmentAttr = Activator.CreateInstance(t);

            var attrValueProperty = t.GetProperty("AttrValue");
            attrValueProperty.SetValue(equipmentAttr,field.InnerXml,null);

            return equipmentAttr;
        }
    }
}
