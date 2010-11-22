using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{
    public partial class Problem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool DeadlineIsApproved { get; set; }
        public bool Solved{get;set;}
        public List<string> Subscriptions{get;set;}
        public string Assignmet{get;set;}
    }
}