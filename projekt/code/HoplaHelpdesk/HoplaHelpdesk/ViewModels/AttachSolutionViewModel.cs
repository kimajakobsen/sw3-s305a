using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class AttachSolutionViewModel
    {
        public int ProblemID { get; set; }
        public List<Solution> Solutions { get; set; }
        public Solution SolutionToAttach { get; set; }
    }
}