using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Index()
        {

            return View();
        }


        public ActionResult ViewProblems()
        {
            var problemList =  new List<Problem>(){
                new Problem(){
                    
                   Title = "John"
                }, new Problem(){
                    Title = "Mikael"
                }
            };

            var problems = new ProblemListViewModel()
            {
                Problems = problemList
            };
         

            return View(problemList);
        }

        //
        // GET: /Client/Details/5


        public ActionResult Details(int id)
        {


            return View();
        }

        //
        // GET: /Client/Create

       
    }
}
