using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using Buscador.Domain.com.clarin.entities;
using Buscador.Services.com.clarin.services;

namespace Buscador.Web.Controllers.Controllers
{
    [HandleError]
    public class AgencyController : SearcherController
    {
        public IIndexService<Agency> AgencyIndexService { get; set; }
        public IIndexService<Publication> PublicationIndexService { get; set; }
        public string ImageUrl { get; set; }

        public ViewResult Details(string agencyName)
        {
            var query = QueryOver<Agency>.Property(x => x.Id).WithValue(agencyName).Build();

            var agency = AgencyIndexService.Query(query).First();

            var queryPublicationFromAgency = QueryOver<Publication>.Property(x => x.UserUid).WithValue(agency.UserId.ToString())
                                                                   //.AndProperty(x=>x.VehicleType).WithValue(1.ToString())
                                                                   .AndProperty(x => x.State).WithValue("Active")
                                                                   .Build();

            var mainPublicationsForAgency = PublicationIndexService.Query(queryPublicationFromAgency, 5);

            ViewData["urlCertifica"] = "/concesionaria/" + agencyName;
            ViewData["Title"] = "Concesionaria " + agencyName;
            ViewData["Publications"] = mainPublicationsForAgency;
            ViewData["ImagesUrl"] = ImageUrl;
            return View("AgencyDetail", agency);
        }
    }
}
