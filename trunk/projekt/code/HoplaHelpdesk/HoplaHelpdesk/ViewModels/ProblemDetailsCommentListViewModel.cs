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

        public CommentListViewModel Commentlistviewmodel { get; set; }
        
        public Comment comment { get; set; } // comment which is about to be added

        public SolutionListViewModel Solutionlistviewmodel { get; set; }
        //public List<Solution> Solutions { get; set; } // list of solutions to this problem

        public bool reassignability { get; set; }
        public bool approveDeadline { get; set; }

        public double hoursTaken { get; set; }
    }
}