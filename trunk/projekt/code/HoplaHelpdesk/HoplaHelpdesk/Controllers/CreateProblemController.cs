using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    public class CreateProblemController : Controller
    {
        //
        // GET: /CreateProblem/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult CategorizeNewProblem()
        {
            var categories = new List<Category>()
            {
                new Category(){
                    Title = "Computers",
                    Tags = new List<Tag>()
                    {
                        new Tag() 
                        {
                            Title = "Tag1",
                            Id = 3
                        },  
                        new Tag() 
                        {
                            Title = "Tag1",
                            Id = 4
                        }

                    }
                },

                new Category()
                {
                    Title = "Sodavand",
                    Tags = new List<Tag>()
                    {
                        new Tag() 
                        {
                            Title = "Tag1",
                            Id = 1
                        },  
                        new Tag() 
                        {
                            Title = "Tag2",
                            Id = 2
                        }

                    }

                }


            };

            var catVievModel = new CategoryTagSelectionViewModel(){
                Categories = categories
            };

            return View(catVievModel);

        }

        [HttpPost]
        public ActionResult CategorizeNewProblem(CategoryTagSelectionViewModel  cats)
        {
             try
             {



                 return RedirectToAction("Index");
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
