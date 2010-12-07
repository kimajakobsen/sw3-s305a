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
    [Authorize(Roles = HoplaHelpdesk.Models.Constants.ClientRoleName)]
    public class ClientController : Controller
    {
        // GET: /Client/
        hoplaEntities db = new hoplaEntities();
        
        public ActionResult Index()
        {
            Session["SearchViewModel"] = null;

            return RedirectToAction("ViewProblems", new { id=-1});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ViewProblems(int? id)
        {
            if (id != null && id < 0)
            {
                id = db.PersonSet.FirstOrDefault(x => x.Name == User.Identity.Name).Id;
                return RedirectToAction("ViewProblems", new { id });
            }
            else if (id != null && id == 0)
            {
                id = null;
                Session["SearchViewModel"] = null;
                return RedirectToAction("ViewProblems", new { id });
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
            foreach (var item in search.CatTag.Categories)
            {
                item.DepartmentHolder = db.DepartmentSet.FirstOrDefault(x => x.Id == db.CategorySet.FirstOrDefault(y => y.Id == item.Id).Department_Id);
            }

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
