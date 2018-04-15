using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NASR.Models;

namespace NASR.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reviews
        public ActionResult Index()
        {
            return View(BuildskiResortReviewViewModels(db.Reviews.ToList()));
        }

        public ActionResult ListOfReviewsBySkiResort(int id)
        {
            var skiResortReviews = db.Reviews.Where(s => s.SkiResortId == id).ToList();
            var skiResort = db.SkiResorts.FirstOrDefault(x => x.Id == id);
            ViewBag.SkiResort = skiResort;

            if (skiResort != null)
            {
                return View(skiResortReviews);
            }
            else
            {
                ViewBag.ErrorMessage = "Ski Resort Not Found.";
                return View("Error");
            }

        }

        [NonAction]
        private SkiResortReviewViewModel BuildskiResortReviewViewModel(Review skiResortReview)
        {
            var skiResortNames = db.SkiResorts.ToDictionary(s => s.Id, s => s.Name);
            return new SkiResortReviewViewModel()
            {
                Id = skiResortReview.Id,
                SkiResortName = skiResortNames[skiResortReview.SkiResortId],
                Content = skiResortReview.Content,
                SkiResortId = skiResortReview.SkiResortId,
                NumberOfStars = skiResortReview.NumberOfStars
            };
        }

        [NonAction]
        private List<SkiResortReviewViewModel> BuildskiResortReviewViewModels(List<Review> skiResortReviews)
        {
            List<SkiResortReviewViewModel> skiResortReviewViewModels = new List<SkiResortReviewViewModel>();

            var SkiResortNames = db.SkiResorts.ToDictionary(s => s.Id, s => s.Name);

            foreach(var resortReviews in skiResortReviews)
            {
                skiResortReviewViewModels.Add(new SkiResortReviewViewModel
                {
                    SkiResortId = resortReviews.SkiResortId,
                    Id = resortReviews.Id,
                    SkiResortName = SkiResortNames[resortReviews.SkiResortId],
                    Content = resortReviews.Content,
                    NumberOfStars = resortReviews.NumberOfStars
                });
            }
            return skiResortReviewViewModels;
        }
    

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            SkiResortReviewViewModel skiResortReviewViewModel = BuildskiResortReviewViewModel(review);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(skiResortReviewViewModel);
        }

        // GET: user create brewery review
        public ActionResult UserCreate()
        {
            return View();
        }

        // POST: user create brewery review
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserCreate([Bind(Include = "Id,Content,NumberOfStars,SkiResortId")] Review skiResortReview)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(skiResortReview);
                db.SaveChanges();
                return RedirectToAction("ListOfReviewsBySkiResort", new { id = skiResortReview.SkiResortId });
            }

            return View(skiResortReview);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            var skiResortList = db.SkiResorts.Select(s => s);
            ViewBag.SelectSkiResortList = new SelectList(skiResortList, "Id", "Name");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,NumberOfStars,SkiResortId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            SkiResortReviewViewModel skiResortReviewViewModel = BuildskiResortReviewViewModel(review);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(skiResortReviewViewModel);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,NumberOfStars,SkiResortId")] Review review)
        {
            SkiResortReviewViewModel skiResortReviewViewModel = BuildskiResortReviewViewModel(review);
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skiResortReviewViewModel);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            SkiResortReviewViewModel skiResortReviewViewModel = BuildskiResortReviewViewModel(review);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(skiResortReviewViewModel);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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

    }
}
