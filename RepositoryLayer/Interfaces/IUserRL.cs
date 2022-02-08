using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.User;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        void RegisterUser(UserPostModel userPostModel);
        string login(UserLogin userLogin);
        bool forgotpassword(string email);
        void ResetPassword(string email, string password, string Cpassword );
        List<User> GetAllUsers();
    }
}
