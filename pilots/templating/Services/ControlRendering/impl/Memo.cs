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
    public class Memo : BaseControl, IRendereable
    {
        public List<WebControl> RenderControl(System.Xml.XmlNode xmlControl)
        {
            base.Initialize(xmlControl);

            ASPxMemo aspxMemo = new ASPxMemo
            {
                    ID = _PropertyMapper.GetID(),
                    NullText = "Ingrese Comentario",
                    Rows = 5,
                    Width = new Unit(80, UnitType.Percentage),
                    ReadOnly = _PropertyMapper.ReadOnly()
            };

            _Controls.Add(aspxMemo);

            aspxMemo.ValidationSettings.SetFocusOnError = true;
            aspxMemo.ValidationSettings.RequiredField.IsRequired = _PropertyMapper.Required();
            aspxMemo.ValidationSettings.RequiredField.ErrorText = "Campo Requerido";
            aspxMemo.ValidationSettings.ValidationGroup = "InputValidation";

            return _Controls;
        }

        public string GetValue(NameValueCollection formCollection, XmlNode xmlControl)
        {
            _PropertyMapper = new PropertyMapper(xmlControl);

            var tag = _PropertyMapper.GetID();

            return "<" + tag + ">" + formCollection[_PropertyMapper.GetID()] + "</" + tag + ">";
        }
    }
}
