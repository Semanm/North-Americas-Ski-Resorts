using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using NASR.CustomAttributes;
using NASR.Models;

namespace NASR.Controllers
{
    public class IdentityRoleController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IdentityRole
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if(role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id, Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if(role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if(role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeOrRedirectAttribute(Roles = "Admin")]
        public ActionResult DeleteConfirmed(string id)
        {
            IdentityRole IdentityRoleTemp = db.Roles.Find(id);
            db.Roles.Remove(IdentityRoleTemp);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}