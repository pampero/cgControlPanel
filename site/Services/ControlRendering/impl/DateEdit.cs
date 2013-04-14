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
    public class DateEdit : BaseControl, IRendereable
    {
        public List<WebControl> RenderControl(System.Xml.XmlNode xmlControl)
        {
            base.Initialize(xmlControl);

            ASPxDateEdit aspxDateEdit = new ASPxDateEdit
            {
                ID = _PropertyMapper.GetID(),
                ClientInstanceName = _PropertyMapper.GetID(),
                NullText = "Ingrese Fecha",
                MinDate =  _PropertyMapper.GetMinDate(),
                MaxDate = _PropertyMapper.GetMaxDate(),
            };

            aspxDateEdit.ValidationSettings.SetFocusOnError = true;
            aspxDateEdit.ValidationSettings.RequiredField.IsRequired = _PropertyMapper.Required();
            aspxDateEdit.ValidationSettings.RequiredField.ErrorText = "Campo Requerido";
            aspxDateEdit.ValidationSettings.ValidationGroup = "InputValidation";

             try
             {
                 if (xmlControl.GetAttribute("CCONTROLASOC") != null)
                 {
                     aspxDateEdit.ValidationSettings.CausesValidation = true;
                     aspxDateEdit.ErrorText = "Error de Rango - Fecha Inicial debe ser menor a Fecha Final";
                     aspxDateEdit.ClientSideEvents.Validation = "function(s,e){e.isValid = CheckDifference(" + _PropertyMapper.GetID() + ", " + xmlControl.GetAttribute("CCONTROLASOC") + "); }";
                 }
             }
             catch (Exception)
            {
            }

                _Controls.Add(aspxDateEdit);

            return _Controls;
        }


        public string GetValue(string formPrefix, NameValueCollection formCollection, XmlNode xmlControl)
        {
            _PropertyMapper = new PropertyMapper(xmlControl);
            var tag = _PropertyMapper.GetID();

            try
            {
                DateTime dateTime = Convert.ToDateTime(formCollection[formPrefix + _PropertyMapper.GetID()]);

                return "<" + tag + ">" + dateTime.ToString("yyyy/MM/dd") + "</" + tag + ">";
            }
            catch (Exception)
            {
                return "<" + tag + "></" + tag + ">";
            }
            
        }
    }
}
