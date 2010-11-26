using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class ProblemDetailsCommentListViewModel
    {
        public Problem Problem { get; set; }


        public List<Comment> Comments { get; set; } // list of problems already added
        public Comment comment { get; set; } // comment which is about to be added

        public SolutionListViewModel Solutionlistviewmodel { get; set; }
        //public List<Solution> Solutions { get; set; } // list of solutions to this problem
    }
}