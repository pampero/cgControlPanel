using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    [Serializable]
    public class PublicationSuperPremiumType : PublicationType
    {
        public PublicationSuperPremiumType()
        {
            
        }

        public override void Accept(IPublicationTypeVisitor publicationTypeVisitor)
        {
            publicationTypeVisitor.Visit(this);
        }
    }
}
