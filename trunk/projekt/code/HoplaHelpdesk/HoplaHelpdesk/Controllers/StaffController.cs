using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    [Authorize(Roles = HoplaHelpdesk.Models.Constants.StaffRoleName)]
    public class StaffController : Controller
    {
        hoplaEntities db = new hoplaEntities();
        PersonController mailf = new PersonController();

        public ActionResult AttachSolution(int id, int solutionID)
        {   
            Solution solution = db.SolutionSet.FirstOrDefault(x => x.Id == solutionID);

            db.ProblemSet.FirstOrDefault(x => x.Id == id).Solutions.Add(solution);
            db.SaveChanges();
            Person [] abc = db.ProblemSet.FirstOrDefault(x => x.Id == id).Persons.ToArray();
            PersonController.PersonMail(abc, id,1);
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult ListSolutions(int id)
        {

            Problem problem = db.ProblemSet.First(x => x.Id == id);
            ViewData["AttachToProblem"] = problem;

            List<Solution> solutions = db.SolutionSet.ToList().Where(x => !x.Problems.Contains(problem)).ToList();
            AttachSolutionViewModel viewModel = new AttachSolutionViewModel();

            if (Session["AttachList"] == null || !(Session["AttachList"] is AttachSolutionViewModel))
            {
                var catTag = new CategoryTagSelectionViewModel
                {
                    Categories = CategoryTagSelectionViewModel.ConvertTo(db.CategorySet.ToList())
                };

                foreach (var probTag in problem.Tags)
                {
                    foreach (var tag in catTag.AllTags())
                    {
                        if (tag.Id == probTag.Id)
                        {
                            tag.IsSelected = true;
                        }
                    }
                }

                var problems = Tools.ProblemSearch.Search(catTag,
                    db.ProblemSet.ToList().Where(x => x.Solutions.Count != 0).ToList(), catTag.AllTags(),
                    Models.Constants.MinimumNumberProblemsForSearch);

                var search = new SearchViewModel
                {
                    CatTag = catTag,
                    MinimumNumberOfProblems = Constants.MinimumNumberProblemsForSearch,
                    OnlySolvedProblems = false,
                    OnlySubscriber = false,
                    OnlyUnsolvedProblems = false,
                    Subscriber = null,
                    ProblemList = new ProblemListViewModel
                    {
                        Problems = problems,
                        SelectedCatTag = catTag,
                        Deletable = false
                    }                    
                };
                viewModel = new AttachSolutionViewModel()
                {
                    Problem = problem,
                    //Solutions = solutions
                    Search = search,
                    SolutionToAttach = null
                };
            }
            else
            {
                ProblemListViewModel problems = new ProblemListViewModel();
                viewModel = (AttachSolutionViewModel)Session["AttachList"];
                problems.Problems = db.ProblemSet.ToList();
                viewModel.Search.OnlySolvedProblems = false;
                viewModel.Search.OnlySubscriber = false;
                viewModel.Search.OnlyUnsolvedProblems = false;
                viewModel.Search.Subscriber = null;
                viewModel.Search.ProblemList = new ProblemListViewModel();

                viewModel.Search.ProblemList.Problems = Tools.ProblemSearch.Search(viewModel.Search.CatTag,
                    db.ProblemSet.ToList().Where(x => x.Solutions.Count != 0).ToList(), viewModel.Search.CatTag.AllTags(),
                    Models.Constants.MinimumNumberProblemsForSearch);
            }

            ViewData["AllTags"] = viewModel.Search.CatTag.AllTagsSelected();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ListSolutions(int id, AttachSolutionViewModel viewModel)
        {
            Session["AttachList"] = viewModel;

            return RedirectToAction("ListSolutions", new { id });
        }

        public ActionResult DetachSolution(int id, int solutionID)
        {
            db.ProblemSet.FirstOrDefault(x => x.Id == id).Solutions.Remove(db.SolutionSet.FirstOrDefault(y => y.Id == solutionID));
            db.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

        /// <summary>
        /// This method is called whenever a new solution has been written and should be saved to the problem.
        /// </summary>
        [HttpPost]
        public ActionResult AddSolution(int id, Solution solution)
        {
            db.ProblemSet.FirstOrDefault(x => x.Id == id).Solutions.Add(solution);

            db.SaveChanges();

            Person[] abc = db.ProblemSet.FirstOrDefault(x => x.Id == id).Persons.ToArray();
            PersonController.PersonMail(abc, id, 1);
            
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult AddSolution(int id)
        {
            return View();
        }

        /// <summary>
        /// This method's purpose is to display the list of problems which the staff member is assigned to solve.
        /// </summary>
        public ActionResult Worklist()
        {
            //try{

             var problemList =  db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).SortedWorklist;
            
           
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

        /// <summary>
        /// This method is called whenever we've updated some information on
        /// the problem, eg added comments, approved deadline and so forth.
        /// </summary>
        [HttpPost]
        public ActionResult Details(ProblemDetailsCommentListViewModel model, int id)
        {
            if (model.comment != null)
            {
                model.comment.Problem_Id = id;
                model.comment.Person = db.PersonSet.Single(x => x.Name.ToLower() == User.Identity.Name.ToLower());

                model.comment.time = DateTime.Now;

                db.ProblemSet.FirstOrDefault(x => x.Id == id).CommentSet.Add(model.comment);
            }

            if (model.approveDeadline == true)
            {
                db.ProblemSet.FirstOrDefault(x => x.Id == id).IsDeadlineApproved = true;
            } else if (model.approveDeadline == false) {
                db.ProblemSet.FirstOrDefault(x => x.Id == id).IsDeadlineApproved = false;
            }

            if (model.reassignability == true)
            {
                db.ProblemSet.FirstOrDefault(x => x.Id == id).Reassignable = true;
            }
            else if (model.reassignability == false)
            {
                db.ProblemSet.FirstOrDefault(x => x.Id == id).Reassignable = false;
            }

            if (model.hoursTaken != 0.0)
            {
                db.ProblemSet.FirstOrDefault(x => x.Id == id).ManageTagTimes(model.hoursTaken);
                db.ProblemSet.FirstOrDefault(x => x.Id == id).SolvedAtTime = DateTime.Now;
                db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Department.BalanceWorkload();

                Person[] abc = db.ProblemSet.FirstOrDefault(x => x.Id == id).Persons.ToArray();
                PersonController.PersonMail(abc, id, 4);
            }


            db.SaveChanges();

            return this.Details(id);
        }

        /// <summary>
        /// This method is called whenever we click on a specific problem and would like to see it's details.
        /// </summary>
        public ActionResult Details(int id)
        {
            Problem problem = new Problem();
            try
            {
                problem = db.ProblemSet.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                ViewData["Error"] = "Problem could not be found";
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
                    Comments = comments
                },
                Solutionlistviewmodel = new SolutionListViewModel(){
                    Solutions = solutions,
                    Deletable = true,
                    Problem = problem
                },
                reassignability = problem.Reassignable.GetValueOrDefault(),
                approveDeadline = problem.IsDeadlineApproved.GetValueOrDefault()
            };

            return View(viewModel);
        }

        //
        // GET: /Staff/Create

        public ActionResult ProblemDetailsWithAttach(int id, int attachToProblem)
        {
            Problem problem = new Problem();
            try
            {
                problem = db.ProblemSet.FirstOrDefault(x => x.Id == id);
                ViewData["AttachToProblem"] = db.ProblemSet.FirstOrDefault(x => x.Id == attachToProblem);
            }
            catch (Exception)
            {
                ViewData["Error"] = "Problem could not be found";
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
                    Comments = comments
                },
                Solutionlistviewmodel = new SolutionListViewModel(){
                    Solutions = solutions,
                    Deletable = false,
                    Problem = problem
                },
                reassignability = problem.Reassignable.GetValueOrDefault(),
                approveDeadline = problem.IsDeadlineApproved.GetValueOrDefault()
            };

            return View(viewModel);
        }

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
