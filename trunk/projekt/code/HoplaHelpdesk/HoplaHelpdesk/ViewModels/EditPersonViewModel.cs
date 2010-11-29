using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class EditPersonViewModel
    {
        public Person Person { get; set; }
        public List<Department> AllDepartments { get; set; }
    }
}