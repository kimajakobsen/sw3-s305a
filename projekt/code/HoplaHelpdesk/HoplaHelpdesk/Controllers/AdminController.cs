using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using HoplaHelpdesk.Models;
namespace HoplaHelpdesk.Controllers
{
    public class AdminController : Controller
    {
        hoplaEntities DB = new hoplaEntities();
        //
        // GET: /Admin/
        
        public ActionResult index()
        {
            return View();
        }
        
        
        public string AddUserToRole (string user, string role)
        {
            Tools.SQLf sql = new Tools.SQLf();

            string msg = HttpUtility.HtmlEncode("admin.AddUserToRole, User = " + user + "&role = " + role );

            //Check if any username is provided
            if (user == null || user == "")
            {
                msg = "No username is provided";
            }
            //Check if any role is provided
            else if (role == null || role == "")
            {
                msg = "No role is provided";
            } 
            //Check if RoleExists
            else if (Roles.RoleExists(role) == false)
            {
                msg = "Role dont exists";
            }
            //Check User by username provided, if username equals null, the user dont exists
            else if (Membership.FindUsersByName(user) == null)
            {
                msg = "User dont exists";
            }
            else
            {
                sql.UserToRole(user, role);
                msg = user + " is assigned to " + role + ".";
            }

            return msg;
            
        }

    }
}
