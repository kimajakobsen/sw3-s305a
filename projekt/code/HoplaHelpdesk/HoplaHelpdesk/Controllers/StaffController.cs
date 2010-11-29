using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    [Authorize(Roles = "Staff")]
    public class StaffController : Controller
    {
        hoplaEntities db = new hoplaEntities();

        public ActionResult AttachSolution(int id, int solutionID)
        {

            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult AttachSolution(int id)
        {
            List<Solution> solutions = db.SolutionSet.ToList();

            var viewModel = new AttachSolutionViewModel()
            {
                ProblemID = id,
                Solutions = solutions
            };

            return View(viewModel);
        }

        public ActionResult DetachSolution(int id, int solutionID)
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddSolution(int id, Solution solution)
        {
            db.ProblemSet.FirstOrDefault(x => x.Id == id).Solutions.Add(solution);

            db.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult AddSolution(int id)
        {
            return View();
        }

        public ActionResult Worklist()
        {
            List<Problem> problemList;

            //try{

            int myID = db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;

            problemList = db.ProblemSet.Where(x => x.PersonsId == myID).ToList();

            //}catch (Exception){return View("Error");}


            var viewModel = new ProblemListViewModel()
            {
                Problems = problemList,
                Deletable = true
                
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(ProblemDetailsCommentListViewModel model, int id)
        {
            model.comment.Problem_Id = id;
            model.comment.Person = db.PersonSet.Single(x => x.Name.ToLower() == User.Identity.Name.ToLower());
            
            model.comment.time = DateTime.Now;

            db.ProblemSet.Single(x => x.Id == id).CommentSet.Add(model.comment);
            db.SaveChanges();

            return this.Details(id);
        }

    
        /*public ActionResult Details(int id,)
        {

            return this.Details(id);
        }*/

        public ActionResult Details(int id)
        {
            Problem problem = new Problem();
            try
            {
                problem = db.ProblemSet.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                return View("Error");
            }

            //try
            //{

            int myID = db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;

            List<Comment> comments = new List<Comment>();

            comments = (from Comment in db.CommentSet
                        where Comment.Problem_Id == id
                        select Comment).ToList();

            //} catch (Exception) { return View("Error");}

            //try
            //{

            List<Solution> solutions = new List<Solution>();

            solutions = db.ProblemSet.FirstOrDefault(x => x.Id == id).Solutions.ToList();

            //} catch (Exception) { return View("Error");}

            var viewModel = new ProblemDetailsCommentListViewModel()
            {
                Problem = problem,
                Commentlistviewmodel = new CommentListViewModel(){
                    Comments = comments,
                    Deletable = true
                },
                Solutionlistviewmodel = new SolutionListViewModel(){
                    Solutions = solutions,
                    Deletable = true
                }  
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

        public ActionResult EditStaff(int id)
        {
            var staff = db.PersonSet.Single(x => x.Id == id);
            
            return View(staff);

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
