using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;

namespace HoplaHelpdesk.Controllers
{
    public class TagController : Controller
    {
        //
        // GET: /Tag/
        hoplaEntities db = new hoplaEntities();
        public ActionResult Index()
        {

            return View(db.TagSet);
        }

        //
        // GET: /Tag/Details/5

        public ActionResult Details(int id)
        {
            var tag = db.TagSet.SingleOrDefault(x => x.Id == id);
            return View(tag);
        }

        //
        // GET: /Tag/Create

        public ActionResult Create()
        {
            
            return View(new Tag());
        } 

        //
        // POST: /Tag/Create

        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            try
            {
               var category = (Category)Session["Category"];
                tag.Category = category;
                tag.Hidden = false;
                db.TagSet.AddObject(tag);
                return RedirectToAction("Details", "Category", new { id= category.Id });
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Tag/Edit/5
 
        public ActionResult Edit(int id)
        {
            var tag = db.TagSet.SingleOrDefault(x => x.Id == id);
            return View(tag);
        }

        //
        // POST: /Tag/Edit/5

        [HttpPost]
        public ActionResult Edit(Tag taget)
        {
            try
            {
                // TODO: Add update logic here
                var tag = db.TagSet.SingleOrDefault(x => x.Id == taget.Id);
                tag.Category = (Category)Session["Category"];
                tag.Name = taget.Name;
                tag.Description = taget.Description;
                db.SaveChanges();
              
                return RedirectToAction("Details", "Category", new { id = tag.Category_Id });
               
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Tag/Delete/5
 
        public ActionResult Delete(int id)
        {
            var tag = db.TagSet.SingleOrDefault(x => x.Id == id);
         
            if (tag == null)
            {
                ViewData["Error"] = "The tag you attempted to delete did not exist";
                return RedirectToAction("Error");

            }
            try
            {
                if (tag.Problems == null || tag.Problems.Count == 0)
                {
                    return View(tag);
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
        // POST: /Tag/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var tag = db.TagSet.SingleOrDefault(x => x.Id == id);
                db.TagSet.DeleteObject(tag);
                db.SaveChanges();
                return RedirectToAction("Details", "Category", new { id = tag.Category_Id });
            }
            catch
            {
                ViewData["Error"] = "The tag could not be deleted.";
                return View("Error");
            }
        }
    }
}
