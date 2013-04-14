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
    public class RadioButton : BaseControl, IRendereable
    {
        public List<WebControl> RenderControl(XmlNode xmlControl)
        {
            base.Initialize(xmlControl);

            XmlNode valuesNode = _PropertyMapper.GetValuesNode();
            
            var firstPass = true;
            var groupName = string.Empty;
            var name = string.Empty;

            foreach (XmlNode xmlValueNode in valuesNode.ChildNodes)
            {
                if (firstPass)
                {
                    firstPass = false;
                    groupName = "Group" + _PropertyMapper.GetName();
                    name = _PropertyMapper.GetID();
                }

                ASPxRadioButton aspxRadioButton = new ASPxRadioButton
                {
                    ID = "rad" + xmlValueNode.GetAttribute("CCLAVE"),
                    Text = xmlValueNode.GetAttribute("CTEXTO"),
                    Value = xmlValueNode.GetAttribute("CCLAVE"),
                    ClientInstanceName = name,
                    Checked = (_PropertyMapper.GetDefault() == xmlValueNode.GetAttribute("CCLAVE")) ? true : false,
                    GroupName = groupName
                };

                try
                {
                    if (xmlControl.GetAttribute("CCONTROLASOC") != null)
                    {
                        aspxRadioButton.ClientSideEvents.CheckedChanged = "function(s, e) { if(s.GetChecked()) {" + xmlControl.GetAttribute("CCONTROLASOC") + ".PerformCallback('" + xmlValueNode.GetAttribute("CCLAVE") + "');} }";
                        aspxRadioButton.ClientSideEvents.Init = "function(s, e) { if(s.GetChecked()) {" + xmlControl.GetAttribute("CCONTROLASOC") + ".PerformCallback('" + xmlValueNode.GetAttribute("CCLAVE") + "');} }";
                    }
                }
                catch (Exception)
                {
                }

                _Controls.Add(aspxRadioButton);
            }

            return _Controls;
          
        }

        public string GetValue(string formPrefix, NameValueCollection FormCollection, XmlNode xmlControl)
        {
            _PropertyMapper = new PropertyMapper(xmlControl);
            XmlNode valuesNode = _PropertyMapper.GetValuesNode();
            var result = String.Empty;

            foreach (XmlNode xmlValueNode in valuesNode.ChildNodes)
            {
                if (FormCollection[formPrefix + "rad" + xmlValueNode.GetAttribute("CCLAVE")] == "C")
                {
                    var tag = _PropertyMapper.GetID();
                    return "<" + tag + ">" + xmlValueNode.GetAttribute("CCLAVE") + "</" + tag + ">";
                }
            }

            return result;
        }
    }
}
