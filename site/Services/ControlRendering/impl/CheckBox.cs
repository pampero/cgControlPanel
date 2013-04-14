using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using DevExpress.Web.ASPxEditors;
using Services.ControlRendering.Mappers;
using Services.Helpers;

namespace Services.ControlRendering.impl
{
    public class CheckBox : BaseControl, IRendereable
    {
        public List<WebControl> RenderControl(XmlNode xmlControl)
        {
            base.Initialize(xmlControl);

            XmlNode valuesNode = _PropertyMapper.GetValuesNode();
            
            foreach (XmlNode xmlValueNode in valuesNode.ChildNodes)
            {
                ASPxCheckBox aspxCheckBox= new ASPxCheckBox
                {
                    ID = "chk" + xmlValueNode.GetAttribute("CCLAVE"),
                    Text = xmlValueNode.GetAttribute("CTEXTO")
                };

                _Controls.Add(aspxCheckBox);
            }

            return _Controls;
        }

        public string GetValue(string formPrefix, NameValueCollection FormCollection, XmlNode xmlControl)
        {
            _PropertyMapper = new PropertyMapper(xmlControl);
            XmlNode valuesNode = _PropertyMapper.GetValuesNode();

            var result = "<" + _PropertyMapper.GetID() + ">";

            foreach (XmlNode xmlValueNode in valuesNode.ChildNodes)
            {
                if (FormCollection[formPrefix + "chk" + xmlValueNode.GetAttribute("CCLAVE")] == "C")
                {
                    result += "<VALUE>" + xmlValueNode.GetAttribute("CCLAVE") + "</VALUE>";
                }
            }

            return result + "</" + _PropertyMapper.GetID() + ">";
        }
    }
}
