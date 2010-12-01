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
          
            foreach(var dep in departments){
                dep.AverageTimePerProblem();

            }
            var viewModels = new StatisticViewModel()
            {
               AllStaff = new TimeSpan(),
                Departments = departments
                
            };
            return View();
        }

    }
}
