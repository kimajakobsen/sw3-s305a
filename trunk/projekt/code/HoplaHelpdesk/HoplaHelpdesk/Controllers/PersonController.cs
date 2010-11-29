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

        public ActionResult Details()
        {
           var Personlist = db.PersonSet.ToList();

           var viewmodel = new PersonListViewModel() { Persons = Personlist };
           return View(viewmodel);
            
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
 
        public ActionResult Edit(int id, string name, string email)
        {
            return View();
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
            Tools.SQLf sql = new Tools.SQLf();

            string msg = HttpUtility.HtmlEncode("admin.AddUserToRole, User = " + user + "&role = " + role);

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
            else if (sql.DoUserExists(user) == false)
            {
                msg = "User dont exists";
            }
            else if (sql.UserIsAlreadyInThatRole(user, role) == true)
            {
                msg = user + " is already assigned to " + role + ".";
            }
            else
            {
                sql.UserToRole(user, role);
                //msg = "|"+sql.UserIsAlreadyInThatRole(user, role)+"|";
                msg = user + " is assigned to " + role + ".";
            }
            return msg;
        }

        [Authorize(Roles = "admin")]
        public String UnRole(string user, string role)
        {
            Tools.SQLf sql = new Tools.SQLf();

            string msg = HttpUtility.HtmlEncode("admin.AddUserToRole, User = " + user + "&role = " + role);

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
            else if (sql.DoUserExists(user) == false)
            {
                msg = "User dont exists";
            }
            else if (sql.UserIsAlreadyInThatRole(user, role) == false)
            {
                msg = user + " is not " + role + ", did you mean to remove " + user + " from another role?";
            }
            else
            {
                sql.UnRole(user, role);
                //msg = "|"+sql.UserIsAlreadyInThatRole(user, role)+"|";
                msg = user + " is no longer " + role + ".";
            }
            return msg;
        }
    }
}
