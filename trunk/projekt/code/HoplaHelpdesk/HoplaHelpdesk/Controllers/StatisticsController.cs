using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.ViewModels;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.Tools;

namespace HoplaHelpdesk.Controllers
{
    [Authorize(Roles = Constants.AdminRoleName)]
    public class StatisticsController : Controller
    {
        //
        // GET: /Statistics/
        hoplaEntities db = new hoplaEntities();
        public ActionResult Index()
        {
            var departments = db.DepartmentSet.ToList();
            
            List<Problem> problems = new List<Problem>();
            List<Problem> problemsPastWeek = new List<Problem>();
            var now = DateTime.Now;
            var since = now.Subtract(new TimeSpan(7, 0, 0, 0));
            foreach(var dep in departments){
                foreach (var person in dep.Persons)
                {
                    problemsPastWeek.AddRange(person.Worklist.Where(x => x.SolvedAtTime > since));
                    problems.AddRange(person.Worklist.Where(x => x.SolvedAtTime != null));
                }
            }

            var viewModel = new StatisticViewModel()
            {
                AverageLastWeek = StatTool.AveragePerProblem(problemsPastWeek),
                AverageAllTime = StatTool.AveragePerProblem(problems),
                Departments = departments
                
            };
            return View(viewModel);
        }

    }
}
