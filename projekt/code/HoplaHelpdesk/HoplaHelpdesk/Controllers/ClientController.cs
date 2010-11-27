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
            if (db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name) != null)
            {
                return View(db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id);
            }
            else
            {
                //This should be changed soon
                //It is mainly for testing purposes atm
                //What should happen when not logged in? Go to login screen?
                return RedirectToAction("LogOn","Account");
            }
        }

        
        public ActionResult ViewProblems(int? id)
        {
            
            // Finds the loged in users problems. 
            SearchViewModel viewModel;
            Person subscriber = null;
            ProblemListViewModel problems;
            bool onlySubscriber;
            bool onlyUnsolvedProblems;
            bool onlySolvedProblems;
            int standardMinNumberOfProblems = 10;

            problems = new ProblemListViewModel
            {
                Problems = new List<Problem>()
            };

            var catTag = new CategoryTagSelectionViewModel();
            catTag.Categories = new List<CategoryWithListViewModel>();
            

            if (Session["SearchViewModel"] == null || !(Session["SearchViewModel"] is SearchViewModel))
            {

                foreach (var item in db.CategorySet)
                {
                    catTag.Categories.Add(new CategoryWithListViewModel(item));
                }
                onlySolvedProblems = false;
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
                    OnlyUnsolvedProblems = onlyUnsolvedProblems,
                    OnlySolvedProblems = onlySolvedProblems,
                    MinimumNumberOfProblems = standardMinNumberOfProblems
                };
            }
            else
            {
                viewModel = (SearchViewModel)Session["SearchViewModel"];
                problems.Problems = db.ProblemSet.ToList();

                if (id != null && viewModel.OnlySubscriber)
                { 
                    subscriber = db.PersonSet.FirstOrDefault(x => x.Id == id);
                    problems.Problems = problems.Problems.Where(x => x.Persons.Contains(subscriber)).ToList();
                    viewModel.Subscriber = subscriber;
                }

                if (viewModel.OnlySolvedProblems && viewModel.OnlyUnsolvedProblems)
                {
                    problems.Problems = new List<Problem>();
                }
                else if (viewModel.OnlySolvedProblems)
                {
                    problems.Problems = problems.Problems.Where(x => x.SolvedAtTime != null).ToList();
                }
                else if (viewModel.OnlyUnsolvedProblems)
                {
                    problems.Problems = problems.Problems.Where(x => x.SolvedAtTime == null).ToList();
                }

                viewModel.ProblemList = new ProblemListViewModel
                {
                    Problems = new List<Problem>()
                };

                viewModel.ProblemList.Problems.AddRange(ProblemSearch.Search( viewModel.CatTag,
                    problems.Problems,db.TagSet.ToList(),viewModel.MinimumNumberOfProblems));            
            }

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult ViewProblems(SearchViewModel search)
        {
            int myId = db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;
            search.Subscriber = db.PersonSet.FirstOrDefault(x => x.Id == myId);
            search.ProblemList = new ProblemListViewModel
            {
                Problems = new List<Problem>()
            };

            Session["SearchViewModel"] = search;

            return RedirectToAction("ViewProblems", new { id = myId });
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
