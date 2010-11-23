﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;
using System.Data.Objects.DataClasses;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.ViewModels
{
    /// <summary>
    /// Contains a list of CategoryWithListViewModel.
    /// </summary>
    public class CategoryTagSelectionViewModel
    {
        /// <summary>
        /// All the categories assigned to the viewmodel.
        /// </summary>
        public List<CategoryWithListViewModel> Categories {get;set;}

        /// <summary>
        /// Converts a List of Categories to a list of CategoryWithListViewModels
        /// </summary>
        /// <param name="list">A List of Categories.</param>
        /// <returns>A list of CategoryWithListViewModels</returns>
        public static List<CategoryWithListViewModel> ConvertTo(List<Category> list)
        {
        
            var superList = new List<CategoryWithListViewModel>();
            foreach (var item in list)
            {
                superList.Add(new CategoryWithListViewModel(item));
            }
            return superList;
        }


        /// <summary>
        /// Converts a EntityCollection of Categories to a list of CategoryWithListViewModels
        /// </summary>
        /// <param name="list">A EntityCollection of Categories.</param>
        /// <returns>A list of CategoryWithListViewModels</returns>
        public static List<CategoryWithListViewModel> ConvertTo(EntityCollection<Category> list)
        {
            return CategoryTagSelectionViewModel.ConvertTo(list.ToList());
        }


        public List<Tag> AllTags()
        {
            var tags = new List<Tag>();



            return tags;

        }
    }
}