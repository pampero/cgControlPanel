using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Buscador.Contracts;
using Buscador.Web.Controllers;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;

namespace Buscador.Web
{
    public class SpringControllerFactory : DefaultControllerFactory
    {
        private static IObjectFactory factory;

        //public static void Init(IApplicationContext ctx)
        //{
        //    factory = ctx;
        //}

        public override IController CreateController(RequestContext context, string controllerName)
        {
            try
            {
                if (factory == null)
                    factory = ContextRegistry.GetContext();
                var controllerNameFix = controllerName.Split('-')[0].Split('.')[0];
                var controller = (SearcherController)factory.GetObject(controllerNameFix + "Controller");
                //controller.SiteName = context.RouteData.Values["site"].ToString();
                //if (context.RouteData.Values["action"] == null || context.RouteData.Values["action"].ToString() == "index")
                //    context.RouteData.Values["action"] = "search";

                var iSearchMethods = typeof (ISearch).GetMethods().Select(x => x.Name);

                if(context.RouteData.Values["query"]!=null)
                    if (iSearchMethods.Contains(context.RouteData.Values["query"].ToString()) || context.RouteData.Values["query"].ToString().ToLower()=="print")
                    {
                        context.RouteData.Values["action"] = context.RouteData.Values["query"];
                    }

                context.RouteData.Values["controller"] = controllerNameFix;
                controller.SiteName = "clarin";
                return controller;
            }
            // If the controller is not configured, fall back to base class.
            catch (Exception e)
            {
               return base.CreateController(context, controllerName);
            }
        }

        public override void ReleaseController(IController controller)
        {
            if (controller is IDisposable)
            {
                (controller as IDisposable).Dispose();
            }
            else
            {
                controller = null;
            }
        }
    }
}