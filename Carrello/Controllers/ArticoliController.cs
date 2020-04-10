using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Carrello.Models;

namespace Carrello.Controllers
{
    public class ArticoliController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Articoli
        public ActionResult Index()
        {
            return View(db.Articoli.ToList());
        }

        // GET: Articoli/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articolo articolo = db.Articoli.Find(id);
            if (articolo == null)
            {
                return HttpNotFound();
            }
            return View(articolo);
        }

        // GET: Articoli/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Articoli/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticoloId,ArticoloNome")] Articolo articolo)
        {
            if (ModelState.IsValid)
            {
                db.Articoli.Add(articolo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articolo);
        }

        // GET: Articoli/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articolo articolo = db.Articoli.Find(id);
            if (articolo == null)
            {
                return HttpNotFound();
            }
            return View(articolo);
        }

        // POST: Articoli/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticoloId,ArticoloNome")] Articolo articolo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articolo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articolo);
        }

        // GET: Articoli/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articolo articolo = db.Articoli.Find(id);
            if (articolo == null)
            {
                return HttpNotFound();
            }
            return View(articolo);
        }

        // POST: Articoli/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articolo articolo = db.Articoli.Find(id);
            db.Articoli.Remove(articolo);
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
