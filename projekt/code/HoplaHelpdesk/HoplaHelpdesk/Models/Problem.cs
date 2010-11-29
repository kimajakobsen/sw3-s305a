using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HoplaHelpdesk.Models
{

    [MetadataType(typeof(ProblemMetaData))]
    public partial class Problem : IProblem
    {
        /// <summary>
        /// The Priority of the problem. Read-only.
        /// </summary>
        public Double Priority
        {
            get { return GetPriority(); }
            private set{}
        }

        /// <summary>
        /// Derived value to determine what has been selected and what has not.
        /// </summary>
        public bool HasBeen { get; set; }

        public class ProblemMetaData
        {
            [Required(ErrorMessage = "A problem Title is required")]
            [StringLength(160)]
            public object Title { get; set; }

        }

        private Double GetPriority()
        {
            if (Tags != null && Tags.Count != 0)
            {
                short sum = 0;
                foreach (var tag in Tags)
                {
                    sum += tag.Priority;
                }
                return Math.Round(sum / (double)Tags.Count, 2);
            }

            return 0;
        }

        public void ManageTagTimes()
        {
            TimeSpan TimeConsumed = new TimeSpan();

            try
            {
                TimeConsumed = (TimeSpan)(SolvedAtTime - Added_date);
            }
            catch
            {
                throw;
            }

            var MinutesConsumed = TimeConsumed.Minutes + (TimeConsumed.Hours * 60) + ((TimeConsumed.Days * 24) * 60);

            foreach (var tag in Tags)
            {
                tag.SolvedProblems++;

                tag.TimeConsumed = tag.TimeConsumed + MinutesConsumed;

           //     tag.AverageTimeSpent = tag.TimeConsumed / tag.SolvedProblems;

            }
        }
    }


     public interface IProblem
     {
         void ManageTagTimes();
         Double Priority { get;  }


     }
}