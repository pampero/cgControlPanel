using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using NUnit.Framework;

namespace Buscador.Domain.Test.entities
{
    [TestFixture]
    public class PublicationTest
    {
         [Test]
         public void AverageRanking_Should_be_Return_2_5()
         {
             Publication publication = new Publication();
             publication.ConfortRanking = 2;
             publication.DesignRanking = 2;
             publication.PriceRanking = 0;
             publication.SecurityRanking = 5;

             Assert.AreEqual(publication.AverageRanking,2.5);
         }
    }
}
