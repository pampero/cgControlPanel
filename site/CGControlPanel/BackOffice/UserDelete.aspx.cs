using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services.Security.Interface;
using System.Web.Security;

namespace CGControlPanel.BackOffice
{
    public partial class UserDelete : BasePage
    {
        public IMembershipService membershipService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            if (!User.IsInRole("Administrador"))
            {
                Response.Redirect(@"\Account\DeniedAccess.aspx");
            }

            base.OnInit(e);

            txtUserName.Disabled = true;
            txtEMail.Disabled = true;
            txtRole.Disabled = true;
        }


        protected void FillUI(MembershipUser user)
        {
            txtUserName.Value = user.UserName;
            txtEMail.Value = user.Email;
            txtRole.Value = membershipService.GetUserRole(user.UserName);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (String.IsNullOrEmpty(Request["UserName"]))
                {
                    return;
                }

                var user = membershipService.GetUser(Request["UserName"]);

                FillUI(user);
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            var user = membershipService.GetUser(Request["UserName"]);

            try
            {
                if (user==null)
                {
                    throw new Exception("Usuario inexistente.");
                }

                switch (e.Parameter)
                {
                    case "DELETE":
                        if (membershipService.DeleteUser(user.UserName))
                        {
                            System.Threading.Thread.Sleep(1000);
                            e.Result = "DELETEDOK";
                        }
                        else
                        {
                            throw new Exception("Usuario inexistente.");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                    log.Error(Utils.UI.Helper.BuildRecursiveErrorMessage(ex));
                e.Result = "Error:\r\n" + Utils.UI.Helper.BuildRecursiveErrorMessage(ex);
            }
        }
    }
}