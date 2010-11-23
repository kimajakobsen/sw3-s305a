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
        DBEntities db = new DBEntities();

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
            var catVievModel = new CategoryTagSelectionViewModel()
            {
                Categories = CategoryTagSelectionViewModel.ConvertTo(categories)
            };
            return View(catVievModel);
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

                if(ProblemList.Count == 0 ||  ProblemList == null){
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
            return View();
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
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /CreateProblem/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CreateProblem/Edit/5

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
        // GET: /CreateProblem/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CreateProblem/Delete/5

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
