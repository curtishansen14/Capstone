using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapStone.Models;

namespace CapStone.Controllers
{
    public class UserTargetDatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserTargetDates
        public ActionResult Index()
        {
            var userTargetDates = db.UserTargetDates.Include(u => u.AspNetUser);
            return View(userTargetDates.ToList());
        }

        // GET: UserTargetDates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTargetDate userTargetDate = db.UserTargetDates.Find(id);
            if (userTargetDate == null)
            {
                return HttpNotFound();
            }
            return View(userTargetDate);
        }

        // GET: UserTargetDates/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "Email"); // replaced db.ApplicationUsers with db.Users
            return View();
        }

        // POST: UserTargetDates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserTargetDateid,Id,datetime")] UserTargetDate userTargetDate)
        {
            if (ModelState.IsValid)
            {
                db.UserTargetDates.Add(userTargetDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userTargetDate.Id); // replaced db.ApplicationUsers with db.Users
            return View(userTargetDate);
        }

        // GET: UserTargetDates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTargetDate userTargetDate = db.UserTargetDates.Find(id);
            if (userTargetDate == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userTargetDate.Id); // replaced db.ApplicationUsers with db.Users
            return View(userTargetDate);
        }

        // POST: UserTargetDates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTargetDateid,Id,datetime")] UserTargetDate userTargetDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTargetDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userTargetDate.Id); // replaced db.ApplicationUsers with db.Users
            return View(userTargetDate);
        }

        // GET: UserTargetDates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTargetDate userTargetDate = db.UserTargetDates.Find(id);
            if (userTargetDate == null)
            {
                return HttpNotFound();
            }
            return View(userTargetDate);
        }

        // POST: UserTargetDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTargetDate userTargetDate = db.UserTargetDates.Find(id);
            db.UserTargetDates.Remove(userTargetDate);
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
