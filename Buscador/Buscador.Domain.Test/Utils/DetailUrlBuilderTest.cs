using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.utils;
using NUnit.Framework;
using Spring.Testing.NUnit;

namespace Buscador.Domain.Test.Utils
{
    [TestFixture]
    public class DetailUrlBuilderTest 
    {
        [Test]
        public void BuildSearchUrlFor_Should_Return_SearchUrlFormatText()
        {


            var publication = new Publication
                                  {
                                      
                                      VehicleMakeText = "Volkswagen",
                                      VehicleModelText = "Gol",
                                      VehicleMake = 395,
                                      VehicleModel = 1950,
                                      PublicationVisitorsQty = 998,
                                      VehicleType = 1
                                  };

            var detailUrlBuilder = new DetailUrlBuilder
                                       {
                                           UrlOfuscator = new OfuscatorStub()
                                       };

        Assert.AreEqual("autos-usados-volkswagen/VTYY1WWMAYY395WWMOYY1950",detailUrlBuilder.BuildSearchUrlFor(publication));
        }
    }

    public class OfuscatorStub : IUrlOfuscator
    {
        public string Ofuscate(string url)
        {
            throw new NotImplementedException();
        }

        public HybridDictionary OfuscatedCharacters
        {
            get
            {
                var characters=new HybridDictionary();
                characters.Add("&","WW");
                characters.Add("=","YY");
                return characters;
            }
            set { throw new NotImplementedException(); }
        }
    }
}
