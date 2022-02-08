using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.User;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        void RegisterUser(UserPostModel userPostModel);
        string login(UserLogin userLogin);
        void ResetPassword(string email, string password, string Cpassword);
        bool forgotpassword(string email);
        List<User> GetAllUsers();
    }
}
