using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;

namespace HoplaHelpdesk.Models
{

    [MetadataType(typeof(PersonMetaData))]
    public partial class Person
    {





        public class PersonMetaData
        {
           


        }


        public bool IsStaff()
        {
         
            if (Roles.IsUserInRole("Staff", Membership.GetUserNameByEmail(Email)))
            {
                return true;
            }
            else if (Roles.IsUserInRole("staff", Membership.GetUserNameByEmail(Email)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}