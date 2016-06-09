using OrderManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Service.Order;
using OrderManagementSystem.UI.ViewModels.Customer;
using System.Net;
using SharpRepository.EfRepository;

namespace OrderManagementSystem.UI.Controllers
{
    public class CustomerController : Controller
    {
        private OrderDbContext _context;
        private CustomerService _customerService;

        protected EfRepository<Customer> _CustomerRepository;

        public CustomerController()
        {
            _context = new OrderDbContext();
            //_customerService = new CustomerService(_context);
            //_customerService = new CustomerService(_context);
            _CustomerRepository = new EfRepository<Customer>(_context);
        }

        // GET: Customer
        public ActionResult Index()
        {
            var model = _CustomerRepository.AsQueryable().ToList()
                .Select(c => new CustomerIndexViewModel()
                {
                    Id = c.Id,
                    UserName = c.CustomerCode,
                    FullName = c.FirstName + " " + c.MiddleName + " " + c.LastName,
                    DateOfBirth = c.DateOfBirth,
                    FullAddress = c.StreetAddress + " " + c.Suburb + " " + c.PostCode + " " + c.State
                });

            return View(model);
        }


        public ActionResult GetStates()
        {
            var o = new { Val = 1, Text = "NSW" };
            var o1 = new { Val = 2, Text = "VIC" };
            var o2 = new { Val = 3, Text = "TAS" };
            var o3 = new { Val = 4, Text = "WA" };
            var o4 = new { Val = 5, Text = "NT" };
            var states = new[] { o, o1,o2,o3,o4 }.ToList();
            return Json(states, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.CreateCustomer(
                       model.CustomerCode,
                       model.DateOfBirth,
                       model.FirstName,
                       model.LastName,
                       model.MiddleName,
                       model.Gender,
                       model.PhoneNo,
                       model.StreetAddress,
                       model.PostCode,
                       model.Suburb,
                       model.State);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                    //ModelState.AddModelError("", ex);
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = _context.Customers.FirstOrDefault(s => s.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var model = new CustomerEditViewModel()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                MiddleName = customer.MiddleName,
                Gender = customer.Gender,
                DateOfBirth = customer.DateOfBirth,
                PhoneNo = customer.PhoneNo,
                PostCode = customer.PostCode,
                State = customer.State,
                StreetAddress = customer.StreetAddress,
                Suburb = customer.Suburb
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, CustomerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerService.UpdateCustomer(model.Id, model.DateOfBirth, model.FirstName, model.LastName, model.MiddleName, model.Gender, model.PhoneNo, model.StreetAddress, model.PostCode, model.Suburb, model.State);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }

            return View(model);
        }



        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var model = new CustomerIndexViewModel()
            {
                Id = customer.Id,
                UserName = customer.CustomerCode,
                FullName = customer.FirstName + " " + customer.MiddleName + " " + customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                FullAddress = String.Format("{0} {1} {2} {3}", customer.StreetAddress, customer.Suburb, customer.State, customer.PostCode)
            };

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var model = new CustomerIndexViewModel()
            {
                Id = customer.Id,
                UserName = customer.CustomerCode,
                FullName = customer.FirstName + " " + customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                FullAddress = customer.StreetAddress + " " + customer.Suburb,
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                _customerService.DeleteCustomer(id.Value);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}