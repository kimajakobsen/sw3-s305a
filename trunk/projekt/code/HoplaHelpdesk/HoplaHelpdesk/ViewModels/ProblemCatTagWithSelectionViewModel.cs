using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class ProblemCatTagWithSelectionViewModel
    {
        public Problem Problem { get; set; }
        public CategoryTagSelectionViewModel CatTag { get; set; }
        public Person Person { get; set; }
    }
}