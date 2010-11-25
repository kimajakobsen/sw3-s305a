using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace HoplaHelpdesk.Helpers
{
    public static class Lists
    {
        /// <summary>
        /// Converts the list to an <code>EntityCollection</code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns> an <code>EntityColection</code> containing the same elements as the list</returns>
        public static EntityCollection<T> ToEntityCollection<T>(this List<T> list) where T : class
        {
            EntityCollection<T> result = new EntityCollection<T>();

            foreach (var t in list)
            {
                result.Add(t);
            }

            return result;
        }
        

        /// <summary>
        /// This function increments the <paramref name="formerRemoved"/> to the next set to be removed
        /// and removes the entries specified in <paramref name="formerRemoved"/> from the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="formerRemoved">A list where integers representing the indices of the list to be removed</param>
        /// <returns>A new list where the specified entries in <paramref name="formerRemoved"/> are removed from the list </returns>
        public static List<T> RemoveNext<T>(this List<T> list, ref List<int> formerRemoved)
        {
            int count = formerRemoved.Count;
            List<T> result = new List<T>();

            for (int i = count-1 ; i >= 0 ; i--)
            {
                int current = ++formerRemoved[i];
                
                for (int j = i+1; j < count; j++)
                {
                    formerRemoved[j] = ++current;
                }
                if (formerRemoved[count-1] < list.Count)
                {
                    return list.RemoveCurrent(formerRemoved);
                }
            }

            throw new NotSupportedException("");
        }

        /// <summary>
        /// This function removes the entries specified in <paramref name="removeList"/> from the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="removeList">A list where integers representing the indices of the list to be removed</param>
        /// <returns>A new list where the specified entries in <paramref name="removeList"/> are removed from the list </returns>
        public static List<T> RemoveCurrent<T>(this List<T> list, List<int> removeList)
        {
            int count = removeList.Count;
            List<T> result = new List<T>();

            if (removeList != null && removeList.Count != 0)
            {
                for (int k = 0, l = 0; k < list.Count; k++)
                {
                    if (k != removeList[l])
                    {
                        result.Add(list[k]);
                    }
                    else
                    {
                        l = (l + 1) % count;
                    }
                }
            }
            else
            {
                for (int k = 0; k < list.Count; k++)
                {
                    result.Add(list[k]);
                }
            }

            return result;
        }

        public static void SortProblemsByLeastTags<T>(this List<T> list, int start, int length) where T : Problem
        {
            try
            {
                QuickSort(list, start, start + length,
                    (x, y) => { return x.Tags.Count - y.Tags.Count; });
            }
            catch (IndexOutOfRangeException ex)
            {
                throw;
            }

            return;
        }

        public static void SortProblemsByLeastTags<T>(this List<T> list, int start) where T : Problem
        {
            list.SortProblemsByLeastTags(start, list.Count - 1);

            return;
        }

        public static void SortProblemsByLeastTags<T>(this List<T> list) where T : Problem
        {
            list.SortProblemsByLeastTags(0);

            return;
        }

        public static void SortProblemsByMostTags<T>(this List<T> list, int start, int length) where T : Problem
        {
            try
            {
                QuickSort(list, start, start + length,
                    (x, y) => { return y.Tags.Count - x.Tags.Count; });
            }
            catch (IndexOutOfRangeException ex)
            {
                throw;
            }

            return;
        }

        public static void AddRangeNoDuplicates<T>(this List<T> list, IEnumerable<T> range) where T : Problem
        {
            foreach (var item in range)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="compareFunction">This delegate must compare two elements of the type
        /// <code>T</code> and return negative if the first element should be before the second,
        ///  positive if the first one should be first in the list, and 0 if it doesn't matter</param>
        private static void QuickSort<T>(List<T> list, int start, int end, Func<T,T,int> compareFunction)
        {
            if (start >= end)
            {
                return;
            }

            Random rand = new Random();
            T pivot = list[rand.Next(start,end)];
            int i = start;
            int j = end;

            while (i < j)
            {
                if (compareFunction(list[i], pivot) < 0)
                {
                    i++;
                }
                else
                {
                    Swap<T>(list, i, j);
                    j--;
                }

                if (compareFunction(list[j], pivot) > 0)
                {
                    j--;
                }
                else
                {
                    Swap<T>(list, i, j);
                    i++;
                }
            }

            QuickSort(list, start, j, compareFunction);
            QuickSort(list, i, end, compareFunction);

            return;
        }

        private static void Swap<T>(ref T input1, ref T input2)
        {
            T temp = input1;
            input1 = input2;
            input2 = temp;
        }

        private static void Swap<T>(List<T> list, int input1, int input2)
        {
            T temp = list[input1];
            list[input1] = list[input2];
            list[input2] = temp;
        }
    }
}