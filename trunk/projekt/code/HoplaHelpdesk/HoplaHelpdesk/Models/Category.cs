using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{

    public partial class Category
    {
        /// <summary>
        /// This is used to hold the department to check if it contains staff. The Department property can not be used since the mapper will try to map it which is impossible do to relations. 
        /// </summary>
        

        public bool Hidden {
            get { return IsHidden(); }
            set 
            { 
                if (value == true) Hide();
                else UnHide();
            }
        }

        virtual protected bool IsHidden()
        {

            if (Tags == null || Tags.Count == 0 || Department.Persons == null || Department.Persons.Count == 0)
            {
                return true;
            }
            foreach (var tag in Tags)
            {
                if (!tag.Hidden)
                {
                    return false;
                }
            }
            return true;
        }


        private void Hide()
        {
            foreach (var tag in Tags)
            {
                tag.Hidden = true;
            }
        }


        private void UnHide()
        {
            foreach (var tag in Tags)
            {
                tag.Hidden = false;
            }
        }
    }
}