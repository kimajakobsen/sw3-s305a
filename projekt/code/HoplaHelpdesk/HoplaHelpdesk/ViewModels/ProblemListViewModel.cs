using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class ProblemListViewModel
    {

        public List<Problem> Problems {get;set;}
        public bool Editable { get; set; }
        public bool Deletable { get; set; }

    }
}