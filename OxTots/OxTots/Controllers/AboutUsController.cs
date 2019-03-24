using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class AboutUsController : BaseController
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);
            var model = new AboutUsViewModel
            {
                Image = page.AboutUsImage ?? dfPage.AboutUsImage,
                Title = page.AboutUsTitle ?? dfPage.AboutUsTitle,
                Description = page.AboutUsDescription ?? dfPage.AboutUsDescription,
                Description2 = page.AboutUsDescription2 ?? dfPage.AboutUsDescription2
            };
            return View(model);
        }
    }
}