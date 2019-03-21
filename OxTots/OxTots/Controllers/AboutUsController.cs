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
            var page = db.Pages.GetPage();
            var model = new AboutUsViewModel
            {
                Title = page.AboutUsTitle,
                Description = page.AboutUsDescription,
                Description2 = page.AboutUsDescription2
            };
            return View(model);
        }
    }
}