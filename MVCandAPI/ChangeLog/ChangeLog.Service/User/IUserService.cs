using ChangeLog.Data;
using ChangeLog.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLog.Service.User
{
    public interface IUserService
    {
        string AuthenticateUser(LoginModel login);
        string AuthenticateUser(string email);
        UserInfo GetById(int id);
    }
}
