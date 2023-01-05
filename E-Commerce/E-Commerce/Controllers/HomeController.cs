using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Entity;
using E_Commerce.Models;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            var urunler = _context.Products
                .Where(i => i.IsPromoted)
                .Select(i => new ProductModel()
                {
                   ID=i.ID,
                   ProductName=i.ProductName,
                   ProductDescription=i.ProductDescription.Length>50?i.ProductDescription.Substring(0,150)+"...":i.ProductDescription,
                   UnitPrice=i.UnitPrice,
                   UnitInStock=i.UnitInStock,
                   PictureURL=i.PictureURL ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                    CategoryID =i.CategoryID
                }).ToList();
            return View(urunler);
        }

        public ActionResult Details(int id)
        {
            var urun=_context.Products.Where(i=>i.ID==id).Select(i=>new ProductModel(){
                   ID = i.ID,
                   ProductName = i.ProductName,
                   SKU=i.SKU,
                   ProductDescription = i.ProductDescription,
                   UnitPrice = i.UnitPrice,
                   UnitInStock = i.UnitInStock,
                   PictureURL = i.PictureURL ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                   CategoryID = i.CategoryID
            }).FirstOrDefault();
            return View(urun);
        }

        public ActionResult List(int id)
        {
            var urunler = _context.Products
                .Where(i => i.CategoryID==id)
                .Select(i => new ProductModel()
                {
                    ID = i.ID,
                    ProductName = i.ProductName,
                    ProductDescription = i.ProductDescription.Length > 50 ? i.ProductDescription.Substring(0, 150) + "..." : i.ProductDescription,
                    UnitPrice = i.UnitPrice,
                    UnitInStock = i.UnitInStock,
                    PictureURL = i.PictureURL ?? "https://i0.wp.com/mobitek.com/wp-content/uploads/2019/11/google-alisveris-reklamlari.jpg",
                    CategoryID = i.CategoryID,
                }).ToList();
            return View(urunler);
        }
        public ActionResult Login()
        {
            return View();        
        }
        public ActionResult Signin()
        {
            return View();
        }
        
    }
}