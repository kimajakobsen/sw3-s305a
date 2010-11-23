using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    public class StaffController : Controller
    {
        //
        // GET: /Staff/

        [Authorize(Roles="Staff")]
        public ActionResult Worklist()
        {
            DBEntities DB = new DBEntities();

            var probs = from Problem in DB.ProblemSet select Problem;

            /*var problemList = new List<Problem>(){
                new Problem(){
                    Title = probs.ToString(), AssignedTo = "myownStaffId"
                }, new Problem(){
                    Title = "Mikael" , AssignedTo = "myNOTownStaffId"
                }
            };
             
            var problems = new ProblemListViewModel()
            {
                Problems = problemList
            };*/
         

            return View(problemList);
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Staff/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Staff/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Staff/Create

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
        // GET: /Staff/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Staff/Edit/5

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

        //
        // GET: /Staff/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Staff/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
