using BusinessLayer.Interface;
using CommonLayer.User;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Class
{
    public class UserBL : IUserBL  
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void RegisterUser(UserPostModel userPostModel)
        {
            try
            {
                userRL.RegisterUser(userPostModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string login(UserLogin userLogin )
        {
            try
            {
                 return userRL.login(userLogin);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void ResetPassword(string email, string password,string Cpassword)
        {
            try
            {
                userRL.ResetPassword(email,password,Cpassword);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool Forgotpassword(string email)
        {
            try
            {
                return userRL.Forgotpassword(email);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                return userRL.GetAllUsers();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
