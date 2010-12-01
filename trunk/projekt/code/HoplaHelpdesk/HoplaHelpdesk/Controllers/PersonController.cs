﻿using System;
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
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

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


            person.SetNewDepartment(db.DepartmentSet.FirstOrDefault(x => x.Id == DepId));
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
            if (person.IsStaff() && person.Department == null)
            {
                return RedirectToAction("ChooseDepartment", new { id });
            }
            if (!person.IsStaff() && person.Department != null)
            {
                person.SetNewDepartment(null);
                
            }

            return View(new EditPersonViewModel
            {
                Person = person,
                AllDepartments = db.DepartmentSet.ToList(),
                Roles = Tools.SQLf.GetRoles(),
                //Role = Tools.SQLf.GetRolesOfUser(person.Name)[0]
            });

            
        }

        public ActionResult BackToEdit(int id)
        {
            Person person = db.PersonSet.FirstOrDefault(x => x.Id == id);
            if (person.IsStaff() && person.Department == null)
            {
                person.Roles.FirstOrDefault(x => x.Name == "Staff").Selected = false;
            }

            return RedirectToAction("Edit", new { id });
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
                person.SetNewDepartment(temp.Department);
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
                    person.SetNewDepartment(null);
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

        [Authorize(Roles = "admin")]
        public static void PersonMail(Person [] user, int problemid, int kindofmail)
        {
            //Used for password if implemented correctly
         /*   String msg;
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
            { */
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("DoNotReply@helpdesk.dk");
            for(int i = 0; i < user.Length; i++)
            {    
            
            mail.To.Add(SQLf.GetEmail(user[i].Name));
            }
            switch (kindofmail)
            {
                case 1: 
                    mail.Subject = "Hopla Helpdesk: A solution has been found!";
                    mail.Body = "A solution has been found for following problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;
                case 2:
                    mail.Subject = "Hopla Helpdesk - Comment Added: id = " + problemid;
                    mail.Body = "A comment has been added to one of your assigned problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;
                case 3:
                    mail.Subject = "Hopla Helpdesk - Reassigned problem: id = " + problemid;
                    mail.Body = "A problem has been reassigned to your workload! \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;
                case 4:
                    mail.Subject = "Hopla Helpdesk - Your problem status has been changed: id = " + problemid;
                    mail.Body = "Your problem status has been changed for following problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;

            }                    
                //"Your password is: " + SQLf.ResetPassword(user) + "\nThis function is not implemented correctly, so the password don't work";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("helps305a", "trekant01");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }

        [Authorize(Roles = "admin")]
        public static void StringMail(String user, int problemid, int kindofmail)
        {
            //Used for password if implemented correctly
            /*   String msg;
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
               { */
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("DoNotReply@helpdesk.dk");
            

                mail.To.Add(SQLf.GetEmail(user));
            
            switch (kindofmail)
            {
                case 1:
                    mail.Subject = "Hopla Helpdesk - A solution has been found: id = " + problemid;
                    mail.Body = "A solution has been found for following problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;
                case 2:
                    mail.Subject = "Hopla Helpdesk - Comment Added: id = " + problemid;
                    mail.Body = "A comment has been added to one of your assigned problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;
                case 3:
                    mail.Subject = "Hopla Helpdesk - Reassigned problem: id = " + problemid;
                    mail.Body = "A problem has been reassigned to your workload! \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;
                case 4:
                    mail.Subject = "Hopla Helpdesk - Your problem status has been changed: id = " + problemid;
                    mail.Body = "Your problem status has been changed for following problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;

            }
            //"Your password is: " + SQLf.ResetPassword(user) + "\nThis function is not implemented correctly, so the password don't work";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("helps305a", "trekant01");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        }

    }

