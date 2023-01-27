using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Review
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public string SenderName { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        public int Ranking { get; set; }

        public string Content { get; set; }
    }
}