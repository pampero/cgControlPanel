using System;

namespace Buscador.Domain.com.clarin.entities
{
    public class PublicationAttr : IndexationAttr
    {
        public PublicationAttr()
        {
            
        }

        public PublicationAttr(string attrKey, string attrValue, string attrType) : base(attrKey, attrValue, attrType)
        {
           
        }

        public override string ToString()
        {
            return AttrValue;
        }
    }
}