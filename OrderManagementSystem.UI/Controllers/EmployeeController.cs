using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderManagementSystem.Data.Models;
using OrderManagementSystem.Service.Order;
using OrderManagementSystem.UI.ViewModels.Employee;
using System.Net;

namespace OrderManagementSystem.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private OrderDbContext _context;
        private EmployeeService _service;
        public EmployeeController()
        {
            _context = new OrderDbContext();
            _service = new EmployeeService(_context);
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employee = _context.Employees.Select(e => new EmployeeIndexViewModel()
            {
                Id = e.Id,
                FullName = e.FirstName + " " + e.MiddleName + " " + e.LastName,
                PhoneNo = e.PhoneNo,
                DateOfBirth = e.DateOfBirth,
                FullAddress = e.StreetAddress + " " + e.Suburb + " " + e.State
            });
            return View(employee.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create(Employee model)
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    _service.CreateEmployee(model.EmployeeNo, model.HireDate, model.DateOfBirth, model.FirstName, model.LastName, model.MiddleName, model.Gender, model.PhoneNo, model.StreetAddress, model.PostCode, model.Suburb, model.State);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }

            return View(model);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            var model = new EmployeeCreateViewModel()
            {
                EmployeeNo = employee.EmployeeNo,
                HireDate = employee.HireDate,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                PhoneNo = employee.PhoneNo,
                StreetAddress = employee.StreetAddress,
                Suburb = employee.Suburb,
                PostCode = employee.PostCode,
                State = employee.State
            };
            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    _service.UpdateEmployee(model.Id, model.EmployeeNo, model.HireDate, model.DateOfBirth, model.FirstName, model.LastName, model.MiddleName, model.Gender, model.PhoneNo, model.StreetAddress, model.PostCode, model.Suburb, model.State);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex);
                }
            }
            return View(model);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new EmployeeCreateViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                Gender = employee.Gender,
                DateOfBirth = employee.DateOfBirth,
                HireDate = employee.HireDate,
                PhoneNo = employee.PhoneNo,
                PostCode = employee.PostCode,
                State = employee.State,
                StreetAddress = employee.StreetAddress,
                Suburb = employee.Suburb
            };
            return View(model);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, EmployeeCreateViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                _service.DeleteEmployee(id.Value);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }

            //var model = _context.Employees
            //    .Select(e => new EmployeeCreateViewModel()
            //    {
            //        Id = e.Id,
            //        DateOfBirth = e.DateOfBirth,
            //        EmployeeNo = e.EmployeeNo,
            //        FirstName = e.FirstName,
            //        Gender = e.Gender,
            //        HireDate = e.HireDate,
            //        LastName = e.LastName,
            //        MiddleName = e.MiddleName,
            //        PhoneNo = e.PhoneNo,
            //        PostCode = e.PostCode,
            //        State = e.State,
            //        StreetAddress = e.StreetAddress,
            //        Suburb = e.Suburb
            //    });

            return View(model);
        }
    }
}
