using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Buscador.Web.Controllers;
using Commons.Collections;
using NVelocity.App;
using NVelocity.Context;
using Spring.Template.Velocity;

namespace Buscador.Web
{
    //public class NVelocityViewEngine : MultipleSiteViewEngine
    //{
    //    public VelocityEngine VelocityEngine { get; set; }

    //    public IContext VelocityContext { get; set; }

    //    public NVelocityViewEngine()
    //    {
    //        ViewLocationFormats = new[] { "{0}/{1}/{2}.aspx"};

    //        PartialViewLocationFormats = ViewLocationFormats;
    //    }

    //    public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
    //    {
    //        var siteName = ((SearcherController) controllerContext.Controller).SiteName;
    //        CurrentSite = siteName;
    //        var controllerName = controllerContext.RouteData.Values["controller"].ToString();
    //        var actionName = controllerContext.RouteData.Values["action"].ToString();
    //        var viewPath = string.Format(ViewLocationFormats[0], controllerName, siteName, actionName);
    //        var nVelocityView = CreateView(controllerContext, viewPath, masterName);
    //        return new ViewEngineResult(nVelocityView,this);
    //    }

    //    protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
    //    {
    //        return new WebFormView(partialPath, null);
    //    }

    //    protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
    //    {
    //        return base.CreateView(controllerContext, viewPath, masterPath);
    //    }
    //}
}