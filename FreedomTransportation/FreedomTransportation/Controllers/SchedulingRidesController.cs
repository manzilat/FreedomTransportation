using FreedomTransportation.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


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

        public ActionResult MakeAPayment()
        {
            var userId = User.Identity.GetUserId();
            var currentCustomer = (from c in db.Customers where userId == c.ApplicationUserId select c).First();
            var currentCustomerCity = currentCustomer.City;
            var currentCustomerState = currentCustomer.State;
            var currentCustomerAddress = currentCustomerCity + ", " + currentCustomerState;

            //Anna's Secret Sauce Formula for Mileage
            //Google Matrix API

            var request = WebRequest.Create("https://maps.googleapis.com/maps/api/distancematrix/json?origins=Milwaukee&destinations=" + currentCustomerAddress);
            // Indicate you are looking for a JSON response
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();

            // Read through the response
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                // Define a serializer to read your response
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                // Get your results
                dynamic result = serializer.DeserializeObject(sr.ReadToEnd());

                // Read the distance property from the JSON request
               // var distance = result["rows"][3]["elements"][0]["distance"]["text"]; // yields "1,300 KM"
               // var serviceCharge = 0.50;//TODO: Implement a service charge
             //   var costPerRide = Double.Parse(distance) * serviceCharge;
            }
            //TotalBill = Bill in Dollar Amount for presentation on View pages
            ViewBag.TotalBill = 0;//Insert variable for calculated value here

            //TotalBillInCents = Bill in Cents Amount for Stripe Checkout processor (it likes cents)
            ViewBag.TotalBillInCents = 0;//Insert variable for calculated value here
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
