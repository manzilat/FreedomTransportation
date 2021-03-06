﻿using FreedomTransportation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;

namespace FreedomTransportation.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "";
                body += "<p>From: {0} ({1})</p>";
                body += "<p>Message:</p>";
                body += "<hr>";
                body += "<p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("quraishiiff@gmail.com")); //Send to this e-mail address
                message.Subject = "Feedback";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    try
                    {
                        await smtp.SendMailAsync(message);
                        return RedirectToAction("Sent");//Goto sent successful page.
                    }
                    catch (Exception e)
                    {
                        Response.Write("<p>" + e.Message + "</p>");
                    }
                    return View();//Send back to form if unsuccessful
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}