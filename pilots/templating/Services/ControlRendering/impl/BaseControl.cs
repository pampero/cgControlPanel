using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using DevExpress.Web.ASPxEditors;
using Services.ControlRendering.Mappers;

namespace Services.ControlRendering.impl
{

    public class BaseControl
    {
        protected List<WebControl> _Controls;
        protected PropertyMapper _PropertyMapper;

        public void Initialize(XmlNode xmlControl)
        {
            _Controls = new List<WebControl>();
            _PropertyMapper = new PropertyMapper(xmlControl);

            _Controls.Add(new ASPxLabel { Text = _PropertyMapper.GetName() });
        }
    }
}
