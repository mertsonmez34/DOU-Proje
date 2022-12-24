using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string  Description { get; set; }
        public List<Product> Products { get; set; }
    }
}