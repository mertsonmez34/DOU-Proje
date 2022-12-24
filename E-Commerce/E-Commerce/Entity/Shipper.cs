using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Shipper
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public bool IsPaymentDone { get; set; }
    }
}