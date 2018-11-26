using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreedomTransportation.Controllers
{
    public class TransportationProvidersController : Controller
    {
        // GET: TransportationProviders
        public ActionResult Index()
        {
            return View();
        }

        // GET: TransportationProviders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransportationProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransportationProviders/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
