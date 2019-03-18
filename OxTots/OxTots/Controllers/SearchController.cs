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
            var page = db.Pages.GetPage();
            var categories = db.Categories;
            var markers = categories.GetMarkers();
            var model = new SearchViewModel
            {
                Title = page.SearchTitle,
                Description = page.SearchDescription,
                SearchPlaceHolder = page.SearchPlaceHolder,
                SearchError = page.SearchError,
                NoResultsFound = page.SearchNoResultsFound,
                Markers = markers,
                Results = new List<SearchResultViewModel>()
            };
            base.SetHeaderDark();
            return View(model);
        }

        public ActionResult Query(string q)
        {
            return View("Index");
        }
    }
}
