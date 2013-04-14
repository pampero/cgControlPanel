namespace Buscador.Domain.com.clarin.entities
{
    public class FeatureAttr
    {
        public virtual int Id { get; set; }
        public virtual int IndexationEntityId { get; set; }
        public virtual string FeatureKey { get; set; }
        public virtual int FeatureId { get; set; }

        public FeatureAttr()
        {
            var a = string.Empty;
        }

        public FeatureAttr(string featureKey, int featureId)
        {
            FeatureKey = featureKey;
            FeatureId = featureId;
        }

        public override string ToString()
        {
            return FeatureKey;
        }
    }
}