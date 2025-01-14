﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class SolutionListViewModel
    {
        public Problem Problem { get; set; }
        public List<Solution> Solutions { get; set; }
        public bool Deletable { get; set; }
    }
}