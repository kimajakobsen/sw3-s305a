using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.Tools
{
    public class StatTool
    {
       
        public static TimeSpan AveragePerProblem(IEnumerable<Problem> problems)
        {
            if (problems == null || problems.Count() == 0)
                return new TimeSpan();
           int totalTime = 0; 
           int problemsCount = 0;
           foreach(var problem in problems){
               problemsCount++;
               totalTime = totalTime + (int)((TimeSpan)(problem.SolvedAtTime - problem.Added_date)).TotalMinutes;
           }

           return new TimeSpan(0,totalTime / problemsCount,0);
           
        }
    }
}