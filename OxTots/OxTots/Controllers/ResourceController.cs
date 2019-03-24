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
            var page = db.Pages.GetPage();
            var resource = db.Resources.FirstOrDefault(c => c.ID == id);
            if (resource == null)
            {
                // category doesn't exist send to error page
                throw new NotImplementedException();
            }

            var resourceDetail = resource.GetDetail();
            var model = new ResourceViewModel
            {
                Title = resourceDetail.Title,
                Description = resourceDetail.Description,
                ContactTitle = page.ResourceContactTitle,
                Phone = resource.Phone,
                Email = resource.Email,
                Address = resource.Address,
                OpeningHours = resourceDetail.OpeningHours,
                Features = resource.ResourceFeatures.ToViewModel(),
                Markers = new List<MarkerViewModel> { resource.GetMarkerViewModel() }
            };
            return View(model);
        }
    }
}