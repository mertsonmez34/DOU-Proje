using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Orders
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int OrderNumber { get; set; }
        public int PaymentID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int ShipperID { get; set; }
        public int TransactSatatus { get; set; }
        public bool IsDeleted { get; set; }
        public double TotalPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public virtual List<OrderLine> Orderlines { get; set; }
    }

    public class OrderLine
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Orders Order { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}