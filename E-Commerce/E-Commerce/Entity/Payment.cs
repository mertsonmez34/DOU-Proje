using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Payment
    {
        public int ID { get; set; }
        public string PaymentType { get; set; }
        public bool IsPaymentDone { get; set; }
    }
}