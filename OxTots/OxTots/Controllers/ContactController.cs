using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            var page = db.Pages.GetPage();
            var categories = db.Categories;
            var markers = categories.GetMarkerViewModels();
            var model = new ContactViewModel
            {
                Title = page.ContactTitle,
                Description = page.ContactDescription
            };
            return View(model);
        }
    }
}