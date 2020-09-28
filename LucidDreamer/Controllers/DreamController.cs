using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LucidDreamer.Models;
using Microsoft.AspNet.Identity;

namespace LucidDreamer.Controllers
{
    public class DreamController : Controller
    {
        private LucidDreamerEntities db = new LucidDreamerEntities();

        // GET: Dream
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            ViewBag.user = user;
            return View(db.DreamTexts.ToList());
        }

        // GET: Dream/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DreamText dreamText = db.DreamTexts.Find(id);
            if (dreamText == null)
            {
                return HttpNotFound();
            }
            return View(dreamText);
        }

        // GET: Dream/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dream/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Summary,Lucid,NScenes,NDirectPeople,NBackgroundPeople,NKnownPeople,NFantasyCharacters,NArchitypicalCharacters,NFalseAwakenings,Fly,Run,TFly,TRun,Control,Relate,Real,Yourself,Colorful,RecogniseSurroundings,PastMemories,Emotion,Conflict,Resolution,RelatedConflict,Prophetic,Spiritual,Rating,Insight,Length,DetailedText")] DreamText dreamText)
        {
            if (ModelState.IsValid)
            {
                dreamText.AspId = User.Identity.GetUserId();
                dreamText.Date = DateTime.Now;
                db.DreamTexts.Add(dreamText);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dreamText);
        }

        // GET: Dream/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DreamText dreamText = db.DreamTexts.Find(id);
            if (dreamText == null)
            {
                return HttpNotFound();
            }
            return View(dreamText);
        }

        // POST: Dream/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Summary,Lucid,NScenes,NDirectPeople,NBackgroundPeople,NKnownPeople,NFantasyCharacters,NArchitypicalCharacters,NFalseAwakenings,Fly,Run,TFly,TRun,Control,Relate,Real,Yourself,Colorful,RecogniseSurroundings,PastMemories,Emotion,Conflict,Resolution,RelatedConflict,Prophetic,Spiritual,Rating,Insight,Length,DetailedText")] DreamText dreamText)
        {
            if (ModelState.IsValid)
            {
                dreamText.AspId = User.Identity.GetUserId();
                dreamText.Date = DateTime.Now;
                db.Entry(dreamText).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dreamText);
        }

        // GET: Dream/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DreamText dreamText = db.DreamTexts.Find(id);
            if (dreamText == null)
            {
                return HttpNotFound();
            }
            return View(dreamText);
        }

        // POST: Dream/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DreamText dreamText = db.DreamTexts.Find(id);
            db.DreamTexts.Remove(dreamText);
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
