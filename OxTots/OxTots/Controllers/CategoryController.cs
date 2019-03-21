using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index(int id)
        {
            base.SetHeaderDark();
            var page = db.Pages.GetPage();
            var category = db.Categories.FirstOrDefault(c => c.ID == id);
            if (category == null)
            {
                // category doesn't exist send to error page
                throw new NotImplementedException();
            }

            var categoryDetail = category.GetDetail();
            var model = new CategoryViewModel
            {
                ID = category.ID,
                Title = categoryDetail.Title,
                Description = categoryDetail.Description,
                ResultsFound = page.SearchResultsFound,
                FilterDescription = page.CategoryFilterDescription,
                Features = category.Features.ToViewModel(),
                Resources = category.GetResourceFilterViewModel(),
                Markers = category.GetMarkerViewModels()
            };
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(CategoryViewModel model)
        {
            base.SetHeaderDark();

            // if no option is selected
            if (model.Features.All(f => !f.IsSelected))
            {
                return RedirectToAction("Index", new { id= model.ID });
            }

            var category = db.Categories.FirstOrDefault(c => c.ID == model.ID);
            if (category == null)
            {
                // category doesn't exist send to error page
                throw new NotImplementedException();
            }

            // selected feature ids
            var selectedFeatures = model.Features.Where(f => f.IsSelected).Select(f => f.ID).ToList();

            var resources = category.Resources
                .Where(r => r.ResourceFeatures
                    .Any(rf => rf.Enabled && selectedFeatures.Contains(rf.Feature.ID))).ToList();

            model.Resources = resources.GetResourceFilterViewModel();
            model.Markers = resources.GetMarkerViewModels();
            return View("Index", model);
        }
    }
}