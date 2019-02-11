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
    public class BudyneksController : Controller
    {
        private PokojeDlaStudentowEntities db = new PokojeDlaStudentowEntities();

        // GET: Budyneks
        public ActionResult Index()
        {
            var budynek = db.Budynek.Include(b => b.Adres).Include(b => b.Opiekun);
            return View(budynek.ToList());
        }

        // GET: Budyneks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budynek budynek = db.Budynek.Find(id);
            if (budynek == null)
            {
                return HttpNotFound();
            }
            return View(budynek);
        }

        // GET: Budyneks/Create
        public ActionResult Create()
        {
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc");
            ViewBag.id_opiekuna = new SelectList(db.Opiekun, "id_opiekuna", "imie");
            return View();
        }

        // POST: Budyneks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_budynku,ilosc_pokoi,ilosc_pieter,czy_winda,id_adresu,id_opiekuna")] Budynek budynek)
        {
            if (ModelState.IsValid)
            {
                db.Budynek.Add(budynek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", budynek.id_adresu);
            ViewBag.id_opiekuna = new SelectList(db.Opiekun, "id_opiekuna", "imie", budynek.id_opiekuna);
            return View(budynek);
        }

        // GET: Budyneks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budynek budynek = db.Budynek.Find(id);
            if (budynek == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", budynek.id_adresu);
            ViewBag.id_opiekuna = new SelectList(db.Opiekun, "id_opiekuna", "imie", budynek.id_opiekuna);
            return View(budynek);
        }

        // POST: Budyneks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_budynku,ilosc_pokoi,ilosc_pieter,czy_winda,id_adresu,id_opiekuna")] Budynek budynek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budynek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", budynek.id_adresu);
            ViewBag.id_opiekuna = new SelectList(db.Opiekun, "id_opiekuna", "imie", budynek.id_opiekuna);
            return View(budynek);
        }

        // GET: Budyneks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Budynek budynek = db.Budynek.Find(id);
            if (budynek == null)
            {
                return HttpNotFound();
            }
            return View(budynek);
        }

        // POST: Budyneks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Budynek budynek = db.Budynek.Find(id);
            db.Budynek.Remove(budynek);
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
