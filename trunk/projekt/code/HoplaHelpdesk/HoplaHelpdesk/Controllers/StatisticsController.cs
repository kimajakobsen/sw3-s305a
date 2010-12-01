using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.ViewModels;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.Controllers
{
    public class StatisticsController : Controller
    {
        //
        // GET: /Statistics/
        hoplaEntities db = new hoplaEntities();
        public ActionResult Index()
        {
            var departments = db.DepartmentSet.ToList();
            int TotalTime = 0;
            int TotalTimeLastWeek = 0;
            int problems = 0;
            foreach(var dep in departments){
               TotalTimeLastWeek = (int)dep.AverageTimePerProblem().TotalMinutes;
               TotalTime = (int)dep.AverageTimePerProblem().TotalMinutes;
               problems++;
            }

            var viewModels = new StatisticViewModel()
            {
                AverageLastWeek = new TimeSpan(0,TotalTimeLastWeek/problems,0),
                AverageAllTime = new TimeSpan(0,TotalTime/problems,0),
                Departments = departments
                
            };
            return View();
        }

    }
}
