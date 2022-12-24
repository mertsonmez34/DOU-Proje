using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Supplier
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int TaxID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebsiteURL { get; set; }
        public string Notes { get; set; }
        public int MessageID { get; set; }
        public string LogoURL { get; set; }
    }
}