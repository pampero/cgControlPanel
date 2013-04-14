using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain;
using Buscador.Web.Controllers;
using NUnit.Framework;

namespace Buscador.Web.Test
{
    [TestFixture]
    public class WebExtensionsMethodsTest
    {
        [Test]
        public void TestWithThousandsSeparator_10000()
        {
            var num = 10000;
            var withDecimal = num.WithThousandsSeparator();
            Assert.IsTrue(withDecimal=="10.000");
        }

        [Test]
        public void TestWithThousandsSeparator_100000()
        {
            var num = 100000;
            var withDecimal = num.WithThousandsSeparator();
            Assert.IsTrue(withDecimal == "100.000");
        }

        [Test]
        public void TestWithThousandsSeparator_1000000()
        {
            var num = 1000000;
            var withDecimal = num.WithThousandsSeparator();
            Assert.IsTrue(withDecimal == "1.000.000");
        }

        [Test]
        public void Test_Split_String_In_Equals_Parts()
        {
            var stringTest = "* Alta y Baja de dominios.- * Informe de deudas.- * Tramites de Moratoria.- * Transferencia Automotor.- * Duplicados de chapas perdidas.- * Asesoramiento en la documentación.-";
            var parts = stringTest.SplitIntoSentencesOfSize(4);
            Assert.IsNotNull(parts);
        }

        [Test]
        public void Test_Split_Little_String()
        {
            var stringTest = "muchos servicios";
            var parts = stringTest.SplitIntoSentencesOfSize(4);
        }

        [Test]
        public void AsPrice_With_Null_Currency_Should_Return_Same_Text()
        {
            Assert.IsTrue("10".AsPrice(null) == "10");
        }
    }
}
