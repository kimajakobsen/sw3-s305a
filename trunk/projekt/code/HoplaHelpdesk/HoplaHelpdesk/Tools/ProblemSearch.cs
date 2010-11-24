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

            List<List<Problem>> temp = new List<List<Problem>>();
            temp.Add(db.ProblemSet.ToList());

            if (catTag.AllTagsSelected().Count != 0)
            {
                while (temp.Count < _maxProblems && noOfTagsToRemove < tags.Count)
                {
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
                                temp.Add(temp[temp.Count - 1].Where(x => x.Tags.Contains(db.TagSet.FirstOrDefault(y => y.Id == tag.Id))).ToList());
                            }
                            currentSearch = tags.RemoveNext(ref tagsToRemove);
                        }
                    }
                    catch (NotSupportedException ex)
                    {
                        noOfTagsToRemove++;
                        result.AddRange(temp[temp.Count - 1].ToList());
                    }
                }
            }

            if (result.Count() < _maxProblems)
            {
                result.AddRange(temp[0].Where(x => x.Tags.Count == 0).ToList());
            }

            return result;
        }

    }
}