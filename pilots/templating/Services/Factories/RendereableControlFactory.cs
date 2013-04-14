using System;
using System.Collections.Generic;
using System.Linq;
using Services.ControlRendering.impl;

namespace Services.ControlRendering
{
    public static class RendereableControlFactory
    {
        public static IRendereable GetControl(string controlType)
        {
            switch (controlType)
            {
                case "TPENTERO":
                    return new Integer();
                
                case "TPRADIO":
                    return new RadioButton();
                
                case "TPCOMBO":
                    return new ListBox();
                    
                case "TPREAL":
                    return new Real();

                case "TPTEXTO":
                    return new TextBox();

                case "TPFECHA":
                    return new DateEdit();

                case "TPHORA":
                    return new TimeEdit();

                case "TPCHECK":
                    return new CheckBox();

                case "TITULO":
                    return new Label();

                default:
                    break;
            }

            return null;
        }

    }
}
