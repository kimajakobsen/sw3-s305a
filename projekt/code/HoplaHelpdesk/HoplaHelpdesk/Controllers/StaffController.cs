using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    //[Authorize(Roles = "Staff")]
    public class StaffController : Controller
    {
        hoplaEntities DB = new hoplaEntities();

        public ActionResult CreateComment(FormCollection collection, int ProblemID)
        {

            return View();
        }

        public ActionResult Worklist()
        {
            List<Problem> problemList;

            //try{

            problemList = (from Problem in DB.ProblemSet
                               where Problem.AssignedTo == User.Identity.Name
                               select Problem).ToList();

            //}catch (Exception){return View("Error");}


            var viewModel = new ProblemListViewModel()
            {
                Problems = problemList,
                Editable = true,
                Deletable = true
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Staff/Details/5

        public ActionResult Details(int id)
        {
            Problem problem = new Problem();
            try
            {
                problem = (from Problem in DB.ProblemSet
                                   where Problem.AssignedTo == User.Identity.Name
                                   where Problem.Id == id
                                   select Problem).Single();

                //problem = DB.ProblemSet.Single(x => x.Id == id && x.AssignedTo == User.Identity.Name);
            }
            catch (Exception)
            {
                return View("Error");
            }

            //try
            //{
                List<Comment> comments = new List<Comment>();

                comments = (from Comment in DB.CommentSet
                            where Comment.Problem_Id == id
                            select Comment).ToList();

            //} catch (Exception) { return View("Error");}

            var viewModel = new ProblemDetailsCommentListViewModel()
            {
                Problem = problem,
                Comments = comments
            };

            return View(viewModel);
        }

        //
        // GET: /Staff/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Staff/Create

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
        // GET: /Staff/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Staff/Edit/5

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
        // GET: /Staff/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Staff/Delete/5

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
    }
}
