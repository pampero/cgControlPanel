using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.Routing;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Services.com.clarin.services.schedule;
using Quartz;
using Quartz.Impl;
using Spring.Context;
using Spring.Context.Support;
using Spring.Template.Velocity;

namespace Buscador.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("ImagesRoute", new Route("Clarin/Content/images/{filename}", new ResourceRouteHandler()));
            routes.Add("ImagesRoute2", new Route("img/{filename}", new ResourceRouteHandler()));
            routes.Add("ScriptsRoute", new Route("Clarin/Scripts/{filename}", new ResourceRouteHandler()));

            routes.MapRoute("datails1", "{seo}/{year}_{id}", new { controller = "autos", action = "showdetails" }, new { year = @"\d+", id = @"\d+" });
            routes.MapRoute("datails2", "{seo}/{id}", new { controller = "autos", action = "showdetails" }, new { id = @"\d+" });

            routes.MapRoute("route3.mvc", "{controller}", new { controller = "home", action = "home" });
            routes.MapRoute("route2.mvc", "{controller}", new { controller = "autos", action = "search" });
            //routes.MapRoute("route2.mvc", "{controller}", new { controller = "autos", action = "index" });
            routes.MapRoute("route1.mvc", "{seo}/{query}", new { controller = "autos", action = "search" });
            routes.MapRoute("route4.mvc", "{controller}/{action}", new {controller = "home", action = "News"});

            routes.MapRoute("agencyDetail", "Agency/Details/{agencyName}",new { controller = "agency", action = "details" });
            routes.MapRoute("routeUrlService", "{controller}/{action}/{query}", new { controller = "agency", action = "details" });
        }

        protected void Application_Start()
        { 
            AreaRegistration.RegisterAllAreas();

            RegisterViewEngines();

            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(typeof(SpringControllerFactory));
            var searchParameterModelBinder = new SearchParametersBinder();// (SearchParametersBinder)(context.GetObject("searchParameterModelBinder"));

            ModelBinders.Binders.Add(typeof(SearchParameters<Publication>), searchParameterModelBinder);
            //ModelBinders.Binders.Add(typeof(SaveSearchParameters), new SaveSearchParametersModelBinder());
        }

        private void RegisterViewEngines()
        {
            ViewEngines.Engines.Clear();
            var viewEngine = new MultipleSiteViewEngine();
            ViewEngines.Engines.Add(viewEngine);
        }
    }

    public class ResourceRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var filename = requestContext.RouteData.Values["filename"] as string;

            if (string.IsNullOrEmpty(filename))
            {
                // return a 404 HttpHandler here
            }
            else
            {
                requestContext.HttpContext.Response.Clear();
                var filepath = string.Empty;

                if (!filename.Contains(".js") && !filename.Contains(".htm"))
                    filepath = requestContext.HttpContext.Server.MapPath("~/Content/images/" + filename);
                else
                    filepath = requestContext.HttpContext.Server.MapPath("~/Scripts/" + filename);

                if (!File.Exists(filepath))
                    filepath = requestContext.HttpContext.Server.MapPath("~/Content/images/");

                requestContext.HttpContext.Response.WriteFile(filepath);
                requestContext.HttpContext.Response.End();
            }
            return null;
        }
    }

    public class SaveSearchParametersModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return new SaveSearchParameters();
        }
    }
}
