using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    //[Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        hoplaEntities db = new hoplaEntities();
        public ActionResult Index()
        {

            return View();
        }

        /*
        public ActionResult ViewProblems()
        {
            
            // Finds the loged in users problems. 
            //var problemList = db.ProblemSet.Where(x => x.aspnet_Users.Contains(db.aspnet_Users.FirstOrDefault(y => y.UserName == User.Identity.Name)));

            var problems = new ProblemListViewModel()
            {
                Problems = problemList.ToList()
            };
         
            
            return View(problems);
        }

        //
        // GET: /Client/Details/5
        */

        public ActionResult Details(int id)
        {


            return View();
        }

        //
        // GET: /Client/Create

       
    }
}
