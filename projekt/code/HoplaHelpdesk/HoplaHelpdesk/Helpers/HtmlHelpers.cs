using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Objects.DataClasses;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.Helpers
{
    public static class HtmlHelpers
    {
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length > length)
            {
                return input.Substring(0, length - 3) + "...";
            }

            return input;
        }

        public static MvcHtmlString CatTagDisplay(this HtmlHelper helper, EntityCollection<Tag> tags)
        {
            var s = "";
            var cats = new List<Category>();
            foreach (var tag in tags)
            {
                if(!cats.Contains(tag.Category)){
                    cats.Add(tag.Category);
                }
            }

            foreach (var cat in cats)
            {
                s += "<strong>" + cat.Name + "</strong><br /> ";
                foreach(var tag in cat.Tags)
                {
                    s += tag.Name + "<br />";
                } 
            }
            var str =  MvcHtmlString.Create(s);
            
            return str;
        }
    }
}