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


        public void FutureImplementationBalanceWorkload()
        {
            Person dummyPerson = new Person();
            List<Person> staffMembers = Persons.ToList();
            List<Problem> problemList = new List<Problem>();

            foreach (var member in staffMembers)
            {
                foreach (var problem in member.Worklist)
                {
                    problemList.Add(problem);
                }
            }

            problemList = problemList.Where(x => x.Reassignable == true && x.SolvedAtTime == null).ToList();

            foreach (var problem in problemList)
            {
                problem.AssignedTo = dummyPerson;
            }

            while (problemList.Count > 0)
            {
                // find the person with the lowest workload
                Person min = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Min(x => x.GetWorkload()));

                // assign the most important problem to the person
                problemList[0].AssignedTo = min;
                problemList.RemoveAt(0);
            }
        }

        /// <summary>
        /// Balance the workload between all staffs in  a department. 
        /// </summary>
        public void BalanceWorkload()
        {
            // Run through all persons.
            for (var i = 0; i < Persons.Count -1; i++)
            {
                    // Find the person with the highest workload
                    var max = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Max(x => x.GetWorkload()));

                    // If there is no person, do nothing.
                    if (max.Worklist == null) return;
                    
                    // Sort his worklist so that the highest priority is the first.
                    var maxWorklist = max.Worklist.ToList();
                    maxWorklist.Sort(Problem.GetETCComparer());

                    // Find the person with the lowest workload
                    var min = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Min(x => x.GetWorkload()));
                 
                    // If max and min is the same person.
                    if (max == min)  return;

                    // To determine the while loop.
                    bool couldStillMove = true;
                    do
                    {
                        // Finde the reassignable problem with the highest priority which has not been moved yet. 
                        var problemToBeMoved = maxWorklist.FirstOrDefault(y => y.Reassignable == true && 
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
            List<Problem> problems = new List<Problem>();
            foreach (var person in Persons)
            {

                problems.AddRange(person.Worklist.Where(x => x.SolvedAtTime != null));

            }
            return StatTool.AveragePerProblem(problems);
        }

        public TimeSpan AverageTimePerProblemLastWeek()
        {
            List<Problem> problems = new List<Problem>();
            var now = DateTime.Now;
            var since = now.Subtract(new TimeSpan(7, 0, 0, 0));
            foreach (var person in Persons)
            {

                problems.AddRange(person.Worklist.Where(x => x.SolvedAtTime > since));

            }
            return StatTool.AveragePerProblem(problems);
        }

     
        #endregion

    }
}