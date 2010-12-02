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
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace HoplaHelpdesk.Controllers
{
    [Authorize(Roles=Constants.AdminRoleName)]
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


            if (person.Department != null)
            {
                person.Department.BalanceWorkload();
            }
          
           

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
                return RedirectToAction("BackToEdit", new { id });
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


        //
        // POST: /Person/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, EditPersonViewModel collection)
        {
            var person = db.PersonSet.FirstOrDefault(x => x.Id == id);

            if (person.Name == HoplaHelpdesk.Models.Constants.RootName)
            { 
                foreach(var item in collection.Person.Roles)
                {
                    if (item.Name == HoplaHelpdesk.Models.Constants.AdminRoleName)
                    {
                        if (!item.Selected)
                        {
                            ViewData["Error"] = "You cannot remove the '" + HoplaHelpdesk.Models.Constants.AdminRoleName
                                + "' role from the " + HoplaHelpdesk.Models.Constants.RootName + " user!"
                                + "This user can be removed only if another person is assigned the '"
                                +  HoplaHelpdesk.Models.Constants.AdminRoleName + "' role.";
                            ViewData["View"] = "Index";

                            return View("Error");
                        }
                    }

                        if (item.Selected)
                        {
                            ViewData["Error"] = "You cannot add the '" + item.Name
                                + "' role to the " + HoplaHelpdesk.Models.Constants.RootName + " user!\n\n"
                                + "This user can only have the '" + HoplaHelpdesk.Models.Constants.AdminRoleName
                                + "' role, but the user can be removed if another person is assigned the '"
                                +  HoplaHelpdesk.Models.Constants.AdminRoleName + "' role.";
                            ViewData["View"] = "Index";

                            return View("Error");
                        }

                }
            }
            try
            {
                if (collection.Person.DepartmentId != person.DepartmentId)
                {
                    person.CascadeProblems(person.Department, collection.Person.Department);
                }
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

        public ActionResult BackToEdit(int id)
        {
            Person person = db.PersonSet.FirstOrDefault(x => x.Id == id);
            if (person.IsStaff() && person.Department == null)
            {
                UnRole(person.Name, HoplaHelpdesk.Models.Constants.StaffRoleName);
            }

            return RedirectToAction("Edit", new { id });
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
            var newDep = db.DepartmentSet.FirstOrDefault(x => x.Id == temp.DepartmentId);

            if (temp.DepartmentId != person.DepartmentId)
            {
                person.CascadeProblems(person.Department, newDep);
            }
 
            try
            {
                person.SetNewDepartment(newDep);
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
        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
        public ActionResult Delete(int id)
        {
            return View(db.PersonSet.FirstOrDefault(x => x.Id == id));
        }

        //
        // POST: /Person/Delete/5

        [Authorize(Roles=HoplaHelpdesk.Models.Constants.AdminRoleName)]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Person person = null;
            try
            {
                person = db.PersonSet.SingleOrDefault(x => x.Id == id);
                if (person.Name == Constants.RootName && db.PersonSet.ToList().Where(x => x.Roles.FirstOrDefault(y=> y.Name == Constants.AdminRoleName).Selected).Count() <= 1)
                {
                    ViewData["Error"] = "You cannot delete the " + HoplaHelpdesk.Models.Constants.RootName
                        + " user when no other person is assigned the '" + HoplaHelpdesk.Models.Constants.AdminRoleName + "' role!";

                    ViewData["View"] = "Index";

                    return View("Error");
                }
                db.PersonSet.DeleteObject(person);
                RemoveUserFromAspnet(person.Name);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
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

        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
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

       // [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
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

        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
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
        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
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

        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
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

        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
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
                try
                {
                    mail.To.Add(SQLf.GetEmail(user[i].Name));
                }
                catch (FormatException)
                { }
            }
            switch (kindofmail)
            {
                case 1:
                    mail.Subject = "Hopla Helpdesk: A solution has been found!";
                    mail.Body = "A solution has been found for following problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;
                case 2:
                    mail.Subject = "Hopla Helpdesk: Comment Added!";
                    mail.Body = "A comment has been added to one of your assigned problem: \nhttp://localhost:6399/Staff/Details/" + problemid;
                    break;
                case 3:
                    mail.Subject = "Hopla Helpdesk: Reassigned problem!";
                    mail.Body = "A problem has been reassigned to your workload! \nhttp://localhost:6399/Staff/Details/" + problemid;
                    break;
                case 4:
                    mail.Subject = "Hopla Helpdesk: Your problem status has been changed!";
                    mail.Body = "Your problem status has been changed for following problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;

            }                    
                //"Your password is: " + SQLf.ResetPassword(user) + "\nThis function is not implemented correctly, so the password don't work";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("helps305a", "trekant01");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }

        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
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
                    mail.Subject = "Hopla Helpdesk: A solution has been found!";
                    mail.Body = "A solution has been found for following problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;
                case 2:
                    mail.Subject = "Hopla Helpdesk: Comment Added!";
                    mail.Body = "A comment has been added to one of your assigned problem: \nhttp://localhost:6399/Staff/Details/" + problemid;
                    break;
                case 3:
                    mail.Subject = "Hopla Helpdesk: Reassigned problem!";
                    mail.Body = "A problem has been reassigned to your workload! \nhttp://localhost:6399/Staff/Details/" + problemid;
                    break;
                case 4:
                    mail.Subject = "Hopla Helpdesk: Your problem status has been changed!";
                    mail.Body = "Your problem status has been changed for following problem: \nhttp://localhost:6399/CreateProblem/Details/" + problemid;
                    break;

            }
            //"Your password is: " + SQLf.ResetPassword(user) + "\nThis function is not implemented correctly, so the password don't work";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("helps305a", "trekant01");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
        public ActionResult PassMail(int id)
        {
            return View(db.PersonSet.FirstOrDefault(x => x.Id == id));
        }

        //
        // POST: /Person/Delete/5

        [Authorize(Roles = HoplaHelpdesk.Models.Constants.AdminRoleName)]
        [HttpPost]
        public ActionResult PassMail(int id, FormCollection collection)
        {
            var person = db.PersonSet.FirstOrDefault(x => x.Id == id);
            String user = person.Name.ToString();
            string msg = HttpUtility.HtmlEncode("Person.PassMail, User = " + user);
            //Used for password if implemented correctly

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("DoNotReply@helpdesk.dk");


            mail.To.Add(SQLf.GetEmail(user));


            mail.Subject = "Hopla Helpdesk: Your password has been changed!";
            mail.Body = "Your password is: \n Username: " + user + "\n Password: " + SQLf.ResetPassword(user);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("helps305a", "trekant01");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            msg = user + "'s password has been resetted and sent to: " + SQLf.GetEmail(user);
            return RedirectToAction("Index");
        }
        }

    }