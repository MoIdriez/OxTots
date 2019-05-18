using System.Linq;
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
            var model = new SubmissionViewModel
            {
                Image = page.SubmissionImage ?? dfPage.SubmissionImage,
                Title = page.SubmissionTitle ?? dfPage.SubmissionTitle,
                Description = page.SubmissionDescription ?? dfPage.SubmissionDescription,

                SelectedType = "New",
                ActionNew = page.SubmissionActionNew ?? dfPage.SubmissionActionNew,
                ActionTranslate = page.SubmissionActionTranslate ?? dfPage.SubmissionActionTranslate,

                LanguageTitle = page.SubmissionLanguageTitle ?? dfPage.SubmissionLanguageTitle,
                Languages = Db.Languages.ToList(),

                PersonalTitle = page.SubmissionFormPersonalTitle ?? dfPage.SubmissionFormPersonalTitle,
                PersonalNamePlaceholder = page.SubmissionFormPersonalPlaceholderName ?? dfPage.SubmissionFormPersonalPlaceholderName,
                PersonalEmailPlaceholder = page.SubmissionFormPersonalPlaceholderEmail ?? dfPage.SubmissionFormPersonalPlaceholderEmail,

                ResourceTitle = page.SubmissionFormResourceTitle ?? dfPage.SubmissionFormResourceTitle,
                ResourceNamePlaceholder = page.SubmissionFormResourcePlaceholderName ?? dfPage.SubmissionFormResourcePlaceholderName,
                ResourceDescriptionPlaceholder = page.SubmissionFormResourcePlaceholderDescription ?? dfPage.SubmissionFormResourcePlaceholderDescription,
                ResourceEmailPlaceholder = page.SubmissionFormResourcePlaceholderEmail ?? dfPage.SubmissionFormResourcePlaceholderEmail,
                ResourceWebsitePlaceholder = page.SubmissionFormResourcePlaceholderWebsite ?? dfPage.SubmissionFormResourcePlaceholderWebsite,
                ResourceAddressPlaceholder = page.SubmissionFormResourcePlaceholderAddress ?? dfPage.SubmissionFormResourcePlaceholderAddress,

                AssociatedResourceTitle = page.SubmissionAssociatedResourceTitle ?? dfPage.SubmissionAssociatedResourceTitle,
                GDPRText = page.SubmissionDescriptionGDPRNotice ?? dfPage.SubmissionDescriptionGDPRNotice,
                SubmitButtonText = page.SubmissionFormSubmitButtonText ?? dfPage.SubmissionFormSubmitButtonText,

                Resources = Db.Resources.ToList()
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
                Language = Db.Languages.Single(l => l.ID == model.SelectedLanguageID),
                Resource = Db.Resources.Single(r => r.ID == model.SelectedResourceID),
                Type = model.SelectedType,
                PersonalName = model.PersonalName,
                PersonalEmail = model.PersonalEmail,
                ResourceName = model.ResourceName,
                ResourceAddress = model.ResourceAddress,
                ResourceDescription = model.ResourceDescription,
                ResourceEmail = model.ResourceEmail,
                ResourceWebsite = model.ResourceWebsite
            });

            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}