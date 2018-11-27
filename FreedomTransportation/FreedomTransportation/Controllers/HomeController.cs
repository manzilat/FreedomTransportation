using Stripe.Terminal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreedomTransportation.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Demo1()
        {
            return View();
        }

        public ActionResult Stripe()
        {
        var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
         ViewBag.StripePublishKey = stripePublishKey;
        return View();
        }
       
    }
}