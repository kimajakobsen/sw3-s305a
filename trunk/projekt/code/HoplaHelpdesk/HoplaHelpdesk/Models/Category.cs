using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{
    public class Category
    {
        public List<Tag> Tags {get;set;}
        public string Title { get; set; }
    }
}