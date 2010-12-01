using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using System.Data.SqlClient;

namespace HoplaHelpdesk.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        hoplaEntities db = new hoplaEntities();

        public ActionResult Index()
        {
            try
            {
                if (!db.DatabaseExists())
                {
                    ViewData["Message"] = "Database does not exist!";

                    return View();
                }

                switch (Tools.SQLf.GetRoles().Count)
                { 
                    case(0):
                        //No roles in the database, add them!
                        Tools.SQLf.AddRole(HoplaHelpdesk.Models.Constants.AdminRoleName, "Administrates the system");
                        Tools.SQLf.AddRole(HoplaHelpdesk.Models.Constants.StaffRoleName, "Solves problems in the system");
                        Tools.SQLf.AddRole(HoplaHelpdesk.Models.Constants.ClientRoleName, "Commits problems to the system");
                        break;
                    case(3):
                        //There is 3 roles in the database, we hope it is the right ones, and break
                        break;
                    default:
                        List<Role> toAdd = new List<Role>
                        {
                            new Role
                            {
                                Name = HoplaHelpdesk.Models.Constants.AdminRoleName,
                                Description = "Administrates the system"
                            },
                            new Role
                            {
                                Name = HoplaHelpdesk.Models.Constants.StaffRoleName, 
                                Description = "Solves problems in the system"
                            },
                            new Role
                            {
                                Name = HoplaHelpdesk.Models.Constants.ClientRoleName, 
                                Description = "Commits problems to the system"
                            }
                        };
                        //We have to add the the three basics roles if they do not exist
                        foreach (var item in Tools.SQLf.GetRoles())
                        {
                            foreach (var add in toAdd)
                            {
                                if (item.Name == add.Name)
                                {
                                    //The role "add" is already in the database, no need to add:
                                    toAdd.Remove(add);
                                }
                            }
                        }

                        //Now add the roles not alreasy in the database
                        foreach (var item in toAdd)
                        {
                            Tools.SQLf.AddRole(item.Name, item.Description);
                        }
                        break;
                }

                
                if (db.PersonSet.FirstOrDefault(x => x.Roles.FirstOrDefault(y => y.Name == HoplaHelpdesk.Models.Constants.AdminRoleName).Selected) == null)
                {
                    //There is no admins, so we will add root if he does not exist and add him to admin role if he does
                    Person root = db.PersonSet.FirstOrDefault(x => x.Name == HoplaHelpdesk.Models.Constants.RootName);
                    if (root == null || !Tools.SQLf.DoUserExists(root.Name))
                    {
                        //The root user does not exist, add him
                        var regModel = new RegisterModel
                        {
                            UserName = HoplaHelpdesk.Models.Constants.RootName,
                            Password = HoplaHelpdesk.Models.Constants.RootPassword,
                            ConfirmPassword = HoplaHelpdesk.Models.Constants.RootPassword,
                            Email = "N/A"
                        };
                        return RedirectToAction("Register", "Account", new { model = regModel });
                    }
                    if (!root.Roles.FirstOrDefault(x => x.Name == HoplaHelpdesk.Models.Constants.AdminRoleName).Selected)
                    { 
                        //Root exists but is not an admin, he is therefore added to the admin role
                        (new HoplaHelpdesk.Controllers.PersonController()).AddUserToRole(HoplaHelpdesk.Models.Constants.RootName,HoplaHelpdesk.Models.Constants.AdminRoleName);
                    }
                }

            }
            catch(SqlException)
            {
                ViewData["Message"] = "Could not connect to database!";

                return View();
            }
            ViewData["Message"] = "Welcome to Hopla Helpdesk";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
