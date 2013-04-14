using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    public class PublicationSuperHighlightedType : PublicationType
    {
        public PublicationSuperHighlightedType()
        {
            
        }

        public override void Accept(IPublicationTypeVisitor publicationTypeVisitor)
        {
            publicationTypeVisitor.Visit(this);
        }
    }
}
