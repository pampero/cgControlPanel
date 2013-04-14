using System.Collections.Generic;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.utils;
using NUnit.Framework;
using Moq;

namespace Buscador.Domain.Test.entities
{
    [TestFixture]
    public class PublicationResultTests
    {
        [Test]
        public void PublicationResult_Foreign_Currency_Shows_Foreign_Price()
        {
            var publication = new Mock<Publication>();

            publication.Setup(x => x.PublishableItemId).Returns(1);
            publication.Setup(x => x.VehicleType).Returns(1);
            publication.Setup(x => x.VehiclePicQty).Returns(1);
            publication.Setup(x => x.PublicationContactsQty).Returns(1);
            publication.Setup(x => x.VehicleMake).Returns(1);
            publication.Setup(x => x.VehicleMakeText).Returns("Clarin");
            publication.Setup(x => x.VehicleModel).Returns(1);
            publication.Setup(x => x.VehicleModelText).Returns("Juan Carlos Altavista");
            publication.Setup(x => x.VehicleVersion).Returns(1);
            publication.Setup(x => x.VehicleVersionText).Returns("Ricardo Montaner");
            publication.Setup(x => x.VehicleSegment).Returns(1);
            publication.Setup(x => x.VehicleSegmentText).Returns("toda estrella tiene contra");
            publication.Setup(x => x.VehicleLocProv).Returns(1);
            publication.Setup(x => x.VehicleLocProvText).Returns("Guadalajara");
            publication.Setup(x => x.VehicleLocPart).Returns(1);
            publication.Setup(x => x.VehicleLocPartText).Returns("Chihuahua");
            publication.Setup(x => x.VehicleLocLoc).Returns(1);
            publication.Setup(x => x.VehicleLocLocText).Returns("Ya no se me ocurre nada");
            publication.Setup(x => x.VehiclePrice).Returns(40000);
            publication.Setup(x => x.CVehiclePriceCurrency.Symbol).Returns("U$S");
            publication.Setup(x => x.VehiclePriceCurrency).Returns(2);
            publication.Setup(x => x.VehicleYear).Returns(3000);
            publication.Setup(x => x.VehicleKm).Returns(18);
            publication.Setup(x => x.VehicleFuelType).Returns(1);
            publication.Setup(x => x.VehicleFuelTypeText).Returns("Energia Atomica");
            publication.Setup(x => x.VehicleFirstOwner).Returns(false);
            publication.Setup(x => x.VehicleColor).Returns(8);
            publication.Setup(x => x.VehicleColorText).Returns("Octavo color");
            publication.Setup(x => x.PaymentMethod).Returns(1);
            publication.Setup(x => x.PaymentMethodText).Returns("Cabras u ovejas");
            publication.Setup(x => x.SellerComment).Returns("Juan carlos");

            publication.Setup(x => x.EquipmentAttributes).Returns(new List<EquipmentAttr>());
            
            var result = new PublicationResult();
            result = result.BuildFrom(publication.Object, new JsonSerializer(), string.Empty, string.Empty);

            Assert.IsTrue(result.PublishableItemData["PUBLISHABLE_ITEM_DATA_PRICE"].AttributeValue.Equals("40000"));
            Assert.IsTrue(result.PublishableItemData["PUBLISHABLE_ITEM_DATA_PRICE_CURRENCY_SYMBOL"].AttributeValue.Equals("U$S"));
        }

        [Test]
        public void PublicationResult_Should_Ignore_Repeated_Equipment()
        {
            var publication = new Mock<Publication>();

            publication.Setup(x => x.PublishableItemId).Returns(1);
            publication.Setup(x => x.VehicleType).Returns(1);
            publication.Setup(x => x.VehiclePicQty).Returns(1);
            publication.Setup(x => x.PublicationContactsQty).Returns(1);
            publication.Setup(x => x.VehicleMake).Returns(1);
            publication.Setup(x => x.VehicleMakeText).Returns("Clarin");
            publication.Setup(x => x.VehicleModel).Returns(1);
            publication.Setup(x => x.VehicleModelText).Returns("Juan Carlos Altavista");
            publication.Setup(x => x.VehicleVersion).Returns(1);
            publication.Setup(x => x.VehicleVersionText).Returns("Ricardo Montaner");
            publication.Setup(x => x.VehicleSegment).Returns(1);
            publication.Setup(x => x.VehicleSegmentText).Returns("toda estrella tiene contra");
            publication.Setup(x => x.VehicleLocProv).Returns(1);
            publication.Setup(x => x.VehicleLocProvText).Returns("Guadalajara");
            publication.Setup(x => x.VehicleLocPart).Returns(1);
            publication.Setup(x => x.VehicleLocPartText).Returns("Chihuahua");
            publication.Setup(x => x.VehicleLocLoc).Returns(1);
            publication.Setup(x => x.VehicleLocLocText).Returns("Ya no se me ocurre nada");
            publication.Setup(x => x.VehiclePrice).Returns(40000);
            publication.Setup(x => x.CVehiclePriceCurrency.Symbol).Returns("U$S");
            publication.Setup(x => x.VehiclePriceCurrency).Returns(2);
            publication.Setup(x => x.VehicleYear).Returns(3000);
            publication.Setup(x => x.VehicleKm).Returns(18);
            publication.Setup(x => x.VehicleFuelType).Returns(1);
            publication.Setup(x => x.VehicleFuelTypeText).Returns("Energia Atomica");
            publication.Setup(x => x.VehicleFirstOwner).Returns(false);
            publication.Setup(x => x.VehicleColor).Returns(8);
            publication.Setup(x => x.VehicleColorText).Returns("Octavo color");
            publication.Setup(x => x.PaymentMethod).Returns(1);
            publication.Setup(x => x.PaymentMethodText).Returns("Cabras u ovejas");
            publication.Setup(x => x.SellerComment).Returns("Juan carlos");

            var equipment = new List<EquipmentAttr>
            {
                new EquipmentAttr("Faros Antiniebla", "No se que va acá", "Faros"),
                new EquipmentAttr("Porta Vasos", "Ni idea", "Porta cosas"),
                new EquipmentAttr("Faros Antiniebla", "No se que va acá", "Faros"),
            };

            var equipmentKeys = new List<string>
            {
                "Faros Antiniebla",
                "Porta Vasos",
                "Faros Antiniebla"
            };

            publication.Setup(x => x.EquipmentAttributesKeys).Returns(equipmentKeys);

            publication.Setup(x => x.EquipmentAttributes).Returns(equipment);
            
            var result = new PublicationResult();

            Assert.DoesNotThrow(() => result.BuildFrom(publication.Object, new JsonSerializer(), string.Empty,
                                                       string.Empty));
        }
    }
}
