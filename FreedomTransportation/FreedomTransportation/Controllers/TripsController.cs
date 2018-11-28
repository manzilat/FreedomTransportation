using FreedomTransportation.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreedomTransportation.Controllers
{
    public class TripsController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        

        public ActionResult Index()
        {
            return View(db.Trips.ToList());
        }


        // GET: Trips/Create
        public ActionResult Create()
        {
            Trips trips = new Trips();
            return View(trips);
            
        }

        // POST: Drivers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PickUpTime,ArrivalTime,DepartureTime,DropOffTime,NameOfTheCustomer,DriverName")] Trips trips)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                
                //  var selectUser = db.FutureSchedule.Where(f => f.ApplicationUserId == userId).SingleOrDefault();
                //futureSchedule.CustomerId = selectUser.CustomerId;
                db.Trips.Add(trips);
                db.SaveChanges();
                return View("Index");
            }


            return View(trips);
        }
    }
}