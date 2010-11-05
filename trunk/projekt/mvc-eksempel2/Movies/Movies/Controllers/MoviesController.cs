using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        MoviesEntities db = new MoviesEntities();

        public ActionResult Index()
        {
            var movies = from m in db.Movies
                         where m.ReleaseDate > new DateTime(1984, 6, 1)
                         select m;

            return View(movies.ToList());

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie newMovie)
        {

            if (ModelState.IsValid)
            {
                db.AddToMovies(newMovie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newMovie);
            }
        }

    }
}
