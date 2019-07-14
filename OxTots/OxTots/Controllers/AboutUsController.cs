using System.Web.Mvc;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class AboutUsController : BaseController
    {
        /// <summary>
        /// Displays the about page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // current language page information
            var page = Db.Pages.GetPage(UserLanguageID);
            
            // default language page information
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);

            // page information model
            var model = new AboutUsViewModel
            {
                Image = page.AboutUsImage ?? dfPage.AboutUsImage,
                Title = page.AboutUsTitle ?? dfPage.AboutUsTitle,
                Description = page.AboutUsDescription ?? dfPage.AboutUsDescription,
                Description2 = page.AboutUsDescription2 ?? dfPage.AboutUsDescription2
            };

            // page sharing information model
            SetOg(new OgViewModel
            {
                Url = page.OgAboutUsUrl ?? dfPage.OgAboutUsUrl,
                Title = page.OgAboutUsTitle ?? dfPage.OgAboutUsTitle,
                Image = page.OgAboutUsImage ?? dfPage.OgAboutUsImage,
                Description = page.OgAboutUsDescription ?? dfPage.OgAboutUsDescription
            });

            return View(model);
        }
    }
}