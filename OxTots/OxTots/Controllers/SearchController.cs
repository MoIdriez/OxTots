using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class SearchController : BaseController
    {
        // GET: Search
        public ActionResult Index()
        {
            base.SetHeaderDark();
            var model = Search("");
            return View(model);
        }

        public ActionResult Query(string q)
        {
            base.SetHeaderDark();
            var model = Search(q);
            return View("Index", model);
        }

        public SearchViewModel Search(string q)
        {
            var page = db.Pages.GetPage();
            var categories = db.Categories;
            var markers = categories.GetMarkers(q);
            var results = categories.GetSearch(q);
            return new SearchViewModel
            {
                Title = page.SearchTitle,
                Description = page.SearchDescription,
                SearchPlaceHolder = page.SearchPlaceHolder,
                SearchError = page.SearchError,
                ResultsFound = page.ResultsFound,
                Markers = markers,
                Results = results
            };
        }
    }
}
