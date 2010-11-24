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
        public List<Comment> Comments { get; set; }
    }
}