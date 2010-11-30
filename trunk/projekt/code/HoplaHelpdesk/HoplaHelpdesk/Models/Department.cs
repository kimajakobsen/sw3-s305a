using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;
using HoplaHelpdesk.Tools;

namespace HoplaHelpdesk.Models
{
    public partial class Department
    {

        public string Name
        {
            get { return DepartmentName; }
            set { DepartmentName = value; }
        }

        public void BalanceWorkload()
        {
           

            for (var i = 0; i < Persons.Count; i++ )
            {
                var max = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Max(x => x.GetWorkload()));
                var min = Persons.FirstOrDefault(y => y.GetWorkload() == Persons.Min(x => x.GetWorkload()));
                if (max == min)
                {
                    return; 
                }
                bool couldStillMove = true;
                do
                {


                    // Finde the reassignable problem with the highest priority.
                    max.Worklist.ToList().Sort(Problem.GetComparer());
                    var problemToBeMoved = max.Worklist.FirstOrDefault(y => y.Reassignable == true && y.HasBeen == false);
                    //var problemToBeMoved = max.Worklist.FirstOrDefault(y => y.Priority == max.Worklist.Where(z => z.Reassignable == true && z.HasBeen == false).Max(x => x.Priority) && y.Reassignable == true && y.HasBeen == false);
                  
                    if (problemToBeMoved == null)
                    {
                        couldStillMove = false;
                    }
                    else
                    {
                        problemToBeMoved.HasBeen = true;

                        // Reassign the highest priority problem to staff called min.
                        problemToBeMoved.AssignedTo = min;
                        if (min.Workload > max.Workload)
                        {
                            // Move it back
                            problemToBeMoved.AssignedTo = max;
                            couldStillMove = false;
                        }
                        else if (min.Workload == max.Workload)
                        {
                            // Don't move bakc if they are equal
                            couldStillMove = false;
                        }
                    }

                } while (couldStillMove);
            } 
        }
        
    }
}