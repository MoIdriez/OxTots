using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class SubmissionController : BaseController
    {
        // GET: Submission
        public ActionResult Index()
        {
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);

            var categories = Db.Categories.ToList();
            var model = new SubmissionViewModel
            {
                Image = page.SubmissionImage ?? dfPage.SubmissionImage,
                Title = page.SubmissionTitle ?? dfPage.SubmissionTitle,
                Description = page.SubmissionDescription ?? dfPage.SubmissionDescription,

                NamePlaceholder = page.SubmissionFormNamePlaceholder ?? dfPage.SubmissionFormNamePlaceholder,
                EmailPlaceholder = page.SubmissionFormEmailPlaceholder ?? dfPage.SubmissionFormEmailPlaceholder,
                ResourceNamePlaceholder = page.SubmissionFormResourceNamePlaceholder ?? dfPage.SubmissionFormResourceNamePlaceholder,
                ResourceAddressPlaceholder = page.SubmissionFormResourceAddressPlaceholder ?? dfPage.SubmissionFormResourceAddressPlaceholder,
                ResourceDescriptionPlaceholder = page.SubmissionFormResourceDescriptionPlaceholder ?? dfPage.SubmissionFormResourceDescriptionPlaceholder,
                ResourcePhonePlaceholder = page.SubmissionFormResourcePhonePlaceholder ?? dfPage.SubmissionFormResourcePhonePlaceholder,
                ResourceEmailPlaceholder = page.SubmissionFormResourceEmailPlaceholder ?? dfPage.SubmissionFormResourceEmailPlaceholder,
                ResourceWebsitePlaceholder = page.SubmissionFormResourceWebsitePlaceholder ?? dfPage.SubmissionFormResourceWebsitePlaceholder,

                PersonalInformationTitle = page.SubmissionFormPersonalInformationTitle ?? dfPage.SubmissionFormPersonalInformationTitle,
                ResourceInformationTitle = page.SubmissionFormResourceInformationTitle ?? dfPage.SubmissionFormResourceInformationTitle,
                ResourceCategoryTitle = page.SubmissionFormResourceCategoryTitle ?? dfPage.SubmissionFormResourceCategoryTitle,
                ResourceFeatureTitle = page.SubmissionFormResourceFeatureTitle ?? dfPage.SubmissionFormResourceFeatureTitle,
                ExtraInformationText = page.SubmissionFormExtraInformationText ?? dfPage.SubmissionFormExtraInformationText,
                SubmitButtonText = page.SubmissionFormSubmitButtonText ?? dfPage.SubmissionFormSubmitButtonText,

                Categories = categories.Select(c =>
                {
                    var categoryDetail = c.GetDetail(UserLanguageID) ?? c.GetDetail(DefaultLanguageID);
                    return new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = categoryDetail.Title
                    };
                }).ToList()
            };

            SetOg(new OgViewModel
            {
                Url = page.OgSubmissionUrl ?? dfPage.OgSubmissionUrl,
                Title = page.OgSubmissionTitle ?? dfPage.OgSubmissionTitle,
                Image = page.OgSubmissionImage ?? dfPage.OgSubmissionImage,
                Description = page.OgSubmissionDescription ?? dfPage.OgSubmissionDescription
            });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(SubmissionViewModel model)
        {
            Db.Submissions.Add(new Submission 
            {
                Name = model.Name,
                Email = model.Email,
                ResourceName = model.ResourceName,
                ResourceAddress = model.ResourceAddress,
                ResourceDescription = model.ResourceDescription,
                ResourcePhone = model.ResourcePhone,
                ResourceEmail = model.ResourceEmail,
                ResourceWebsite = model.ResourceWebsite,
                Language = Db.Languages.First(l => l.ID == UserLanguageID),
                Category = Db.Categories.First(c => c.ID == model.SelectedCategoryID)
            });

            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}