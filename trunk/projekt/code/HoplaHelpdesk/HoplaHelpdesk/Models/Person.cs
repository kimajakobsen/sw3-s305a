using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Models
{

    [MetadataType(typeof(PersonMetaData))]
    public partial class Person : IPerson
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

        public double GetWorkload()
        {
            return Worklist.Count;
        }
    }

    public interface IPerson {
        bool IsStaff();
        double GetWorkload();
        string Name { get; set; }
        string Email { get; set; }
        EntityCollection<Problem> Worklist { get; set; }
        int Id { get; set; }
        Department Department { get; set; }
    }
}