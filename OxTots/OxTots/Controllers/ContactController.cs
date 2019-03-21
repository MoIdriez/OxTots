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
    public class ContactController : BaseController
    {
        // GET: Contact
        public ActionResult Index()
        {
            var page = db.Pages.GetPage();
            var model = new ContactViewModel
            {
                Title = page.ContactTitle,
                Description = page.ContactDescription
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(ContactViewModel model)
        {
            db.Contacts.Add(new Contact
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message
            });

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}