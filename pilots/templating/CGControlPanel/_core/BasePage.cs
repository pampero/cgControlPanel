using System;
using System.Web.UI;
using log4net;

namespace CGControlPanel
{
    public class BasePage : Page
    {
        protected static readonly ILog log = LogManager.GetLogger("LogFileAppender");
      
        //protected string GetThemeCookieName()
        //{
        //    return "MyThemeName";
        //}
         /* Page PreInit */
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //string themeName = "Office2010Blue";
            //if (Page.Request.Cookies[GetThemeCookieName()] != null)
            //{
            //    themeName = Page.Request.Cookies[GetThemeCookieName()].Value;
            //}

            //var clientScriptBlock = "var DXCurrentThemeCookieName = \"" + GetThemeCookieName() + "\";";
            //Page.ClientScript.RegisterClientScriptBlock(GetType(), "DXCurrentThemeCookieName", clientScriptBlock, true);

            //this.Page.Theme = themeName;
        }
    }
}