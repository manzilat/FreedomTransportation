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
        public Customer GetCustomer()
        {
            var customer = db.Customers.Where(x => x.Email == HttpContext.User.Identity.Name).FirstOrDefault();
            return customer;
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Phone,Street,State,Zip,City,lat,lng")] Customer customer)
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