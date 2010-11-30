using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class ClientProblemDetailsViewModel
    {
        public Problem Problem { get; set; }
        public SolutionListViewModel Solutionlistviewmodel { get; set; }
        public CommentListViewModel Commentlistviewmodel { get; set; }
        

    }
}