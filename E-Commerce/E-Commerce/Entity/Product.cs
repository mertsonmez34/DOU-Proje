using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Product
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public bool IsPromoted { get; set; } // anasayfada görüntülenecek mi?
        public string ProductDescription { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public double UnitPrice { get; set; }
        public string AvailableSize { get; set; } // stokta olan bedenler
        public string AvailableColors { get; set; }  // stokta olan renkler
        public int Discount { get; set; } //indirim
        public int UnitInStock { get; set; } // stoktaki adet
        public short UnitsOnOrder { get; set; } //sipariş edilme sayısı
        public bool ProductAvailable { get; set; } // ürün var mı
        public int DiscountAvailable { get; set; } //indirim var mı
        public string Note { get; set; }
        public string PictureURL { get; set; } // picture url
        public short Ranking { get; set; } //oylama


    }
}