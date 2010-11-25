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
        /// Gets department from a list of tags.
        /// </summary>
        /// <param name="tags"> A list of tags.</param>
        /// <returns>The department which has most tags included in the list.</returns>
        public static Department GetDepartment(List<Tag> tags){

            var departments = new List<DepCount>();
           // Runs through all tags.
            foreach(var tag in tags){
               // Get the appropriete department for that tag.
                var dept = departments.SingleOrDefault(x => x.Department == tag.Category.Department);
                if (dept == null)
                {
                    // If it doesent exist add it.
                    departments.Add(new DepCount() { 
                         Department = tag.Category.Department,
                         Count = 1
                    });

                } else {
                    // increment it. 
                    dept.Count++;
                }
            }


            // returns the department with the highest count. 
            return departments.OrderByDescending(x => x.Count).First().Department;
        }

        private class DepCount{
            public Department Department { get; set;}
            public int Count { get; set; }
        }
    }
}