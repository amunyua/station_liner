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
    public class NozzleTypesController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        // GET: NozzleTypes
        public ActionResult Index()
        {
            return View(db.NozzleTypes.ToList());
        }

        // GET: NozzleTypes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NozzleType nozzleType = db.NozzleTypes.Find(id);
            if (nozzleType == null)
            {
                return HttpNotFound();
            }
            return View(nozzleType);
        }

        // GET: NozzleTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NozzleTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Status")] NozzleType nozzleType)
        {
            if (ModelState.IsValid)
            {
                nozzleType.IsDeleted = false;
                nozzleType.CreatedBy = User.Identity.GetUserId<int>();
                db.NozzleTypes.Add(nozzleType);
                db.SaveChanges();
                Session["success"] = "Nozzle Type Created";
                return RedirectToAction("Index");
            }

            return View(nozzleType);
        }

        // GET: NozzleTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NozzleType nozzleType = db.NozzleTypes.Find(id);
            if (nozzleType == null)
            {
                return HttpNotFound();
            }
            return View(nozzleType);
        }

        // POST: NozzleTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,Status,IsDeleted")] NozzleType nozzleType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nozzleType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nozzleType);
        }

        // GET: NozzleTypes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NozzleType nozzleType = db.NozzleTypes.Find(id);
            if (nozzleType == null)
            {
                return HttpNotFound();
            }
            return View(nozzleType);
        }

        // POST: NozzleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            NozzleType nozzleType = db.NozzleTypes.Find(id);
            db.NozzleTypes.Remove(nozzleType);
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
