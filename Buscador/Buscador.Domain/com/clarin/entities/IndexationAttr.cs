namespace Buscador.Domain.com.clarin.entities
{
    public abstract class IndexationAttr
    {
        public virtual int Id { get; set; }
        public virtual int IndexationEntityId { get; set; }
        public virtual string AttrKey { get; set; }
        public virtual string AttrValue { get; set; }
        public virtual string AttrType { get; set; }

        public IndexationAttr()
        {
            
        }

        public IndexationAttr( string attrKey, string  attrValue, string attrType)
        {
            AttrKey = attrKey;
            AttrValue = attrValue;
            AttrType = attrType;
        }

        public override bool Equals(object obj)
        {
            if (this.Id == ((IndexationAttr)obj).Id &&
                this.AttrKey == ((IndexationAttr)obj).AttrKey &&
                this.AttrValue == ((IndexationAttr)obj).AttrValue &&
                this.AttrType == ((IndexationAttr)obj).AttrType)
                return true;
            return false;
        }

        public override string ToString()
        {
            return AttrValue;
        }
    }
}