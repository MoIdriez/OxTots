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
            var page = db.Pages.GetPage();
            var markers = db.Categories.GetMarkerViewModels();
            var model = new MapViewModel
            {
                Title = page.MapTitle,
                Description = page.MapDescription,
                Markers = markers
            };
            return View(model);
        }
    }
}