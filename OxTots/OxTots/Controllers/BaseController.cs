using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class BaseController : Controller
    {
        protected SiteContext db = new SiteContext();
        public BaseController()
        {
            GetLayoutViewModel();
        }

        public ActionResult ChangeLanguage(int languageID)
        {
            return RedirectToAction("Index", "Home");
        }

        public void SetHeaderDark()
        {
            GetLayoutViewModel(true);
        }

        private void GetLayoutViewModel(bool dark = false)
        {
            var model = new LayoutViewModel
            {
                Title = "OxTots",
                Search = "Search",
                Listing = "Categories",
                Map = "Map",
                Submission = "Submission",
                Contact = "Contact",
                AboutUs = "About Us",
                Link1 = "Privacy",
                Link2 = "Cookie Policy",
                HeaderDark = dark,
                Categories = db.Categories.ToList(),

                MainLogo = "/Images/logo.png",
                MainLogoAlt = "/Images/sticky-logo.png",

                LanguageName = db.Languages.First().Name,
                LanguageIcon = db.Languages.First().Flag,
                Languages = db.Languages.ToList()
            };
            //var test = db.CategoryDetails.ToList();
            ViewData["LayoutViewModel"] = model;
        }
    }
}