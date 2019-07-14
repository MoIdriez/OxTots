using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    /// <summary>
    /// partial admin page - main page information
    /// </summary>
    public partial class AdminController : Controller
    {
        // context of the database
        protected SiteContext Db = new SiteContext();

        // wrapper for Login session
        private bool IsLoggedIn
        {
            get
            {
                if (Session["IsLoggedIn"] == null)
                {
                    Session["IsLoggedIn"] = false;
                }

                return Convert.ToBoolean(Session["IsLoggedIn"]);
            }
            set => Session["IsLoggedIn"] = value;
        }

        /// <summary>
        /// admin index page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (IsLoggedIn)
                return RedirectToAction("Main");
            return View(new AdminLoginViewModel());
        }
        
        /// <summary>
        /// Logout method sets cookie to false
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            IsLoggedIn = false;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method to check the login details given
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLoginViewModel model)
        {
            if (IsLoggedIn)
                return RedirectToAction("Main");

            if (model.Username == "OxTots" && model.Password == "Ox4Tots2018")
            {
                IsLoggedIn = true;
                return RedirectToAction("Main");
            }
            model.Password = "";
            model.ErrorMessage = "IncorrectLogin";
            return View("Index", model);
        }

        /// <summary>
        /// Main method that displays all the admin page subsections
        /// </summary>
        /// <returns></returns>
        public ActionResult Main()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            return View();
        }

        /// <summary>
        /// Submission admin page
        /// </summary>
        /// <returns></returns>
        public ActionResult Submission()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var model = new AdminSubmissionViewModel
            {
                Submissions = Db.Submissions.ToList()
            };
            return View(model);
        }

        /// <summary>
        /// Remove a submission by id
        /// </summary>
        /// <param name="id">id of submission to be removed</param>
        /// <returns></returns>
        public ActionResult SubmissionRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var sb = Db.Submissions.Where(s => s.ID == id);
            Db.Submissions.RemoveRange(sb);
            Db.SaveChanges();
            return RedirectToAction("Submission");
        }

        /// <summary>
        /// Contact admin page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var model = new AdminContactViewModel
            {
                Contacts = Db.Contacts.ToList()
            };
            return View(model);
        }

        /// <summary>
        /// Remove a contact by id
        /// </summary>
        /// <param name="id">id of contact to be removed</param>
        /// <returns></returns>
        public ActionResult ContactRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var sb = Db.Contacts.Where(s => s.ID == id);
            Db.Contacts.RemoveRange(sb);
            Db.SaveChanges();
            return RedirectToAction("Contact");
        }

        /// <summary>
        /// Language admin page
        /// </summary>
        /// <returns></returns>
        public ActionResult Language()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var model = new AdminLanguageViewModel
            {
                AvailableLanguages = Directory.EnumerateFiles(Server.MapPath("~/Images/flags")).Select(Path.GetFileName).ToList(),
                Languages = Db.Languages.ToList()
            };
            return View(model);
        }

        /// <summary>
        /// Remove a language by id
        /// </summary>
        /// <param name="id">id of language to be removed</param>
        /// <returns></returns>
        public ActionResult LanguageRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var sb = Db.Languages.Where(s => s.ID == id);
            Db.Languages.RemoveRange(sb);
            Db.SaveChanges();
            return RedirectToAction("Language");
        }

        /// <summary>
        /// Add a new language
        /// </summary>
        /// <param name="model">model with the new language's name, icon and direction</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LanguageAdd(AdminLanguageViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var l = new Language
            {
                Name = model.Name,
                Icon = model.Icon,
                InverseDirection = model.InverseDirection
            };
            Db.Languages.Add(l);
            Db.SaveChanges();
            return RedirectToAction("Language");
        }

        /// <summary>
        /// Edit an existing language
        /// </summary>
        /// <param name="model">model with the edit information</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LanguageEdit(AdminLanguageViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var language = Db.Languages.First(l => l.ID == model.ID);
            language.Name = model.Name;
            language.Icon = model.Icon;
            language.InverseDirection = model.InverseDirection;

            Db.SaveChanges();
            return RedirectToAction("Language");
        }
    }
}