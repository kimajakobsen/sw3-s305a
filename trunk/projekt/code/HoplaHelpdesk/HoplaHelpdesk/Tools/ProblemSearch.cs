using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Tools
{
    public static class ProblemSearch
    {
        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, DBEntities db)
        {
            List<Problem> result;

            var temp = db.ProblemSet;

            if (catTag.Categories != null)
            {
                foreach (Tag tag in catTag.AllTagsSelected())
                {
                    temp = (System.Data.Objects.ObjectSet<Problem>)temp.Where(x => x.Tags.Contains(tag));
                }
                
                result = temp.ToList();
            }
            else
            {
                result = temp.Where(x => x.Tags.Count == 0).ToList();
            }

            return result;
        }

    }
}