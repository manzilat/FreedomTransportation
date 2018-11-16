using FreedomTransportation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }
    }
}