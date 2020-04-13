using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Carrello.Models;
using Carrello.ViewModels;

namespace Carrello.Controllers
{
    public class ClientiController : Controller
    {
        private AppDBContext db = new AppDBContext();


        // GET: Clienti
        public ActionResult Index()
        {
            return View(db.Clienti.ToList());
        }

        // GET: Clienti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteBase cliente = db.Clienti.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clienti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clienti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ClienteId,ClienteNome")] ClienteBase cliente)
        public ActionResult Create([Bind(Include = "ClienteId,ClienteNome")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clienti.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clienti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clienti.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ClientiViewModel model = new ClientiViewModel();

           List<Articolo> articoli = db.Articoli.Where(O => O.ClienteId == id).ToList();

            model.Cliente = cliente;
            model.ArticoliList = articoli;
           ViewBag.articoli = articoli;
            return View();

           // return View(cliente);
        }

        // POST: Clienti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      //  public ActionResult Edit([Bind(Include = "ClienteId,ClienteNome")] ClienteBase cliente)
            public ActionResult Edit([Bind(Include = "ClienteId,ClienteNome")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clienti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteBase cliente = db.Clienti.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        public ActionResult GetArticoli(int id)
        {
            ClientiViewModel model = new ClientiViewModel();
                 Cliente cliente = db.Clienti.FirstOrDefault(u => u.ClienteId== id);
          
       
            var articoli = db.Articoli.Where(O => O.ClienteId == id).ToList();

            model.Cliente = cliente;
            model.ArticoliList = articoli;
            ViewBag.articoli = articoli;
            return View(model);
        }



        // POST: Clienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //  ClienteBase cliente = db.Clienti.Find(id);
            Cliente cliente = db.Clienti.Find(id);
            db.Clienti.Remove(cliente);
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
