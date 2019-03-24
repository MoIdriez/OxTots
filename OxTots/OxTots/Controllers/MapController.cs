using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class MapController : BaseController
    {
        // GET: Map
        public ActionResult Index()
        {
            this.SetHeaderDark();
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);
            var markers = Db.Categories.ToList().GetMarkerViewModels(UserLanguageID, DefaultLanguageID);
            var model = new MapViewModel
            {
                Title = page.MapTitle ?? dfPage.MapTitle,
                Description = page.MapDescription ?? dfPage.MapDescription,
                Markers = markers
            };
            return View(model);
        }
    }
}