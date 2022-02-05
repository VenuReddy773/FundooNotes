using CommonLayer.User;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Class
{
        public class UserRL : IUserRL
        {
            FundooDbContext dbContext;
            public UserRL(FundooDbContext dbContext)
            {
                this.dbContext = dbContext;
            }
            public void RegisterUser(UserPostModel userPostModel)
            {
                try
                {
                    User user = new User();
                    user.userId = new User().userId;
                    user.firstName = userPostModel.firstName;
                    user.lastName = userPostModel.lastName;
                    user.phoneNo = userPostModel.phoneNo;
                    user.address = userPostModel.address;
                    user.email = userPostModel.email;
                    user.password = userPostModel.password;
                    user.Cpassword = userPostModel.Cpassword;
                    user.registeredDate = DateTime.Now;
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
}
