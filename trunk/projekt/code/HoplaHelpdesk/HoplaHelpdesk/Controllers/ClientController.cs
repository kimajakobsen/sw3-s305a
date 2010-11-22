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


        public ActionResult CategorizeNewProblem()
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

        public ActionResult Create()
        {

            var problem = new Problem();

            return View(problem);
        } 

        //
        // POST: /Client/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Client/Edit/5
        
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Client/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
       
    }
}
