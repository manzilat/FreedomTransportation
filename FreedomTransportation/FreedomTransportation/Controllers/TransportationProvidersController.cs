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
    public class TransportationProvidersController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: TransportationProviders
        public ActionResult Index()
        {
            return View();
        }

        // GET: TransportationProviders/Details/5
        public ActionResult Details(int ID)
        {
            TransportationProvider transportationProvider = db.TransportationProviders.Find(ID);
            return View(transportationProvider);
        }
        [HttpPost]
        public ActionResult Details(int ID, FormCollection form)
        {

            var userId = User.Identity.GetUserId();

            var Details = (from d in db.TransportationProvider where d.ApplicationUserId == userId select d).First();

            var detail = db.TransportationProvider.Where(x => x.Id == ID).FirstOrDefault();
           
            db.SaveChanges();
            return View(detail);
        }
        // GET: TransportationProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportationProviders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProviderName,Email,Phone,Street,State,Zip,City,DriverId")] TransportationProvider transportationProvider  )
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var currentProvider = (from p in db.Users where p.Id == userId select p);
                db.Entry(currentProvider).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Details");
            }
            return View(transportationProvider);

                
        }

        // GET: TransportationProviders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransportationProviders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TransportationProviders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransportationProviders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
