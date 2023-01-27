using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter the address description.")]
        [DisplayName("Address Type")]
        public string AddressName { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter district.")]
        public string District { get; set; }

        [Required(ErrorMessage = "Please enter neighborhood.")]
        [DisplayName("Street")]
        public string Neighborhood { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
    }
}