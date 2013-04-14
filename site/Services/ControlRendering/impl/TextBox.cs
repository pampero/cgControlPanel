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

    public class TextBox : BaseControl, IRendereable
    {

        public List<WebControl> RenderControl(XmlNode xmlControl)
        {
            base.Initialize(xmlControl);

            ASPxTextBox aspxTextBox = new ASPxTextBox
                                          {
                                              MaxLength = _PropertyMapper.GetMaxLength(),
                                              ID = _PropertyMapper.GetID(),
                                              NullText = "Ingrese un valor",
                                              Width = new Unit(80, UnitType.Percentage),
                                              ReadOnly = _PropertyMapper.ReadOnly()
                                          };

            aspxTextBox.ValidationSettings.SetFocusOnError = true;
            aspxTextBox.ValidationSettings.RequiredField.IsRequired = _PropertyMapper.Required();
            aspxTextBox.ValidationSettings.RequiredField.ErrorText = "Campo Requerido";
            aspxTextBox.ValidationSettings.ValidationGroup = "InputValidation";

            _Controls.Add(aspxTextBox);

            return _Controls;
        }


        public string GetValue(string formPrefix, NameValueCollection formCollection, XmlNode xmlControl)
        {
            _PropertyMapper = new PropertyMapper(xmlControl);

            var tag = _PropertyMapper.GetID();
            
            return "<" + tag + ">" + formCollection[formPrefix + _PropertyMapper.GetID()] + "</" + tag + ">";
          
        }
    }
}
