using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.UI.Controllers
{
    public class SaleLineItemsController : Controller
    {
        private OrderDbContext db = new OrderDbContext();

        // GET: SaleLineItems
        public ActionResult Index()
        {
            var saleLineItems = db.SaleLineItems.Include(s => s.Product).Include(s => s.Sale);
            return View(saleLineItems.ToList());
        }

        // GET: SaleLineItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLineItem saleLineItem = db.SaleLineItems.Find(id);
            if (saleLineItem == null)
            {
                return HttpNotFound();
            }
            return View(saleLineItem);
        }

        // GET: SaleLineItems/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName");
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "SaleId");
            return View();
        }

        // POST: SaleLineItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleId,ProductId,Quantity,UnitPrice")] SaleLineItem saleLineItem)
        {
            if (ModelState.IsValid)
            {
                db.SaleLineItems.Add(saleLineItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", saleLineItem.ProductId);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "SaleId", saleLineItem.SaleId);
            return View(saleLineItem);
        }

        // GET: SaleLineItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLineItem saleLineItem = db.SaleLineItems.Find(id);
            if (saleLineItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", saleLineItem.ProductId);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "SaleId", saleLineItem.SaleId);
            return View(saleLineItem);
        }

        // POST: SaleLineItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleId,ProductId,Quantity,UnitPrice")] SaleLineItem saleLineItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleLineItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "ProductName", saleLineItem.ProductId);
            ViewBag.SaleId = new SelectList(db.Sales, "SaleId", "SaleId", saleLineItem.SaleId);
            return View(saleLineItem);
        }

        // GET: SaleLineItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLineItem saleLineItem = db.SaleLineItems.Find(id);
            if (saleLineItem == null)
            {
                return HttpNotFound();
            }
            return View(saleLineItem);
        }

        // POST: SaleLineItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleLineItem saleLineItem = db.SaleLineItems.Find(id);
            db.SaleLineItems.Remove(saleLineItem);
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
