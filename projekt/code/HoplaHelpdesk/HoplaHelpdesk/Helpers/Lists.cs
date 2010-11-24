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
                if (formerRemoved[count] < list.Count)
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
    }
}