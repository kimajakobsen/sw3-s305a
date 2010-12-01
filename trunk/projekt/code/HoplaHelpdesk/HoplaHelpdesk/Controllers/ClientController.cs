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
    //[Authorize(Roles = HoplaHelpdesk.Models.Constants.ClientRoleName)]
    public class ClientController : Controller
    {
        // GET: /Client/
        hoplaEntities db = new hoplaEntities();
        public ActionResult Index()
        {
            Session["SearchViewModel"] = null;

            if (db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name) != null)
            {
                return View(db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id);
            }
            else
            {
                return RedirectToAction("LogOn","Account");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">This is the name of the user, not actually the id, this may be confusing, but I don't
        /// want to change it now.</param>
        /// <returns></returns>
        public ActionResult ViewProblems(int? id)
        {
            //int userid = db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;

            //Notice that the id is actually the name og the client
            if (id != null && id < 0)
            {
                id = db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;
            }
            else if (id != null && id == 0)
            {
                id = null;
                Session["SearchViewModel"] = null;
            }
            ViewData["Message"] = null;
            // Finds the loged in users problems. 
            SearchViewModel viewModel;
            Person subscriber = null;
            ProblemListViewModel problems;
            bool onlySubscriber;
            bool onlyUnsolvedProblems;
            bool onlySolvedProblems;
            int standardMinNumberOfProblems = Constants.MinimumNumberProblemsForSearch;

            problems = new ProblemListViewModel
            {
                Problems = new List<Problem>()
            };

            var catTag = new CategoryTagSelectionViewModel
            {
                Categories = new List<CategoryWithListViewModel>()
            };
            

            if (Session["SearchViewModel"] == null || !(Session["SearchViewModel"] is SearchViewModel))
            {
                catTag.Categories = CategoryTagSelectionViewModel.ConvertTo(db.CategorySet.ToList());

                onlySolvedProblems = false;
                if (id != null)
                {
                    subscriber = db.PersonSet.FirstOrDefault(x => x.Id == id);

                    List<Problem> tempProb = db.ProblemSet.ToList().Where(x => x.Persons.Contains(subscriber) && x.SolvedAtTime == null).ToList();
                    problems.Problems.AddRange(ProblemSearch.Search(catTag, tempProb,
                        db.TagSet.ToList(), standardMinNumberOfProblems));

                    /*
                    List<Problem> tempProb = db.ProblemSet.Where(x => x.Persons.Contains(subscriber)).ToList();
                    problems.Problems.AddRange(ProblemSearch.Search(catTag, tempProb,
                        db.TagSet.ToList(), Constants.MinimumNumberProblemsForSearch));
                     */
                    onlySubscriber = true;
                    onlyUnsolvedProblems = true;
                    ViewData["Header"] = "My Problems";
                }
                else
                {
                    //problems.Problems.AddRange(ProblemSearch.Search(catTag, db.ProblemSet.ToList(), db.TagSet.ToList(), standardMinNumberOfProblems));
                    onlySubscriber = false;
                    onlyUnsolvedProblems = false;
                    ViewData["Message"] = "Enter search criteria above and press search";
                    ViewData["Header"] = "Problem Search";
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

                if (viewModel.OnlySolvedProblems && viewModel.OnlyUnsolvedProblems)
                {
                    problems.Problems = new List<Problem>();
                }
                else
                {
                    ViewData["Header"] = "Problem Search";
                    if (id != null && viewModel.OnlySubscriber)
                    {
                        subscriber = db.PersonSet.FirstOrDefault(x => x.Id == id);
                        problems.Problems = problems.Problems.Where(x => x.Persons.Contains(subscriber)).ToList();
                        viewModel.Subscriber = subscriber;
                        ViewData["Header"] = "My Problems";
                    }
                    if (viewModel.OnlySolvedProblems)
                    {
                        problems.Problems = problems.Problems.Where(x => x.SolvedAtTime != null).ToList();
                    }
                    else if (viewModel.OnlyUnsolvedProblems)
                    {
                        problems.Problems = problems.Problems.Where(x => x.SolvedAtTime == null).ToList();
                    }
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


            return RedirectToAction("Details", "CreateProblem", new { id });
        }

        //
        // GET: /Client/Create

       
    }
}
