using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{
    public partial class Problem
    {
        public string Title;
        public string Description;
        public DateTime Deadline;
        public bool DeadlineIsApproved;
        public bool Solved;
        public List<string> Subscriptions;
        public string Assignmet;
    }
}