using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Collections;

namespace HoplaHelpdesk.Tools
{
    
    public class ProblemComparer<T>: IComparer<T>
    {
        public int Compare(T a, T b)
        {
            Problem proA = a as Problem;
            Problem proB = a as Problem;
            return proB.Priority.CompareTo(proA.Priority);
            
        }
    }
  
}