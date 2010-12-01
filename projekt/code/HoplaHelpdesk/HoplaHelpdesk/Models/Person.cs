using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Objects.DataClasses;
using HoplaHelpdesk.Tools;

namespace HoplaHelpdesk.Models
{

    //[MetadataType(typeof(PersonMetaData))]

    public partial class Person : IPerson
    {


        #region Sort stuff

        private List<Problem> GetSortedList()
        {
            List<Problem> problemList = Worklist.ToList().Where(x => x.SolvedAtTime == null && x.IsDeadlineApproved == true).ToList();

            List<Problem> problemWithoutDeadline = Worklist.ToList().Where(x => x.SolvedAtTime == null && (x.IsDeadlineApproved == false || x.IsDeadlineApproved == null)).ToList();


            problemList.Sort(Problem.GetComparer());

            problemWithoutDeadline.Sort(Problem.GetComparer());

            problemList.AddRange(problemWithoutDeadline);

            return problemList;
        }
        public List<Problem> SortedWorklist { get { return GetSortedList(); } }

        #endregion

        #region Role Stuff
        private List<Role> _roles;
        /*public class PersonMetaData
        {
           


        }*/

        public List<Role> Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = Tools.SQLf.GetRoles();
                    List<Role> allRoles;
                    try
                    {
                        allRoles = Tools.SQLf.GetRolesOfUser(this.Name);
              
                        foreach (var role in _roles)
                        {
                            foreach (var item in allRoles)
                            {
                                if (item.Name == role.Name)
                                {
                                    role.Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                    catch (ArgumentException)
                    {

                    }
                }
                
                return _roles;
            }

            private set
            {
                _roles = value;
            }
        }

        public bool IsStaff()
        {
            foreach (var role in Roles)
            {
                if (role.Name == "Staff")
                {
                    if (role.Selected)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }
        #endregion

        #region Workload and ETA
        public double Workload { get { return GetWorkload(); } }

    

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public double GetWorkload()
        {
            TimeSpan PersonTime = new TimeSpan(0,0,0,0);

            foreach (Problem problem in Worklist.Where(x => x.SolvedAtTime == null))
            {
                PersonTime = PersonTime.Add(problem.EstimatedTimeConsumption);
            }

            return PersonTime.TotalMinutes;

        }
        #endregion

        #region Cascade Problem

        public void CascadeProblems(Department oldDep, Department newDep)
        {
               if (oldDep != null)
            {
                if (Worklist != null)
                {
                    foreach (var problem in Worklist.ToList())
                    {
                        if (oldDep.Persons.Count == 0 || newDep == null)
                        {
                            problem.Reassignable = false;
                        }
                        else
                        {
                            if (problem.Reassignable == true)
                            {
                                problem.AssignedTo = (Person)ProblemDistributer.GetStaff(problem, oldDep);
                            }
                        }

                    }
                }
            }
        }

        public void SetNewDepartment(Department newDep)
        {
            var oldDep = Department; 
            Department = newDep;
         
                CascadeProblems(oldDep, newDep);
          

        }
        #endregion

        #region Statistics

        /// <summary>
        /// Get the average time per problem solved by the staff
        /// </summary>
        /// <returns></returns>
        public TimeSpan AverageTimePerProblem()
        {
            return AverageTime("PerProblem");
        }

        /// <summary>
        ///  Gets the average solving time per problem solved in the last week.
        /// </summary>
        /// <returns></returns>
        public TimeSpan AverageTimePerProblemLastWeek()
        {
            return AverageTime("LastWeek");
        }


        private TimeSpan AverageTime(string method)
        {
            int totalTime = 0;
            int problems = 0;
              IEnumerable<Problem> worklist = null;
              if (method == "LastWeek")
              {
                  var lastWeek = DateTime.Now;
                  var aWeek = new TimeSpan(7,0, 0, 0);
                  lastWeek = lastWeek.Subtract(aWeek);
                  worklist = Worklist.Where(x => x.SolvedAtTime > lastWeek);
              }
              else
              {
                  worklist = Worklist.Where(x => x.SolvedAtTime != null);
              }

            foreach(var problem in worklist)
            {
                problems++;
                totalTime = (int)((TimeSpan)(problem.Added_date - problem.SolvedAtTime)).TotalMinutes;
            }
            if (problems == 0)
                return new TimeSpan();
            else 
                return new TimeSpan(0, totalTime / problems,0);
        }

        #endregion

    }

    public interface IPerson 
    {
        bool IsStaff();
        double GetWorkload();
        string Name { get; set; }
        string Email { get; set; }
        EntityCollection<Problem> Worklist { get; set; }
        int Id { get; set; }
        Department Department { get;  }
    }
}