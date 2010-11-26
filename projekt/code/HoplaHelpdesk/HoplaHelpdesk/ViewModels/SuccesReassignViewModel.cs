using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class SuccesReassignViewModel
    {
        public Person From { get; set; }
        public Person To { get; set; }
        public Problem Problem { get; set; }
    }
}