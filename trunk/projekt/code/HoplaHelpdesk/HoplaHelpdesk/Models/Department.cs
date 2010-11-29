using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;

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
                bool couldStillMove = true;
                do
                {


                    // Finde the reassignable problem with the highest priority.
                    var problemToBeMoved = max.Problems.FirstOrDefault(y => y.Priority == max.Problems.Max(x => x.Priority) && y.Reassignable == true);

                    if (problemToBeMoved == null)
                    {
                        couldStillMove = false;
                    }
                    else
                    {
                        // Reassign the highest priority problem to staff called min.
                        problemToBeMoved.AssignedTo = min;
                        if (min.Workload > max.Workload)
                        {
                            // Move it back
                            problemToBeMoved.AssignedTo = max;
                            couldStillMove = false;
                        }
                    }

                } while (couldStillMove);
            } 
        }
        
    }
}