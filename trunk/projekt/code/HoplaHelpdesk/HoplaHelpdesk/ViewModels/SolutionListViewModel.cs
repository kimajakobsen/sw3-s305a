﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class SolutionListViewModel
    {
        public List<Comment> Solutions { get; set; }
        public bool Editable;
        public bool Eeletable;
    }
}