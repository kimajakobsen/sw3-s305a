using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.ViewModels
{
    public class PersonListViewModel
    {
        public List<Person> Persons { get; set; }
    }
}