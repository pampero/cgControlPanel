namespace Buscador.Domain.com.clarin.entities
{
    public class PublicationLinealType : PublicationType
    {
        public PublicationLinealType()
        {
            
        }

        public override void Accept(IPublicationTypeVisitor publicationTypeVisitor)
        {
            publicationTypeVisitor.Visit(this);
        }
    }
}