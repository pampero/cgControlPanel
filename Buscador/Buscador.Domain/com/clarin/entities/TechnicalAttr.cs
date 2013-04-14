using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    public class TechnicalAttr : IndexationAttr
    {
        public TechnicalAttr()
        {
            
        }

        public TechnicalAttr(string attrKey, string attrValue, string attrType) : base(attrKey, attrValue, attrType)
        {
            
        }

        public override string ToString()
        {
            return AttrValue;
        }
    }
}
