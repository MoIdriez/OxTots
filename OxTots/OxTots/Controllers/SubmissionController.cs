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
            var page = db.Pages.GetPage();
            var categories = db.Categories.ToList();
            var model = new SubmissionViewModel
            {
                Image = page.SubmissionImage,
                Title = page.SubmissionTitle,
                Description = page.SubmissionDescription,

                NamePlaceholder = page.SubmissionFormNamePlaceholder,
                EmailPlaceholder = page.SubmissionFormEmailPlaceholder,
                ResourceNamePlaceholder = page.SubmissionFormResourceNamePlaceholder,
                ResourceAddressPlaceholder = page.SubmissionFormResourceAddressPlaceholder,
                ResourceDescriptionPlaceholder = page.SubmissionFormResourceDescriptionPlaceholder,
                ResourcePhonePlaceholder = page.SubmissionFormResourcePhonePlaceholder,
                ResourceEmailPlaceholder = page.SubmissionFormResourceEmailPlaceholder,
                ResourceWebsitePlaceholder = page.SubmissionFormResourceWebsitePlaceholder,

                PersonalInformationTitle = page.SubmissionFormPersonalInformationTitle,
                ResourceInformationTitle = page.SubmissionFormResourceInformationTitle,
                ResourceCategoryTitle = page.SubmissionFormResourceCategoryTitle,
                ResourceFeatureTitle = page.SubmissionFormResourceFeatureTitle,
                ExtraInformationText = page.SubmissionFormExtraInformationText,
                SubmitButtonText = page.SubmissionFormSubmitButtonText,

                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(SubmissionViewModel model)
        {
            db.Submissions.Add(new Submission 
            {
                Name = model.Name,
                Email = model.Email,
                ResourceName = model.ResourceName,
                ResourceAddress = model.ResourceAddress,
                ResourceDescription = model.ResourceDescription,
                ResourcePhone = model.ResourcePhone,
                ResourceEmail = model.ResourceEmail,
                ResourceWebsite = model.ResourceWebsite,
                Language = db.Languages.First(l => l.CountryCode == "en-GB"),
                Category = db.Categories.First()
            });

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}