using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Models
{

    //[MetadataType(typeof(PersonMetaData))]
    public partial class Person : IPerson
    {
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
                    _roles = Tools.SQLf.GetRolesOfUser(this.Name);
                    foreach (var role in _roles)
                    {
                        role.Selected = true;
                    }
                    List<Role> allRoles = Tools.SQLf.GetRoles();
                    foreach (var role in allRoles)
                    {
                        if (!_roles.Contains(role))
                        {
                            _roles.Add(role);
                        }
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
            if (DepartmentId == 0)
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        public double Workload { get { return GetWorkload(); } }



        public double GetWorkload()
        {
            int NumberOfTags = 0;
            decimal? ProblemTime = 0;
            decimal? PersonTime = 0;

            foreach (Problem problem in Worklist)
            {
                foreach (Tag tag in problem.Tags)
                {
                    if (tag.AverageTimeSpent != null)
                    {
                        ProblemTime = ProblemTime + tag.AverageTimeSpent;
                    }
                    NumberOfTags++;
                }

                if(NumberOfTags == 0){
                    NumberOfTags = 1;
                    ProblemTime = 10;
                }

                PersonTime = PersonTime + ProblemTime/NumberOfTags;
                NumberOfTags = 0;
                ProblemTime = 0;
                 

            }

            return (double)PersonTime;
        }
        /*
        public double GetWorkload()
        {
            int TotalNumberOfTags = 0;
            decimal? ProblemTime = 0;
            decimal? PersonTime = 0;

            foreach (Problem problem in Problems)
            {
                foreach (Tag tag in problem.Tags)
                {
                    if (tag.AverageTimeSpent != null)
                    {
                        ProblemTime = ProblemTime + tag.AverageTimeSpent;
                    }
                    TotalNumberOfTags++;
                }


                PersonTime = PersonTime + ProblemTime;
                ProblemTime = 0;

            }

            return ((double)(PersonTime)/TotalNumberOfTags);
        }
         * */
    }

    public interface IPerson 
    {
        bool IsStaff();
        double GetWorkload();
        string Name { get; set; }
        string Email { get; set; }
        EntityCollection<Problem> Worklist { get; set; }
        int Id { get; set; }
        Department Department { get; set; }
    }
}