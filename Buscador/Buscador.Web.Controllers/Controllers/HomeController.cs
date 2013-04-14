using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.slices;
using Buscador.Domain.com.clarin.utils;
using Buscador.Services.com.clarin.services;
using Buscador.Web.Controllers.ViewModels;

namespace Buscador.Web.Controllers.Controllers
{
    public class HomeController : SearcherController
    {
        public IIndexService<Publication> IndexService { get; set; }
        public IIndexService<PublicationHome> IndexHomeService { get; set; }
        public IDetailUrlBuilder DetailUrlBuilder { get; set; }
        public int RankingPublicationsMaxQty { get; set; }
        public int RankingPublicationQty { get; set; }
        public INewsService NewsService { get; set; }
        public string RssUrl { get; set; }

        public ActionResult Home()
        {
            ViewData["breadcumbs"] = new List<Slice>();
            ViewData["Title"] = "DeAutos";
            ViewData["bannerHeaderHtml"] = "";
            ViewData["vehicleTypeText"] = "nuevos";
            ViewData["bannerMainHtml"] = "";
            ViewData["urlCertifica"] = string.Format("{0}", "/home/inicio");

            var query = QueryOver<Publication>.Property(x => x.State).WithValue("Active").AndProperty(x => x.PublicationDate).Build();

            var publications = IndexService.Query(query, RankingPublicationsMaxQty, new OrderInfo { Direction = "DESC", OrderField = "publication_visitors_qty" })
                .Select(publication => publication).Distinct(new PublicationComparer()).Take(RankingPublicationQty);
            var homeViewModel = new HomeViewModel
                                    {
                                        RankingResults = publications.Select(publication => new RankingResult(publication.VehicleMakeText, publication.VehicleModelText, DetailUrlBuilder.BuildSearchUrlFor(publication))).ToList()
                                    };
            return View("Home", homeViewModel);
        }

        [ChildActionOnly]
        public ActionResult News()
        {
            var news = NewsService.GetLastestFrom(RssUrl);
            return PartialView("News", news);
        }
    }
}
