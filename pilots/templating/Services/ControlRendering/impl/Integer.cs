using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using C5;
using DevExpress.Web.ASPxEditors;

namespace Services.ControlRendering.impl
{

    public class Integer : BaseControl, IRendereable
    {
        public List<WebControl> RenderControl(System.Xml.XmlNode xmlControl)
        {
            base.Initialize(xmlControl);
            
            ASPxSpinEdit aspxSpinEdit = new ASPxSpinEdit
            {
                ID = _PropertyMapper.GetID(),
                NullText = "Entre " + _PropertyMapper.GetMinValue() + " y " + _PropertyMapper.GetMaxValue(),
                //ReadOnly = _PropertyMapper.ReadOnly(),
                MinValue = _PropertyMapper.GetMinValue(),
                MaxValue = _PropertyMapper.GetMaxValue(),
                NumberType = SpinEditNumberType.Integer
            };

            aspxSpinEdit.SpinButtons.ShowIncrementButtons = false;

            aspxSpinEdit.ValidationSettings.SetFocusOnError = true;
            aspxSpinEdit.ValidationSettings.RequiredField.IsRequired = _PropertyMapper.Required();
            aspxSpinEdit.ValidationSettings.RequiredField.ErrorText = "Campo Requerido";
            aspxSpinEdit.ValidationSettings.ValidationGroup = "InputValidation";

            _Controls.Add(aspxSpinEdit);

            return _Controls; 
        }

        public string GetValue(NameValueCollection formCollection, XmlNode xmlControl)
        {
            base.Initialize(xmlControl);
            var tag = _PropertyMapper.GetID();

            try
            {
                Convert.ToInt32(formCollection[_PropertyMapper.GetID()]);

                return "<" + tag + ">" + formCollection[_PropertyMapper.GetID()] + "</" + tag + ">";
            }
            catch (Exception)
            {
                return  "<" + tag + "></" + tag + ">";
            }
           
        }
    }
}
