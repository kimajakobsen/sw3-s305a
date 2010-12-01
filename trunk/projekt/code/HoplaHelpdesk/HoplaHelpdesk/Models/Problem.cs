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

        public int NumOfMatchingTags(Problem OtherProblem)
        {
            int count = 0;
            for (int i = 0; i < OtherProblem.Tags.Count; i++)
            {
                if (Tags.Contains(OtherProblem.Tags.ElementAt(i)))
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Derived value to determine what has been selected and what has not.
        /// </summary>
        public bool HasBeen { get; set; }

        public static ProblemComparer GetComparer()
        {
            return new ProblemComparer();
        }

        public class ProblemMetaData
        {
            [Required(ErrorMessage = "A problem Title is required")]
            [StringLength(160)]
            public object Title { get; set; }

        }

        private Double GetPriority()
        {
            if (DateTime.Now > Deadline)
            { // Whenever a 
                return 10.0;
            }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="StaffTimeSpentInput"></param>
        public void ManageTagTimes(double StaffTimeSpentInput)
        {

            string StaffTimeSpent = StaffTimeSpentInput.ToString();

            string[] split = StaffTimeSpent.Split(".".ToCharArray());
            
            int HoursUsed = Int32.Parse(split[0]);
            int MinutesUsed = 0;

            try
            {
                MinutesUsed = (int)(0.6*(double.Parse(split[1]))) + (HoursUsed*60);
            }
            catch
            {
                MinutesUsed = HoursUsed*60;
            }

            foreach (var tag in Tags)
            {
                if (tag.SolvedProblems == null)
                tag.SolvedProblems = 0;
                
                tag.SolvedProblems++;

                if (tag.TimeConsumed == null)
                tag.TimeConsumed = 0;

                tag.TimeConsumed = tag.TimeConsumed + MinutesUsed;
            }

        }


        public DateTime Eta 
        {
            get
            {
                return CalculateETA();
            } 
        } 

        private DateTime CalculateETA()
        {
            DateTime DateTime = DateTime.Now;

            foreach (Problem problem in AssignedTo.SortedWorklist)
            {
                if (problem.Id == Id)
                    break;

                DateTime.Add(EstimatedTimeConsumption);

            }

            return DateTime;
        }

        public TimeSpan EstimatedTimeConsumption
        {
            get
            {
                return CalculateEstimatedTimeConsumption();
            }
        }

        private TimeSpan CalculateEstimatedTimeConsumption()
        {
            int NumberOfTags = 0;
            decimal? ProblemTime = 0;
            int Minutes = 0;
            int Hours = 0;
            int Days = 0;

            decimal? average = 0;

            foreach (Tag tag in Tags)
            {
                if (tag.AverageTimeSpent != null)
                {
                    ProblemTime = ProblemTime + tag.AverageTimeSpent;
                }
                NumberOfTags++;
            }

            if(NumberOfTags == 0)
            {
                NumberOfTags = 1;
                ProblemTime = 10;
            }

            average = ProblemTime / NumberOfTags;

            Hours = (int)average % 60;
            Minutes = (int)average - (Hours*60);
            Days = Hours % 24;
            Hours = Hours - (Days * 24);

            return new TimeSpan(Days, Hours, Minutes, 0);
        }

        public class ProblemComparer : IComparer<Problem>
        {
            public int Compare(Problem a, Problem b)
            {
              
                return b.Priority.CompareTo(a.Priority);
            }
        }

    }


     public interface IProblem
     {
         void ManageTagTimes(double StaffTimeSpent);
         Double Priority { get;  }


     }
}