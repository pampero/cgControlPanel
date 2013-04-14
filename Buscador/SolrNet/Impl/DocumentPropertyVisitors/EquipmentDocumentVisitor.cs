using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using SolrNet.Utils;

namespace SolrNet.Impl.DocumentPropertyVisitors
{
    public class EquipmentDocumentVisitor : ISolrDocumentPropertyVisitor
    {
        private ISolrFieldParser _parser;
        private IReadOnlyMappingManager _mapper;

        public EquipmentDocumentVisitor(ISolrFieldParser parser, IReadOnlyMappingManager mapper)
        {
            _parser = parser;
            _mapper = mapper;
        }

        public void Visit(object doc, string fieldName, XmlNode field)
        {
            if(fieldName.Contains("_eq"))
            {
                var property = Func.FirstOrDefault(doc.GetType().GetProperties(), p => p.Name.ToLower().Contains("equipment"));

                var propertyList = (IList)property.GetValue(doc, null);

                var genericArgument = propertyList.GetType().GetGenericArguments();

                var values = (IList)_parser.Parse(field, typeof (IList));

                foreach (var value in values)
                {
                    var equipmentAttr = Activator.CreateInstance(genericArgument[0], null);
                    var propAttrValue = equipmentAttr.GetType().GetProperty("AttrValue");
                    var propAttrKey = equipmentAttr.GetType().GetProperty("AttrKey");
                    propAttrValue.SetValue(equipmentAttr, value, null);
                    propAttrKey.SetValue(equipmentAttr, fieldName, null);
                    propertyList.Add(equipmentAttr);
                }
            }
        }
    }
}
