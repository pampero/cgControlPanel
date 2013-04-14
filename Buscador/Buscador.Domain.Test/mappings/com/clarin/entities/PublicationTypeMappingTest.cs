using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using FluentNHibernate.Mapping;
using FluentNHibernate.Testing;
using NUnit.Framework;

namespace Buscador.Domain.Test.mappings.com.clarin.entities
{
    [TestFixture]
    public class PublicationTypeMappingTest : TestDaoBase
    {
        //[Test]
        //public void Test_PublicationType_Mapping()
        //{
        //    new PersistenceSpecification<PublicationPremiumType>(_session)
        //                                  .CheckProperty(x => x.Descripcion, "desc")
        //                                  .CheckProperty(x => x.EstadoDefaultPers ,1)
        //                                  .CheckProperty(x => x.EstadoDefaultEmpr,1) 
        //                                  .CheckProperty(x => x.DiasPublicacionE ,1)	 
        //                                  .CheckProperty(x => x.DiasRenovacionE ,1) 
        //                                  .CheckProperty(x => x.DiasPublicacionP ,1)	 
        //                                  .CheckProperty(x => x.DiasRenovacionP ,1)	 
        //                                  .CheckProperty(x => x.CantFotos ,1)	 
        //                                  .CheckProperty(x => x.CantVideos ,1)	 
        //                                  .CheckProperty(x => x.Prioridad ,1)	 
        //                                  .CheckProperty(x => x.PrecioPartPublicacion,1)	
        //                                  .CheckProperty(x => x.PrecioPartRenovacion,1) 
        //                                  .CheckProperty(x => x.Particulares ,1) 
        //                                  .CheckProperty(x => x.Empresas ,1)
        //                                  .CheckProperty(x => x.Deautos ,1)	 
        //                                  .CheckProperty(x => x.AutosClarin ,1)
        //                                  .VerifyTheMappings();
        //}
    }
}
