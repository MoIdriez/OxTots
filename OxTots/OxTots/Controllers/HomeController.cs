﻿using System.Linq;
using System.Web.Mvc;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// Displays a home controller
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);

            var categories = Db.Categories.ToList();
            var resources = Db.Resources.ToList();
            var model = new HomeViewModel
            {
                SearchPlaceHolder = page.HomeSearch ?? dfPage.HomeSearch,
                SearchError = page.HomeSearchError ?? dfPage.HomeSearchError,
                CategoriesText = page.HomeCategoriesText ?? dfPage.HomeCategoriesText,
                Title = page.HomeTitle ?? dfPage.HomeTitle,
                Description = page.HomeDescription ?? dfPage.HomeDescription,
                Image = page.HomeImage ?? dfPage.HomeImage,
                Categories = categories.Select(c => new HomeCategoryViewModel
                {
                    ID = c.ID,
                    Icon = c.Icon,
                    Title = (c.GetDetail(UserLanguageID) ?? c.GetDetail(DefaultLanguageID)).Title
                }).ToList(),
                Markers = resources.GetMarkerViewModels(UserLanguageID, DefaultLanguageID)
            };

            SetOg(new OgViewModel
            {
                Url = page.OgHomeUrl ?? dfPage.OgHomeUrl,
                Title = page.OgHomeTitle ?? dfPage.OgHomeTitle,
                Image = page.OgHomeImage ?? dfPage.OgHomeImage,
                Description = page.OgHomeDescription ?? dfPage.OgHomeDescription
            });
            return View(model);
        }
    }
}