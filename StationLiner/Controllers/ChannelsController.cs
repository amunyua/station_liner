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
    public class ChannelsController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        // GET: Channels
        public ActionResult Index()
        {
            var channels = (Library.IsAdmin())
                ? db.Channels.Where(x => x.IsDeleted == false)
                : db.Channels.Where(x => x.IsDeleted == false && x.CreatedBy == Library.UserId);
            return View(channels.ToList());
        }



        // GET: Channels/Create
        public ActionResult Create()
        {
            ViewBag.ChannelType = new SelectList(db.ChannelTypes, "Id", "Type");
            return View();
        }

        // POST: Channels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ChannelName,ChannelDescription,ChannelType,Country,Address,City")] Channels channels)
        {
            if (ModelState.IsValid)
            {
                channels.CreatedAt = DateTime.Now;
                channels.CreatedBy =User.Identity.GetUserId<int>();
                channels.IsDeleted = false;
                db.Channels.Add(channels);
                db.UserAllocatedChannels.Add(
                    new UserAllocatedChannels() {ChannelId = channels.Id, UserId = Library.UserId});
                db.SaveChanges();
                Session["success"] = "Channel Created";
                return RedirectToAction("Index");
            }

            ViewBag.ChannelType = new SelectList(db.ChannelTypes, "Id", "Type", channels.ChannelType);
            return View(channels);
        }

        // GET: Channels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channels channels = db.Channels.Find(id);
            if (channels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelType = new SelectList(db.ChannelTypes, "Id", "Type", channels.ChannelType);
            return View(channels);
        }

        // POST: Channels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ChannelName,ChannelDescription,ChannelType,Country,Address,City    ")] Channels channels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(channels).State = EntityState.Modified;
                db.SaveChanges();
                Session["success"] = "Channel details updated";
                return RedirectToAction("Index");
            }
            ViewBag.ChannelType = new SelectList(db.ChannelTypes, "Id", "Type", channels.ChannelType);
            return View(channels);
        }

        // GET: Channels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channels channels = db.Channels.Find(id);
            if (channels == null)
            {
                return HttpNotFound();
            }
            return View(channels);
        }

        // POST: Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Channels channels = db.Channels.Find(id);
            channels.IsDeleted = true;
//            db.Channels.Remove(channels);
            db.SaveChanges();
            Session["success"] = "Channel has been deleted";
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
