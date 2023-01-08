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
        [Required(ErrorMessage = "Please Enter Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Surname")]
        [DisplayName("Surname")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Please Enter User Name.")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Email ")]
        [EmailAddress(ErrorMessage = "Entered Invalid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Password Again")]
        [DisplayName("Confirm Password")]
        [Compare("Password",ErrorMessage = "Password Does not Match.")]
        public string RePassword { get; set; }
    }
}