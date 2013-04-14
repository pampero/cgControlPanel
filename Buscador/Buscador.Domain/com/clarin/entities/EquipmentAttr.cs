namespace Buscador.Domain.com.clarin.entities
{
    public class EquipmentAttr : IndexationAttr
    {
        
        public EquipmentAttr()
        {
            
        }

        public EquipmentAttr(string attrKey, string attrValue, string attrType) : base(attrKey, attrValue, attrType)
        {
           
        }

        public override string ToString()
        {
            return AttrValue;
        }
    }
}