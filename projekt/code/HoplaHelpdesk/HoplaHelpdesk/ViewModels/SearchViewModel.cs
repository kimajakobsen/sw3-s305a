using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace HoplaHelpdesk.ViewModels
{
    public class SearchViewModel
    {
        public CategoryTagSelectionViewModel CatTag { get; set; }
        public ProblemListViewModel ProblemList { get; set; }
        public IPerson Subscriber { get; set; }

        [DisplayName("Only your problems")]
        public bool OnlySubscriber { get; set; }

        [DisplayName("Only unsolved problems")]
        public bool OnlyUnsolvedProblems { get; set; }

        [DisplayName("Only solved problems")]
        public bool OnlySolvedProblems { get; set; }

        private int _minimumNumberOfProblems;
        [DisplayName("Minimum Number of problems to find")]
        [Required(ErrorMessage="Cannot leave blank")]
        //[Range(1,int.MaxValue,ErrorMessage="Must be at least one")]
        public int MinimumNumberOfProblems {
            get
            {
                return _minimumNumberOfProblems;
            }
            set
            {
                if(value < 1)
                {
                    _minimumNumberOfProblems = 1;
                }
                else
                {
                    _minimumNumberOfProblems = value;
                }
            }
        }
    }
}