using FreedomTransportation.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;



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
            var customer = (from c in db.Customers where c.Id.ToString() == userId select c).FirstOrDefault();
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
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Home");
            }


            return View(customer);
        }
    }
}