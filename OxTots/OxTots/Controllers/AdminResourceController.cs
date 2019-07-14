using System.Linq;
using System.Web.Mvc;
using OxTots.Models;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    /// <summary>
    /// partial admin page - resource page information
    /// </summary>
    public partial class AdminController
    {
        /// <summary>
        /// Displays the admin resource page
        /// </summary>
        /// <returns></returns>
        public ActionResult Resource()
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var model = new AdminResourceViewModel
            {
                Resources = Db.Resources.OrderBy(r => r.Name).ToList(),
                Categories = Db.Categories.ToList(),
                Features = Db.Features.ToList(),
            };
            return View(model);
        }

        /// <summary>
        /// Method that adds a new resource
        /// </summary>
        /// <param name="model">model of new resource with it's information</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceAdd(AdminResourceViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            // the new resource
            var r = new Resource
            {
                Name = model.Name,
                GPSLong = model.GPSLong,
                GPSLat = model.GPSLat,
                Phone = model.Phone,
                Email = model.Email,
                Website = model.Website,
                Image = model.Image,
                Icon = model.Icon,
                MainCategory = Db.Categories.Single(c => model.MainCategoryID == c.ID)
            };

            // associating it with a feature
            r.ResourceFeatures = Db.Features.ToList().Select(f => new ResourceFeature
            {
                Resource = r,
                Feature = f

            }).ToList();

            Db.Resources.Add(r);
            Db.SaveChanges();
            return RedirectToAction("Resource");
        }

        /// <summary>
        /// Edit a resource
        /// </summary>
        /// <param name="model">model with the resource's information</param>
        /// <returns></returns>
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
                GPSLong = model.GPSLong,
                GPSLat = model.GPSLat,
                Phone = model.Phone,
                Email = model.Email,
                Website = model.Website,
                Image = model.Image,
                Icon = model.Icon,
                MainCategory = Db.Categories.Single(c => model.MainCategoryID == c.ID)
            };
            Db.Entry(Db.Resources.First(ft => ft.ID == model.ID)).CurrentValues.SetValues(r);
            Db.SaveChanges();
            return RedirectToAction("Resource");
        }

        /// <summary>
        /// Method to remove existing resource
        /// </summary>
        /// <param name="id">id of resrouce being removed</param>
        /// <returns></returns>
        public ActionResult ResourceRemove(int id)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var r = Db.Resources.Single(s => s.ID == id);
            // remove resource's features and details as well
            Db.ResourceFeatures.RemoveRange(Db.ResourceFeatures.Where(rf => rf.Resource.ID == id).ToList());
            Db.ResourceDetails.RemoveRange(Db.ResourceDetails.Where(rd => rd.Resource.ID == id).ToList());
            Db.Resources.Remove(r);
            Db.SaveChanges();
            return RedirectToAction("Resource");
        }

        /// <summary>
        /// Add or edit resource to category association
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceAssociateCategory(AdminResourceViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var r = Db.Resources.Single(s => s.ID == model.ID);
            var category = Db.Categories.Single(c => c.ID == model.MainCategoryID);
            if (model.FeatureEnabled)
            {
                r.Categories.Add(category);
            }
            else
            {
                r.Categories.Remove(category);
            }

            Db.SaveChanges();
            return RedirectToAction("Resource");
        }

        /// <summary>
        /// Displays a resource's associated features
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceFeature(AdminResourceViewModel model)
        {
            if (!IsLoggedIn)
                return RedirectToAction("Index");

            var r = Db.ResourceFeatures.Single(rf => rf.Resource.ID == model.ID && rf.Feature.ID == model.FeatureID);
            r.Enabled = model.FeatureEnabled;
            Db.SaveChanges();
            return RedirectToAction("Resource");
        }

        /// <summary>
        /// Displays a resource's details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Add a new resource detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
                Address = model.Address,
                Language = Db.Languages.Single(l => l.ID == model.LanguageID),
                Resource = Db.Resources.Single(c => c.ID == model.ResourceID)
            };
            Db.ResourceDetails.Add(rd);
            Db.SaveChanges();
            return RedirectToAction("ResourceDetail", new { id = model.ResourceID });
        }

        /// <summary>
        /// Remove a resource's detail
        /// </summary>
        /// <param name="id">id of resource detail to be removed</param>
        /// <returns></returns>
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