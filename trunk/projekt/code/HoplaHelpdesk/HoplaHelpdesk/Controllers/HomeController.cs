﻿using System;
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
            ViewData["Message"] = "Velkommen til Hopla Helpdesk - WE WILL VAPORIZE YOU!!!!!!!!!1111111";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
