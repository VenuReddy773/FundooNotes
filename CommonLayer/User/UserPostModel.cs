using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.User
{
    public class UserPostModel
    {
        public string firstName { get; set; }        
        public string lastName { get; set; }
        public string phoneNo { get; set; }
        public string address { get; set; }

        [RegularExpression(@"^[^\s@]+@[^\s@]+\.[^\s@]+$",
         ErrorMessage = "Please enter correct email address")]
        public string email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
         ErrorMessage = "Please enter Strong Password")]
        public string password { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Please enter Strong Password")]
        public string Cpassword { get; set; }
    }
}
