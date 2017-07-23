using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Data.Models;
using OrderManagementSystem.Service.Order;
using OrderManagementSystem.UI.ViewModels.Sale;
using OrderManagementSystem.UI.ViewModels.SaleLineItem;

namespace OrderManagementSystem.UI.Controllers
{
    public class SaleController : Controller
    {
        private OrderDbContext _context;
        private SaleService _saleApplicationService;
        private static List<Product> items = new List<Product>();
        private static List<SaleLineItemCreateViewModel> sales = new List<SaleLineItemCreateViewModel>();


        public SaleController()
        {
            _context = new OrderDbContext();
            _saleApplicationService = new SaleService(_context);
        }

        // GET: Sale
        public ActionResult Index()
        {
            var model = _context.Sales.Select(p => new SaleIndexViewModel()
            {
                Id = p.SaleId,
                CustomerName = p.Customer.FirstName + " " + p.Customer.LastName,
                PaymentDate = p.PaymentDate,
                PurchaseDate = p.PurchaseDate

            });

            return View(model);
        }

        public PartialViewResult getSaleDetail()
        {
            var model = _context.SaleLineItems.ToList();
            return PartialView("_SaleDetail", model);
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
                    ProductName = s.ProductName,
                    ProductFullDetail = s.ProductName + " , $" + s.Price
                }).ToList();

            //var product = _context.Products.ToList();

            var model = new SaleCreateViewModel()
            {
                SaleLineItems = sales
            };
            model.CustomerSelectList = new SelectList(customer, "CustomerId", "CustomerFullName");
            model.ProductSelectList = new SelectList(product, "Productindex", "ProductName");

            return View(model);
        }

        public ActionResult Add(int? Productindex)
        {
            if (Productindex == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productfromdb = _context.Products.Find(Productindex);
            if (productfromdb == null)
            {
                return HttpNotFound();
            }
            //foreach (var product in sales)
            //{
            //    if (product.ProductId == productfromdb.Id)
            //    {
            //        product.QTY++;
            //    }
            //}
            items.Add(productfromdb);
            //var i = 0;

            var salelineItem = new SaleLineItemCreateViewModel()
            {
                ProductId = productfromdb.Id,
                ProductName = productfromdb.ProductName,
                QTY = 1,
                Price = productfromdb.Price.Value
            };

            sales.Add(salelineItem);

            return RedirectToAction("Create");
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create(SaleCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    //_saleApplicationService.CreateSale(model.CustomerId, model.PaymentDate, model.Productindex,
                    //    model.Quantity);
                    var list = new List<SaleLineItem>();
                    foreach (var item in sales)
                    {
                        var saleLineItem = new SaleLineItem()
                        {
                            ProductId = item.ProductId,
                            Quantity = item.QTY,
                            UnitPrice = item.Price
                        };
                        list.Add(saleLineItem);
                    }

                    _saleApplicationService.CreateSale(model.CustomerId, model.PaymentDate, list);

                    // reduce qty from product table
                    foreach (var product1 in list)
                    {
                        var productqty = _context.Products.FirstOrDefault(p => p.Id == product1.ProductId);
                        if (productqty != null)
                        {
                            productqty.CurrentQTY -= product1.Quantity;
                            _context.SaveChanges();
                        }
                        
                    }

                    sales = null;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }

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
                    ProductName = s.ProductName,
                    ProductFullDetail = s.ProductName + " , $" + s.Price
                }).ToList();

            //model.CustomerSelectList = new SelectList(customer, "Id", "FirstName");
            //model.ProductSelectList = new SelectList(product, "Id", "Name");

            model.CustomerSelectList = new SelectList(customer, "CustomerId", "CustomerFullName");
            model.ProductSelectList = new SelectList(product, "Productindex", "ProductName");

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

        public ActionResult AddQuant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var checkqty = sales.Find(itemid => itemid.ProductId == id);
            if (checkqty != null)
            {
                checkqty.QTY += 1;
            }

            if (checkqty == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Create");
        }

        //
        public ActionResult SubQuant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var checkqty = sales.Find(itemid => itemid.ProductId == id);
            if (checkqty != null)
            {
                if (checkqty.QTY > 0)
                {
                    checkqty.QTY -= 1;
                }
            }

            if (checkqty == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Create");
        }

    }
}
