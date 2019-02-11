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
    public class UczelniasController : Controller
    {
        private PokojeDlaStudentowEntities db = new PokojeDlaStudentowEntities();

        // GET: Uczelnias
        public ActionResult Index()
        {
            var uczelnia = db.Uczelnia.Include(u => u.Adres);
            return View(uczelnia.ToList());
        }

        // GET: Uczelnias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uczelnia uczelnia = db.Uczelnia.Find(id);
            if (uczelnia == null)
            {
                return HttpNotFound();
            }
            return View(uczelnia);
        }

        // GET: Uczelnias/Create
        public ActionResult Create()
        {
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc");
            return View();
        }

        // POST: Uczelnias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_uczelni,nazwa,id_adresu")] Uczelnia uczelnia)
        {
            if (ModelState.IsValid)
            {
                db.Uczelnia.Add(uczelnia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", uczelnia.id_adresu);
            return View(uczelnia);
        }

        // GET: Uczelnias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uczelnia uczelnia = db.Uczelnia.Find(id);
            if (uczelnia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", uczelnia.id_adresu);
            return View(uczelnia);
        }

        // POST: Uczelnias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_uczelni,nazwa,id_adresu")] Uczelnia uczelnia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uczelnia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", uczelnia.id_adresu);
            return View(uczelnia);
        }

        // GET: Uczelnias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uczelnia uczelnia = db.Uczelnia.Find(id);
            if (uczelnia == null)
            {
                return HttpNotFound();
            }
            return View(uczelnia);
        }

        // POST: Uczelnias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uczelnia uczelnia = db.Uczelnia.Find(id);
            db.Uczelnia.Remove(uczelnia);
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
