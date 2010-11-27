using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{

    public partial class Category
    {

        public bool Hidden {
            get { return IsHidden(); }
            set { if (value == true) Hide(); else UnHide(); }
        }

        private bool IsHidden()
        {
            
            if (Tags == null || Tags.Count == 0)
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