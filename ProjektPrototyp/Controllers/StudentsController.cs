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
    public class StudentsController : Controller
    {
        private PokojeDlaStudentowEntities db = new PokojeDlaStudentowEntities();

        // GET: Students
        public ActionResult Index()
        {
            var student = db.Student.Include(s => s.Adres).Include(s => s.Kierunek).Include(s => s.Pokoj);
            return View(student.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc");
            ViewBag.id_kierunku = new SelectList(db.Kierunek, "id_kierunku", "nazwa");
            ViewBag.id_pokoju = new SelectList(db.Pokoj, "id_pokoju", "id_pokoju");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_studenta,imie,nazwisko,pesel,telefon,id_adresu,id_kierunku,id_pokoju")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Student.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", student.id_adresu);
            ViewBag.id_kierunku = new SelectList(db.Kierunek, "id_kierunku", "nazwa", student.id_kierunku);
            ViewBag.id_pokoju = new SelectList(db.Pokoj, "id_pokoju", "id_pokoju", student.id_pokoju);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", student.id_adresu);
            ViewBag.id_kierunku = new SelectList(db.Kierunek, "id_kierunku", "nazwa", student.id_kierunku);
            ViewBag.id_pokoju = new SelectList(db.Pokoj, "id_pokoju", "id_pokoju", student.id_pokoju);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_studenta,imie,nazwisko,pesel,telefon,id_adresu,id_kierunku,id_pokoju")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_adresu = new SelectList(db.Adres, "id_adresu", "miejscowosc", student.id_adresu);
            ViewBag.id_kierunku = new SelectList(db.Kierunek, "id_kierunku", "nazwa", student.id_kierunku);
            ViewBag.id_pokoju = new SelectList(db.Pokoj, "id_pokoju", "id_pokoju", student.id_pokoju);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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
