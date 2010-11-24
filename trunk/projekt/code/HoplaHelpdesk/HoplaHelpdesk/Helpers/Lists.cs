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
    }
}