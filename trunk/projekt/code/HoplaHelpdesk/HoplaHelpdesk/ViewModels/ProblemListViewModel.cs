using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    /// <summary>
    /// ViewModel for a  Problem List containing attributes for Deletable and Editable
    /// </summary>
    public class ProblemListViewModel
    {

        public List<Problem> Problems {get;set;}
        public bool Editable { get; set; }
        public bool Deletable { get; set; }

    }
}