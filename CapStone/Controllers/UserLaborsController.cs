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
    public class UserLaborsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserLabors
        public ActionResult Index()
        {
            var userLabors = db.UserLabors.Include(u => u.AspNetUser).Include(u => u.Labor);
            return View(userLabors.ToList());
        }

        // GET: UserLabors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLabor userLabor = db.UserLabors.Include(x => x.Labor).Include(z => z.UserQuest).FirstOrDefault();
            if (userLabor == null)
            {
                return HttpNotFound();
            }
            return View(userLabor);
        }

        // GET: UserLabors/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "Email");
            ViewBag.Labor_ID = new SelectList(db.Labors, "Labor_ID", "Title");
            return View();
        }

        // POST: UserLabors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserLaborId,Labor_ID,Id,isComplete")] UserLabor userLabor)
        {
            if (ModelState.IsValid)
            {
                db.UserLabors.Add(userLabor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userLabor.Id); // replaced db.ApplicationUsers with db.Users
            ViewBag.Labor_ID = new SelectList(db.Labors, "Labor_ID", "Title", userLabor.Labor_ID);
            return View(userLabor);
        }

        public ActionResult Complete(int? id)
        {
            UserLabor userlabor = db.UserLabors.Find(id);
            userlabor.isComplete = true;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: UserLabors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLabor userLabor = db.UserLabors.Find(id);
            if (userLabor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userLabor.Id); // replaced db.ApplicationUsers with db.Users
            ViewBag.Labor_ID = new SelectList(db.Labors, "Labor_ID", "Title", userLabor.Labor_ID);
            return View(userLabor);
        }

        // POST: UserLabors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserLaborId,Labor_ID,Id,isComplete,UserQuestid")] UserLabor userLabor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userLabor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userLabor.Id); // replaced db.ApplicationUsers with db.Users
            ViewBag.Labor_ID = new SelectList(db.Labors, "Labor_ID", "Title", userLabor.Labor_ID);
            return View(userLabor);
        }

        // GET: UserLabors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLabor userLabor = db.UserLabors.Find(id);
            if (userLabor == null)
            {
                return HttpNotFound();
            }
            return View(userLabor);
        }

        // POST: UserLabors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserLabor userLabor = db.UserLabors.Find(id);
            db.UserLabors.Remove(userLabor);
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
