using System;
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
                Session["Category"] = category;
                return View(category);
            }
            catch
            {
                ViewData["Error"] = "The user could not be found";
                return View("Error");
            }
          
        }

        //
        // GET: /Category/Create/id

        public ActionResult Create(int id)
        {

            return View(new Category() { Department_Id = id});
        } 

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            { 
                category.Department = db.DepartmentSet.SingleOrDefault(x => x.Id == category.Department_Id);
                db.CategorySet.AddObject(category);
                db.SaveChanges();
                return RedirectToAction("Edit", "Department", new { id = category.Department_Id });
            }
            catch
            {
                return View(category);
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
                cat.Department = category.Department;
                db.SaveChanges();
                Session["Category"] = category;
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
            var category = db.CategorySet.SingleOrDefault(x => x.Id == id);
            Session["Category"] = category;
            if (category == null)
            {
                ViewData["Error"] = "The category you attempted to delete did not exist";
                return RedirectToAction("Error");

            }
            try
            { 
                if ( category.Tags == null || category.Tags.Count == 0)
                {
                    return View(category);
                }
                else
                {
                    return RedirectToAction("Details", new { id = id });
                }
            }
            catch
            {
                return RedirectToAction("Details", new { id = id });
            }
         
        }

        //
        // POST: /Category/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var category = db.CategorySet.SingleOrDefault(x => x.Id == id);
                db.CategorySet.DeleteObject(category);
                db.SaveChanges();
                return RedirectToAction("Edit", "Department", new { id = category.Department_Id});
            }
            catch
            {

                return RedirectToAction("Details", new { id = id });
            }
        }



       

        public ActionResult HideUnhide(int id, bool value)
        {
            var category = db.CategorySet.SingleOrDefault(x => x.Id == id);
            category.Hidden = value;
            Session["Category"] = category;
            db.SaveChanges();
            return View("Details", category);
        }

    }
}
