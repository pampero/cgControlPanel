using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CG.Services.interfaces;
using DevExpress.Web.ASPxGridView;
using Services.Security.Interface;

namespace CGControlPanel.BackOffice
{
    public partial class Users : System.Web.UI.Page
    {
        public IMembershipService membershipService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            if (!User.IsInRole("Administrador"))
            {
                Response.Redirect(@"\Account\DeniedAccess.aspx");
            }

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            grdUsers.DataSource = membershipService.GetAllUsers();
            grdUsers.PageIndex = 0;
            grdUsers.DataBind();
        }

        public IList<string> NotFilterableColumnFieldNames
        {
            get { return new string[] { "IsApproved" }; }
        }

        protected void grdUsers_AutoFilterCellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (NotFilterableColumnFieldNames.Contains(e.Column.FieldName))
            {
                e.Editor.Parent.Controls.Add(new LiteralControl("&nbsp;"));
                e.Editor.Parent.Controls.Remove(e.Editor);
            }
        }
    }
}