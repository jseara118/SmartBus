using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartBus.Models;

namespace SmartBus.Controllers
{
    [Authorize]
    public class TarifasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tarifas
        public ActionResult Index()
        {
            var tarifas = db.Tarifas.Include(t => t.Ruta);
            return View(tarifas.ToList());
        }

        // GET: Tarifas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifas.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // GET: Tarifas/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RutaId = new SelectList(
                db.Rutas.ToList().Select(r => new {
                    RutaId = r.RutaId,
                    NombreRuta = r.Origen + " → " + r.Destino
                }),
                "RutaId",
                "NombreRuta"
            );

            return View();
        }

        // POST: Tarifas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TarifaId,Precio,RutaId")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                db.Tarifas.Add(tarifa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RutaId = new SelectList(db.Rutas, "RutaId", "Origen", tarifa.RutaId);
            return View(tarifa);
        }

        // GET: Tarifas/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifas.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            ViewBag.RutaId = new SelectList(
            db.Rutas.ToList().Select(r => new {
                RutaId = r.RutaId,
                NombreRuta = r.Origen + " → " + r.Destino
            }),
            "RutaId",
            "NombreRuta",
            tarifa.RutaId
        );
            return View(tarifa);
        }

        // POST: Tarifas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TarifaId,Precio,RutaId")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarifa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RutaId = new SelectList(db.Rutas, "RutaId", "Origen", tarifa.RutaId);
            return View(tarifa);
        }

        // GET: Tarifas/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifas.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // POST: Tarifas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarifa tarifa = db.Tarifas.Find(id);
            db.Tarifas.Remove(tarifa);
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
