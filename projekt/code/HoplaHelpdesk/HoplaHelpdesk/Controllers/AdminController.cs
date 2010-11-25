using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    public class AdminController : Controller
    {
        hoplaEntities DB = new hoplaEntities();
        //
        // GET: /Admin/
        
        public String index(String name,String role)
        {
            string msg = HttpUtility.HtmlEncode("Admin.index, Name = " + name + ", Role = " + role);
            String both = "name: " + name + " Role: " + role;
        return both;
        }
        
        
        public ActionResult AddUserToRole (String user, String role)
        {
            String msg = "";
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
                Roles.AddUserToRole(user, role);
                msg = user + " is assigned to " + role + ".";
            }

            return View(msg);
            
        }

    }
}
