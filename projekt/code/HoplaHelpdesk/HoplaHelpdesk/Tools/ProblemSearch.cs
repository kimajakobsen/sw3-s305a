using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;
using System.Data.Linq;
using HoplaHelpdesk.Helpers;
using System.Data.Objects;

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
        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, List<Problem> allProblems,
            List<Tag> allTags, int listMinSize)
        {
            List<Problem> result = new List<Problem>();
            List<Problem> tempResult;
            int noOfTagsToRemove = 0;
            List<int> tagsToRemove;
            List<Tag> tags = catTag.AllTagsSelected();

            List<Problem> temp = new List<Problem>();
            

            if (tags.Count != 0)
            {
                while (result.Count < listMinSize && noOfTagsToRemove < tags.Count)
                {
                    tempResult = new List<Problem>();  
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
                            temp = allProblems.ToList();
                            foreach (Tag tag in currentSearch)
                            {
                                temp = temp.Where(x => x.Tags.Contains(allTags.FirstOrDefault(y => y.Id == tag.Id))).ToList();
                            }
                            tempResult.AddRangeNoDuplicates(temp.ToList());
                            currentSearch = tags.RemoveNext(ref tagsToRemove);
                        }
                    }
                    catch (NotSupportedException)
                    {
                        noOfTagsToRemove++;
                        tempResult.SortProblemsByLeastTags();
                        result.AddRangeNoDuplicates(tempResult.ToList());
                    }
                }
            }

            int count = 0;
            while (result.Count() < listMinSize && count <= allTags.Count)
            {
                temp = (allProblems.Where(x => x.Tags.Count == count).ToList());
                result.AddRangeNoDuplicates(temp);
                count++;
            }

            return result;
        }

        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, List<Problem> allProblems,
            List<Tag> allTags, int listMinSize, IPerson subscriber, List<Person> allPersons)
        {
            if (subscriber == null)
            {
                throw new NullReferenceException("Subscriber is null, not so good");
            }

            return Search(catTag, allProblems.Where(x => x.Persons.Contains(allPersons.FirstOrDefault(y => y.Id == subscriber.Id))).ToList(),
                allTags, listMinSize);
        }
    }
}