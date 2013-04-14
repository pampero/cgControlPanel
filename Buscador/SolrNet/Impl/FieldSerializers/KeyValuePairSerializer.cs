using System;
using System.Collections.Generic;
using System.Text;

namespace SolrNet.Impl.FieldSerializers
{
    public class KeyValuePairSerializer : ISolrFieldSerializer
    {
        private ISolrFieldSerializer _fieldSerializer;

        public KeyValuePairSerializer(ISolrFieldSerializer defaultFieldSerializer)
        {
            _fieldSerializer = defaultFieldSerializer;
        }

        public bool CanHandleType(Type t)
        {
            return t.FullName.Contains("KeyValuePair");
        }

        public IEnumerable<PropertyNode> Serialize(object obj)
        {
            var propertyNode = new PropertyNode();
            propertyNode.FieldValue = ((List<KeyValuePair<string, object>>) (obj))[0].Value.ToString();
            yield return propertyNode;
        }
    }
}
