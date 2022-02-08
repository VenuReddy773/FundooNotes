﻿using BusinessLayer.Interface;
using CommonLayer.User;
using Experimental.System.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        FundooDbContext fundooDBContext;
        IUserBL userBL;
        public UserController(IUserBL userBL, FundooDbContext fundooDB)
        {
            this.userBL = userBL;
            this.fundooDBContext = fundooDB;
        }
        [HttpPost]
        public ActionResult RegisterUser(UserPostModel userPostModel)
        {
            try
            {
                this.userBL.RegisterUser(userPostModel);
                return this.Ok(new { success = true, message = $"Registration Successful  {userPostModel.email}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public ActionResult login(UserLogin userLogin)
        {
            try
            {
                string result=this.userBL.login(userLogin);
                return this.Ok(new { success = true, message = $"Login Successful,Token={result}"});
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [AllowAnonymous]
        [HttpPut]
        public ActionResult ResetPassword(string email,string password,string Cpassword)
        {
            try
            {
                if (password != Cpassword)
                {
                    return this.BadRequest(new { success = false, message = $"Passwords are not same" });
                }
                var Identity = User.Identity as ClaimsIdentity;
                if (Identity != null)
                {
                    IEnumerable<Claim> claims = Identity.Claims;
                    var UserEmailObject = claims.Where(p => p.Type == @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    this.userBL.ResetPassword(UserEmailObject,password,Cpassword);
                    return Ok(new { success = true, message = "Password Changed Sucessfully" });
                }
                return Ok(new { success = false, message = "Password not Changed" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult forgotpassword(string email)
        {
            try
            {
                this.userBL.forgotpassword(email);
                return this.Ok(new { success = true, message = $"The link has been sent to {email}, please check your email to reset your password..." });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            try
            {
                var result = this.userBL.GetAllUsers();
                return this.Ok(new { success = true, message = $"Below are the User data", data = result });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}