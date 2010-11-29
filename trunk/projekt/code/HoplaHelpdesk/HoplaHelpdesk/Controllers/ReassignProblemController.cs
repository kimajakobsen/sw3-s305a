using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.Tools;
using HoplaHelpdesk.ViewModels;

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
            var from = problem.AssignedTo;
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
           
           // problem.PersonsId = ((Person)staff).Id;
           // problem.AssignedTo = ((Person)staff);
            
            from.Worklist.Remove(problem);
            db.SaveChanges();
            staff.Worklist.Add(problem);
            db.SaveChanges();
            var viewModel = new SuccesReassignViewModel()
            {
                From = from,
             
                Problem = problem

            };
            return View("Succes", viewModel);
        }

    }
}
