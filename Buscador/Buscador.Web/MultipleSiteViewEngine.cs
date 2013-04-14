using System;
using System.Web.Mvc;
using Buscador.Web.Controllers;

namespace Buscador.Web
{
    public class MultipleSiteViewEngine : WebFormViewEngine
    {
        public static string CurrentSite { get; protected set; }

        public MultipleSiteViewEngine()
        {
            ViewLocationFormats = new[] { "~/Views/{0}/{1}/{2}.aspx", "~/Views/{0}/{1}/partials/{2}.ascx", "~/Views/{0}/{1}/partials/home/{2}.ascx" };

            PartialViewLocationFormats = ViewLocationFormats;
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var siteName = ((SearcherController)controllerContext.Controller).SiteName;
            CurrentSite = siteName;
            var controllerName = controllerContext.RouteData.Values["controller"].ToString();
            var actionName = controllerContext.RouteData.Values["action"].ToString();
            var viewPath = string.Format(ViewLocationFormats[0], controllerName, siteName, viewName!=string.Empty?viewName:actionName);
            var velocityView = CreateView(controllerContext, viewPath.Replace("/autos/", "/home/").Replace("/Agency/", "/home/").Replace("/agency/", "/home/"), masterName);
            return new ViewEngineResult(velocityView, this);
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            var siteName = ((SearcherController)controllerContext.Controller).SiteName;
            CurrentSite = siteName;
            var controllerName = controllerContext.RouteData.Values["controller"].ToString();
            var viewLocationFormats = controllerName == "home" ? ViewLocationFormats[2] : ViewLocationFormats[1];
            var viewPath = string.Format(viewLocationFormats, controllerName, siteName, partialViewName);
            var partialView = CreatePartialView(controllerContext, viewPath.Replace("/autos/", "/home/").Replace("/Agency/", "/home/").Replace("/agency/", "/home/"));
            return new ViewEngineResult(partialView,this);
        }
    }
}