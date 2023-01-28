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
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products
                .Include(p => p.Category)
                .Select(i => new ProductModel()
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

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductModel productModel = GetProductModel((int)id);


            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Image,IsHome,IsApproved,CategoryId")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(db.Products.Find(productModel.Id));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", productModel.CategoryId);
            return View(productModel);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductModel productModel = GetProductModel((int)id);

            if (productModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", productModel.CategoryId);

            return View(productModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Image,IsHome,IsApproved,CategoryId")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(db.Products.Find(productModel.Id)).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", productModel.CategoryId);
            return View(productModel);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductModel productModel = GetProductModel((int)id);

            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private ProductModel GetProductModel(int productId)
        {
            var productModel = db.Products.Where(i => i.Id == productId).Select(i => new ProductModel()
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
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
            }).FirstOrDefault();

            return productModel;
        }
    }
}
