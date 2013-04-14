using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    [DataContract]
    public class ItemData
    {
        [DataMember]
        public string AttributeValue { get; set; }
        [DataMember]
        public string AttributeDataType { get; set; }

        public ItemData(string attributeValue,string attributeDataType)
        {
            AttributeDataType = attributeDataType;
            AttributeValue = attributeValue;
        }
    }
}
