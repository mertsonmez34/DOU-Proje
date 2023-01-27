using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class CreditCardModel
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "You reached maximum character limit")]
        public string FullName { get; set; }

        [Required]
        [StringLength(maximumLength: 16, MinimumLength = 16, ErrorMessage = "Enter valid card number")]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(maximumLength: 3, MinimumLength = 3, ErrorMessage = "Enter valid CVV number")]
        public string CVV { get; set; }
    }
}