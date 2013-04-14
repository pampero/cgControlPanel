using System;
using System.Web.Security;
using Services.Security.Interface;

namespace Services.Security.impl
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public void RedirectFromLoginPage(string userName, bool isPersisted)
        {
            FormsAuthentication.RedirectFromLoginPage(userName, isPersisted);
        }
    }
}
