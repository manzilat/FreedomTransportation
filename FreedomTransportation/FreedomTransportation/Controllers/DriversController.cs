﻿using FreedomTransportation.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FreedomTransportation.Controllers
{
    public class DriversController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.TransportationProvider.ToList());
        }


        // GET: Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Driver'sLicense,Email,Phone,Street,State,Zip,Status,CustomerId,TripId")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var currentUser = (from u in db.Users where u.Id == userId select u).First();
                currentUser.Id = currentUser.Id;
                //driver.DriversLicense = currentUser.Id ;
                //driver.Email = currentUser.Email;
                db.Entry(currentUser).State = EntityState.Modified;

                db.TransportationProvider.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = driver.Id });
            }
            //else
            //{
            //    var errors = ModelState.Select(x => x.Value.Errors)
            //                           .Where(y => y.Count > 0)
            //                           .ToList();
            //}
            return View(driver);
        }
        // GET: Drivers/Details/5
        public ActionResult Details(int id)
        {
            Driver driver = db.TransportationProvider.Find(id);

            return View(driver);
        }

        [HttpPost]
        public ActionResult Details(int id, FormCollection form)
        {

            var userId = User.Identity.GetUserId();

            var Details = (from d in db.TransportationProvider where d.ApplicationUserId == userId select d).First();

            var detail = db.TransportationProvider.Where(x => x.Id == id).FirstOrDefault();
            //var rides = db.SchedulingRides.Where(r => r.Id.ToString() == userId);
            db.SaveChanges();
            return View(detail);
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int id)
        {

            Driver driver = db.TransportationProvider.Find(id);

            return View(driver);
        }


        // POST: Drivers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DriversLicense,Email,Phone,Street,City,State,Zip,Status,CustomerId,TripId")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(driver);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {

            Driver driver = db.TransportationProvider.Find(id);

            return View(driver);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Driver driver = db.TransportationProvider.Find(id);
            db.TransportationProvider.Remove(driver);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ConfirmPickup(string id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        [HttpPost, ActionName("ConfirmPickup")]
        public ActionResult ConfirmedPickup(string id)
        {
            var currentCustomer = (from c in db.Customers where c.ApplicationUserId == id select c).FirstOrDefault();


            if (currentCustomer != null) currentCustomer.IsConfirmed = true;

            db.Entry(currentCustomer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EmployeeTodayPickups");

        }
        public ActionResult ScheduleDetails()
        {
            return View(db.Customers.ToList());
        }

    }
}