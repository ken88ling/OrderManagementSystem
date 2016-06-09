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
    public class StatesController : Controller
    {
        private OrderDbContext db = new OrderDbContext();

        // GET: States
        public ActionResult Index()
        {
            return View(db.Staties.ToList());
        }

        // GET: States/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            States states = db.Staties.Find(id);
            if (states == null)
            {
                return HttpNotFound();
            }
            return View(states);
        }

        // GET: States/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(States states)
        {
            if (ModelState.IsValid)
            {
                db.Staties.Add(states);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(states);
        }

        // GET: States/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            States states = db.Staties.Find(id);
            if (states == null)
            {
                return HttpNotFound();
            }
            return View(states);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(States states)
        {
            if (ModelState.IsValid)
            {
                db.Entry(states).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(states);
        }

        // GET: States/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            States states = db.Staties.Find(id);
            if (states == null)
            {
                return HttpNotFound();
            }
            return View(states);
        }

        // POST: States/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            States states = db.Staties.Find(id);
            db.Staties.Remove(states);
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
