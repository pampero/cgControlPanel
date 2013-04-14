using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml;
using System.Web.UI.WebControls;

namespace Services.ControlRendering
{
	public interface IRendereable
	{
	    List<WebControl> RenderControl(XmlNode xmlControl);
        string GetValue(NameValueCollection FormCollection, XmlNode xmlControl);
	}
}
