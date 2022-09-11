using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AFIPPersonasWebApp.Data;
using AFIPPersonasWebApp.Models;

namespace AFIPPersonasWebApp.Controllers
{
    public class CodActividadsController : Controller
    {
        private AFIPPersonasWebAppContext db = new AFIPPersonasWebAppContext();

        // GET: CodActividads
        public ActionResult Index()
        {
            return View(db.CodActividads.ToList());
        }

        // GET: CodActividads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodActividad codActividad = db.CodActividads.Find(id);
            if (codActividad == null)
            {
                return HttpNotFound();
            }
            return View(codActividad);
        }

        // GET: CodActividads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodActividads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descripcion,Codigo")] CodActividad codActividad)
        {
            if (ModelState.IsValid)
            {
                db.CodActividads.Add(codActividad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(codActividad);
        }

        // GET: CodActividads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodActividad codActividad = db.CodActividads.Find(id);
            if (codActividad == null)
            {
                return HttpNotFound();
            }
            return View(codActividad);
        }

        // POST: CodActividads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripcion,Codigo")] CodActividad codActividad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codActividad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(codActividad);
        }

        // GET: CodActividads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodActividad codActividad = db.CodActividads.Find(id);
            if (codActividad == null)
            {
                return HttpNotFound();
            }
            return View(codActividad);
        }

        // POST: CodActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodActividad codActividad = db.CodActividads.Find(id);
            db.CodActividads.Remove(codActividad);
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
