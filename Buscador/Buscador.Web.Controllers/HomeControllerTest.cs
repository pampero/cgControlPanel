using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.utils;
using Buscador.Services.com.clarin.services;
using Buscador.Services.com.clarin.services.impl;
using Buscador.Web.Controllers.Controllers;
using Buscador.Web.Controllers.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using Spring.Context.Support;

namespace Buscador.Web.Controllers.Test
{
    [TestFixture]
    public class HomeControllerTest 
    {
        public Mock<IIndexService<Publication>> IndexServiceMock { get; set; }
        public Mock<IDetailUrlBuilder> DetailUrlBuilderMock { get; set; }
        public Mock<IIndexService<PublicationHome>>  IndexServicePublicationHomeMock { get; set; }
        public Mock<INewsService> NewServiceMock { get; set; }

        private int _rankingPublicationQty = 6;
        
        [SetUp]
        public void SetUp()
        {
            IndexServiceMock = new Mock<IIndexService<Publication>>();
            DetailUrlBuilderMock = new Mock<IDetailUrlBuilder>();
            IndexServicePublicationHomeMock = new Mock<IIndexService<PublicationHome>>();
            NewServiceMock = new Mock<INewsService>();
            
            var publications = new List<Publication>
                                   {
                                       new Publication 
                                           {
                                               VehicleMakeText = "Peugeot",
                                               VehicleModelText = "205",
                                               VehicleMake = 385,
                                               VehicleModel = 1892,
                                               PublicationVisitorsQty = 1000
                                           },
                                       new Publication
                                           {
                                               VehicleMakeText = "Volkswagen",
                                               VehicleModelText = "Gol",
                                               VehicleMake = 395,
                                               VehicleModel = 1950,
                                               PublicationVisitorsQty = 998
                                           },
                                       new Publication
                                           {
                                               VehicleMakeText = "Chevrolet",
                                               VehicleModelText = "Corsa II",
                                               VehicleMake = 363,
                                               VehicleModel = 2981,
                                               PublicationVisitorsQty = 800
                                           },
                                       new Publication
                                           {
                                               VehicleMakeText = "Chevrolet",
                                               VehicleModelText = "Aveo",
                                               VehicleMake = 363,
                                               VehicleModel = 2983,
                                               PublicationVisitorsQty = 762
                                           },
                                       new Publication
                                           {
                                               VehicleMakeText = "Ford",
                                               VehicleModelText = "Fiesta",
                                               VehicleMake = 371,
                                               VehicleModel = 1798,
                                               PublicationVisitorsQty = 600
                                           },
                                       new Publication
                                           {
                                               VehicleMakeText = "Susuky",
                                               VehicleModelText = "Fun",
                                               VehicleMake = 391,
                                               VehicleModel = 2677,
                                               PublicationVisitorsQty = 526
                                           },

                                       new Publication
                                           {
                                               VehicleMakeText = "Ford",
                                               VehicleModelText = "Escort",
                                               VehicleMake = 371,
                                               VehicleModel = 1799,
                                               PublicationVisitorsQty = 526
                                           }, 
                                        new Publication
                                           {
                                               VehicleMakeText = "Volkswagen",
                                               VehicleModelText = "Fox",
                                               VehicleMake = 395,
                                               VehicleModel = 1952,
                                               PublicationVisitorsQty = 1023
                                           }, 
                                        
                                   };
            
            IndexServiceMock.Setup(x => x.Query(It.IsAny<List<KeyValuePair<Expression<Func<Publication, object>>, string>>>(),It.IsAny<int>(),It.IsAny<OrderInfo>())).Returns(publications);
            DetailUrlBuilderMock.Setup(x => x.BuildSearchUrlFor(null)).Returns("autos-usados-peugeot/VTYY1WWMAYY385WWMOYY1892");

        }

        [Test]
        public void Can_Parce_Xml_Test()
        {

            
        }

        [Test]
        public void HomeController_Should_Return_RankingResultsList()
        {
            var homeController = new HomeController
                                     {
                                         IndexService = IndexServiceMock.Object,
                                         DetailUrlBuilder = DetailUrlBuilderMock.Object,
                                         IndexHomeService = IndexServicePublicationHomeMock.Object,
                                         RankingPublicationQty = _rankingPublicationQty,
                                         RankingPublicationsMaxQty = 30,
                                         NewsService = NewServiceMock.Object
                                      };
           
            var result = (ViewResult)homeController.Home();
            Assert.IsTrue(((HomeViewModel)result.ViewData.Model).RankingResults.Count  == _rankingPublicationQty);
        }
    }
}
