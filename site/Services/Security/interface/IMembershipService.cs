using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Services.Security.Interface
{
	public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipUser GetUser(string userName);
        MembershipUserCollection GetAllUsers();
        string[] GetAllRoles();
        string GetUserRole(string userName);
        bool DeleteUser(string userName);
        MembershipCreateStatus CreateUser(string userName, string password, string email, string role);
        void UpdateUser(string userName, string password, string oldPassword, string email, string role);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        string ResetPassword(string userName);
    }

}
