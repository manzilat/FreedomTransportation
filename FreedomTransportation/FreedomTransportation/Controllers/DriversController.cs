using FreedomTransportation.Models;
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
        //public ActionResult DriverTodayPickups()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var currentDriver = (from d in db.Drivers where d.Id.ToString() == userId select d).FirstOrDefault();
           
        //    var todayDate = DateTime.Now.Date;
        //    var customersMatchingZip = (from c in db.Customers where c.Zip == currentDriver.Zip select c).ToList();

        //    if (!customersMatchingZip.Any())
        //    {
        //        return View();
        //    }
        //    return View(customersMatchingZip);
        //}
        // GET: Drivers
        public ActionResult Index()
        {
            return View(db.Drivers.ToList());
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int id)
        {
          Driver driver = db.Drivers.Find(id);
           
            return View(driver);
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

                var currentUser = (from u in db.Users where u.Id == userId select u).FirstOrDefault();
                driver.DriversLicense = currentUser.Id ;
                driver.Email = currentUser.Email;
     

                db.Drivers.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //else
            //{
            //    var errors = ModelState.Select(x => x.Value.Errors)
            //                           .Where(y => y.Count > 0)
            //                           .ToList();
            //}
            return View(driver);
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int id)
        {
           
            Driver driver = db.Drivers.Find(id);
            
            return View(driver);
        }


        // POST: Drivers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Driver'sLicense,Email,Phone,Street,State,Zip,Status,CustomerId,TripId")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
          
            Driver driver = db.Drivers.Find(id);
          
            return View(driver);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Driver driver = db.Drivers.Find(id);
            db.Drivers.Remove(driver);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
