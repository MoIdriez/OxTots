using System.Linq;
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

            var categories = Db.Categories.ToList();
            var markers = categories.GetMarkerViewModels(UserLanguageID,DefaultLanguageID, q);
            var results = categories.GetResourceFilterViewModel(UserLanguageID, DefaultLanguageID, q);
            return new SearchViewModel
            {
                Title = page.SearchTitle ?? dfPage.SearchTitle,
                Description = page.SearchDescription ?? dfPage.SearchDescription,
                SearchPlaceHolder = page.SearchPlaceHolder ?? dfPage.SearchDescription,
                SearchError = page.SearchError ?? dfPage.SearchDescription,
                ResultsFound = page.SearchResultsFound ?? dfPage.SearchDescription,
                GoToResource = page.SearchGoToResource ?? dfPage.SearchGoToResource,
                Markers = markers,
                Results = results
            };
        }
    }
}
