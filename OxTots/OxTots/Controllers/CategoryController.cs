using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    /// <summary>
    /// Category controller
    /// </summary>
    public class CategoryController : BaseController
    {
        // Displays a category by id
        public ActionResult Index(int id)
        {
            return View("Index", GetViewModel(id, new List<FeatureViewModel>()));
            
        }

        /// <summary>
        /// Filter the category's resource by selected features
        /// </summary>
        /// <param name="model">category controller with the selected features</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(CategoryViewModel model)
        {
            // if no option is selected
            if (model.Features.All(f => !f.IsSelected))
            {
                return View("Index", GetViewModel(model.ID, new List<FeatureViewModel>()));
            }

            return View("Index", GetViewModel(model.ID, model.Features));
        }

        /// <summary>
        /// Generates the viewmodel by the category ID and the selected features
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="features"></param>
        /// <returns></returns>
        private CategoryViewModel GetViewModel(int categoryID, List<FeatureViewModel> features)
        {
            SetHeaderDark();
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);

            var category = Db.Categories.Single(c => c.ID == categoryID);
            var categoryDetail = category.GetDetail(UserLanguageID) ?? category.GetDetail(DefaultLanguageID);

            var resources = Db.Resources.Where(r => r.MainCategory.ID == categoryID || r.Categories.Any(c => c.ID == categoryID)).ToList();
            if (features.Any())
            {
                var selectedFeatureIDs = features.Where(f => f.IsSelected).Select(f => f.ID).ToList();
                resources = resources.Where(r => 
                        r.ResourceFeatures.Any(rf => 
                            selectedFeatureIDs.Contains(rf.Feature.ID) && rf.Enabled))
                    .ToList();
            }
            else
            {
                features = Db.Features.ToList().ToViewModel(UserLanguageID, DefaultLanguageID);
            }

            SetCategoryOg(page, dfPage, category);

            return new CategoryViewModel
            {
                ID = category.ID,
                Title = categoryDetail.Title,
                Description = categoryDetail.Description,
                ResultsFound = page.CategoryResultsFound ?? dfPage.CategoryResultsFound,
                FilterDescription = page.CategoryFilterDescription ?? dfPage.CategoryFilterDescription,
                GoToResource = page.CategoryGoToResource ?? dfPage.CategoryGoToResource,
                Features = features,
                Resources = resources.GetResourceFilterViewModel(UserLanguageID, DefaultLanguageID),
                Markers = resources.GetMarkerViewModels(UserLanguageID, DefaultLanguageID),
                Filter = page.CategoryFilter ?? dfPage.CategoryFilter,
                Refresh = page.CategoryRefresh ?? dfPage.CategoryRefresh

            };
        }

        /// <summary>
        /// Sets the sharing options for the this page
        /// </summary>
        /// <param name="page">page with selected language</param>
        /// <param name="dfPage">page with default language</param>
        /// <param name="category">category selected</param>
        private void SetCategoryOg(Page page, Page dfPage, Category category)
        {
            SetOg(new OgViewModel
            {
                Url = (page.OgCategoryUrl ?? dfPage.OgCategoryUrl) + category.ID,
                Title = page.OgCategoryTitle ?? dfPage.OgCategoryTitle,
                Image = page.OgCategoryImage ?? dfPage.OgCategoryImage,
                Description = page.OgCategoryDescription ?? dfPage.OgCategoryDescription
            });
        }
    }
}