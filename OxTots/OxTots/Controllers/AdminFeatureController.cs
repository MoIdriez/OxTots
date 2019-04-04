using System.Linq;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public partial class AdminController
    {
        public ActionResult Feature(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var ct = Db.Categories.Single(c => c.ID == id);
            
            var model = new AdminFeatureViewModel
            {
                CategoryID = id,
                Features = ct.Features.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeatureAdd(AdminFeatureViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var ct = Db.Categories.Single(c => c.ID == model.CategoryID);

            var f = new Feature
            {
                Name = model.Name,
                Category = ct
            };
            Db.Features.Add(f);
            Db.SaveChanges();
            return RedirectToAction("Feature", new {id = model.CategoryID });
        }

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
            return RedirectToAction("Feature", new { id = model.CategoryID });
        }

        public ActionResult FeatureRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var f = Db.Features.Single(s => s.ID == id);
            var cid = f.Category.ID;
            Db.Features.Remove(f);
            Db.SaveChanges();
            return RedirectToAction("Feature", new { id = cid });
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FeatureDetailEdit(AdminFeatureDetailViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var fd = new FeatureDetail
            {
                ID = model.ID,
                Title = model.Title
            };
            var featureDetail = Db.FeatureDetails.First(ct => ct.ID == model.ID);
            featureDetail.Language = Db.Languages.Single(l => l.ID == model.LanguageID);
            Db.Entry(featureDetail).CurrentValues.SetValues(fd);
            Db.SaveChanges();
            return RedirectToAction("FeatureDetail", new { id = model.FeatureID });
        }

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