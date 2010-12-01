using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class StatisticViewModel
    {
        public List<Department> Departments;
        public TimeSpan AverageAllTime;
        public TimeSpan AverageLastWeek;
    }
}