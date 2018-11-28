using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreedomTransportation.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }

//        public ActionResult GetMessages()
//        {
//            var allMessages = Message.GetMessages();
//            return View(allMessages);
//        }

//        public ActionResult SendMessage()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult SendMessage(Message newMessage)
//        {
//            newMessage.Send();
//            return RedirectToAction("Index");
//        }
//    }
//}
