using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class SimilairProblemListViewModel
    {
        public Problem Problem { get; set; }
        public List<Problem> Problems { get; set; }
        public bool Deletable { get; set; }
        public CategoryTagSelectionViewModel SelectedCatTag { get; set; }

    }
}