﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Web.Security;
using System.Data.Objects.DataClasses;
using System.Diagnostics.Contracts;
using System.Data.Objects;

namespace HoplaHelpdesk.Tools
{

    /// <summary>
    /// Main function is getStaff which gets a person who should solve the inputtet problem.
    /// If a is not specified it determines the currect departmen by itself. 
    /// The function overrules the Reassignable property of the problem... 
    /// </summary>
    public static class ProblemDistributer
    {
        public static IPerson GetStaff(Problem Problem, List<Person> PersonSet)
        {
            var persons = new List<IPerson>();
            foreach (var item in PersonSet)
            {
                persons.Add(item);

            }
            return GetStaff(Problem, persons, GetDepartment(Problem.Tags));
        }


        public static IPerson GetStaff(Problem Problem, List<IPerson> PersonSet)
        {
          
            return GetStaff(Problem, PersonSet, GetDepartment(Problem.Tags));
        }


        public static IPerson GetStaff(Problem Problem, List<Person> PersonSet, Department department)
        {
            var persons = new List<IPerson>();
            foreach (var item in PersonSet)
            {
                persons.Add(item);

            }
            return GetStaff(Problem, persons, department);
        }




        public static IPerson GetStaff(Problem Problem, Department department)
        {

            return GetStaff(Problem, department.Persons.ToList(), department);
        }

       

     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Problem"></param>
        /// <param name="PersonSet">Persons the problem will be distributed to. </param>
        /// <param name="department">Only people from this department will be assigned to the problem. </param>
        /// <returns></returns>
        public static IPerson GetStaff(Problem Problem,  List<IPerson> PersonSet, Department department)
        {
            
            
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
            if (persons.Count() == 0 || persons == null)
            {
                throw new ArgumentNullException("The Person List were empty");
            }
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