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
    public class ProductsController : Controller
    {
        private IMSDataEntities db = new IMSDataEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProdCategory).Include(p => p.UnitOfMeasure);
            return View(products.ToList());
        }

      

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories.Where(x=>x.ParentCategory != null), "Id", "CategoryName");
            ViewBag.Uom = new SelectList(db.Uom, "Id", "UOMName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_id,ProductCode,Product_Name,Product_Description,ProductCategoryId,ProductRefCode,Sellable,Uom")] Product product)
        {
            
            if (ModelState.IsValid)
            {
                product.CreatedAt = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName", product.ProductCategoryId);
            ViewBag.Uom = new SelectList(db.Uom, "Id", "UOMName", product.Uom);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories.Where(x=>x.ParentCategory != null), "Id", "CategoryName", product.ProductCategoryId);
            ViewBag.Uom = new SelectList(db.Uom, "Id", "UOMName", product.Uom);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_id,ProductCode,Product_Name,Product_Description,ProductCategoryId,ProductRefCode,Sellable,Uom")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories, "Id", "CategoryName", product.ProductCategoryId);
            ViewBag.Uom = new SelectList(db.Uom, "Id", "UOMName", product.Uom);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
