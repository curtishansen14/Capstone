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
    public class ETAsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ETAs
        public ActionResult Index()
        {
            return View(db.ETAs.ToList());
        }

        // GET: ETAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETA eTA = db.ETAs.Find(id);
            if (eTA == null)
            {
                return HttpNotFound();
            }
            return View(eTA);
        }

        // GET: ETAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ETAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ETA_ID,TIME")] ETA eTA)
        {
            if (ModelState.IsValid)
            {
                db.ETAs.Add(eTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eTA);
        }

        // GET: ETAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETA eTA = db.ETAs.Find(id);
            if (eTA == null)
            {
                return HttpNotFound();
            }
            return View(eTA);
        }

        // POST: ETAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ETA_ID,TIME")] ETA eTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eTA);
        }

        // GET: ETAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ETA eTA = db.ETAs.Find(id);
            if (eTA == null)
            {
                return HttpNotFound();
            }
            return View(eTA);
        }

        // POST: ETAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ETA eTA = db.ETAs.Find(id);
            db.ETAs.Remove(eTA);
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
