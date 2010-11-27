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
        // GET: /Tag/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Tag/Delete/5

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
