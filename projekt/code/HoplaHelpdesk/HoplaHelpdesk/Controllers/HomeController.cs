using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoplaHelpdesk.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to Hopla Helpdesk";

            return Redirect("Client/Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
