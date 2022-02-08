using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.User
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int userId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string phoneNo { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string Cpassword { get; set; }
        [Required]
        public DateTime registeredDate { get; set; }
        [Required]
        public DateTime modifiedDate  { get; set; }
    }
}
