using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;
using System.Data.Linq;
using HoplaHelpdesk.Helpers;

namespace HoplaHelpdesk.Tools
{
    public static class ProblemSearch
    {
        private static int _maxProblems = 10;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catTag">A CategoryTagSelectionViewModel</param>
        /// <param name="db">Hopla entitites</param>
        /// <returns></returns>
        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, hoplaEntities db)
        {
            List<Problem> result = new List<Problem>();
            int noOfTagsToRemove = 0;
            List<int> tagsToRemove;
            List<Tag> tags = catTag.AllTagsSelected();

            List<Problem> temp = new List<Problem>();
            

            if (tags.Count != 0)
            {
                while (result.Count < _maxProblems && noOfTagsToRemove < tags.Count)
                {
                    temp = (db.ProblemSet.ToList());
                    tagsToRemove = new List<int>();
                    for (int i = 0; i < noOfTagsToRemove; i++)
                    {
                        tagsToRemove.Add(i);
                    }
                    try
                    {
                        List<Tag> currentSearch = tags.RemoveCurrent(tagsToRemove);
                        while (true)
                        {
                            foreach (Tag tag in currentSearch)
                            {
                                temp = temp.Where(x => x.Tags.Contains(db.TagSet.FirstOrDefault(y => y.Id == tag.Id))).ToList();
                            }
                            currentSearch = tags.RemoveNext(ref tagsToRemove);
                            result.AddRangeNoDuplicates(temp.ToList());
                        }
                    }
                    catch (NotSupportedException ex)
                    {
                        noOfTagsToRemove++;
                        result.AddRangeNoDuplicates(temp.ToList());
                    }
                }
            }

            if (result.Count() < _maxProblems)
            {
                temp = (db.ProblemSet.Where(x => x.Tags.Count == 0).ToList());
                result.AddRangeNoDuplicates(temp);
            }

            return result;
        }

    }
}