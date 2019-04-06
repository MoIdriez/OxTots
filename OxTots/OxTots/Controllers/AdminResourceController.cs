using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public partial class AdminController
    {
        public ActionResult Resource(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var ct = Db.Categories.Single(c => c.ID == id);

            var model = new AdminResourceViewModel
            {
                CategoryID = id,
                Resources = ct.Resources.ToList(),
                Features = ct.Features.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceAdd(AdminResourceViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var ct = Db.Categories.Single(c => c.ID == model.CategoryID);

            var r = new Resource
            {
                Name = model.Name,
                Address = model.Address,
                GPSLong = model.GPSLong,
                GPSLat = model.GPSLat,
                Phone = model.Phone,
                Email = model.Email,
                Website = model.Website,
                Image = model.Image,
                Icon = model.Icon,
                Category = ct
            };

            r.ResourceFeatures = ct.Features.Select(f => new ResourceFeature
            {
                Resource = r,
                Feature = f

            }).ToList();

            Db.Resources.Add(r);
            Db.SaveChanges();
            return RedirectToAction("Resource", new { id = model.CategoryID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceEdit(AdminResourceViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");
            var r = new Resource
            {
                ID = model.ID,
                Name = model.Name,
                Address = model.Address,
                GPSLong = model.GPSLong,
                GPSLat = model.GPSLat,
                Phone = model.Phone,
                Email = model.Email,
                Website = model.Website,
                Image = model.Image,
                Icon = model.Icon
            };
            Db.Entry(Db.Resources.First(ft => ft.ID == model.ID)).CurrentValues.SetValues(r);
            Db.SaveChanges();
            return RedirectToAction("Resource", new { id = model.CategoryID });
        }

        public ActionResult ResourceRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var r = Db.Resources.Single(s => s.ID == id);
            var cid = r.Category.ID;
            Db.Resources.Remove(r);
            Db.SaveChanges();
            return RedirectToAction("Resource", new { id = cid });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceFeature(AdminResourceViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var r = Db.ResourceFeatures.Single(rf => rf.Resource.ID == model.ID && rf.Feature.ID == model.FeatureID);
            r.Enabled = model.FeatureEnabled;
            Db.SaveChanges();
            return RedirectToAction("Resource", new { id = model.CategoryID });
        }

        public ActionResult ResourceDetail(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var r = Db.Resources.Single(rs => rs.ID == id);

            var model = new AdminResourceDetailViewModel
            {
                ResourceID = id,
                Languages = Db.Languages.ToList(),
                ResourceDetails = r.ResourceDetails.ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceDetailAdd(AdminResourceDetailViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var rd = new ResourceDetail
            {
                Title = model.Title,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                OpeningHours = model.OpeningHours,
                Language = Db.Languages.Single(l => l.ID == model.LanguageID),
                Resource = Db.Resources.Single(c => c.ID == model.ResourceID)
            };
            Db.ResourceDetails.Add(rd);
            Db.SaveChanges();
            return RedirectToAction("ResourceDetail", new { id = model.ResourceID });
        }

        public ActionResult ResourceDetailRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var rd = Db.ResourceDetails.Single(s => s.ID == id);
            var rid = rd.Resource.ID;
            Db.ResourceDetails.Remove(rd);
            Db.SaveChanges();
            return RedirectToAction("ResourceDetail", new { id = rid });
        }
    }
}