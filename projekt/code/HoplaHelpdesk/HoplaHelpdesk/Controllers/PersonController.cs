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


        /// <summary>
        /// Reassign the staff from one department to another. 
        /// </summary>
        /// <param name="DepId">Department id</param>
        /// <param name="PerId">Person Id</param>
        /// <returns>A view</returns>
        public ActionResult ChangeDepartment(int DepId, int PerId)
        {
            var person = db.PersonSet.FirstOrDefault(x => x.Id == PerId);
            
            var oldDep = person.Department;
            person.DepartmentId = DepId;
            db.SaveChanges();
            foreach (var problem in person.Worklist)
            {
                if (oldDep.Persons.Count == 0)
                {
                    problem.Reassignable = false;
                }
                else
                {
                    if (problem.Reassignable == true)
                    {
                        problem.AssignedTo = (Person)ProblemDistributer.GetStaff(problem, oldDep);
                    }
                }
                
            }
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
                //Role = Tools.SQLf.GetRolesOfUser(person.Name)[0]
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
                db.SaveChanges();
                //Tools.SQLf.UserToRole(person.Name, collection.Role.Name);
                foreach (var role in collection.Person.Roles)
                {
                    if (role.Selected)
                    {
                        AddUserToRole(person.Name, role.Name);
                    }
                    else
                    {
                        UnRole(person.Name, role.Name);
                    }
                }

                if (person.IsStaff() && person.Department == null)
                {
                    return RedirectToAction("ChooseDepartment", new { id });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit",new {id});
            }
        }

        /// <summary>
        /// This is called when a person is made staff and has no department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ChooseDepartment(int id)
        {
            ViewData["Departments"] = db.DepartmentSet.ToList();
            return View(db.PersonSet.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public ActionResult ChooseDepartment(int id, Person temp)
        {
            var person = db.PersonSet.FirstOrDefault(x => x.Id == id);
 
            try
            {
                person.DepartmentId = temp.DepartmentId;
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ChooseDepartment", new { id });
            }

        }

        //
        // GET: /Person/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View(db.PersonSet.FirstOrDefault(x => x.Id == id));
        }

        //
        // POST: /Person/Delete/5

        [Authorize(Roles="Admin")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Person person = null;
            try
            {
                person = db.PersonSet.SingleOrDefault(x => x.Id == id);
                db.PersonSet.DeleteObject(person);
                RemoveUserFromAspnet(person.Name);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
                if (person != null && person.Name != null && person.Name != "")
                {
                    ViewData["Error"] = "The person '" + person.Name + "' could not be deleted.";
                }
                else
                {
                    ViewData["Error"] = "The person could not be deleted.";
                }
                return View("Error");
            }
        }

        [Authorize(Roles = "Admin")]
        public string RemoveUserFromAspnet(string user)
        {
            string msg;//HttpUtility.HtmlEncode("Person.AddUserToRole, User = " + user + "&role = " + role);

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
            else
            {
                SQLf.RemoveUserFromAspnet(user);
                //msg = "|"+sql.UserIsAlreadyInThatRole(user, role)+"|";
                msg = user + " is removed from aspnet_Users";
            }
            return msg;
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

                /*
                if (SQLf.IsStaff(user))
                {
                    Person person = db.PersonSet.FirstOrDefault(x => x.Name == user);
                    if (person.Department == null)
                    {
                        person.Department = db.DepartmentSet.FirstOrDefault();
                        db.SaveChanges();
                    }
                }
                 */
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

                if (!SQLf.IsStaff(user))
                {
                    Person person = db.PersonSet.FirstOrDefault(x => x.Name == user);
                    person.Department = null;
                    person.DepartmentId = null;
                    db.SaveChanges();
                }
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
                msg = role + "already exists";
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
