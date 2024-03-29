﻿using System.Web.Mvc;
using OxTots.Models;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    /// <summary>
    /// Contact controller
    /// </summary>
    public class ContactController : BaseController
    {
        /// <summary>
        /// Displays the contact page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);
            var model = new ContactViewModel
            {
                Title = page.ContactTitle ?? dfPage.ContactTitle,
                Description = page.ContactDescription ?? dfPage.ContactDescription,
                NamePlaceHolder = page.ContactNamePlaceHolder ?? dfPage.ContactNamePlaceHolder,
                EmailPlaceHolder = page.ContactEmailPlaceHolder ?? dfPage.ContactEmailPlaceHolder,
                MessagePlaceHolder = page.ContactMessagePlaceHolder ?? dfPage.ContactMessagePlaceHolder,
                ContactGDPRMessage = page.ContactGDPRMessage ?? dfPage.ContactGDPRMessage,
                SubmitButtonText = page.ContactSubmitButtonText ?? dfPage.ContactSubmitButtonText,
            };

            SetOg(new OgViewModel
            {
                Url = page.OgContactUrl ?? dfPage.OgContactUrl,
                Title = page.OgContactTitle ?? dfPage.OgContactTitle,
                Image = page.OgContactImage ?? dfPage.OgContactImage,
                Description = page.OgContactDescription ?? dfPage.OgContactDescription
            });
            return View(model);
        }

        /// <summary>
        /// Method to submit the contact form
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(ContactViewModel model)
        {
            Db.Contacts.Add(new Contact
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message
            });

            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}