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
            return View();
        }


        /// <summary>
        /// This action method is called when a problem should be categorized
        /// </summary>
        /// <returns></returns>
        public ActionResult CategorizeNewProblem()
        {
            var categories = db.CategorySet.ToList();


            var catVievModel = new CategoryTagSelectionViewModel(){
                Categories = CategoryTagSelectionViewModel.ConvertTo(categories)
            };

            return View(catVievModel);

        }



        [HttpPost]
        public ActionResult CategorizeNewProblem(CategoryTagSelectionViewModel  cats)
        {
             try
             {
                 var problems = ProblemSearch.Search(cats);

                 var problemView = new ProblemListViewModel()
                 {
                     Editable = false,
                     Deletable = false,
                     Problems = problems

                 };



                 return View("SimilarProblems", problemView);
             }
            
            
          

             catch
             {
                 return View(cats);
             }

            // return RedirectToAction("Index");
            //return View();

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
            return View();
        } 

        //
        // POST: /CreateProblem/Create

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
