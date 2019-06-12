using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class ResourceController : BaseController
    {
        // GET: Resource
        public ActionResult Index(int id)
        {
            base.SetHeaderDark();

            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);

            var resource = Db.Resources.FirstOrDefault(c => c.ID == id);
            if (resource == null)
            {
                // category doesn't exist send to error page
                throw new NotImplementedException();
            }

            var resourceDetail = resource.GetDetail(UserLanguageID) ?? resource.GetDetail(DefaultLanguageID);
            var model = new ResourceViewModel
            {
                Title = resourceDetail.Title,
                Description = resourceDetail.Description,
                ContactTitle = page.ResourceContactTitle ?? dfPage.ResourceContactTitle,
                Phone = resource.Phone,
                Email = resource.Email,
                Website = resource.Website,
                Address = resourceDetail.Address,
                OpeningHours = resourceDetail.OpeningHours,
                GPSLat = resource.GPSLat,
                GPSLong = resource.GPSLong,
                Features = resource.ResourceFeatures.ToList().ToViewModel(UserLanguageID, DefaultLanguageID),
                Markers = new List<MarkerViewModel> { resource.GetMarkerViewModel(UserLanguageID, DefaultLanguageID) }
            };

            SetOg(new OgViewModel
            {
                Url = (page.OgResourceUrl ?? dfPage.OgResourceUrl) + resource.ID,
                Title = page.OgResourceTitle ?? dfPage.OgResourceTitle,
                Image = page.OgResourceImage ?? dfPage.OgResourceImage,
                Description = page.OgResourceDescription ?? dfPage.OgResourceDescription
            });
            return View(model);
        }
    }
}