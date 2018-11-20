using FreedomTransportation.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace FreedomTransportation.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
           public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult Home()
        {
            var userId = User.Identity.GetUserId();
            var customer = (from c in db.Customers where c.ApplicationUserId == userId select c).FirstOrDefault();

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Phone,Street,State,Zip,City,lat,lng,CustomerWalleteId,SchedulingRide")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                customer.ApplicationUserId = userId;

                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Home");
            }


            return View(customer);
        }
        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // GET: Customers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Phone,Street,State,City,Zip")] Customer customer, string id)
        {

            if (ModelState.IsValid)
            {
                Customer updatedCustomer = db.Customers.Find(id);
                if (updatedCustomer == null)
                {
                    return RedirectToAction("DisplayError", "Employees");
                }
                updatedCustomer.FirstName = customer.FirstName;
                updatedCustomer.LastName = customer.LastName;
                updatedCustomer.Email = customer.Email;
                updatedCustomer.Phone = customer.Phone;
                updatedCustomer.Street = customer.Street;
                updatedCustomer.State = customer.State;
                updatedCustomer.Zip = customer.Zip;
                updatedCustomer.City = customer.City;
                db.Entry(updatedCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View(customer);
        }
        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            customer.FirstName = "Deleted";
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("LogOff", "Account");
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