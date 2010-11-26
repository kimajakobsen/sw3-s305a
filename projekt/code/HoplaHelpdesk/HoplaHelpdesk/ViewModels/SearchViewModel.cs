using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class SearchViewModel
    {
        public CategoryTagSelectionViewModel CatTag { get; set; }
        public ProblemListViewModel ProblemList { get; set; }
        public IPerson Subscriber { get; set; }
        public bool OnlySubscriber { get; set; }
        public bool OnlyUnsolvedProblems { get; set; }
    }
}