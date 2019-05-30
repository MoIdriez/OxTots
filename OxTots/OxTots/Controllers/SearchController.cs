using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class SearchController : BaseController
    {
        // GET: Search
        public ActionResult Index()
        {
            SetHeaderDark();
            var model = Search("");
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);
            SetOg(new OgViewModel
            {
                Url = page.OgSearchUrl ?? dfPage.OgSearchUrl,
                Title = page.OgSearchTitle ?? dfPage.OgSearchTitle,
                Image = page.OgSearchImage ?? dfPage.OgSearchImage,
                Description = page.OgSearchDescription ?? dfPage.OgSearchDescription
            });
            return View(model);
        }

        public ActionResult Query(string q)
        {
            SetHeaderDark();
            var model = Search(q);
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);
            SetOg(new OgViewModel
            {
                Url = page.OgSearchUrl ?? dfPage.OgSearchUrl,
                Title = page.OgSearchTitle ?? dfPage.OgSearchTitle,
                Image = page.OgSearchImage ?? dfPage.OgSearchImage,
                Description = page.OgSearchDescription ?? dfPage.OgSearchDescription
            });
            return View("Index", model);
        }

        public SearchViewModel Search(string q)
        {
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);

            var resources = q.Trim() == string.Empty 
                            ? new List<Resource>()
                            : Db.Resources.ToList().SearchResources(UserLanguageID, DefaultLanguageID, q);


            var markers = resources.GetMarkerViewModels(UserLanguageID,DefaultLanguageID);
            var results = resources.GetResourceFilterViewModel(UserLanguageID, DefaultLanguageID);

            return new SearchViewModel
            {
                Title = page.SearchTitle ?? dfPage.SearchTitle,
                Description = page.SearchDescription ?? dfPage.SearchDescription,
                SearchPlaceHolder = page.SearchPlaceHolder ?? dfPage.SearchDescription,
                SearchError = page.SearchError ?? dfPage.SearchDescription,
                ResultsFound = page.SearchResultsFound ?? dfPage.SearchDescription,
                GoToResource = page.SearchGoToResource ?? dfPage.SearchGoToResource,
                SearchEmpty = page.SearchEmpty ?? dfPage.SearchEmpty,
                Markers = markers,
                Results = results
            };
        }
    }
}
