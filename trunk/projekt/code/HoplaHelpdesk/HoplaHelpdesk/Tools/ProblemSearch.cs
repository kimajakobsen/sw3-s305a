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
        private static const int _maxProblems = 10;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catTag">A CategoryTagSelectionViewModel</param>
        /// <param name="db">Hopla entitites</param>
        /// <returns></returns>
        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, hoplaEntities db)
        {
            List<Problem> result;
            int problemsFound = 0;
            int noOfTagsToRemove = 0;
            List<int> tagsToRemove;
            List<Tag> tags = catTag.AllTagsSelected();

            List<List<Problem>> temp = new List<List<Problem>>();
            temp.Add(db.ProblemSet.ToList());

            if (catTag.AllTagsSelected().Count != 0)
            {
                while (problemsFound < _maxProblems)
                {
                    tagsToRemove = new List<int>();
                    for (int i = 0; i < noOfTagsToRemove; i++)
                    {
                        tagsToRemove.Add(i);
                    }
                    try
                    {
                        while (true)
                        {
                            List<Tag> currentSearch = tags.RemoveNext(ref tagsToRemove);
                            foreach (Tag tag in currentSearch)
                            {
                                temp.Add(temp[temp.Count - 1].Where(x => x.Tags.Contains(db.TagSet.FirstOrDefault(y => y.Id == tag.Id))).ToList());
                            }
                        }
                    }
                    catch (NotSupportedException ex)
                    {

                    }
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