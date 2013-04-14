using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

namespace CGControlPanel
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetThemeCookieName()
        {
            return "MyThemeName";
        }

       

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("Utilities", Page.ResolveUrl("~/Scripts/Utilities.js"));
        }

        /* Skins */
        //protected void cbSkins_DataBound(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //    //    ListEditItem item = cbSkins.Items.FindByValue(Page.Theme);
        //    //    if (item == null)
        //    //        item = cbSkins.Items.FindByValue("Glass");
        //    //    if (item != null)
        //    //        cbSkins.SelectedItem = item;
        //    }
        //}
    }
}
