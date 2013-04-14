using System;
using System.Xml;

namespace Services.Helpers
{
    public static class XmlHelper
    {

        public static String GetAttribute(this XmlNode xmlNode, String attrName)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (String.Compare(node.Name, attrName, true) == 0)
                {
                    return node.InnerText;
                }      
            }

            return null;
        }

        public static XmlNode GetNode(this XmlNode xmlNode, String attrName)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)
            {
                if (String.Compare(node.Name, attrName, true) == 0)
                {
                    return node;
                }
            }

            return GetNode(xmlNode, attrName);
        }
       
    }
}
