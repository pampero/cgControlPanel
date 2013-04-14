using System;
using System.Collections.Generic;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.utils;
using FluentNHibernate.Testing;
using NUnit.Framework;

namespace Buscador.Domain.Test.mappings.com.clarin.entities
{
    //[TestFixture]
    //public class PublicationMappingTest : TestDaoBase
    //{
    //    [Test]
    //    public void Test_FluentNh_CheckProperty()
    //    {
    //        new PersistenceSpecification<Publication>(_session)
    //            .CheckProperty(x => x.IndexWeight, 100)
    //            .CheckProperty(x => x.PublicationContactsQty, 100)
    //            .CheckProperty(x => x.PublicationDate, DateTime.Now.TruncateToSeconds())
    //            .CheckProperty(x => x.PublicationStartDate, DateTime.Now.TruncateToSeconds())
    //            .CheckProperty(x => x.PublicationEndDate, DateTime.Now.TruncateToSeconds())
    //            .CheckProperty(x => x.PublicationDeleted, false)
    //            .CheckProperty(x => x.PublicationHighLight, "si")
    //            .CheckProperty(x => x.PublicationId, 1)
    //            .CheckProperty(x => x.PublicationSubtitle, "subtitulo")
    //            .CheckProperty(x => x.PublicationType,"A")
    //            .CheckProperty(x => x.PublicationUrl, "http://localhost:8080")
    //            .CheckProperty(x => x.PublicationVisitorsQty, 123)
    //            .CheckProperty(x => x.VehicleLocPart, 1)
    //            .CheckProperty(x => x.VehicleLocProv, 1)
    //            .CheckProperty(x => x.VehicleLocLoc, 1)
    //            .CheckProperty(x => x.VehicleColor, 1)
    //            .CheckProperty(x => x.VehicleFirstOwner, true)
    //            .CheckProperty(x => x.VehicleFuelType, 1)
    //            .CheckProperty(x => x.VehicleKm, 353434)
    //            .CheckProperty(x => x.VehicleMake, 1)
    //            .CheckProperty(x => x.VehicleModel, 1)
    //            .CheckProperty(x => x.VehicleVersion, 1)
    //            .CheckProperty(x => x.VehiclePicQty, 12)
    //            .CheckProperty(x => x.VehiclePrice, 15000.00)
    //            .CheckProperty(x => x.VehiclePriceCurrency, 1)
    //            .CheckProperty(x => x.VehicleSegment, 1)
    //            .CheckProperty(x => x.VehicleStatus, 1)
    //            .CheckProperty(x => x.VehicleType, 1)
    //            .CheckProperty(x => x.VehicleYear, 1978)
    //            .CheckProperty(x => x.UserUid, 1)
    //            .CheckProperty(x => x.UserType, "con")
    //            .VerifyTheMappings();
    //    }

    //    [Test]
    //    public void Test_PublicationAttribute()
    //    {
    //        new PersistenceSpecification<PublicationAttr>(_session)
    //            .CheckProperty(x => x.AttrKey, "1")
    //            .CheckProperty(x => x.AttrType, "string")
    //            .CheckProperty(x => x.AttrValue, "value1")
    //            .CheckProperty(x => x.IndexationEntityId, 131136) //tiene que existir en la INDEX_TABLE!!!
    //            .VerifyTheMappings();
    //    }

    //    [Test]
    //    public void Test_EquipmentAttribute()
    //    {
    //        new PersistenceSpecification<EquipmentAttr>(_session)
    //            .CheckProperty(x => x.AttrKey, "1")
    //            .CheckProperty(x => x.AttrType, "string")
    //            .CheckProperty(x => x.AttrValue, "value1")
    //            .CheckProperty(x => x.IndexationEntityId, 131136)//tiene que existir en la INDEX_TABLE!!!
    //            .VerifyTheMappings();
    //    }
    //}
}
