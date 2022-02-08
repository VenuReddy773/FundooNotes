using Experimental.System.Messaging;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Class;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmailService
    {
        public static void sendMail(string Email, string token)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {

                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("dummymail88973@gmail.com", "Venu@123");

                MailMessage msgObj = new MailMessage();
                msgObj.To.Add(Email);
                msgObj.From = new MailAddress("dummymail88973@gmail.com");
                msgObj.Subject = "Password Reset Link";
                msgObj.Body = $"FundooNotes/{token}";
                client.Send(msgObj);
            }
        }
    }
}
