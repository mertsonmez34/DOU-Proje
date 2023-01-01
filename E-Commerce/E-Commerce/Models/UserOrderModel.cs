using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_Commerce.Entity;

namespace E_Commerce.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public EnumOrderState OrderState { get; set; }
        public DateTime OrderDate { get; set; }
    }
}