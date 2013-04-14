using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using FluentNHibernate.Mapping;

namespace Buscador.Domain.mappings.com.clarin.entities
{
    //public class PublicationTypeMapping : ClassMap<PublicationType>
    //{
    //    public PublicationTypeMapping()
    //    {
    //        Table("OfertasTipo");
    //        Id(x => x.Id, "Id").GeneratedBy.Identity();
            
    //        Map(x => x.Descripcion);
    //        Map(x => x.EstadoDefaultPers);
    //        Map(x => x.EstadoDefaultEmpr);
    //        Map(x => x.DiasPublicacionE);
    //        Map(x => x.DiasRenovacionE);
    //        Map(x => x.DiasPublicacionP);
    //        Map(x => x.DiasRenovacionP);
    //        Map(x => x.CantFotos);
    //        Map(x => x.CantVideos);
    //        Map(x => x.Prioridad);
    //        Map(x => x.PrecioPartPublicacion);
    //        Map(x => x.PrecioPartRenovacion);
    //        Map(x => x.Particulares);
    //        Map(x => x.Empresas);
    //        Map(x => x.Deautos);
    //        Map(x => x.AutosClarin);

    //        DiscriminateSubClassesOnColumn("Id");
    //    }
    //}

    //public class PublicationPremiumTypeMapping : SubclassMap<PublicationPremiumType>
    //{
    //    public PublicationPremiumTypeMapping()
    //    {
    //        DiscriminatorValue(1);
    //    }
    //}

    //public class PublicationBasicTypeMapping : SubclassMap<PublicationBasicType>
    //{
    //    public PublicationBasicTypeMapping()
    //    {
    //        DiscriminatorValue(100);
    //    }
    //}

    //public class PublicationSimpleTypeMapping : SubclassMap<PublicationSimpleType>
    //{
    //    public PublicationSimpleTypeMapping()
    //    {
    //        DiscriminatorValue(0);
    //    }
    //}

    //public class PublicationPremium45HighlighDaysTypeTypeMapping : SubclassMap<PublicationPremium45HighlighDaysType>
    //{
    //    public PublicationPremium45HighlighDaysTypeTypeMapping()
    //    {
    //        DiscriminatorValue(2);
    //    }
    //}

    //public class PublicationSuperPremiumTypeMapping : SubclassMap<PublicationSuperPremiumType>
    //{
    //    public PublicationSuperPremiumTypeMapping()
    //    {
    //        DiscriminatorValue(6);
    //    }
    //}

    //public class PublicationHighlightedTypeMapping : SubclassMap<PublicationHighlightedType>
    //{
    //    public PublicationHighlightedTypeMapping()
    //    {
    //        DiscriminatorValue(101);
    //    }
    //}

    //public class PublicationSuperHighlightedTypeMapping : SubclassMap<PublicationSuperHighlightedType>
    //{
    //    public PublicationSuperHighlightedTypeMapping()
    //    {
    //        DiscriminatorValue(103);
    //    }
    //}
}
