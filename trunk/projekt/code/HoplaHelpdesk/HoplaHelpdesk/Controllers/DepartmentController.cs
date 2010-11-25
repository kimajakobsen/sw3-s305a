using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;

namespace HoplaHelpdesk.Controllers
{
    public class DepartmentController : Controller
    {
        hoplaEntities db = new hoplaEntities();
        //
        // GET: /Index/
        
        public ActionResult Index()
        {
            var DepartmentList = db.DepartmentSet.ToList();

            var viewmodel = new DepartmentListViewModel() { Departments = DepartmentList };


            
           /* List<string> ListOfDepartments = new List<string>();
                foreach (var item in db.DepartmentSet)
                    {
                        ListOfDepartments.Add(item.DepartmentName);
                    }
                ViewData["Departments"] = new SelectList(ListOfDepartments);
           **/      


            return View(viewmodel);
        }



        

        //
        // GET: /Department/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Department/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Department/Create

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
        // GET: /Department/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Department/Edit/5

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
        // GET: /Department/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Department/Delete/5

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
