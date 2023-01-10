using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Models;
using E_Commerce.Entity;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products
                .Where(i => i.IsHome)
                .Select(i => new ProductModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 50 ? i.Name.Substring(0, 47) + "..." : i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                    CategoryId = i.CategoryId,
                    Brand = i.Brand,
                    Type = i.Type,
                    Reviews = i.Reviews.Select(a => new ReviewModel()
                    {
                        ProductID = a.ProductID,
                        Date = a.Date,
                        SenderName = a.SenderName,
                        Ranking = a.Ranking,
                        Content = a.Content

                    }).OrderByDescending(b => b.Date).ToList()
                }).ToList();

            return View(urunler);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return Redirect("List");
            }

            var productModel = GetProductModel((int)id);

            return View(productModel);
        }

        public ActionResult List(int? id)
        {

            if (id == null)
            {
                return Redirect("List/1");
            }

            var products = _context.Products
                 .Where(i => i.CategoryId == id)
                 .Select(i => new ProductModel()
                 {
                     Id = i.Id,
                     Name = i.Name,
                     Description = i.Description.Length > 50 ? i.Description.Substring(0, 150) + "..." : i.Description,
                     Price = i.Price,
                     //UnitInStock = i.UnitInStock,
                     Image = i.Image ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                     CategoryId = i.CategoryId,
                     Brand = i.Brand,
                     Type = i.Type,
                     Reviews = i.Reviews.Select(a => new ReviewModel()
                     {
                         ProductID = a.ProductID,
                         Date = a.Date,
                         SenderName = a.SenderName,
                         Ranking = a.Ranking,
                         Content = a.Content

                     }).OrderByDescending(b => b.Date).ToList()
                 }).ToList();

            return View(products);

        }

        public int CalculateAverageRanking(int productId)
        {
            var productModel = GetProductModel(productId);

            int averageRanking = 0;

            if (productModel.Reviews.Count() != 0)
            {

                foreach (var item in productModel.Reviews)
                {
                    averageRanking += item.Ranking;
                }

                averageRanking /= productModel.Reviews.Count();
            }

            return averageRanking;
        }

        private ProductModel GetProductModel(int productId)
        {
            var productModel = _context.Products.Where(i => i.Id == productId).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                SKU = i.SKU,
                Description = i.Description,
                Price = i.Price,
                Image = i.Image ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                CategoryId = i.CategoryId,
                Brand = i.Brand,
                Type = i.Type,
                Reviews = i.Reviews.Select(a => new ReviewModel()
                {
                    ProductID = a.ProductID,
                    Date = a.Date,
                    SenderName = a.SenderName,
                    Ranking = a.Ranking,
                    Content = a.Content

                }).OrderByDescending(b => b.Date).ToList()
            }).FirstOrDefault();

            return productModel;
        }

        public string GetReviewDayString(ReviewModel reviewModel)
        {
            TimeSpan difference = DateTime.Now.Subtract(reviewModel.Date);

            int days = difference.Days;
            int minutes = difference.Minutes;
            int hours = difference.Hours;

            if (minutes == 0)
            {
                return "just now";
            }

            string reviewDayText;

            if (days == 0 && hours == 0)
            {
                // show minutes ago
                reviewDayText = minutes + (minutes == 1 ? " minute" : " minutes") + " ago";

            }
            else if (days == 0)
            {
                // show hours ago
                reviewDayText = hours + (hours == 1 ? " hour" : " hours") + " ago";
            }
            else
            {
                // show days ago
                reviewDayText = days + (days == 1 ? " day" : " days") + " ago";
            }

            return reviewDayText;
        }

        public string GetReviewCountString(int productId)
        {
            var productModel = GetProductModel(productId);

            int reviewCount = productModel.Reviews.Count();

            if (reviewCount == 0)
            {
                return "0 Review";
            }
            else
            {
                return reviewCount + (reviewCount == 1 ? " Review" : " Reviews");
            }
        }

        public List<ProductModel> GetSuggestionsList(int CategoryId)
        {
            var products = _context.Products
                 .Where(i => i.CategoryId == CategoryId)
                 .Select(i => new ProductModel()
                 {
                     Id = i.Id,
                     Name = i.Name,
                     Description = i.Description.Length > 50 ? i.Description.Substring(0, 150) + "..." : i.Description,
                     Price = i.Price,
                     Image = i.Image ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                     CategoryId = i.CategoryId,
                     Brand = i.Brand,
                     Type = i.Type,
                     Reviews = i.Reviews.Select(a => new ReviewModel()
                     {
                         ProductID = a.ProductID,
                         Date = a.Date,
                         SenderName = a.SenderName,
                         Ranking = a.Ranking,
                         Content = a.Content

                     }).OrderByDescending(b => b.Date).ToList()
                 }).ToList();

            var relatedProducts = new List<ProductModel>();

            if (products.Count >= 5)
            {
                relatedProducts = products.GetRange((new Random()).Next(0, products.Count - 5), 5);
            }
            else
            {
                for (int i = 0; i < products.Count; i++)
                {
                    relatedProducts.Add(products[i]);

                }
            }

            return relatedProducts;

        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}