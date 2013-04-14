using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;

namespace CGControlPanel
{
    public partial class DialogMaster : System.Web.UI.MasterPage
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.ClientScript.RegisterClientScriptInclude("Utilities", Page.ResolveUrl("~/Scripts/Utilities.js"));
            Page.ClientScript.RegisterClientScriptInclude("DateFunctions", Page.ResolveUrl("~/Scripts/DateFunctions.js"));
        }
    }
}
