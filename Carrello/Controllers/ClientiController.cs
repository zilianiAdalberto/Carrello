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
        public ActionResult Create([Bind(Include = "ClienteId,ClienteNome")] ClienteBase cliente)
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
            ClienteBase cliente = db.Clienti.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clienti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteId,ClienteNome")] ClienteBase cliente)
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


         public ActionResult<Articolo> GetArticoli(int id)
        {
           
                // var customer = await context.Customers.FindAsync(id);

                //if (customer == null)
                //{
                //    return NotFound();
                //}


                List<Cliente> clienti = await db.Clienti.ToListAsync();
            //   List<Cliente> clienti = await _context.Clienti.ToListAsync();


            //var query = from customer in customers
            //            join ticket in tickets
            //            on customer.CustomerID 
            //            equals  ticket.CustomerID 
            //            where customer.CustomerID == id
            //            select new { TicketID = ticket.TicketID,
            //                        TicketNumber = ticket.TicketBarCode, 
            //                Id = customer.CustomerID, 
            //                Name = customer.Name 
            //            };

            // anonymous type


            //var cliente = _context.Clienti.Include(o=> o.Biglietti).FirstOrDefault(o => o.ClienteID==id);
            var articoli = db.Articoli.Where(O => O.ArticoloId == id).Include(O => O.ClienteId).ToList();                
                
         
            return View(articoli);
        }



        // POST: Clienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteBase cliente = db.Clienti.Find(id);
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
