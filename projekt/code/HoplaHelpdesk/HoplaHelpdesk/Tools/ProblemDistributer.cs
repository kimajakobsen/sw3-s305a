﻿using System;
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


        public static Department GetDepartment(List<Tag> tags){

            var departments = new List<DepCount>();
            foreach(var tag in tags){
                tag.Categories.Departments

            }

            return new Department();
        }

        private struct DepCount{
            Department Department { get; set;}
            int Count { get; set; }
        }
    }
}