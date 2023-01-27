using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }
        public bool IsHome { get; set; } // anasayfada görüntülenecek mi? (IsPromoted)

        [DisplayName("Product Description")]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public string ChosenOption { get; set; }
        public string AvailableColors { get; set; }  // stokta olan renkler
        public int Discount { get; set; } //indirim
        public int Stock { get; set; } // stoktaki adet
        public short UnitsOnOrder { get; set; } //sipariş edilme sayısı
        public bool ProductAvailable { get; set; } // ürün var mı
        public int DiscountAvailable { get; set; } //indirim var mı
        public string Note { get; set; }
        public string Image { get; set; } // picture url
        public short Ranking { get; set; } //oylama
        public bool IsApproved { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}