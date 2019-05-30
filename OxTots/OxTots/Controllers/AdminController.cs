using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public partial class AdminController : Controller
    {
        protected SiteContext Db = new SiteContext();
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
        
        public ActionResult Index()
        {
            if (IsLoggedIn)
                return RedirectToAction("Main");
            return View(new AdminLoginViewModel());
        }
        
        public ActionResult Logout()
        {
            IsLoggedIn = false;
            return RedirectToAction("Index");
        }

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

        public ActionResult Main()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            return View();
        }

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

        public ActionResult SubmissionRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var sb = Db.Submissions.Where(s => s.ID == id);
            Db.Submissions.RemoveRange(sb);
            Db.SaveChanges();
            return RedirectToAction("Submission");
        }

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

        public ActionResult ContactRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var sb = Db.Contacts.Where(s => s.ID == id);
            Db.Contacts.RemoveRange(sb);
            Db.SaveChanges();
            return RedirectToAction("Contact");
        }

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

        public ActionResult LanguageRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var sb = Db.Languages.Where(s => s.ID == id);
            Db.Languages.RemoveRange(sb);
            Db.SaveChanges();
            return RedirectToAction("Language");
        }

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