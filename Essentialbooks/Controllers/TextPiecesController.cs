using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Essentialbooks.Models;

namespace Essentialbooks.Controllers
{
    public class TextPiecesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TextPieces
        public ActionResult Index()
        {
            var tp = db.TextPieces;
            IEnumerable<TextPiece> tplist =
                from tpitem in tp
             //   where tpitem.Rating > 5
                select tpitem;


            // return View(db.TextPieces.ToList());
            return View(tplist);

        }

        // GET: TextPieces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextPiece textPiece = db.TextPieces.Find(id);
            if (textPiece == null)
            {
                return HttpNotFound();
            }
            return View(textPiece);
        }

        // GET: TextPieces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TextPieces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,Rating")] TextPiece textPiece)
        {
            if (ModelState.IsValid)
            {

                var x = textPiece.Author;

                db.TextPieces.Add(textPiece);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(textPiece);
        }

        // GET: TextPieces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextPiece textPiece = db.TextPieces.Find(id);
            if (textPiece == null)
            {
                return HttpNotFound();
            }
            return View(textPiece);
        }

        // POST: TextPieces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,Rating")] TextPiece textPiece)
        {
            if (ModelState.IsValid)
            {
                db.Entry(textPiece).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(textPiece);
        }

        // GET: TextPieces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextPiece textPiece = db.TextPieces.Find(id);
            if (textPiece == null)
            {
                return HttpNotFound();
            }
            return View(textPiece);
        }

        // POST: TextPieces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TextPiece textPiece = db.TextPieces.Find(id);
            db.TextPieces.Remove(textPiece);
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
