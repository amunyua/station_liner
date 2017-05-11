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
    [Authorize]
    public class PumpsController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();
        private int UserId { get; set; }


        // GET: Pumps
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var pumps = db.Pumps.Where(x=>x.IsDeleted == false && x.CreatedBy == userId ).Include(p => p.Channel);
            return View(pumps.ToList());
        }

       
        // GET: Pumps/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId<int>();
            ViewBag.ChannelId = new SelectList(db.Channels.Where(x=>x.CreatedBy == userId), "Id", "ChannelName");
            return View();
        }

        // POST: Pumps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ChannelId,Status")] Pump pump)
        {
            if (ModelState.IsValid)
            {
                pump.CreatedBy = User.Identity.GetUserId<int>();
                pump.Status = true;
                db.Pumps.Add(pump);
                db.SaveChanges();
                Session["success"] = "Pump Created";
                return RedirectToAction("Index");
            }

            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", pump.ChannelId);
            return View(pump);
        }

        // GET: Pumps/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pump pump = db.Pumps.Find(id);
            if (pump == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", pump.ChannelId);
            return View(pump);
        }

        // POST: Pumps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ChannelId,Status")] Pump pump)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pump).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", pump.ChannelId);
            return View(pump);
        }

        // GET: Pumps/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pump pump = db.Pumps.Find(id);
            if (pump == null)
            {
                return HttpNotFound();
            }
            return View(pump);
        }

        // POST: Pumps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Pump pump = db.Pumps.Find(id);
            pump.IsDeleted = true;
//            db.Pumps.Remove(pump);
            db.SaveChanges();
            Session["success"] = "Pump has been deleted";
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
