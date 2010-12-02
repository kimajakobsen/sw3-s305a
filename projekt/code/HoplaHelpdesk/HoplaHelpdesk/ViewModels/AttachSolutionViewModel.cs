using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class AttachSolutionViewModel
    {
        public Problem Problem { get; set; }
        //public List<Solution> Solutions { get; set; }
        public SearchViewModel Search {get;set;}
        public Solution SolutionToAttach { get; set; }
    }
}