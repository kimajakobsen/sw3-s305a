using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class SolutionListViewModel
    {
        public List<Solution> Solutions { get; set; }
        public bool Editable = false;
        public bool Deletable = false;
    }
}