using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Tools
{
    
    public static class MaxPriority
    {
        static hoplaEntities db = new hoplaEntities();
        static public double max
        {
            get {
                double maxpriority = (double)int.MinValue;
                for (int i = 0; i < db.TagSet.ToList().Count; i++)
                {
                    if (db.TagSet.ToList().ElementAt(i).Priority > maxpriority)
                    {
                        maxpriority = db.TagSet.ToList().ElementAt(i).Priority;
                    }
                }
                return maxpriority;
            }
        }
    }
}