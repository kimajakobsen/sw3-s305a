using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

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

            return View(categories);

        }

        [HttpPost]
        public ActionResult CategorizeNewProblem(List<Category> cats)
        {
            try
            {
                var newcats = new List<Category>();
                foreach (var cat in cats)
                {
                    var tag = cat.Tags.Where(t => t.IsSelected == true);
                    newcats.Single(t => t.Title == cat.Title).Tags = tag.ToList();
                }

                return View(cats);
               // return RedirectToAction("Index");
            }
            catch
            {
              
                return View();
            }
        }




        public ActionResult ViewProblems()
        {
            var problemList =  new List<Problem>(){
                new Problem(){
                    Title = "John"
                }, new Problem(){
                    Title = "Mikael"
                }
            };

            var problems = new ProblemListViewModel()
            {
                Problems = problemList
            };
         

            return View(problemList);
        }

        //
        // GET: /Client/Details/5


        public ActionResult Details(int id)
        {


            return View();
        }

        //
        // GET: /Client/Create

        public ActionResult Create()
        {

            var problem = new Problem();

            return View(problem);
        } 

        //
        // POST: /Client/Create

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
                return RedirectToAction("Index");
                //return View();
            }
        }
        
        //
        // GET: /Client/Edit/5
        
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Client/Edit/5

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

      
       
    }
}
