﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Data.Models;
using OrderManagementSystem.Service.Order;
using OrderManagementSystem.UI.ViewModels.Product;
using SharpRepository.EfRepository;

namespace OrderManagementSystem.UI.Controllers
{
    public class ProductController : Controller
    {
        private OrderDbContext db;
        private ProductService productService;

        protected EfRepository<Product> _ProductRepository;

        public ProductController()
        {
            db = new OrderDbContext();
            
            _ProductRepository = new EfRepository<Product>(db);
            productService = new ProductService(_ProductRepository);
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = _ProductRepository.AsQueryable()//add to repository first
                .Select(p => new ProductIndexViewModel()
            {
                ProductId = p.Id,
                CategoryName = p.Category.Description,
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price.Value,
                VendorName = p.Vendor.Name
            });

            //var products = db.Products.Include(p => p.Category).Include(p => p.Vendor);
            return View(model.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
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

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description");
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                productService.CreateProduct(product.CategoryId, product.ProductName, product.Description, product.Price.Value,product.Cost.Value,
                    product.VendorId);
               
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", product.CategoryId);
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", product.VendorId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", product.CategoryId);
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", product.VendorId);
            return View(product);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", product.CategoryId);
            ViewBag.VendorId = new SelectList(db.Vendors, "VendorId", "Name", product.VendorId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
