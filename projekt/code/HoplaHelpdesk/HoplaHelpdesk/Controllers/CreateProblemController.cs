﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;
using HoplaHelpdesk.Tools;
using System.Collections.ObjectModel;
using System.Data.Objects.DataClasses;

namespace HoplaHelpdesk.Controllers
{
    [Authorize(Roles = Constants.ClientRoleName)]
    public class CreateProblemController : Controller
    {
        hoplaEntities db = new hoplaEntities();

        //
        // GET: /CreateProblem/
        public ActionResult Index()
        {
            return RedirectToAction("CategorizeNewProblem");
        }

        /// <summary>
        /// This action method is called when a problem should be categorized
        /// </summary>
        /// <returns></returns>
        public ActionResult CategorizeNewProblem()
        {
            var categories = db.CategorySet.ToList();

            var catViewModel = new CategoryTagSelectionViewModel()
            {
                Categories = CategoryTagSelectionViewModel.ConvertTo(categories)
            };
            
            return View(catViewModel);
        }



        [HttpPost]
        public ActionResult CategorizeNewProblem(CategoryTagSelectionViewModel  cats)
        {
            foreach (var item in cats.Categories)
            {
                item.DepartmentHolder = db.DepartmentSet.FirstOrDefault(x => x.Id == db.CategorySet.FirstOrDefault(y => y.Id == item.Id).Department_Id);
            }
           
            Session["SelectedCatTag"] = cats;
  
            return RedirectToAction("SimilarProblems");
            

            // return RedirectToAction("Index");
            //return View();

        }


        // GET: /CreatePRoblem/SimilarProblems
        public ActionResult SimilarProblems()
        {
            var catViewModel = new CategoryTagSelectionViewModel();
            if(Session["SelectedCatTag"] == null)
            {
                var categories = db.CategorySet.ToList();

                catViewModel.Categories = CategoryTagSelectionViewModel.ConvertTo(categories);
                
            } else 
            {
                catViewModel = (CategoryTagSelectionViewModel)Session["SelectedCatTag"];
            }
            
            try
            {
                ViewData["AllTags"] = catViewModel.AllTagsSelected();
                var ProblemList = ProblemSearch.SearchSolvedFirst(catViewModel,db.ProblemSet.ToList(),
                    db.TagSet.ToList(),Models.Constants.MinimumNumberProblemsForSearch);
                
                if(ProblemList.Count == 0 ||  ProblemList == null)
                {
                    throw new ArgumentNullException();
                }

                var viewModel = new SimilairProblemListViewModel(){
                    Problems = ProblemList,
                    SelectedCatTag = catViewModel
                };

                return View(viewModel);

 
             }
             catch
             {
                 /*
                 var viewModel = new ProblemCatTagWithSelectionViewModel()
                 {
                     CatTag = cats
                   

                 };
                  * */
                 //throw;
                 return RedirectToAction("Create");
             }

           
        }
      
        //
        // GET: /CreateProblem/Details/5

        [HttpPost]
        public ActionResult Details(ClientProblemDetailsViewModel model, int id)
        {
            if (model.Comment != null)
            {
                model.Comment.Problem_Id = id;
                model.Comment.Person = db.PersonSet.Single(x => x.Name.ToLower() == User.Identity.Name.ToLower());
                model.Comment.time = DateTime.Now;

                db.ProblemSet.FirstOrDefault(x => x.Id == id).CommentSet.Add(model.Comment);
                String abc = db.ProblemSet.FirstOrDefault(x => x.Id == id).AssignedTo.Name;
                PersonController.StringMail(abc, id, 2);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = id });
        }

        [Authorize(Roles = HoplaHelpdesk.Models.Constants.ClientRoleName)]
        public ActionResult Details(int id)
        {   
            ViewData["LoggedUser"] = db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;

            /*try
            {*/
                Problem problem = db.ProblemSet.FirstOrDefault(x => x.Id == id);
                List<Solution> solutions = db.ProblemSet.FirstOrDefault(x => x.Id == id).Solutions.ToList();
                List<Comment> comments = db.ProblemSet.FirstOrDefault(x => x.Id == id).CommentSet.ToList();

                ClientProblemDetailsViewModel viewModel = new ClientProblemDetailsViewModel()
                {
                    Problem = problem,
                    Solutionlistviewmodel = new SolutionListViewModel()
                    {
                        Solutions = solutions,
                        Deletable = false
                    },
                    Commentlistviewmodel = new CommentListViewModel()
                    {
                        Comments = comments
                    }
                };

                return View(viewModel);
            /*}
            catch
            {
                return View("Error");
            }*/
        }

        //
        // GET: /CreateProblem/Create

        public ActionResult Create()
        {
            var viewModel = new CategoryTagSelectionViewModel();

            // If no session is defined then an empty all categories will be sent to the CategoryTagSelection View Model. 
            if (Session["SelectedCatTag"] == null)
            {      
                var categories = db.CategorySet.ToList();
                viewModel.Categories = CategoryTagSelectionViewModel.ConvertTo(categories);
            }
            else
            {
                viewModel = (CategoryTagSelectionViewModel)Session["SelectedCatTag"];
            } 
         
            var probCatviewModel = new ProblemCatTagWithSelectionViewModel()
            {
                // The problem is left to null.
                CatTag = viewModel,
                Person = new Person()
            };
            return View(probCatviewModel);
        }

        // POST: /CreateProblem/Create

        [HttpPost]
        public ActionResult Create(ProblemCatTagWithSelectionViewModel model)
        {
            try
            {
              foreach(var tag in model.CatTag.AllTagsSelected()){
                  model.Problem.Tags.Add(db.TagSet.Single(x => x.Id == tag.Id));
                }
                  model.Problem.Added_date = DateTime.Now;
                  model.Problem.Reassignable = true;
                  model.Problem.AssignedTo = (Person)ProblemDistributer.GetStaff(model.Problem, db.PersonSet.ToList());
                  var person = db.PersonSet.Single(x => x.Name == User.Identity.Name.ToLower());
                  model.Problem.Persons.Add(person);
              
                
                db.ProblemSet.AddObject(model.Problem);
              
                db.SaveChanges();

                //var problem = db.ProblemSet.Where(x => x.Description == model.Problem.Description).Single(x => x.Title == model.Problem.Title);
                //return View("Details", problem);
                
                return View("Succes");
            }
            catch
            {
                ViewData["Error"] = "An error occur durring the creation of the problem with the title: '"
                    + model.Problem.Title + "' and description: '"
                    + model.Problem.Description + "'";
                ViewData["View"] = "Create";
                return View("Error");
            }
                 
        }





        //
        // GET: /CreateProblem/NoSuffice

        public ActionResult NoSufficeCreate()
        {
            return RedirectToAction("Create");
        }



        public ActionResult Subscribe(int PerId, int ProId )
        {
            //try
            //{
            if (!(db.PersonSet.FirstOrDefault(x => x.Id == PerId).Problems.Contains(db.ProblemSet.FirstOrDefault(x => x.Id == ProId))))
            {

                db.PersonSet.FirstOrDefault(x => x.Id == PerId).Problems.Add(db.ProblemSet.FirstOrDefault(x => x.Id == ProId));

                db.SaveChanges();

                return RedirectToAction("ViewProblems", "Client", new { id = PerId });
            }
            else
            {
                ViewData["Error"] = "You are allready subscribed to the problem";
                return View("Error");
            }  
            //}
            //catch 
            //{
            //    ViewData["Error"] = "An error occered, while trying to subscribe you to the problem";
            //    return View("Error");
            //}
            
        }
        public ActionResult Unsubscribe(int PerId, int ProId)
        {
            //try
            //{
            if (db.PersonSet.FirstOrDefault(x => x.Id == PerId).Problems.Contains(db.ProblemSet.FirstOrDefault(x => x.Id == ProId)) 
                && (db.ProblemSet.FirstOrDefault(x => x.Id == ProId).Persons.Count > 1 ))
            {

                db.PersonSet.FirstOrDefault(x => x.Id == PerId).Problems.Remove(db.ProblemSet.FirstOrDefault(x => x.Id == ProId));

                db.SaveChanges();

                return RedirectToAction("ViewProblems", "Client", new { id = PerId});
            }
            else
            {
                ViewData["Error"] = "You cannot subscribe from this problem";
                return View("Error");
            }
        }
    }
}
