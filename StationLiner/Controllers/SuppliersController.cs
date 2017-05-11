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
    public class SuppliersController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(db.Supppliers.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PostalAddress,PostalCode,City,Contact1,Contact2,Email,PinNumber,ContactPersonName,CreditLimit")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Supppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PostalAddress,PostalCode,City,Contact1,Contact2,Email,PinNumber,ContactPersonName,CreditLimit")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Supppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Supplier supplier = db.Supppliers.Find(id);
            db.Supppliers.Remove(supplier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SupplierProducts(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.id = id;
            var products = db.SupplierProducts.Where(p => p.SupplierId == id).Include(p => p.ProdId);

            return View(products);
        }

        [HttpPost]
        public ActionResult AddProduct([Bind(Include = "ProductId,Price, SupplierId")] SupplierProduct supplierP)
        {
            //check whether the warehouse item already exists
            var supplierId = Int64.Parse(Request.Form["SupplierId"]);
            var productId = Int64.Parse(Request.Form["ProductId"]);

            if (
                db.SupplierProducts.Any(
                    x =>
                        x.SupplierId == supplierId&&
                        x.ProductId == productId))
            {
                Session["warning"] = "Item is already attached to supplier";
            }
            else
            {
                supplierP.CreatedAt = DateTime.Now;
                supplierP.UpdatedAt = DateTime.Now;
                db.SupplierProducts.Add(supplierP);
                db.SaveChanges();
                Session["success"] = "Item has been added";
            }


            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult RemoveSupplierProduct(long? id)
        {
            SupplierProduct p = db.SupplierProducts.Find(id);
            db.SupplierProducts.Remove(p);

            db.SaveChanges();
            Session["success"] = "The product has been detached from the supplier";
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult EditSupplierItem()
        {
            var id = Int64.Parse(Request.Form["ProductId"]);
            var price = int.Parse(Request.Form["Price"]);
            SupplierProduct p = db.SupplierProducts.Find(id);

            p.Price = price;
            p.UpdatedAt = DateTime.Now;
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.ToString());
        }


        //show all drivers
        public ActionResult Drivers(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.Drivers.Where(x=>x.SupplierId == id).Include(x=>x.Suppliers));
        }

        public ActionResult AddDriver([Bind(Include = "DriverName,PhoneNumber,SupplierId")] SupplierDriver driver)
        {
            if (ModelState.IsValid)
            {
                db.Drivers.Add(driver);
                db.SaveChanges();
                Session["success"] = "Driver has been added";
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        //function to delete a driver from the supplier
        public ActionResult DeleteDriver(long? id)
        {
            SupplierDriver p = db.Drivers.Find(id);
            db.Drivers.Remove(p);

            db.SaveChanges();
            Session["success"] = "The driver details have been deleted";
            return Redirect(Request.UrlReferrer.ToString());
        }


        //Edit driver details
        public ActionResult EditDriverDetails()
        {
            var id = Int64.Parse(Request.Form["DriverId"]);
            SupplierDriver driver = db.Drivers.Find(id);

            driver.DriverName = Request.Form["DriverName"];
            driver.PhoneNumber = Request.Form["PhoneNumber"];
            db.SaveChanges();
            Session["success"] = "Driver details have been updated";

            return Redirect(Request.UrlReferrer.ToString());
        }

        //show all Vehicles
        public ActionResult Vehicles(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.Vehicles.Where(x => x.SupplierId == id).Include(x => x.Suppliers));
        }

        public ActionResult AddVehicle([Bind(Include = "RegNumber,MaximumCapacity,SupplierId")] SupplierVehicle v)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(v);
                db.SaveChanges();
                Session["success"] = "Vehicle has been added";
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        //function to delete a driver from the supplier
        public ActionResult DeleteVehicle(long? id)
        {
            SupplierVehicle v = db.Vehicles.Find(id);
            db.Vehicles.Remove(v);

            db.SaveChanges();
            Session["success"] = "The Vehicle details have been deleted";
            return Redirect(Request.UrlReferrer.ToString());
        }


        //Edit Vehicle details
        public ActionResult EditVehicleDetails()
        {
            var id = Int64.Parse(Request.Form["VehicleId"]);
            SupplierVehicle v = db.Vehicles.Find(id);

            v.RegNumber = Request.Form["RegNumber"];
            v.MaximumCapacity = Request.Form["MaximumCapacity"];
            db.SaveChanges();
            Session["success"] = "Vehicle details have been updated";

            return Redirect(Request.UrlReferrer.ToString());
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
