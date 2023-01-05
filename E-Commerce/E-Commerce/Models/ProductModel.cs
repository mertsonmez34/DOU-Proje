using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryID { get; set; }
        public double UnitPrice { get; set; }
        public string AvailableSize { get; set; } // stokta olan bedenler
        public string AvailableColors { get; set; }  // stokta olan renkler
        public int Discount { get; set; } //indirim
        public bool UnitInStock { get; set; } // stoktaki adet
        public short UnitsOnOrder { get; set; } //sipariş edilme sayısı
        public bool ProductAvailable { get; set; } // ürün var mı
        public int DiscountAvailable { get; set; } //indirim var mı
        public string Note { get; set; }
        public string PictureURL { get; set; } // picture url
        public short Ranking { get; set; } //oylama
    }
}