using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Security.Interface
{
	public interface IAuthenticationService
    {
        void RedirectFromLoginPage(string userName, bool isPersisted);
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

}
