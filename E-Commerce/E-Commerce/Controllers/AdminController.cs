using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Entity;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(GetTopTenProductModel());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public int GetTotalProductCount()
        {
            return db.Products.ToList().Count();
        }

        public int GetTotalOrdersCount()
        {
            return db.Orders.ToList().Count();

        }

        public int GetTotalProductShownInHomeCount()
        {
            return db.Products.Where(i => i.IsHome).ToList().Count();

        }

        public int GetTotalReviewCount()
        {
            return db.Reviews.ToList().Count();
        }

        public List<ProductModel> GetTopTenProductModel()
        {
            return db.Products.Take(10).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Price = i.Price,
                ProductAvailable = i.ProductAvailable,
                Image = i.Image ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                CategoryId = i.CategoryId,
                Category = i.Category,
                Brand = i.Brand,
                IsApproved = i.IsApproved,
                ChosenOption = i.ChosenOption,
                SKU = i.SKU,
                IsHome = i.IsHome,
                Type = i.Type,
                Reviews = i.Reviews.Select(a => new ReviewModel()
                {
                    ID = a.ID,
                    Product = a.Product,
                    ProductID = a.ProductID,
                    Date = a.Date,
                    SenderName = a.SenderName,
                    Ranking = a.Ranking,
                    Content = a.Content

                }).OrderByDescending(b => b.Date).ToList()

            }).ToList();
        }
    }
}
