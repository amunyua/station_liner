using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StationLinerDataEntities.Models;


namespace StationLinerMVC
{
    [Authorize]
    public static class Library
    {
        private static IMSDataEntities db = new IMSDataEntities();
        public static long UserRole { get; set; }
        public static int UserId { get; private set; }
        public static string Layout { get; set; }
        public static long? ChannelId { get; set; }

        static Library()
        {
            UserRole = GetUserRole();
            UserId = HttpContext.Current.User.Identity.GetUserId<int>();
            Layout = ViewLayout();
        }
        public static long GetUserRole()
        {
            
            var userId = HttpContext.Current.User.Identity.GetUserId<int>();
          
            var userRole = db.UserRoles.FirstOrDefault(x => x.UserId == userId).RoleId;
                return userRole;
        }

        public static string GetRoleName()
        {
            return db.Roles.Find(GetUserRole()).RoleName;
        }

        /* This function returns the logged in person
            if the logged in is the admin, the method returns true
        */
        public static bool IsAdmin()
        {
            if (GetRoleName() == Constants.AdminRole)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string  ViewLayout()
        {
            var lay = db.UserLayout.Where(x => x.UserId == UserId);
            if (lay.Any())
            {
                return lay.First().Mode;
            }
            else
            {
                return "";
            }
        }
    }
}