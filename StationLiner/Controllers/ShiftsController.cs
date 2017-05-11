using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth.Messages;
using StationLinerDataEntities.Migrations;
using StationLinerDataEntities.Models;

namespace StationLinerMVC.Controllers
{
    [Authorize]
    public class ShiftsController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        // GET: Shifts
        public ActionResult Index()
        {
            var shifts = db.Shifts.Where(s=>s.IsDeleted == false &&s.ChannelId == Library.ChannelId).Include(s => s.Channels);
            return View(shifts.ToList());
        }


        // GET: Shifts/Create
        public ActionResult Create()
        {
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName");
            return View();
        }

        // POST: Shifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ChannelId,StartTime,EndTime")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                shift.CreatedBy = User.Identity.GetUserId<int>();
                shift.IsDeleted = false;
                shift.Status = true;
                db.Shifts.Add(shift);
                db.SaveChanges();
                Session["success"] = "The Shift has been created";
                return RedirectToAction("Index");
            }

            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", shift.ChannelId);
            return View(shift);
        }

        // GET: Shifts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", shift.ChannelId);
            return View(shift);
        }

        // POST: Shifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ChannelId,StartTime,EndTime,Status")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shift).State = EntityState.Modified;
                db.SaveChanges();
                Session["success"] = "Shift details have been updated";
                return RedirectToAction("Index");
            }
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", shift.ChannelId);
            return View(shift);
        }

        // GET: Shifts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shift shift = db.Shifts.Find(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Shift shift = db.Shifts.Find(id);
            shift.IsDeleted = true;
//            db.Shifts.Remove(shift);
            db.SaveChanges();
            Session["success"] = "Shift has been deleted";
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
