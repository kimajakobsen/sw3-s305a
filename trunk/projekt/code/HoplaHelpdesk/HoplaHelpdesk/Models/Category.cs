using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoplaHelpdesk.Models
{
    public partial class Category
    {

        public bool IsHidden()
        {
            bool isHidden = true;
            foreach (var tag in Tags)
            {
                if (!tag.Hidden)
                {
                    isHidden = false;
                }


            }
            return isHidden;
        }
    }
}