using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using C5;
using DevExpress.Web.ASPxEditors;
using Services.ControlRendering.Mappers;
using Services.Helpers;

namespace Services.ControlRendering.impl
{

    public class Label : BaseControl, IRendereable
    {

        public List<WebControl> RenderControl(XmlNode xmlControl)
        {
            base.Initialize(xmlControl);

            ASPxLabel aspxLabel = (ASPxLabel)_Controls[0];
            aspxLabel.Style.Value = "bold";
            
            return _Controls;
        }

        public string GetValue(string formPrefix, NameValueCollection FormCollection, XmlNode xmlControl)
        {
            return null;
        }
    }
}
