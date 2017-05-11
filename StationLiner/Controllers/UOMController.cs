using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StationLinerDataEntities.Models;

namespace StationLinerMVC.Controllers
{
    [Authorize]
    public class UOMController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        // GET: UOM
        public ActionResult Index()
        {
            return View(db.Uom.ToList());
        }

        // GET: UOM/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOM uOM = db.Uom.Find(id);
            if (uOM == null)
            {
                return HttpNotFound();
            }
            return View(uOM);
        }

        // GET: UOM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UOM/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UOMName,UOMDescription")] UOM uOM)
        {
            if (ModelState.IsValid)
            {
                db.Uom.Add(uOM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uOM);
        }

        // GET: UOM/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOM uOM = db.Uom.Find(id);
            if (uOM == null)
            {
                return HttpNotFound();
            }
            return View(uOM);
        }

        // POST: UOM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UOMName,UOMDescription")] UOM uOM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uOM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uOM);
        }

        // GET: UOM/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOM uOM = db.Uom.Find(id);
            if (uOM == null)
            {
                return HttpNotFound();
            }
            return View(uOM);
        }

        // POST: UOM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            UOM uOM = db.Uom.Find(id);
            db.Uom.Remove(uOM);
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
