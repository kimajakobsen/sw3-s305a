using System;
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
            
            try {
                var ProblemList = ProblemSearch.Search(catViewModel,db);

                if(ProblemList.Count == 0 ||  ProblemList == null)
                {
                    throw new ArgumentNullException();
                }
                
                var viewModel = new ProblemListViewModel(){
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
                 return RedirectToAction("Create");
             }

           
        }
      
        //
        // GET: /CreateProblem/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                var problem = db.ProblemSet.Single(x => x.Id == id);
                return View(problem);
            }
            catch
            {
                return View("Error");
            }
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
                CatTag = viewModel
            };
            return View(probCatviewModel);
        }

        //
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
                  model.Problem.aspnet_Users.Add(db.aspnet_Users.Single(x => x.UserName == User.Identity.Name));
                db.ProblemSet.AddObject(model.Problem);
              
                db.SaveChanges();



                //var problem = db.ProblemSet.Where(x => x.Description == model.Problem.Description).Single(x => x.Title == model.Problem.Title);
               // return View("Details", problem);
                
                return View("Succes");
            }
                
            catch
            {
                return View(model);
            }
                 
        }





        //
        // GET: /CreateProblem/NoSuffice

        public ActionResult NoSufficeCreate()
        {
            return RedirectToAction("Create");
        }

        
    }
}
