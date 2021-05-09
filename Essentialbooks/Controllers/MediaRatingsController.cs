using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Essentialbooks.Models;
using Microsoft.AspNet.Identity;

namespace Essentialbooks.Controllers
{
    public class MediaRatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MediaRatings
        public ActionResult Index()
        {
            var mediaRatings = db.MediaRatings.Include(m => m.TextPiece).Include(m => m.User);
            return View(mediaRatings.ToList());
        }

        // GET: MediaRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaRating mediaRating = db.MediaRatings.Find(id);
            if (mediaRating == null)
            {
                return HttpNotFound();
            }
            return View(mediaRating);
        }

        // GET: MediaRatings/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.MediaId = new SelectList(db.TextPieces, "Id", "Title");
                //   ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email");
                return View();
            }
            else
                return RedirectToAction("Index","Home");
        }

        // POST: MediaRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MediaId,Rating")] MediaRating mediaRating)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);


                var zz = db.MediaRatings.Where(x => x.UserId == currentUserId);
               var yy = zz.Where(x => x.MediaId == mediaRating.MediaId);

                mediaRating.UserId = currentUserId;

                if (yy.FirstOrDefault() != null)
                {

                    MediaRating oldNewMediaRating = yy.FirstOrDefault();
                    oldNewMediaRating.Rating = mediaRating.Rating;              

                    db.Entry(oldNewMediaRating).State = EntityState.Modified;

                }
                else
                {
                    db.MediaRatings.Add(mediaRating);
                }
                
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MediaId = new SelectList(db.TextPieces, "Id", "Title", mediaRating.MediaId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", mediaRating.UserId);
            return View(mediaRating);
        }

        // GET: MediaRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaRating mediaRating = db.MediaRatings.Find(id);
            if (mediaRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.MediaId = new SelectList(db.TextPieces, "Id", "Title", mediaRating.MediaId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", mediaRating.UserId);
            return View(mediaRating);
        }

        // POST: MediaRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MediaId,Rating,UserId")] MediaRating mediaRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MediaId = new SelectList(db.TextPieces, "Id", "Title", mediaRating.MediaId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", mediaRating.UserId);
            return View(mediaRating);
        }

        // GET: MediaRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaRating mediaRating = db.MediaRatings.Find(id);
            if (mediaRating == null)
            {
                return HttpNotFound();
            }
            return View(mediaRating);
        }

        // POST: MediaRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaRating mediaRating = db.MediaRatings.Find(id);
            db.MediaRatings.Remove(mediaRating);
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
