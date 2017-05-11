using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StationLinerDataEntities.Models;

namespace StationLinerMVC.Controllers
{
    public class NozzlesController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        // GET: Nozzles
        public ActionResult Index()
        {
            var nozzles = db.Nozzles.Include(n => n.NozzleTypes).Include(n => n.Pump);
            return View(nozzles.ToList());
        }

       
        // GET: Nozzles/Create
        public ActionResult Create()
        {
            ViewBag.NozzleType = new SelectList(db.NozzleTypes, "Id", "Name");
            ViewBag.PumpId = new SelectList(db.Pumps, "Id", "Name");
            return View();
        }

        // POST: Nozzles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NozzleName,Description,NozzleType,PumpId,CreatedBy,Status,IsDeleted")] Nozzle nozzle)
        {
            if (ModelState.IsValid)
            {
                nozzle.CreatedBy = User.Identity.GetUserId<int>();
                nozzle.IsDeleted = false;
                db.Nozzles.Add(nozzle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NozzleType = new SelectList(db.NozzleTypes, "Id", "Name", nozzle.NozzleType);
            ViewBag.PumpId = new SelectList(db.Pumps, "Id", "Name", nozzle.PumpId);
            return View(nozzle);
        }

        // GET: Nozzles/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nozzle nozzle = db.Nozzles.Find(id);
            if (nozzle == null)
            {
                return HttpNotFound();
            }
            ViewBag.NozzleType = new SelectList(db.NozzleTypes, "Id", "Name", nozzle.NozzleType);
            ViewBag.PumpId = new SelectList(db.Pumps, "Id", "Name", nozzle.PumpId);
            return View(nozzle);
        }

        // POST: Nozzles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NozzleType,PumpId,CreatedBy,Status,IsDeleted")] Nozzle nozzle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nozzle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NozzleType = new SelectList(db.NozzleTypes, "Id", "Name", nozzle.NozzleType);
            ViewBag.PumpId = new SelectList(db.Pumps, "Id", "Name", nozzle.PumpId);
            return View(nozzle);
        }

        // GET: Nozzles/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nozzle nozzle = db.Nozzles.Find(id);
            if (nozzle == null)
            {
                return HttpNotFound();
            }
            return View(nozzle);
        }

        // POST: Nozzles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Nozzle nozzle = db.Nozzles.Find(id);
            db.Nozzles.Remove(nozzle);
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
