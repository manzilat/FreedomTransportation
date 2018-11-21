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
    public class SchedulingRidesController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: SchedulingRides
        public ActionResult Index()
        {
            return View();
        }

        // GET: SchedulingRides/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        







        public ActionResult SchedulingRide()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SchedulingRide([Bind(Include = "PickupAddress,PickupCity,PickupState,PickupZipCode,DropoffAddress,DropoffCity,DropoffState,DropoffZipCode,OneTimePickup")] SchedulingRide ride)
        {

            var userId = User.Identity.GetUserId();
            // customer.ApplicationUserId = userId;


            var currentCustomer = (from c in db.Customers where userId == c.ApplicationUserId select c).First();
            currentCustomer.SchedulingRide = currentCustomer.SchedulingRide;

            db.Entry(currentCustomer).State = EntityState.Modified;
            db.SchedulingRides.Add(ride);
            db.SaveChanges();

            return RedirectToAction("TripInfo", new { id = ride.Id });
        }
        public ActionResult TripInfo(int? id)
        {
            var pickup = db.SchedulingRides.Where(x => x.Id == id).FirstOrDefault();
            return View(pickup);
        }
        [HttpPost]
        public ActionResult TripInfo(int id, FormCollection form)
        {
          
            

            var userId = User.Identity.GetUserId();
            //TripInfo.ApplicationUserId = userId;
            var schedulingRide = (from s in db.Customers where s.ApplicationUserId == userId select s).First();
      
            var pickup = db.SchedulingRides.Where(x => x.Id == id).FirstOrDefault();
            //var rides = db.SchedulingRides.Where(r => r.Id.ToString() == userId);
            db.SaveChanges();
            return View(pickup);
        }


    }
}
