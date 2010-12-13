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
        private static Comparison<Problem> LeastTagsSolvedFirst = (x, y) =>
        {
            if (x.SolvedAtTime != null && y.SolvedAtTime == null)
            {
                return -1;
            }
            else if (x.SolvedAtTime == null && y.SolvedAtTime != null)
            {
                return 1;
            }
            int dif = x.Tags.Count - y.Tags.Count;
            if (dif != 0)
            {
                return dif;
            }
            return x.Id - y.Id;
        };

        private static Comparison<Problem> LeastTags = (x, y) =>
        {
            int dif = x.Tags.Count - y.Tags.Count;
            if (dif != 0)
            {
                return dif;
            }
            return x.Id - y.Id;
        };

        public static List<Problem> SearchSolvedFirst(CategoryTagSelectionViewModel catTag, List<Problem> allProblems,
            List<Tag> allTags, int listMinSize)
        {
            return InternalSearch(catTag, allProblems, allTags, listMinSize, LeastTagsSolvedFirst);
        }

        public static List<Problem> SearchSolvedFirst(CategoryTagSelectionViewModel catTag, List<Problem> allProblems,
            int listMinSize)
        {
            List<Tag> allTags = new List<Tag>();
            foreach (var prob in allProblems)
            {
                allTags.AddRange(prob.Tags);
            }

            return InternalSearch(catTag, allProblems, allTags, listMinSize, LeastTagsSolvedFirst);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catTag">A CategoryTagSelectionViewModel</param>
        /// <param name="db">Hopla entitites</param>
        /// <returns></returns>
        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, List<Problem> allProblems,
            List<Tag> allTags, int listMinSize)
        {
            return InternalSearch(catTag,allProblems,allTags,listMinSize,LeastTags);
        }

        public static List<Problem> Search(CategoryTagSelectionViewModel catTag, List<Problem> allProblems,
            int listMinSize)
        {
            List<Tag> allTags = new List<Tag>();
            foreach (var prob in allProblems)
            {
                allTags.AddRange(prob.Tags);
            }

            return InternalSearch(catTag, allProblems, allTags, listMinSize, LeastTags);
        }

        private static List<Problem> InternalSearch(CategoryTagSelectionViewModel catTag, List<Problem> allProblems,
            List<Tag> allTags, int listMinSize, Comparison<Problem> compare)
        {
            List<Problem> result = new List<Problem>();
            List<Problem> tempResult;
            int noOfTagsToRemove = 0;
            List<int> tagsToRemove;
            List<Tag> tags = catTag.AllTagsSelected();
            List<Problem> temp = new List<Problem>();

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
                        foreach (Tag curTag in currentSearch)
                        {
                            temp = temp.Where(x => x.Tags.Contains(allTags.FirstOrDefault(y => y.Id == curTag.Id))).ToList();
                        }
                        tempResult.AddRangeNoDuplicates(temp.ToList());
                        currentSearch = tags.RemoveNext(ref tagsToRemove);
                    }
                }
                catch (NotSupportedException)
                {
                    noOfTagsToRemove++;
                    tempResult.Sort(compare);
                    result.AddRangeNoDuplicates(tempResult.ToList());
                }
            }

            tempResult = new List<Problem>();
            int count = 0;
            while (result.Count+tempResult.Count < listMinSize && count <= allTags.Count)
            {
                temp = (allProblems.Where(x => x.Tags.Count == count).ToList());
                tempResult.AddRangeNoDuplicates(temp);
                count++;
            }
            tempResult.Sort(compare);
            result.AddRangeNoDuplicates(tempResult);

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