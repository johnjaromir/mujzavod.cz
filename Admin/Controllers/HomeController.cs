using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MujZavod.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (User.IsInRole("Organizer"))
                return RedirectToAction("Index", "Race");
            else if (User.IsInRole("User"))
                return RedirectToAction("Index", "Runner");
            return View();
        }
    }
}