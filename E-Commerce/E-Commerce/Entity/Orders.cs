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
    }
}