using System.Linq;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public partial class AdminController
    {
        /// <summary>
        /// partial admin page - feature page information
        /// </summary>
        /// <returns></returns>
        public ActionResult Feature()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            
            var model = new AdminFeatureViewModel { Features = Db.Features.ToList() };
            return View(model);
        }

        /// <summary>
        /// Add a new feature
        /// </summary>
        /// <param name="model">model with new features name</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeatureAdd(AdminFeatureViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            var f = new Feature { Name = model.Name };
            Db.Features.Add(f);
            Db.SaveChanges();
            return RedirectToAction("Feature");
        }

        /// <summary>
        /// Edit an existing feature
        /// </summary>
        /// <param name="model">model with the feature id and name</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeatureEdit(AdminFeatureViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            var f = new Feature
            {
                ID = model.ID,
                Name = model.Name
            };
            Db.Entry(Db.Features.First(ft => ft.ID == model.ID)).CurrentValues.SetValues(f);
            Db.SaveChanges();
            return RedirectToAction("Feature");
        }

        /// <summary>
        /// Method to remove feature
        /// </summary>
        /// <param name="id">id of feature to be removed</param>
        /// <returns></returns>
        public ActionResult FeatureRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var f = Db.Features.Single(s => s.ID == id);
            Db.Features.Remove(f);
            Db.SaveChanges();
            return RedirectToAction("Feature");
        }

        /// <summary>
        /// Show the feature's details
        /// </summary>
        /// <param name="id">id of feature</param>
        /// <returns></returns>
        public ActionResult FeatureDetail(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var f = Db.Features.Single(s => s.ID == id);
            var model = new AdminFeatureDetailViewModel
            {
                FeatureID = id,
                Languages = Db.Languages.ToList(),
                FeatureDetails = f.FeatureDetails.ToList()
            };
            return View(model);
        }

        /// <summary>
        /// add a new feature detail
        /// </summary>
        /// <param name="model">model of new feature with title, language id and feature id</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeatureDetailAdd(AdminFeatureDetailViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var fd = new FeatureDetail
            {
                Title = model.Title,
                Language = Db.Languages.Single(l => l.ID == model.LanguageID),
                Feature = Db.Features.Single(c => c.ID == model.FeatureID)
            };
            Db.FeatureDetails.Add(fd);
            Db.SaveChanges();
            return RedirectToAction("FeatureDetail", new { id = model.FeatureID });
        }

        /// <summary>
        /// Remove a feature's details
        /// </summary>
        /// <param name="id">id of the feature detail to be removed</param>
        /// <returns></returns>
        public ActionResult FeatureDetailRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var f = Db.FeatureDetails.Single(s => s.ID == id);
            var fid = f.Feature.ID;
            Db.FeatureDetails.Remove(f);
            Db.SaveChanges();
            return RedirectToAction("FeatureDetail", new { id = fid });
        }
    }
}