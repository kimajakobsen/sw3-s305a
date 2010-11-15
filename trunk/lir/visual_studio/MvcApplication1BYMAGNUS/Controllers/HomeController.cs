using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1BYMAGNUS.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome tdso ASP.NEdwadT MVC!";
            
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
