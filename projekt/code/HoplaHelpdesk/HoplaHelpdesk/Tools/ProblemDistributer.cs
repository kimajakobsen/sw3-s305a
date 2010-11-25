using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Web.Security;

namespace HoplaHelpdesk.Tools
{
    public static class ProblemDistributer
    {
        public static Person GetStaff(Problem Problem, hoplaEntities db)
        {

            var department = GetDepartment(Problem.Tags.ToList());


            var person = db.PersonSet.Single(x => x.Id == 1);
            return person;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public static Department GetDepartment(List<Tag> tags){

            var departments = new List<DepCount>();
           
           
            foreach(var tag in tags){
               
                var dept = departments.SingleOrDefault(x => x.Department == tag.Category.Department);
                if (dept == null)
                {
                    departments.Add(new DepCount() { 
                         Department = tag.Category.Department,
                         Count = 1
                    });

                } else {
                    dept.Count++;
                }
            }



            return departments.OrderByDescending(x => x.Count).First().Department;
        }

        private class DepCount{
            public Department Department { get; set;}
            public int Count { get; set; }
        }
    }
}