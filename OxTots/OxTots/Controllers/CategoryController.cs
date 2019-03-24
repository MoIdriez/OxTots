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
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);
            var category = Db.Categories.FirstOrDefault(c => c.ID == id);
            if (category == null)
            {
                // category doesn't exist send to error page
                throw new NotImplementedException();
            }

            var categoryDetail = category.GetDetail(UserLanguageID) ?? category.GetDetail(DefaultLanguageID);
            var model = new CategoryViewModel
            {
                ID = category.ID,
                Title = categoryDetail.Title,
                Description = categoryDetail.Description,
                ResultsFound = page.CategoryResultsFound ?? dfPage.CategoryResultsFound,
                FilterDescription = page.CategoryFilterDescription ?? dfPage.CategoryFilterDescription,
                GoToResource = page.CategoryGoToResource ?? dfPage.CategoryGoToResource,
                Features = category.Features.ToList().ToViewModel(UserLanguageID, DefaultLanguageID),
                Resources = category.GetResourceFilterViewModel(UserLanguageID, DefaultLanguageID),
                Markers = category.GetMarkerViewModels(UserLanguageID, DefaultLanguageID)
            };

            SetOg(new OgViewModel
            {
                Url = (page.OgCategoryUrl ?? dfPage.OgCategoryUrl) + category.ID,
                Title = page.OgCategoryTitle ?? dfPage.OgCategoryTitle,
                Image = page.OgCategoryImage ?? dfPage.OgCategoryImage,
                Description = page.OgCategoryDescription ?? dfPage.OgCategoryDescription
            });
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(CategoryViewModel model)
        {
            base.SetHeaderDark();

            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);

            // if no option is selected
            if (model.Features.All(f => !f.IsSelected))
            {
                return RedirectToAction("Index", new { id= model.ID });
            }

            var category = Db.Categories.FirstOrDefault(c => c.ID == model.ID);
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

            model.Resources = resources.GetResourceFilterViewModel(UserLanguageID, DefaultLanguageID);
            model.Markers = resources.GetMarkerViewModels(UserLanguageID, DefaultLanguageID);

            SetOg(new OgViewModel
            {
                Url = (page.OgCategoryUrl ?? dfPage.OgCategoryUrl) + category.ID,
                Title = page.OgCategoryTitle ?? dfPage.OgCategoryTitle,
                Image = page.OgCategoryImage ?? dfPage.OgCategoryImage,
                Description = page.OgCategoryDescription ?? dfPage.OgCategoryDescription
            });
            return View("Index", model);
        }
    }
}