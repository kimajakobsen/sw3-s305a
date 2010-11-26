using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class SearchViewModel
    {
        CategoryTagSelectionViewModel CatTag { get; set; }
        ProblemListViewModel ProblemList { get; set; }
    }
}