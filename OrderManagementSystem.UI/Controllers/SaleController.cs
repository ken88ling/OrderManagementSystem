using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Data.Models;
using OrderManagementSystem.Service.Order;
using OrderManagementSystem.UI.ViewModels.Sale;

namespace OrderManagementSystem.UI.Controllers
{
    public class SaleController : Controller
    {
        private OrderDbContext _context;
        private SaleService _saleApplicationService;
        public SaleController()
        {
            _context = new OrderDbContext();
            _saleApplicationService = new SaleService(_context);
        }

        // GET: Sale
        public ActionResult Index()
        {
            var sale = _context.Sales.ToList();
            var model = _context.Sales.Select(p => new SaleIndexViewModel()
            {
                Id = p.SaleId,
                CustomerName = p.Customer.FirstName + " " + p.Customer.LastName,
                PaymentDate = p.PaymentDate,
                PurchaseDate = p.PurchaseDate

            });

            return View(model);
        }

        // GET: Sale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sale = _context.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            var model = new SaleDetailsViewModel()
            {
                Id = sale.SaleId,
                CustomerName = sale.Customer.FirstName + " " + sale.Customer.LastName,
                PaymentDate = sale.PaymentDate,
                PurchaseDate = sale.PurchaseDate
            };

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Sale/Create

        public ActionResult Create()
        {
            var customer = _context.Customers
                .Select(s => new SaleCreateViewModel()
                {
                    CustomerId = s.Id,
                    CustomerFullName = s.FirstName + " " + s.LastName
                });

            var product = _context.Products
                .Select(s => new SaleCreateViewModel()
                {
                    Productindex = s.Id,
                    ProductFullDetail = s.ProductName + " , $" + s.Price
                });

            //var product = _context.Products.ToList();

            var model = new SaleCreateViewModel();
            model.CustomerSelectList = new SelectList(customer, "CustomerId", "CustomerFullName");
            model.ProductSelectList = new SelectList(product, "Productindex", "ProductFullDetail");

            return View(model);
        }

        // POST: Sale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    //_saleApplicationService.CreateSale( model.CustomerId, model.PurchaseDate,model.PaymentDate, model.ProductId, model.Quantity);
                    _saleApplicationService.CreateSale(model.CustomerId, model.PaymentDate, model.Productindex,
                        model.Quantity);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }

            var customer = _context.Customers.ToList();
            var product = _context.Products.ToList();

            model.CustomerSelectList = new SelectList(customer, "Id", "FirstName");
            model.ProductSelectList = new SelectList(product, "Id", "Name");

            return View(model);
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sale = _context.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            SaleEditViewModel model = new SaleEditViewModel()
            {
                Id = sale.SaleId,
                CustomerId = sale.CustomerId,
                PurchaseDate = sale.PurchaseDate,
                PaymentDate = sale.PaymentDate
            };

            model.Customers = new SelectList(_context.Customers, "Id", "CustomerId", sale.CustomerId);
            return View(model);
        }

        // POST: Sale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, SaleEditViewModel model)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    _saleApplicationService.UpdateSale(
                        model.Id,
                        model.CustomerId,
                        model.PurchaseDate.Value,
                        model.PaymentDate);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }

            model.Customers = new SelectList(_context.Sales, "Id", "CustomerId", model.CustomerId);
            return View(model);
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sale = _context.Sales.Find(id);


            var model = new SaleDetailsViewModel()
            {
                Id = sale.SaleId,
                CustomerName = sale.Customer.FirstName + " " + sale.Customer.LastName,
                PaymentDate = sale.PaymentDate,
                PurchaseDate = sale.PurchaseDate
            };

            return View(model);
        }

        // POST: Sale/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                // TODO: Add delete logic here
                _saleApplicationService.DeleteSale(id.Value);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }
            var sale = _context.Sales.Find(id);
            var model = new SaleDetailsViewModel()
            {
                Id = sale.SaleId,
                CustomerName = sale.Customer.FirstName + " " + sale.Customer.LastName,
                PaymentDate = sale.PaymentDate,
                PurchaseDate = sale.PurchaseDate
            };
            return View(model);
        }
    }
}
