using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreedomTransportation.Models
{
    public class FutureScheduleController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: FutureSchedule
        public ActionResult Index()
        {
            return View(db.FutureSchedule.ToList());
        }
        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PickUpId,CustomerId,Date,Time,Email,PickupAddress,DropoffAddress")] FutureSchedule futureSchedule)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
              //  var selectUser = db.FutureSchedule.Where(f => f.ApplicationUserId == userId).SingleOrDefault();
                //futureSchedule.CustomerId = selectUser.CustomerId;
                db.FutureSchedule.Add(futureSchedule);
                db.SaveChanges();
                return View("Details", futureSchedule);
               // RedirectToAction("Details");
            }
            return View(futureSchedule);
        }
        public ActionResult Details(FutureSchedule futureSchedule)
        {

            FutureSchedule futureScheduleNow = db.FutureSchedule.Find(futureSchedule.PickUpId);

            return View(futureSchedule);
        }
        public ActionResult Route()
        {
            return View();
        }
    }
}