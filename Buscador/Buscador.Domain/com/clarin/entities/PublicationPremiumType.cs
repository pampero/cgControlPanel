using System;
using System.Runtime.Serialization;

namespace Buscador.Domain.com.clarin.entities
{
    [DataContract]
    public class PublicationPremiumType : PublicationType
    {
        public PublicationPremiumType()
        {
            
        }

        public override void Accept(IPublicationTypeVisitor publicationTypeVisitor)
        {
            publicationTypeVisitor.Visit(this);
        }
    }

    public class PublicationPremium45HighlighDaysType : PublicationType
    {
        public PublicationPremium45HighlighDaysType()
        {

        }

        public override void Accept(IPublicationTypeVisitor publicationTypeVisitor)
        {
            publicationTypeVisitor.Visit(this);
        }
    }
}