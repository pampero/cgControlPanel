using System;
using System.Web.Security;
using Services.Security.Interface;

namespace Services.Security.impl
{

    public class FormsMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;
        private readonly RoleProvider _roleProvider;

        public FormsMembershipService()
            : this(null)
        {
        }

        public FormsMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
            _roleProvider = System.Web.Security.Roles.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            return _provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email, string role)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);

            if (status == MembershipCreateStatus.Success)
            {
                string[] users = { userName };
                string[] roles = { role };
                
                ResetRoles(userName);

                _roleProvider.AddUsersToRoles(users , roles);
            }

            return status;
        }

        public bool DeleteUser(string userName)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            string[] users = { userName };

            ResetRoles(userName);

            return _provider.DeleteUser(userName, false);
        }

        public MembershipUser GetUser(string userName)
        {
            return _provider.GetUser(userName, true /* userIsOnline */);
        }

        public void UpdateUser(string userName, string password, string oldPassword, string email, string role)
        {
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

            MembershipUser user = _provider.GetUser(userName, false /* userIsOnline */);

            if (user == null) throw new Exception("Usuario no encontrado");

            user.Email = email;

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(password))
            {
                string[] users = { userName };
                string[] roles = { role };

                ResetRoles(userName);

                _roleProvider.AddUsersToRoles(users, roles);
                _provider.UpdateUser(user);
            }
            else
            {
                if (_provider.ChangePassword(userName, oldPassword, password))
                {
                    _provider.UpdateUser(user);
                }
                else
                {
                    throw new Exception("Ha ocurrido un error al cambiar la clave.");
                }
            }
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }

        public string ResetPassword(string userName)
        {
            return _provider.ResetPassword(userName, "");
        }

        public MembershipUserCollection GetAllUsers()
        {
            int totalRecords = 0;

            return _provider.GetAllUsers(0, 20, out totalRecords);
        }

        public string[] GetAllRoles()
        {
            return _roleProvider.GetAllRoles();
        }

        public string GetUserRole(string userName)
        {
            return _roleProvider.GetRolesForUser(userName)[0];
        }

        private void ResetRoles(string userName)
        {
            string[] users = { userName };

            foreach (var role in _roleProvider.GetRolesForUser(userName))
            {
                if (_roleProvider.IsUserInRole(userName, role))
                {
                    string[] roles = { role };
                    _roleProvider.RemoveUsersFromRoles(users, roles);
                }
            }

        }
    }
}