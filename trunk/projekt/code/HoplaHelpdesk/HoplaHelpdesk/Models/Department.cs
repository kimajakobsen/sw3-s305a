using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Models
{
    public partial class Department
    {

        public string Name
        {
            get { return DepartmentName; }
            set { DepartmentName = value; }
        }


        
    }
}