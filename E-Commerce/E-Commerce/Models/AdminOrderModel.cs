using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using E_Commerce.Entity;

namespace E_Commerce.Models
{
    public class AdminOrderModel
    {
        public int Id { get; set; }

        [DisplayName("Order Number")]
        public string OrderNumber { get; set; }
        public double Total { get; set; }

        [DisplayName("Order Status")]
        public EnumOrderState OrderState { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        public int Count { get; set; }
    }
}