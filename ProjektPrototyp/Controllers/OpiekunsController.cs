using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektPrototyp;

namespace ProjektPrototyp.Controllers
{
    [Authorize]
    public class OpiekunsController : Controller
    {
        private PokojeDlaStudentowEntities db = new PokojeDlaStudentowEntities();

        // GET: Opiekuns
        public ActionResult Index()
        {
            var opiekun = db.Opiekun.Include(o => o.Adres);
            return View(opiekun.ToList());
        }

        // GET: Opiekuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiekun opiekun = db.Opiekun.Find(id);
            if (opiekun == null)
            {
                return HttpNotFound();
            }
            return View(opiekun);
        }

        // GET: Opiekuns/Create
        public ActionResult Create()
        {
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc");
            return View();
        }

        // POST: Opiekuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_opiekuna,imie,nazwisko,telefon,id_adresu")] Opiekun opiekun)
        {
            if (ModelState.IsValid)
            {
                db.Opiekun.Add(opiekun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", opiekun.id_adresu);
            return View(opiekun);
        }

        // GET: Opiekuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiekun opiekun = db.Opiekun.Find(id);
            if (opiekun == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", opiekun.id_adresu);
            return View(opiekun);
        }

        // POST: Opiekuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_opiekuna,imie,nazwisko,telefon,id_adresu")] Opiekun opiekun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opiekun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", opiekun.id_adresu);
            return View(opiekun);
        }

        // GET: Opiekuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opiekun opiekun = db.Opiekun.Find(id);
            if (opiekun == null)
            {
                return HttpNotFound();
            }
            return View(opiekun);
        }

        // POST: Opiekuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opiekun opiekun = db.Opiekun.Find(id);
            db.Opiekun.Remove(opiekun);
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
