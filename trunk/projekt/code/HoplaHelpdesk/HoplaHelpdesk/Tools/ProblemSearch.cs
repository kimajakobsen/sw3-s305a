using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;
using System.Data.Linq;

namespace HoplaHelpdesk.Tools
{
    public static class ProblemSearch
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="catTag">A CategoryTagSelectionViewModel</param>
        /// <param name="db">Hopla entitites</param>
        /// <returns></returns>
        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, hoplaEntities db)
        {
            List<Problem> result;

            List<List<Problem>> temp = new List<List<Problem>>();
            temp.Add(db.ProblemSet.ToList());

            if (catTag.AllTagsSelected().Count != 0)
            {
                foreach (Tag tag in catTag.AllTagsSelected())
                {
                    temp.Add(temp[temp.Count-1].Where(x => x.Tags.Contains(db.TagSet.FirstOrDefault(y => y.Id == tag.Id))).ToList());
                }

                try
                {
                    result = temp[temp.Count-1].ToList();
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                result = temp[0].Where(x => x.Tags.Count == 0).ToList();
            }

            return result;
        }

    }
}