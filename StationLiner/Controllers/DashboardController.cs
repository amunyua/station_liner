using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Schema;
using StationLinerDataEntities.Models;

namespace StationLinerMVC.Controllers
{  
    [Authorize]
    public class DashboardController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeMode(string mode, long? channelId)
        {
            var userId = Library.UserId;
            var users = db.UserLayout.Where(x => x.UserId == userId);
            if (users.Any())
            {
                Library.ChannelId = channelId;
                users.First().Mode = mode;
                users.First().ChannelId = channelId;
                db.SaveChanges();
            }
            else
            {
                Library.ChannelId = channelId;
                db.UserLayout.Add(new UserLayout() {UserId = userId, Mode = mode, ChannelId = channelId});
                db.SaveChanges();
            }

//            return Redirect(Request.UrlReferrer.ToString());
            return RedirectToAction("Index");
        }

       
    }
}