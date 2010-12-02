using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.ViewModels
{
    /// <summary>
    /// This is a wrapper for the Model.Category Class. This uses a List&lt;T&gt; enstead of a EntityCollection&lt;T&gt. Beaware that it does not map all properties of the Category.
    /// </summary>
    public class CategoryWithListViewModel : Category
    {

        /// <summary>
        /// <code>Tags</code> list is the same as <code>Tag</code> except that is uses a List&lt;T&gt; enstead of a EntityCollection&lt;T&gt;
        /// </summary>
        public List<Tag> TagList { get; set; }


        /// <summary>
        /// Empty constructor
        /// </summary>
        public CategoryWithListViewModel():base()
        {

        }

        /// <summary>
        /// This maps a Category to a CategoryWithListViewModel. Beware that it does not map all Category Properties. 
        /// </summary>
        /// <param name="cat">A category, which will be mapped to a CategoryWithListViewModel</param>
        public CategoryWithListViewModel(Category cat):base()
        {
            Id = cat.Id;
            Name = cat.Name;
            TagList = cat.Tags.ToList();

        }

        override protected bool IsHidden()
        {

            if (TagList == null || TagList.Count == 0 || Department.Persons.Count == 0 || Department.Persons == null)
            {
                return true;  
            }
            foreach (var tag in TagList)
            {
                if (!tag.Hidden)
                {
                    return false;
                }
            }
            return true;
        }
    }

}