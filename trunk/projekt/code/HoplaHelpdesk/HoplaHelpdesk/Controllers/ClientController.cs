using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using HoplaHelpdesk.ViewModels;
using HoplaHelpdesk.Tools;

namespace HoplaHelpdesk.Controllers
{
    //[Authorize(Roles = "Client")]
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        hoplaEntities db = new hoplaEntities();
        public ActionResult Index()
        {

            return View(db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id);
        }

        
        public ActionResult ViewProblems(int? id)
        {
            
            // Finds the loged in users problems. 
            SearchViewModel viewModel;
            Person subscriber = null;
            ProblemListViewModel problems;
            bool onlySubscriber;
            bool onlyUnsolvedProblems;

            problems = new ProblemListViewModel
            {
                Problems = new List<Problem>()
            };

            var catTag = new CategoryTagSelectionViewModel();
            catTag.Categories = new List<CategoryWithListViewModel>();
            foreach (var item in db.CategorySet)
            {
                catTag.Categories.Add(new CategoryWithListViewModel(item));
            }

            

            if (Session["SearchViewModel"] == null)
            {

                if (id != null)
                {
                    subscriber = db.PersonSet.FirstOrDefault(x => x.Id == id);
                    problems.Problems.AddRange(ProblemSearch.Search(catTag, db.ProblemSet.ToList(), db.TagSet.ToList(), 10, subscriber, db.PersonSet.ToList()));
                    onlySubscriber = true;
                    onlyUnsolvedProblems = true;
                }
                else
                {
                    problems.Problems.AddRange(ProblemSearch.Search(catTag, db.ProblemSet.ToList(), db.TagSet.ToList(), 10));
                    onlySubscriber = false;
                    onlyUnsolvedProblems = false;
                }

                viewModel = new SearchViewModel
                {
                    CatTag = catTag,
                    ProblemList = problems,
                    Subscriber = subscriber,
                    OnlySubscriber = onlySubscriber,
                    OnlyUnsolvedProblems = onlyUnsolvedProblems
                };
            }
            else
            {
                viewModel = (SearchViewModel)Session["SearchViewModel"];

                if (id != null && viewModel.OnlySubscriber)
                {
                    subscriber = db.PersonSet.FirstOrDefault(x => x.Id == id);

                    if (viewModel.OnlyUnsolvedProblems)
                    {
                        problems.Problems.AddRange(ProblemSearch.Search(catTag, db.ProblemSet.Where(x => x.SolvedAtTime != null).ToList(),
                            db.TagSet.ToList(), 10, subscriber, db.PersonSet.ToList()));
                    }
                    else
                    {
                        problems.Problems.AddRange(ProblemSearch.Search(catTag, db.ProblemSet.ToList(), db.TagSet.ToList(), 10, subscriber,
                            db.PersonSet.ToList()));
                    }
                }
                else
                {
                    if (viewModel.OnlyUnsolvedProblems)
                    {
                        problems.Problems.AddRange(ProblemSearch.Search(catTag, db.ProblemSet.Where(x => x.SolvedAtTime != null).ToList(),
                            db.TagSet.ToList(), 10));
                    }
                    else
                    {
                        problems.Problems.AddRange(ProblemSearch.Search(catTag, db.ProblemSet.ToList(), db.TagSet.ToList(), 10));
                    }
                }

                
            }
            
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult ViewProblems(SearchViewModel search)
        {
            Session["SearchViewModel"] = search;

            return RedirectToAction("ViewProblems", new { id = db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id });
        }

        //
        // GET: /Client/Details/5

        public ActionResult Details(int id)
        {


            return View();
        }

        //
        // GET: /Client/Create

       
    }
}
