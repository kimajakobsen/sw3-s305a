using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.Tools;

namespace HoplaHelpdesk.Controllers
{
    public class ReassignProblemController : Controller
    {
        hoplaEntities db = new hoplaEntities();
        //
        // GET: /ReassignProblem/Index/5
        // id is problem id
        public ActionResult Index(int? id)
        {
            if (id == 0 || id == null)
            {
                ViewData["Error"] = "The id were not added";
                return View("Error");
            }

            var problem = db.ProblemSet.FirstOrDefault(x => x.Id == id);
            if (problem == null)
            {
                ViewData["Error"] = "No such problem exist";
                return View("Error");
            }
            Session["Problem"] = problem;

           return View(db.DepartmentSet);

        }

        // id is person
        public ActionResult Assign(int id, int dept)
        {
            var problem = (Problem)Session["Problem"];

            IPerson staff = null;
            if (dept == 0)
            {
                staff = ProblemDistributer.GetStaff(problem, db.PersonSet);
            }
            else
            {
                staff = db.PersonSet.FirstOrDefault(x => x.Id == id);
                problem.Reassignable = false;
                if (staff.IsStaff() == false)
                {
                    ViewData["Error"] = "The assigned person were not a staff!";
                    return View("Error");
                }
            }

            problem.PersonsId = ((Person)staff).Id;
               
            db.SaveChanges();

            return View("Succes");
        }

        //
        // GET: /ReassignProblem/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ReassignProblem/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ReassignProblem/Create

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
        // GET: /ReassignProblem/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ReassignProblem/Edit/5

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
        // GET: /ReassignProblem/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ReassignProblem/Delete/5

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
