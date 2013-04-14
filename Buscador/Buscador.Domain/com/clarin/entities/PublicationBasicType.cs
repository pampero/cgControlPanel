namespace Buscador.Domain.com.clarin.entities
{
    public class PublicationBasicType : PublicationType
    {
        public PublicationBasicType()
        {
            
        }

        public override void Accept(IPublicationTypeVisitor publicationTypeVisitor)
        {
            publicationTypeVisitor.Visit(this);
        }
    }
}