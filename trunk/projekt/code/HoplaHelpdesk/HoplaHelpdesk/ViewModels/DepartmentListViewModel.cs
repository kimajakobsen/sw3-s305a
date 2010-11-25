using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;


namespace HoplaHelpdesk.ViewModels
{
    public class DepartmentListViewModel
    {
        public List<Department> Departments { get; set; }
        public List<Category> Categories { get; set; }
        public List<Person> Staffmembers { get; set; }
    }
}