using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NVelocity;
using NVelocity.Context;
using Spring.Template.Velocity;

namespace Buscador.Web
{
    public class NVelocityView : IView
    {
        private Template _template;
        private IContext _velocityContext;

        public NVelocityView(Template template,IContext velocityContext)
        {
            _template = template;
            _velocityContext = velocityContext;
        }

        public void RenderView(ControllerContext ctlCtx)
        {
            
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            _template.Merge(_velocityContext,writer);
        }
    }
}