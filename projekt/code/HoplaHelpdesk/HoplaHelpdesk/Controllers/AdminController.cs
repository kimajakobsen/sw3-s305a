using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using HoplaHelpdesk.Models;
namespace HoplaHelpdesk.Controllers
{
    public class AdminController : Controller
    {
        hoplaEntities DB = new hoplaEntities();
        //
        // GET: /Admin/
        
        public ActionResult index()
        {
            return View();
        }
        
        
       
                        
        

    }
}
