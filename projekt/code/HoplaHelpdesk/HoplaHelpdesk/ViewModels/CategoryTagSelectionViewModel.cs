using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Data.Objects.DataClasses;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.ViewModels
{
    public class CategoryTagSelectionViewModel
    {
        public List<CategoryWithListViewModel> Categories {get;set;}


        public static List<CategoryWithListViewModel> ConvertTo(EntityCollection<Category> list)
        {
            var newList = list.ToList();
            var superList = new List<CategoryWithListViewModel>();
            foreach (var item in list)
            {
                superList.Add(new CategoryWithListViewModel(item));
            }
            return superList;
        }
    }
}