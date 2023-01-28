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
    public class ReviewController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Review
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.Product).Select(i => new ReviewModel()
            {
                ID = i.ID,
                ProductID = i.ProductID,
                SenderName = i.SenderName,
                Content = i.Content,
                Date = i.Date,
                Ranking = i.Ranking,
                Product = i.Product,
            }).OrderByDescending(b => b.Date).ToList();


            return View(reviews);
        }

        // GET: Review/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);

            if (review == null)
            {
                return HttpNotFound();
            }

            ReviewModel reviewModel = new ReviewModel()
            {
                ID = review.ID,
                SenderName = review.SenderName,
                Ranking = review.Ranking,
                Date = review.Date,
                Content = review.Content,
                ProductID = review.ProductID,
                Product = review.Product,
            };

            return View(reviewModel);
        }

        // GET: Review/Create
        [HttpGet]
        [Authorize]
        public ActionResult Create(int id)
        {
            ReviewModel reviewModel = new ReviewModel();
            reviewModel.ProductID = id;

            return View(reviewModel);
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Date,SenderName,ProductID,Ranking,Content,Product")] ReviewModel reviewModel)
        {
            if (ModelState.IsValid)
            {
                reviewModel.Date = DateTime.Now;
                reviewModel.SenderName = User.Identity.Name;

                Review review = new Review()
                {
                    ID = reviewModel.ID,
                    SenderName = reviewModel.SenderName,
                    Ranking = reviewModel.Ranking,
                    Date = reviewModel.Date,
                    Content = reviewModel.Content,
                    ProductID = reviewModel.ProductID,
                    Product = reviewModel.Product,
                };

                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ProductID = new SelectList(db.Products, "Id", "SKU", reviewModel.ProductID);
            return View(reviewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
