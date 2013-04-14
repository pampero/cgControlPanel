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
    public class ListBox : BaseControl, IRendereable
    {
        public List<WebControl> RenderControl(XmlNode xmlControl)
        {
            base.Initialize(xmlControl);

            ASPxComboBox aspxListBox = new ASPxComboBox 
            {
                ID = _PropertyMapper.GetID(),
                ClientInstanceName = _PropertyMapper.GetID()
            };

            if (string.IsNullOrEmpty(_PropertyMapper.GetDefault()))
                aspxListBox.SelectedIndex = 0;

            aspxListBox.Callback += new DevExpress.Web.ASPxClasses.CallbackEventHandlerBase(aspxListBox_Callback);
            XmlNode valuesNode = _PropertyMapper.GetValuesNode();

            // Carga los datos de la lista
            foreach (XmlNode xmlValueNode in valuesNode.ChildNodes)
            {
                ListEditItem listEditItem = new ListEditItem();
                
                    listEditItem.Value = xmlValueNode.GetAttribute("CCLAVE");
                    listEditItem.Text = xmlValueNode.GetAttribute("CTEXTO");
                    listEditItem.Selected = (_PropertyMapper.GetDefault() == xmlValueNode.GetAttribute("CCLAVE")) ? true : false;

                    aspxListBox.Items.Add(listEditItem);
                
            }

            try
            {
                if (xmlControl.GetAttribute("CCONTROLASOC") != null)
                {
                    aspxListBox.ClientSideEvents.ValueChanged = "function(s, e) {" + xmlControl.GetAttribute("CCONTROLASOC") + ".PerformCallback(" + _PropertyMapper.GetID() + ".GetValue());}";
                    aspxListBox.ClientSideEvents.Init = "function(s, e) {" + xmlControl.GetAttribute("CCONTROLASOC") + ".PerformCallback(" + _PropertyMapper.GetID() + ".GetValue());}";
                }
            }
            catch (Exception)
            {
            }

            _Controls.Add(aspxListBox);

            return _Controls;
        }

        void aspxListBox_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            XmlNode valuesNode = _PropertyMapper.GetValuesNode();
            string asocKey = e.Parameter;

            ASPxComboBox aspxListBox = (ASPxComboBox)sender;

            aspxListBox.Items.Clear();

            foreach (XmlNode xmlValueNode in valuesNode.ChildNodes)
            {
                ListEditItem listEditItem = new ListEditItem();

                if (xmlValueNode.GetAttribute("CCLAVEASOC") == asocKey)
                {
                    listEditItem.Value = xmlValueNode.GetAttribute("CCLAVE");
                    listEditItem.Text = xmlValueNode.GetAttribute("CTEXTO");

                    aspxListBox.Items.Add(listEditItem);
                }
            }

            aspxListBox.DataBind();
            
        }

        public string GetValue(NameValueCollection formCollection, XmlNode xmlControl)
        {
            _PropertyMapper = new PropertyMapper(xmlControl);

            var tag = _PropertyMapper.GetID();

            return "<" + tag + ">" + formCollection[_PropertyMapper.GetID() + "_VI"] + "</" + tag + ">";
        }
    }
}
