namespace Buscador.Domain.com.clarin.entities
{
    public class PublicationSimpleType : PublicationType
    {
        public PublicationSimpleType()
        {
            
        }

        public override void Accept(IPublicationTypeVisitor publicationTypeVisitor)
        {
            publicationTypeVisitor.Visit(this);
        }
    }
}