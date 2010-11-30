using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text;

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

        public static ProblemComparer<Problem> GetComparer()
        {

            return new ProblemComparer<Problem>();

        }

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

        public void ManageTagTimes(double StaffTimeSpentInput)
        {
            string StaffTimeSpent = StaffTimeSpentInput.ToString();

            string[] split = StaffTimeSpent.Split(",".ToCharArray());
            
            int HoursUsed = Int32.Parse(split[0]);
            int MinutesUsed = (int)(0.6*(double.Parse(split[1]))) + (HoursUsed*60);

            foreach (var tag in Tags)
            {
                tag.SolvedProblems++;

                tag.TimeConsumed = tag.TimeConsumed + MinutesUsed;
            }
        }

        public class ProblemComparer<T> : IComparer<T>
        {
            public int Compare(T a, T b)
            {
                Problem proA = a as Problem;
                Problem proB = a as Problem;
                return proB.Priority.CompareTo(proA.Priority);
            }
        }

    }


     public interface IProblem
     {
         void ManageTagTimes(double StaffTimeSpent);
         Double Priority { get;  }


     }
}