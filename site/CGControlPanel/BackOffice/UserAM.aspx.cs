using System;
using System.Web.Security;
using Services.Security.Interface;

namespace CGControlPanel.BackOffice
{
    public partial class UserAM : BasePage
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
            if (!Page.IsPostBack)
            {
                cmbRoles.DataSource = membershipService.GetAllRoles();
                cmbRoles.DataBind();
                cmbRoles.SelectedIndex = 0;

                if (!String.IsNullOrEmpty(Request["UserName"]))
                {
                    ltrlLegend.Text = "Modificación";
                    txtUserName.Disabled = true;
                    var membershipUser = membershipService.GetUser(Request["UserName"]);

                    if (membershipUser != null)
                    {
                        txtEMail.Value = membershipUser.Email;
                        txtUserName.Value = membershipUser.UserName;
                        cmbRoles.Value = membershipService.GetUserRole(membershipUser.UserName);
                        hdnUserId.Value = Request["UserName"];
                    }
                }
                else
                {
                    btnReset.Visible = false;
                    ltrlLegend.Text = "Alta";
                }
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(1000);

                switch (e.Parameter)
                {
                    case "NEW":
                        if (String.IsNullOrEmpty(txtOldPassword.Value))
                            throw new Exception("El campo Clave es requerido!");
                        if (txtOldPassword.Value.Length < membershipService.MinPasswordLength)
                            throw new Exception("El campo Clave debe tener una longitud mínima de " + membershipService.MinPasswordLength + " caracteres!");

                        var membershipCreateStatus = membershipService.CreateUser(txtUserName.Value, txtOldPassword.Value, txtEMail.Value, cmbRoles.Value);
                        
                        if (membershipCreateStatus == MembershipCreateStatus.Success)
                            e.Result = "NEWOK";
                        else
                            throw new Exception(membershipCreateStatus.ToString());
                        break;
                    case "UPDATE":
                        if (!String.IsNullOrEmpty(txtOldPassword.Value) && !String.IsNullOrEmpty(txtPassword.Value))
                        {
                            if (txtOldPassword.Value.Length < membershipService.MinPasswordLength)
                                throw new Exception("El campo Clave debe tener una longitud mínima de " +
                                                    membershipService.MinPasswordLength + " caracteres!");
                            if (txtPassword.Value.Length < membershipService.MinPasswordLength)
                                throw new Exception("El campo Nueva Clave debe tener una longitud mínima de " +
                                                    membershipService.MinPasswordLength + " caracteres!");

                            membershipService.UpdateUser(txtUserName.Value, txtPassword.Value, txtOldPassword.Value,
                                                         txtEMail.Value, cmbRoles.Value);
                        }
                        else 
                        {
                            if (String.IsNullOrEmpty(txtOldPassword.Value) && String.IsNullOrEmpty(txtPassword.Value))
                            {
                                membershipService.UpdateUser(txtUserName.Value, txtPassword.Value, txtOldPassword.Value,
                                                         txtEMail.Value, cmbRoles.Value);
                            }
                            else
                            {
                                throw new Exception(
                                    "Si se desea realizar un cambio de Clave los campos Clave y Nueva Clave son requeridos!");
                            }
                        }

                        e.Result = "UPDATEDOK";
                        break;
                    case "RESETPASSWORD":
                        e.Result = "La nueva Clave es: " + membershipService.ResetPassword(txtUserName.Value);
                        break;
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                    log.Error(Utils.UI.Helper.BuildRecursiveErrorMessage(ex));
                e.Result = Utils.UI.Helper.BuildRecursiveErrorMessage(ex);
            }
        }
    }
}