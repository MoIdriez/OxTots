using System.Linq;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public partial class AdminController
    {
        /// <summary>
        /// partial admin page - general page information
        /// </summary>
        /// <returns></returns>
        public ActionResult Page()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var model = new AdminPageViewModel
            {
                Pages = Db.Pages.ToList()
            };
            return View(model);
        }

        /// <summary>
        /// Page to add a new translation for the general pages
        /// </summary>
        /// <returns></returns>
        public ActionResult PageAdd()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var model = new AdminPageAddModel
            {
                Languages = Db.Languages.ToList(),
                Page = new Page()
            };
            return View(model);
        }

        /// <summary>
        /// add a new page translation
        /// </summary>
        /// <param name="model">model with new page translation</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PageAdd(AdminPageAddModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            model.Page.Language = Db.Languages.First(l => l.ID == model.SelectedLanguage);
            Db.Pages.Add(model.Page);
            Db.SaveChanges();
            return RedirectToAction("Page");
        }

        /// <summary>
        /// Edit existing page translation - form page
        /// </summary>
        /// <param name="id">page id that is edited</param>
        /// <returns></returns>
        public ActionResult PageEdit(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var model = new AdminPageAddModel
            {
                Edit = true,
                Languages = Db.Languages.ToList(),
                Page = Db.Pages.First(p => p.ID == id)
            };
            return View("PageAdd", model);
        }

        /// <summary>
        /// Edit existing page translation
        /// </summary>
        /// <param name="model">model with edit page translation</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PageEdit(AdminPageAddModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            model.Page.Language = Db.Languages.First(l => l.ID == model.SelectedLanguage);
            Db.Entry(Db.Pages.First(p => p.ID == model.Page.ID)).CurrentValues.SetValues(model.Page);
            Db.SaveChanges();
            return RedirectToAction("Page");
        }

        /// <summary>
        /// Remove existing page
        /// </summary>
        /// <param name="id">page id to be removed</param>
        /// <returns></returns>
        public ActionResult PageRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Main");

            var sb = Db.Pages.Where(s => s.ID == id);
            Db.Pages.RemoveRange(sb);
            Db.SaveChanges();
            return RedirectToAction("Page");
        }
    }
}