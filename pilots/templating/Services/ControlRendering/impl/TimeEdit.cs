using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using DevExpress.Web.ASPxEditors;
using Services.ControlRendering.Mappers;

namespace Services.ControlRendering.impl
{
    public class TimeEdit : BaseControl, IRendereable
    {
        public List<WebControl> RenderControl(XmlNode xmlControl)
        {
            base.Initialize(xmlControl);

            ASPxTimeEdit aspxTimeEdit = new ASPxTimeEdit 
            {
                ID = _PropertyMapper.GetID()
            };

            aspxTimeEdit.ValidationSettings.SetFocusOnError = true;
            aspxTimeEdit.ValidationSettings.RequiredField.IsRequired = _PropertyMapper.Required();
            aspxTimeEdit.ValidationSettings.RequiredField.ErrorText = "Campo Requerido";
            aspxTimeEdit.ValidationSettings.ValidationGroup = "InputValidation";

            _Controls.Add(aspxTimeEdit);

            return _Controls;
        }

        public string GetValue(NameValueCollection formCollection, XmlNode xmlControl)
        {
            _PropertyMapper = new PropertyMapper(xmlControl);
            var tag = _PropertyMapper.GetID();

            try
            {
                var dateTime = Convert.ToDateTime(formCollection[_PropertyMapper.GetID()]);

                return "<" + tag + ">" + dateTime.ToString("hh:mm") + "</" + tag + ">";
            }
            catch (Exception)
            {
                return "<" + tag + "></" + tag + ">";
            }
            
        }
    }
}
