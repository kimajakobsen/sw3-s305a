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
                    for (int k = 0, l = 0; k < list.Count; k++)
                    {
                        if (k != formerRemoved[l])
                        {
                            result.Add(list[k]);
                        }
                        else
                        {
                            l = (l+1) % count;
                        }
                    }

                    return result;
                }
            }

            throw new NotSupportedException("");
        }
    }
}