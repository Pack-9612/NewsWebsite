using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSystem.MVC.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Event()
        {
            return View();
        }
    }
}