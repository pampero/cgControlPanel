#region license
// Copyright (c) 2007-2009 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Xml;

namespace SolrNet.Impl {
    /// <summary>
    /// Serializes a Solr document to xml
    /// </summary>
    /// <typeparam name="T">Document type</typeparam>
    public class SolrDocumentSerializer<T> : ISolrDocumentSerializer<T> {
        
        private readonly IReadOnlyMappingManager mappingManager;
        private readonly ISolrFieldSerializer fieldSerializer;
        private ITypeStrategySerializer typeStrategySerializer;

        public SolrDocumentSerializer(IReadOnlyMappingManager mappingManager, ISolrFieldSerializer fieldSerializer) {
            this.mappingManager = mappingManager;
            this.fieldSerializer = fieldSerializer;
            typeStrategySerializer=new TypeStrategySerializer(new DefaultSolrTypesSerializer(),
                                                              new KeyValuesTypesSerializer());
        }

        public XmlDocument Serialize(T doc, double? boost) {
            var xml = new XmlDocument();
            var docNode = xml.CreateElement("doc");
            if (boost.HasValue) {
                var boostAttr = xml.CreateAttribute("boost");
                boostAttr.Value = boost.Value.ToString(CultureInfo.InvariantCulture.NumberFormat);
                docNode.Attributes.Append(boostAttr);
            }
            var fields = mappingManager.GetFields(typeof(T));
            foreach (var kv in fields)
            {
                typeStrategySerializer.Serialize(kv, xml, docNode, doc, fieldSerializer);
            }
            xml.AppendChild(docNode);
            return xml;            
        }
    }

    public class KeyValuesTypesSerializer : ITypeStrategySerializer
    {
        public void Serialize(KeyValuePair<PropertyInfo, string> kv, XmlDocument xml, XmlElement docNode, object doc, ISolrFieldSerializer fieldSerializer)
        {
            var porpertyList = (List<KeyValuePair<string, object>>)kv.Key.GetValue(doc, null);

            foreach (var keyValuePair in porpertyList)
            {
                var p = keyValuePair.Value;
                var value = p;
                if (value == null)
                    continue;
                var nodes = fieldSerializer.Serialize(value);
                foreach (var n in nodes)
                {
                    var fieldNode = xml.CreateElement("field");
                    var nameAtt = xml.CreateAttribute("name");
                    nameAtt.InnerText = keyValuePair.Key + "_eq";
                    fieldNode.Attributes.Append(nameAtt);
                    fieldNode.InnerText = n.FieldValue;
                    docNode.AppendChild(fieldNode);
                }
            }
        }

        public bool CanSerialize(KeyValuePair<PropertyInfo, string> kv)
        {
            return kv.Key.PropertyType == typeof (List<KeyValuePair<string, object>>);
        }
    }

    public class DefaultSolrTypesSerializer : ITypeStrategySerializer
    {
        public void Serialize(KeyValuePair<PropertyInfo, string> kv, XmlDocument xml, XmlElement docNode, object doc, ISolrFieldSerializer fieldSerializer)
        {
            var p = kv.Key;
            var value = p.GetValue(doc, null);
            if (value == null) return;
            //    continue;
            var nodes = fieldSerializer.Serialize(value);
            foreach (var n in nodes)
            {
                var fieldNode = xml.CreateElement("field");
                var nameAtt = xml.CreateAttribute("name");
                nameAtt.InnerText = (kv.Value == "*" ? "" : kv.Value) + n.FieldNameSuffix;
                fieldNode.Attributes.Append(nameAtt);
                fieldNode.InnerText = n.FieldValue;
                docNode.AppendChild(fieldNode);
            }
        }

        public bool CanSerialize(KeyValuePair<PropertyInfo, string> kv)
        {
            return kv.Key.PropertyType != typeof(List<KeyValuePair<string, object>>);
        }
    }

    public interface ITypeStrategySerializer
    {
        void Serialize(KeyValuePair<PropertyInfo, string> kv, XmlDocument xml, XmlElement docNode, object doc, ISolrFieldSerializer fieldSerializer);
        bool CanSerialize(KeyValuePair<PropertyInfo, string> kv);
    }

    public class TypeStrategySerializer : ITypeStrategySerializer
    {
        private List<ITypeStrategySerializer> serializers;

        public TypeStrategySerializer(ITypeStrategySerializer defaultSolrTypesSerializer, ITypeStrategySerializer equipmentTypesSerializer)
        {
            serializers = new List<ITypeStrategySerializer>();
            serializers.Add(defaultSolrTypesSerializer);
            serializers.Add(equipmentTypesSerializer);
        }

        public void Serialize(KeyValuePair<PropertyInfo, string> kv, XmlDocument xml, XmlElement docNode, object doc, ISolrFieldSerializer fieldSerializer)
        {
            foreach (var serializer in serializers)
            {
                if(serializer.CanSerialize(kv))
                    serializer.Serialize(kv,xml,docNode, doc, fieldSerializer);
            }
        }

        public bool CanSerialize(KeyValuePair<PropertyInfo, string> kv)
        {
            throw new NotImplementedException();
        }
    }
}