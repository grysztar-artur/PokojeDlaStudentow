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
    public class KieruneksController : Controller
    {
        private PokojeDlaStudentowEntities db = new PokojeDlaStudentowEntities();

        // GET: Kieruneks
        public ActionResult Index()
        {
            var kierunek = db.Kierunek.Include(k => k.Uczelnia);
            return View(kierunek.ToList());
        }

        // GET: Kieruneks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierunek kierunek = db.Kierunek.Find(id);
            if (kierunek == null)
            {
                return HttpNotFound();
            }
            return View(kierunek);
        }

        // GET: Kieruneks/Create
        public ActionResult Create()
        {
            ViewBag.id_uczelni = new SelectList(db.Uczelnia, "id_uczelni", "nazwa");
            return View();
        }

        // POST: Kieruneks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_kierunku,nazwa,id_uczelni")] Kierunek kierunek)
        {
            if (ModelState.IsValid)
            {
                db.Kierunek.Add(kierunek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_uczelni = new SelectList(db.Uczelnia, "id_uczelni", "nazwa", kierunek.id_uczelni);
            return View(kierunek);
        }

        // GET: Kieruneks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierunek kierunek = db.Kierunek.Find(id);
            if (kierunek == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_uczelni = new SelectList(db.Uczelnia, "id_uczelni", "nazwa", kierunek.id_uczelni);
            return View(kierunek);
        }

        // POST: Kieruneks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_kierunku,nazwa,id_uczelni")] Kierunek kierunek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kierunek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_uczelni = new SelectList(db.Uczelnia, "id_uczelni", "nazwa", kierunek.id_uczelni);
            return View(kierunek);
        }

        // GET: Kieruneks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierunek kierunek = db.Kierunek.Find(id);
            if (kierunek == null)
            {
                return HttpNotFound();
            }
            return View(kierunek);
        }

        // POST: Kieruneks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kierunek kierunek = db.Kierunek.Find(id);
            db.Kierunek.Remove(kierunek);
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
