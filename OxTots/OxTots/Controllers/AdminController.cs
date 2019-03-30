using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class AdminController : Controller
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

            if (model.Username == "mo" && model.Password == "123")
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

            var sb = Db.Submissions.Where(s => s.ID == id);
            Db.Submissions.RemoveRange(sb);
            Db.SaveChanges();
            return RedirectToAction("Submission");
        }
    }
}