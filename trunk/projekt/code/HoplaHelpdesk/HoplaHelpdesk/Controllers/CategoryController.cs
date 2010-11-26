﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.Controllers
{
    public class CategoryController : Controller
    {
        hoplaEntities db = new hoplaEntities();


        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id)
        {
            try
            {
                var category = db.CategorySet.Single(x => x.Id == id);
                return View(category);
            }
            catch
            {
                ViewData["Error"] = "The user could not be found";
                return View("Error");
            }
          
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {

            return View(new Category());
        } 

        //
        // POST: /Category/Create

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
        // GET: /Category/Edit/5
 
        public ActionResult Edit(int id)
        {
            var Category = db.CategorySet.Single(x => x.Id == id);
            return View(Category);


           
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                var cat = db.CategorySet.SingleOrDefault(x => x.Id == category.Id);
                cat.Name = category.Name;
                cat.Description = category.Description;
                db.SaveChanges();
                return RedirectToAction("Edit", "Department", new { id=category.Department_Id });
            }
            catch
            {
                return View(category);
            }
        }

        //
        // GET: /Category/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Category/Delete/5

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
