using System;
using Model;
using Services.Security.Interface;

namespace CGControlPanel.Account
{
    public partial class Login : BasePage
    {
        public IAuthenticationService authenticationService { get; set; }
        public IMembershipService membershipService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                authenticationService.SignOut();
            else
            {
                if (membershipService.ValidateUser(username.Value, password.Value))
                {
                    authenticationService.SignIn(username.Value, RememberMe.Checked);

                    if (Request.QueryString.Count == 0)
                        Response.Redirect(@"\Home.aspx");
                    else
                        authenticationService.RedirectFromLoginPage(username.Value, RememberMe.Checked);
                }
            }
        }
    }
}
