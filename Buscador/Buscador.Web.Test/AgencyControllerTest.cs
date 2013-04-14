using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Buscador.Domain.com.clarin.entities;
using Buscador.Services.com.clarin.services;
using Buscador.Services.com.clarin.services.impl;
using Buscador.Web.Controllers.Controllers;
using NUnit.Framework;
using NUnit.Mocks;

namespace Buscador.Web.Test
{
    [TestFixture]
    public class AgencyControllerTest
    {
        [Test]
        public void Details_Action_Should_Return_Correct_View_Model()
        {
            var agencyIndexServiceMock = new DynamicMock(typeof(IndexServiceAgencySolrImpl));
            var publicationIndexServiceMock = new DynamicMock(typeof(IndexServicePublicationSolrImpl));

            var agency = new Agency
                             {
                                 Address = "Direccion",
                                 Name = "agencia prueba",
                                 UserId = 1
                             };

            var agencysPublication1 = new Publication
                                          {
                                              VehicleMakeText = "Ford",
                                              UserUid = agency.UserId
                                          };

            var agencysPublication2 = new Publication
                                     {
                                         VehicleMakeText = "Peugeot",
                                         UserUid = agency.UserId
                                     };

            var listPublications = new List<Publication>
                                      {
                                          agencysPublication1,
                                          agencysPublication2
                                      };

            var listAgency = new List<Agency>
                                 {
                                     agency
                                 };

            agencyIndexServiceMock.SetReturnValue("Query", listAgency);
            publicationIndexServiceMock.SetReturnValue("Query",listPublications);

            var agencyController = new AgencyController
                                       {
                                           AgencyIndexService = (IndexServiceAgencySolrImpl)agencyIndexServiceMock.MockInstance,
                                           PublicationIndexService = (IndexServicePublicationSolrImpl)publicationIndexServiceMock.MockInstance,
                                       };   

            var viewResult = agencyController.Details("abrahamautomotores");

            Assert.IsNotNull(viewResult);
            Assert.NotNull(viewResult.ViewData["Title"]);
            Assert.True(viewResult.ViewData["Title"].ToString() == "Concesionaria abrahamautomotores");
            Assert.NotNull(viewResult.ViewData["Publications"]);
            Assert.True(((List<Publication>)viewResult.ViewData["Publications"]).Count == listPublications.Count);
            Assert.True(((List<Publication>)viewResult.ViewData["Publications"])[0].VehicleMakeText == listPublications[0].VehicleMakeText);
        }
    }
}
