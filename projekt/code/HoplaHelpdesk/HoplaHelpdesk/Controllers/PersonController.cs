using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Web.Routing;
using System.Web.Security;
using HoplaHelpdesk.ViewModels;
using HoplaHelpdesk.Tools;


namespace HoplaHelpdesk.Controllers
{
    public class PersonController : Controller
    {
        hoplaEntities db = new hoplaEntities();

        //
        // GET: /Person/

        public ActionResult Index()
        {
            var Personlist = db.PersonSet.ToList();

            var viewmodel = new PersonListViewModel() { Persons = Personlist };


            return View(viewmodel);   
        }

        
        //
        // GET: /Person/Create

        public ActionResult Create(int? id)
        {

            return View();
        }

        //
        // GET: /Person/Details

        public ActionResult Details(int prevDepartment)
        {
           var Personlist = db.PersonSet.ToList();
           ViewData["homeDepartment"] = prevDepartment;
           var viewmodel = new PersonListViewModel() { Persons = Personlist };
           return View(viewmodel);
            
        }

        public ActionResult ChangeDepartment(int DepId, int PerId)
        {

            db.PersonSet.FirstOrDefault(x => x.Id == PerId).DepartmentId = DepId;
            db.SaveChanges();


            return RedirectToAction("Edit", "Department", new { id = DepId });
        }

        //
        // POST: /Person/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Person/Edit/5
 
        public ActionResult Edit(int id)
        {
            Person person = db.PersonSet.FirstOrDefault(x => x.Id == id);
            //ViewData["asp_User"] =Tools.SQLf.GetRoleOfUser(person.Name);

            return View(new EditPersonViewModel
            {
                Person = person,
                AllDepartments = db.DepartmentSet.ToList(),
                Roles = Tools.SQLf.GetRoles(),
                Role = Tools.SQLf.GetRolesOfUser(person.Name)[0]
            });

            
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EditPersonViewModel collection)
        {
            var person = db.PersonSet.FirstOrDefault(x => x.Id == id);

            try
            {
                UpdateModel(person, "Person");
                Tools.SQLf.UserToRole(person.Name, collection.Role.Name);
                db.SaveChanges();
 
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit",new {id});
            }
        }

        //
        // GET: /Person/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Person/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "admin")]
        public String AddUserToRole(string user, string role)
        {
            string msg = HttpUtility.HtmlEncode("Person.AddUserToRole, User = " + user + "&role = " + role);

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
            else if (SQLf.DoUserExists(user) == false)
            {
                msg = "User dont exists";
            }
            else if (SQLf.UserIsAlreadyInThatRole(user, role) == true)
            {
                msg = user + " is already assigned to " + role + ".";
            }
            else
            {
                SQLf.UserToRole(user, role);
                //msg = "|"+sql.UserIsAlreadyInThatRole(user, role)+"|";
                msg = user + " is assigned to " + role + ".";
            }
            return msg;
        }

        [Authorize(Roles = "admin")]
        public String UnRole(string user, string role)
        {
            string msg = HttpUtility.HtmlEncode("Person.UnRole, User = " + user + "&role = " + role);

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
            else if (SQLf.DoUserExists(user) == false)
            {
                msg = "User dont exists";
            }
            else if (SQLf.UserIsAlreadyInThatRole(user, role) == false)
            {
                msg = user + " is not " + role + ", did you mean to remove " + user + " from another role?";
            }
            else
            {
                SQLf.UnRole(user, role);
                //msg = "|"+sql.UserIsAlreadyInThatRole(user, role)+"|";
                msg = user + " is no longer " + role + ".";
            }
            return msg;
        }
        [Authorize(Roles = "admin")]
        //ITS WORKING !!! WAAAOUUU !
        public String IsStaff(string user, string role)
        {
            string msg = HttpUtility.HtmlEncode("Person.IsStaff, User = " + user);

            //Check if any username is provided
            if (user == null || user == "")
            {
                msg = "No username is provided";
            }
            //Check User by username provided, if username equals null, the user dont exists
            else if (SQLf.DoUserExists(user) == false)
            {
                msg = "User dont exists";
            }
            else if (SQLf.IsStaff(user) == true)
            {
                msg = user + " is staff.";
            }
            else
            {
                //msg = "|"+sql.UserIsAlreadyInThatRole(user, role)+"|";
                msg = user + " is not staff.";
            }
            return msg;
    }

        [Authorize(Roles = "admin")]
        public String AddRole(String role, String description)
        {
            string msg = HttpUtility.HtmlEncode("Person.AddRole, role = " + role + "&description = " + description);

            //Check if any role is provided
            if (role == null || role == "")
            {
                msg = "No role is provided";
            }
            //Check if RoleExists
            else if (Roles.RoleExists(role) == true)
            {
                msg = role + "already exists.";
            }
            //Check User by username provided, if username equals null, the user dont exists
            else if (description == null || description == "")
            {
                SQLf.AddRole(role, description);
                msg = role + " is created without a desciption.";
            }
            else
            {
                SQLf.AddRole(role, description);
                msg = role + " is created with following desciption:" + description;
            }
            return msg;
        }

    }
}
