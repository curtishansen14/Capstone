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
    public class LaborsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Labors
        public ActionResult Index(int? id)
        {
            if( id != null)
            {
                return View(db.Labors.Include(x => x.Quest).Include(y => y.Quest_ID == id).ToList());
            }


            var labors = db.Labors.Include(l => l.ETA).Include(l => l.Quest);
            return View(labors.ToList());
        }

        // GET: Labors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labor labor = db.Labors.Find(id);
            if (labor == null)
            {
                return HttpNotFound();
            }
            return View(labor);
        }

        // GET: Labors/Create
        public ActionResult Create(int? id)
        {
            ViewBag.ETA_ID = new SelectList(db.ETAs, "ETA_ID", "TIME");
            ViewBag.Quest_ID = new SelectList(db.Quests, "Quest_ID", "Title");
            return View();
        }

        // POST: Labors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Labor_ID,Quest_ID,Title,Description,ETA_ID,Location")] Labor labor, int? id)
        {
            if (ModelState.IsValid)
            {
                labor.Quest_ID = (int)id;
                db.Labors.Add(labor);
                db.SaveChanges();
                TempData["Message"] = "Labor Added";
                return RedirectToAction("Create", "Labors", new { id = labor.Quest_ID });
                //return RedirectToAction("Confirmation");
                //return RedirectToAction("Confirmation", new { id = labor.Quest_ID });
            }

            ViewBag.ETA_ID = new SelectList(db.ETAs, "ETA_ID", "TIME", labor.ETA_ID);
            ViewBag.Quest_ID = new SelectList(db.Quests, "Quest_ID", "Title", labor.Quest_ID);
            return View(labor);
        }

        // GET: Labors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labor labor = db.Labors.Find(id);
            if (labor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ETA_ID = new SelectList(db.ETAs, "ETA_ID", "TIME", labor.ETA_ID);
            ViewBag.Quest_ID = new SelectList(db.Quests, "Quest_ID", "Title", labor.Quest_ID);
            return View(labor);
        }

        // POST: Labors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Labor_ID,Quest_ID,Title,Description,ETA_ID,Location")] Labor labor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ETA_ID = new SelectList(db.ETAs, "ETA_ID", "TIME", labor.ETA_ID);
            ViewBag.Quest_ID = new SelectList(db.Quests, "Quest_ID", "Title", labor.Quest_ID);
            return View(labor);
        }

        // GET: Labors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Labor labor = db.Labors.Find(id);
            if (labor == null)
            {
                return HttpNotFound();
            }
            return View(labor);
        }

        // POST: Labors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Labor labor = db.Labors.Find(id);
            db.Labors.Remove(labor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Confirmation(int? id)
        {
            Labor labor = db.Labors.Find(id);
            return View(labor);
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
