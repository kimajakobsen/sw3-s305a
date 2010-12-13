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

        public int NumOfMatchingTags(List<Tag> listTags)
        {
            int count = 0;

            foreach (var probTag in Tags)
            {
                foreach (var compareTag in listTags)
                {
                    if (compareTag.Id == probTag.Id)
                    {
                        count++;
                    }
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

        public static ProblemETCComparer GetETCComparer()
        {
            return new ProblemETCComparer();
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
        /// When a member of Staff submits how much time is spent solving a specific problem,
        /// this void submits the time to the problem's tags for later statistics.
        /// </summary>
        /// <param name="StaffTimeSpentInput">Hours as a double, seperated with ".".</param>
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

        /// <summary>
        /// Returns when in time a problem is most likely solved
        /// </summary>
        /// <returns>Returns a variable of type DateTime</returns>

        public DateTime Eta 

        {
            get
            {
                try
                {
                    return CalculateETA();
                }
                catch (NullReferenceException)
                {
                    return DateTime.Today.Add(new TimeSpan(1,0,0,0,0));
                }
            } 
        } 

        private DateTime CalculateETA()
        {
            DateTime DateTime = DateTime.Now;

            foreach (Problem problem in AssignedTo.SortedWorklist)
            {
                DateTime = DateTime.Add(EstimatedTimeConsumption);

                if (problem.Id == Id)
                    break;
            }

            return DateTime;
        }

        /// <summary>
        /// Returns how much time one person shall spend solving a specific problem.
        /// The assumption is based on the average time it's tags as taken to solve in the past.
        /// </summary>
        /// <returns>Returns a variable of Type TimeSpan</returns>

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

            if (NumberOfTags == 0)
            {
                average = 10;
            }
            else
            {
                average = ProblemTime / NumberOfTags;
            }

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

        public class ProblemETCComparer : IComparer<Problem>
        {
            public int Compare(Problem a, Problem b)
            {

                return a.EstimatedTimeConsumption.CompareTo(b.EstimatedTimeConsumption);
            }
        }

    }


     public interface IProblem
     {
         void ManageTagTimes(double StaffTimeSpent);
         Double Priority { get;  }


     }
}