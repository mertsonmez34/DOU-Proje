using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Register
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Surname")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Entered Invalid Email.")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password",ErrorMessage = "Password Does not Match.")]
        public string RePassword { get; set; }
    }
}