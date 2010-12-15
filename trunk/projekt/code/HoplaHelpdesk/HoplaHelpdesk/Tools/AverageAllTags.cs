using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Tools
{
    public static class AverageAllTags
    {
        static hoplaEntities db = new hoplaEntities();
        public static decimal averageAll
        {
            get
            {
                int NumberOfTags = 0;
                decimal? ProblemTime = 0;

                foreach (Tag tag in db.TagSet.ToList())
                {
                    if (tag.AverageTimeSpent != null)
                    {
                        ProblemTime = ProblemTime + tag.AverageTimeSpent;
                    }
                    NumberOfTags++;
                    
                }
                return (decimal)(ProblemTime / NumberOfTags);
            }
        }
    }
}