using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Web.Security;
using System.Data.Objects.DataClasses;
using System.Diagnostics.Contracts;

namespace HoplaHelpdesk.Tools
{
    public static class ProblemDistributer
    {
        public static IPerson GetStaff(Problem Problem, EntityCollection<IPerson> PersonSet)
        {
            return GetStaff(Problem, PersonSet, GetDepartment(Problem.Tags));
        }

        public static IPerson GetStaff(Problem Problem,  EntityCollection<IPerson> PersonSet, Department department)
        {
            Contract.Invariant(PersonSet != null, "PersonSet were null");
            
            IEnumerable<IPerson> persons = null;
            if (department != null)
            {
                 persons = PersonSet.Where(x => x.Department == department && x.IsStaff() == true);
                 if (persons == null || persons.Count() == 0)
                 {
                     persons = PersonSet.Where(x => x.IsStaff() == true);
                 }
            } else {
                 persons = PersonSet.Where(x => x.IsStaff() == true);
            }
            Double min = Double.MaxValue;
            IPerson staff = persons.First();
            foreach (var person in persons)
            {
                    var workload = person.GetWorkload();
                    if (workload < min)
                    {
                        min = workload;
                        staff = person;
                    }   
            }
            //var person = PersonSet.Single(x => x.Id == 1);
            if (persons == null)
            {
                staff = persons.First();
            }
           
            return staff;
        }

        /// <summary>
        /// Gets department from a list of tags.
        /// </summary>
        /// <param name="tags"> A list of tags.</param>
        /// <returns>The department which has most tags included in the list.</returns>
        public static Department GetDepartment(EntityCollection<Tag> tags){

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

            if (departments.Count == 0 || departments == null)
            {
                return null;
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