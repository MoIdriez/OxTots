using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.Models;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var page = db.Pages.GetPage();
            var categories = db.Categories;
            var markers = categories.GetMarkerViewModels();
            var model = new HomeViewModel
            {
                SearchPlaceHolder = page.HomeSearch,
                SearchError = page.HomeSearchError,
                CategoriesText = page.HomeCategoriesText,
                Title = page.HomeTitle,
                Description = page.HomeDescription,
                Categories = categories.ToList(),
                Markers = markers
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}