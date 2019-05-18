using System.Linq;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public partial class AdminController
    {
        public ActionResult Feature()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            
            var model = new AdminFeatureViewModel { Features = Db.Features.ToList() };
            return View(model);
        }

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

        public ActionResult FeatureRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var f = Db.Features.Single(s => s.ID == id);
            Db.Features.Remove(f);
            Db.SaveChanges();
            return RedirectToAction("Feature");
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