using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Data.Models;
using OrderManagementSystem.UI.ViewModels.Inventory;
using OrderManagementSystem.UI.ViewModels.Sale;

namespace OrderManagementSystem.UI.Controllers
{
    public class InventoryController : Controller
    {
        private OrderDbContext db = new OrderDbContext();
        
        // GET: Inventory
        public ActionResult Index()
        {   
            var model = db.Inventories
                .Include(a => a.SaleLineItem)
                .Select(p => new InventoryIndexMV()
                {
                    InventoryId = p.InventoryId,
                    ProductId = p.ProductId,
                    InitialQTY = p.InitialQTY,
                    CurrentQuantity = p.Product.CurrentQTY,
                    ProductName=p.Product.ProductName
                });

            return View(model.ToList()); 
        }
        
        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            var model = db.Inventories
             .Include(a => a.SaleLineItem)
             .Select(p => new InventoryIndexMV()
             {
                 InventoryId = p.InventoryId,
                 ProductId = p.ProductId,
                 InitialQTY = p.InitialQTY,
                 CurrentQuantity = p.Product.CurrentQTY,
                 ProductName = p.Product.ProductName
             });

            List<InventoryIndexMV> inventories;
            if (string.IsNullOrEmpty(searchTerm))
            {
                inventories = model.ToList();
            }
            else
            {
                inventories = model.Where(x => x.ProductName.StartsWith(searchTerm)).ToList();
            }
            return View(inventories);
        }

        public JsonResult GetProductByName(string term) // the term is fix by jquery
        {
            var model = db.Inventories
            .Include(a => a.SaleLineItem)
            .Select(p => new InventoryIndexMV()
            {
                InventoryId = p.InventoryId,
                ProductId = p.ProductId,
                InitialQTY = p.InitialQTY,
                CurrentQuantity = p.Product.CurrentQTY,
                ProductName = p.Product.ProductName
            });

            List<string> inventories = model.Where(x => x.ProductName.Contains(term))
                .Select(y => y.ProductName).ToList();

            return Json(inventories, JsonRequestBehavior.AllowGet);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            var product = db.Products.Select(s => new InventoryCreateVM()
            {
                ProductId = s.Id,
                ProductName = s.ProductName
            });


            var model = new InventoryCreateVM();
            model.ProductSelectList = new SelectList(product, "ProductId", "ProductName");
            return View(model);
        }

        //public JsonResult AutocompleteSuggestions(string term)
        //{
        //    var suggestions = db.GetAutoCompleteSearchSuggestion(term);
        //}
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();

                // add qty to product table
                var addQTY = db.Products.FirstOrDefault(p => p.Id == inventory.ProductId);
                if (addQTY != null)
                {
                    addQTY.CurrentQTY += inventory.InitialQTY;
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
