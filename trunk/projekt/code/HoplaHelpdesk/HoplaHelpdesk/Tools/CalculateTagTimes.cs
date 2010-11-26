using System;
using HoplaHelpdesk.Models;
using System.Linq;

namespace HoplaHelpdesk.Tools
{
    public static class TagETAMangager
    {
        public static void ManageTagTimes(Problem problem)
        {
            TimeSpan TimeConsumed = new TimeSpan();

            try
            {
                TimeConsumed = (TimeSpan)(problem.Added_date - problem.SolvedAtTime);
            }
            catch
            {
                throw;
            }

            var MinutesConsumed = TimeConsumed.Minutes + (TimeConsumed.Hours * 60) + ((TimeConsumed.Days * 24) * 60);

            foreach (var tag in problem.Tags)
            {
                tag.SolvedProblems++;

                tag.TimeConsumed = tag.TimeConsumed + MinutesConsumed;

                tag.AverageTimeSpent = tag.TimeConsumed / tag.SolvedProblems;

            }

        }

    }
}