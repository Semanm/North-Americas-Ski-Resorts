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
    public class SkiResortsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SkiResorts
        public ActionResult Index()
        {
            return View(db.SkiResorts.ToList());
        }

        public ActionResult ListSkiResorts()
        {
            return View(db.SkiResorts.ToList());
        }

        public ActionResult Search(string q)
        {
            var skiResorts = db.SkiResorts
                .Where(a => a.Name.Contains(q))
                .ToList();

            return View(skiResorts);
        }

        // GET: SkiResorts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkiResort skiResort = db.SkiResorts.Find(id);
            if (skiResort == null)
            {
                return HttpNotFound();
            }
            return View(skiResort);
        }

        // GET: SkiResorts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkiResorts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,City,State,Address,Zip,SnowFall,NumberOfRuns,NumberOfLifts,Elevation")] SkiResort skiResort)
        {
            if (ModelState.IsValid)
            {
                db.SkiResorts.Add(skiResort);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skiResort);
        }

        // GET: SkiResorts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkiResort skiResort = db.SkiResorts.Find(id);
            if (skiResort == null)
            {
                return HttpNotFound();
            }
            return View(skiResort);
        }

        // POST: SkiResorts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,City,State,Address,Zip,SnowFall,NumberOfRuns,NumberOfLifts,Elevation")] SkiResort skiResort)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skiResort).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skiResort);
        }

        // GET: SkiResorts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkiResort skiResort = db.SkiResorts.Find(id);
            if (skiResort == null)
            {
                return HttpNotFound();
            }
            return View(skiResort);
        }

        // POST: SkiResorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkiResort skiResort = db.SkiResorts.Find(id);
            db.SkiResorts.Remove(skiResort);
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
