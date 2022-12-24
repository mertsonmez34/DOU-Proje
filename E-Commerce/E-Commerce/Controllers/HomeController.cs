using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Commerce.Entity;

namespace E_Commerce.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(_context.Products.Where(i => i.IsPromoted && i.ProductAvailable).ToList());
        }

        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(i => i.ID == id).FirstOrDefault());
        }

        public ActionResult List()
        {
            return View(_context.Products.Where(i => i.ProductAvailable).ToList());
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