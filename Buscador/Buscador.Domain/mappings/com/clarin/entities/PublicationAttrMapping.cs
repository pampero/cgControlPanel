using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using FluentNHibernate.Mapping;

namespace Buscador.Domain.mappings.com.clarin.entities
{
    public class PublicationAttrMapping : SubclassMap<PublicationAttr>
    {
        public PublicationAttrMapping()
        {
            DiscriminatorValue("PUBLI");
        }
    }
}
