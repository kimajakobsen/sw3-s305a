using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    public class CategoryWithListViewModel : Category
    {
        public List<Tag> TagList { get; set; }

        public CategoryWithListViewModel()
        {

        }
        public CategoryWithListViewModel(Category cat)
        {
            Id = cat.Id;
            Name = cat.Name;
            TagList = cat.Tags.ToList();

        }
        
    }

}