﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapStone.Models;
using Microsoft.AspNet.Identity;

namespace CapStone.Controllers
{
    public class UserQuestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserQuests
        public ActionResult Index(string Id)
        {
            var userQuests = from a in db.UserQuests.Include("Quest")
                             where a.Id == Id
                             select a; 
            //var userID = db.UserQuests.Include(y => y.Id).FirstOrDefault();
            //Review I want to include userlabors 
           // var userQuests = db.UserQuests.Include(u => u.AspNetUser).Include(u => u.Quest);
            return View(userQuests.ToList());
        }

        // GET: UserQuests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuest userQuest = db.UserQuests.Include(x => x.UserLabors).Include(z => z.Quest).FirstOrDefault(q => q.UserQuestid == id);


            if (userQuest == null)
            {
                return HttpNotFound();
            }
            return View(userQuest);
        }

        // GET: UserQuests/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "Email"); // replaced db.ApplicationUsers with db.Users
            ViewBag.Quest_ID = new SelectList(db.Quests, "Quest_ID", "Title");
            return View();
        }

        // POST: UserQuests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserQuestid,Quest_ID,Id,isActive,isComplete,rating")] UserQuest userQuest)
        {
            if (ModelState.IsValid)
            {
                db.UserQuests.Add(userQuest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userQuest.Id); // replaced db.ApplicationUsers with db.Users
            ViewBag.Quest_ID = new SelectList(db.Quests, "Quest_ID", "Title", userQuest.Quest_ID);
            return View(userQuest);
        }

        // GET: UserQuests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuest userQuest = db.UserQuests.Find(id);
            if (userQuest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userQuest.Id); // replaced db.ApplicationUsers with db.Users
            ViewBag.Quest_ID = new SelectList(db.Quests, "Quest_ID", "Title", userQuest.Quest_ID);
            return View(userQuest);
        }

        // POST: UserQuests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserQuestid,Quest_ID,Id,isActive,isComplete,rating,Target")] UserQuest userQuest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userQuest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Users, "Id", "Email", userQuest.Id); // replaced db.ApplicationUsers with db.Users
            ViewBag.Quest_ID = new SelectList(db.Quests, "Quest_ID", "Title", userQuest.Quest_ID);
            return View(userQuest);
        }

        // GET: UserQuests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserQuest userQuest = db.UserQuests.Find(id);
            if (userQuest == null)
            {
                return HttpNotFound();
            }
            return View(userQuest);
        }

        // POST: UserQuests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserQuest userQuest = db.UserQuests.Find(id);
            db.UserQuests.Remove(userQuest);
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
