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
    public class GeneralSettingsController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        // GET: GeneralSettings
        public ActionResult Index()
        {
            return View(db.GeneralSettings.ToList());
        }

    

        // POST: GeneralSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CompanyName,VAT,Location,PinNumber,Contact1,Contact2")] GeneralSettings generalSettings)
        {
            if (ModelState.IsValid)
            {
                db.GeneralSettings.Add(generalSettings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(generalSettings);
        }

        // GET: GeneralSettings/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralSettings generalSettings = db.GeneralSettings.Find(id);
            if (generalSettings == null)
            {
                return HttpNotFound();
            }
            return View(generalSettings);
        }

        // POST: GeneralSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CompanyName,VAT,Location,PinNumber,Contact1,Contact2")] GeneralSettings generalSettings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalSettings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(generalSettings);
        }

        // GET: GeneralSettings/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralSettings generalSettings = db.GeneralSettings.Find(id);
            if (generalSettings == null)
            {
                return HttpNotFound();
            }
            return View(generalSettings);
        }

        // POST: GeneralSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            GeneralSettings generalSettings = db.GeneralSettings.Find(id);
            db.GeneralSettings.Remove(generalSettings);
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
