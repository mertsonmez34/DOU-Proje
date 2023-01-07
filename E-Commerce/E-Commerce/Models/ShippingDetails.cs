using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter the address description.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Please enter city.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Please enter district.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Please enter neighborhood.")]
        public string Mahalle { get; set; }

        public string PostaKodu { get; set; }
    }
}