using E_Commerce.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string SKU { get; set; }

        [Required(ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }

        [DisplayName("Show on Home")]
        public bool IsHome { get; set; } // anasayfada görüntülenecek mi? (IsPromoted)

        [Required(ErrorMessage = "Description can't be empty")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required(ErrorMessage = "Price can't be empty")]
        public double Price { get; set; }

        [DisplayName("Chosen Option")]
        public string ChosenOption { get; set; }

        [Required(ErrorMessage = "Stock can't be empty")]
        public int Stock { get; set; } // stoktaki adet

        public bool ProductAvailable { get; set; } // ürün var mı

        public virtual List<ReviewModel> Reviews { get; set; }

        [Required(ErrorMessage = "Image URL can't be empty")]
        public string Image { get; set; } // image url

        [DisplayName("Product Available")]
        public bool IsApproved { get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }

    }


}