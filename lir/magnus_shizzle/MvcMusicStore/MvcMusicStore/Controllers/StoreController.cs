using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.View_Models;
using MvcMusicStore.Models;
using MvcMusicStore.ViewModels;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = new List<string> { "Techno", "Dubstep", "Trance", "House", "Deep House", "Tech House" };

            var viewModel = new StoreIndexViewModel
            {
                NumberOfGenres = genres.Count(),
                Genres = genres
            };

            return View(viewModel);
        }

        // Now let’s browse to /Store/Browse?Genre=Disco
        public ActionResult Browse(string genre)
        {
            var genreModel = new Genre
            {
                name = genre
            };

            var albums = new List<Album>()
            {
                new Album { Title = genre + " Album 1" },
                new Album {Title = genre + " Album 1" }
            };

            var viewModel = new StoreBrowseViewModel
            {
                Genre = genreModel,
                Albums = albums
            };

            return View(viewModel);
        }


        // /Store/Details/3
        public string Details(int id)
        {
            string message = "Store.Details, ID = " + id;
            return message;
        }

    }
}
