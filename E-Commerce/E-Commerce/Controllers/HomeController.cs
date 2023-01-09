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
                    CategoryId = i.CategoryId
                }).ToList();

            return View(urunler);
        }

        public ActionResult Details(int id)
        {
            var urun = _context.Products.Where(i => i.Id == id).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                SKU = i.SKU,
                Description = i.Description,
                Price = i.Price,
                Image = i.Image ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                CategoryId = i.CategoryId
            }).FirstOrDefault();
            return View(urun);
        }

        public ActionResult List(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("List/1");
            }

            var urunler = _context.Products
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
                     Brand=i.Brand,
                     Type=i.Type,
                 }).ToList();
            return View(urunler);

        }
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}