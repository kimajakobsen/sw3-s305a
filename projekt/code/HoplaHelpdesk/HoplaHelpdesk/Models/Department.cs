using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;
using HoplaHelpdesk.Tools;
using System.ComponentModel;
using System.Web.Mvc;

namespace HoplaHelpdesk.Models
{
    public partial class Department
    {
       

        public string Name
        {
            get { return DepartmentName; }
            set { DepartmentName = value; }
        }
        /// <summary>
        /// Balance the workload between all staffs in  a department. 
        /// </summary>
        public void BalanceWorkload()
        {
            // Run through all persons.
            for (var i = 0; i < Persons.Count; i++)
            {
                    // Find the person with the highest workload
                    var max = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Max(x => x.GetWorkload()));

                    // If there is no person, do nothing.
                    if (max.Worklist == null) return;
                    
                    // Sort his worklist so that the highest priority is the first.
                    max.Worklist.ToList().Sort(Problem.GetComparer());

                    // Find the person with the lowest workload
                    var min = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Min(x => x.GetWorkload()));
                 
                    // If max and min is the same person.
                    if (max == min)  return;

                    // To determine the while loop.
                    bool couldStillMove = true;
                    do
                    {
                        // Finde the reassignable problem with the highest priority which has not been moved yet. 
                        var problemToBeMoved = max.Worklist.FirstOrDefault(y => y.Reassignable == true && 
																		   		y.HasBeen == false && 
																				y.SolvedAtTime == null);
                   
  						// If none can be moved leave the while loop
                        if (problemToBeMoved == null)
                        {
                            couldStillMove = false;
                        }
                        else
                        {
                            // Mark as has been moved
                            problemToBeMoved.HasBeen = true;

                            // Reassign the highest priority problem to staff called min.
                            problemToBeMoved.AssignedTo = min;

                            if (min.Workload >= max.Workload)
                            {
                                // Initialize variables for checking whether or not to move the last problem back
                                double beforeMoveBack = 0.0;
                                double afterMoveBack = 0.0;

                                // Calculate difference before moving
                                beforeMoveBack = Math.Abs(max.Workload - min.Workload);

                                // Move it back
                                problemToBeMoved.AssignedTo = max;

                                // Calculate difference after moving
                                afterMoveBack = Math.Abs(max.Workload - min.Workload);

                                // Compare
                                if (beforeMoveBack < afterMoveBack)
                                {
                                    problemToBeMoved.AssignedTo = min;
                                }

                                couldStillMove = false;
                            }
                            else if (min.Workload == max.Workload)
                            {
                                // Don't move back if they are equal
                                couldStillMove = false;
                            }
                        }

                    } while (couldStillMove);
                }
            }

        #region Statistics

        public TimeSpan AverageTimePerProblem()
        {
            return AverageTimePerProblem(null);

        }

        public TimeSpan AverageTimePerProblemLastWeek()
        {
            return AverageTimePerProblem("LastWeek");

        }

        private TimeSpan AverageTimePerProblem(string method)
        {
            int people = 0;
            int totalTime = 0;
            foreach (var person in Persons)
            {
                people++;
                if (method == "LastWeek")
                    totalTime = (int)person.AverageTimePerProblemLastWeek().TotalMinutes;
                 else 
                    totalTime = (int)person.AverageTimePerProblem().TotalMinutes;
            }
            if (people == 0)
                return new TimeSpan();
            else
                return new TimeSpan(0, totalTime / people, 0);

        }
        #endregion

    }
}