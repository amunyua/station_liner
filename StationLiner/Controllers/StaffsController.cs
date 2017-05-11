using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using StationLinerDataEntities.Models;
using StationLinerMVC.Models;

namespace StationLinerMVC.Controllers
{
    [Authorize]
    public class StaffsController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        private ApplicationUserManager _userManager;

        public StaffsController()
        {

        }

        public StaffsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Staffs
        public ActionResult Index()
        {
            var staffs = db.Staffs.Where(x=>x.IsDeleted == false).Include(s => s.BusinessRoles).Include(s => s.Channels).Include(s => s.Roles);
            return View(staffs.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            ViewBag.BusinessRole = new SelectList(db.BusinessRoles, "Id", "Name");
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName");
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,PIN,IdNumber,Password,PhoneNumber,ChannelId,Role,BusinessRole")] Staff staff)
        {
            var userId = 0;
            if (ModelState.IsValid)
            {
//
                //here create a user account if it is specfied
                if (Request.Form["UserAccont"] == "1")
                {



                    var user = new ApplicationUser
                    {
                        Channel = staff.ChannelId,
                        UserName = staff.Name,
                        Email = staff.Email,
                        PhoneNumber = staff.PhoneNumber.ToString(),
                        CreatedBy = Library.UserId
                    };
                    Debug.WriteLine("reached here");
//                var userMan = new UserManager<ApplicationUserManager,string>();
                    var result = await UserManager.CreateAsync(user, "123456");
                    if (result.Succeeded)
                    {
                        userId = user.Id;

                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                        //if the account has been created assign the user to the role assigned
                        var userRole = db.UserRoles.Add(new UserRoles() {RoleId = staff.Role, UserId = user.Id});

                        Debug.WriteLine("saving");
//                    db.SaveChanges();
//                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
//                    return RedirectToAction("Index", "Staffs");


                    }
                }


                staff.CreatedAt = DateTime.Now;
                staff.CreatedBy = User.Identity.GetUserId<int>();
                staff.IsActive = true;
                staff.IsDeleted = false;
                staff.UserId = userId;
                db.Staffs.Add(staff);
                
                db.SaveChanges();
                Session["success"] = "Staff created";
                return RedirectToAction("Index");
            }

            ViewBag.BusinessRole = new SelectList(db.BusinessRoles, "Id", "Name", staff.BusinessRole);
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", staff.ChannelId);
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", staff.Role);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessRole = new SelectList(db.BusinessRoles, "Id", "Name", staff.BusinessRole);
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", staff.ChannelId);
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", staff.Role);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,PIN,IdNumber,Password,PhoneNumber,ChannelId,Role,BusinessRole")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.IsDeleted = false;
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                Session["success"] = "Staff details updated";
                return RedirectToAction("Index");
            }
            ViewBag.BusinessRole = new SelectList(db.BusinessRoles, "Id", "Name", staff.BusinessRole);
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "ChannelName", staff.ChannelId);
            ViewBag.Role = new SelectList(db.Roles, "RoleId", "RoleName", staff.Role);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Staff staff = db.Staffs.Find(id);
            staff.IsDeleted = true;
//            db.Staffs.Remove(staff);
            Session["success"] = "Staff deleted";
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
