using System;
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
    public class QuestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quests
        public ActionResult Index(string searchString)
        {

            var quests = from q in db.Quests.Include("Topic").Include("ETA")
                         select q;

            var Themelist = new List<string>();

            var ThemeQry = from x in db.Quests
                           orderby x.Topic.theme
                           select x.Topic.theme;

            Themelist.AddRange(ThemeQry.Distinct());

            ViewBag.questTopic = new SelectList(Themelist);

            if (!string.IsNullOrEmpty(searchString))
            {
                quests = quests.Where(y => y.Title.Contains(searchString) || y.Topic.theme.Contains(searchString));
            }
            return View(quests);
        }
        public ActionResult AddToProfile([Bind(Include = "Quest_ID,Title,Description,ETA_ID,TopicID,isFlagged,Labors")] int? id)
        {

            //get - set user id, get - set quest ID, set UserQuest table to defualt, change quest to ACTIVE (true)  
            string userId = User.Identity.GetUserId();
            UserQuest userquest = new UserQuest();
            userquest.Quest_ID = (int)id;
            userquest.Id = userId;
            userquest.isActive = true; 
            userquest.isComplete = false;
            userquest.rating = null;
            userquest.Target = null;

            db.UserQuests.Add(userquest);
            db.SaveChanges();
            
            List<Labor> LaborsToAdd = (from x in db.Labors where x.Quest_ID == id select x).ToList();

            foreach(Labor labor in LaborsToAdd)
            {
                UserLabor userlabor = new UserLabor();
                userlabor.Labor_ID = labor.Labor_ID;
                userlabor.Id = userId;
                userlabor.UserQuestid = userquest.UserQuestid;
                userlabor.isComplete = false;

                db.UserLabors.Add(userlabor);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "UserQuests", new { Id = userId });
            //return RedirectToAction("Index", "UserQuests");
        }

        // GET: Quests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quest quest = db.Quests.Include(x => x.Labors).FirstOrDefault(q => q.Quest_ID == id);
            if (quest == null)
            {
                return HttpNotFound();
            }

            var locations = (from q in db.Labors.Include("Quest")
                             where q.Location != null && id == q.Quest_ID
                             select q).ToList();

            return View(quest);
   
        }

        // GET: Quests/Create
        public ActionResult Create()
        {
            ViewBag.ETA_ID = new SelectList(db.ETAs, "ETA_ID", "TIME");
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "theme");
            return View();
        }

        // POST: Quests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Quest_ID,Title,Description,ETA_ID,TopicID,isFlagged,Labors")] Quest quest)
        {
            if (ModelState.IsValid)
            {
                db.Quests.Add(quest);
                db.SaveChanges();
                return RedirectToAction("Create", "Labors", new { id = quest.Quest_ID });
            }

            ViewBag.ETA_ID = new SelectList(db.ETAs, "ETA_ID", "TIME", quest.ETA_ID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "theme", quest.TopicID);
            return View(quest);
        }

        // GET: Quests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quest quest = db.Quests.Find(id);
            if (quest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ETA_ID = new SelectList(db.ETAs, "ETA_ID", "TIME", quest.ETA_ID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "theme", quest.TopicID);
            return View(quest);
        }

        // POST: Quests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Quest_ID,Title,Description,ETA_ID,TopicID,isFlagged")] Quest quest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ETA_ID = new SelectList(db.ETAs, "ETA_ID", "TIME", quest.ETA_ID);
            ViewBag.TopicID = new SelectList(db.Topics, "TopicId", "theme", quest.TopicID);
            return View(quest);
        }

        // GET: Quests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quest quest = db.Quests.Find(id);
            if (quest == null)
            {
                return HttpNotFound();
            }
            return View(quest);
        }

        // POST: Quests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quest quest = db.Quests.Find(id);
            db.Quests.Remove(quest);
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
