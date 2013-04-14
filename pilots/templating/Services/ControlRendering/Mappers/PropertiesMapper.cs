using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Services.Helpers;

namespace Services.ControlRendering.Mappers
{
    public class PropertyMapper
    {
        private readonly XmlNode xmlControl;

        public PropertyMapper(XmlNode xmlNode)
        {
            xmlControl = xmlNode;
        }

        public string GetID()
        {
            return xmlControl.GetAttribute("CCLAVE");
        }

        public string GetDefault()
        {
            return xmlControl.GetAttribute("CDEFAULT");
        }

        public string GetName()
        {
            return xmlControl.GetAttribute("CNOMBRE").Trim();
        }

        public Decimal GetMinValue()
        {
            return Convert.ToDecimal(xmlControl.GetAttribute("NMINIMO"), new System.Globalization.CultureInfo("en-US"));
        }

        public Decimal GetMaxValue()
        {
            return Convert.ToDecimal(xmlControl.GetAttribute("NMAXIMO"), new System.Globalization.CultureInfo("en-US"));
        }

        public DateTime GetMinDate()
        {
            return Convert.ToDateTime(xmlControl.GetAttribute("DMINDATE"));
        }

        public int GetMaxLength()
        {
            return Convert.ToInt16(xmlControl.GetAttribute("NLARGOMAX"));
        }

        public DateTime GetMinLength()
        {
            return Convert.ToDateTime(xmlControl.GetAttribute("NLARGOMIN"));
        }

        public DateTime GetMaxDate()
        {
            return Convert.ToDateTime(xmlControl.GetAttribute("DMAXDATE"));
        }
        
        public XmlNode GetValuesNode()
        {
            return xmlControl.GetNode("VALORES");
        }

        public bool Required()
        {
            var value = xmlControl.GetAttribute("LVACIO");
            return (value == "1") ? true : false;
        }

        public bool ReadOnly()
        {
            var value = xmlControl.GetAttribute("LMODIFICABLE");
            return (value == "1") ? false : true;
        }

        
    }
}
