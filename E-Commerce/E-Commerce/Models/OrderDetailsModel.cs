using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using E_Commerce.Entity;

namespace E_Commerce.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Order Number")]
        public string OrderNumber { get; set; }
        public double Total { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Order Status")]
        public EnumOrderState OrderState { get; set; }

        [DisplayName("Address Type")]
        public string AddressName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        [DisplayName("Street")]
        public string Neighborhood { get; set; }

        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        public virtual List<OrderLineModel> Orderlines { get; set; }
    }

    public class OrderLineModel
    {
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        [DisplayName("Chosen Option")]
        public string ChosenOption { get; set; }
    }
}