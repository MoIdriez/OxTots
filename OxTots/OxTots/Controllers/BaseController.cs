using System.Linq;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    /// <summary>
    /// Non admin base controller
    /// </summary>
    [CookieConsent, Layout]
    public class BaseController : Controller
    {
        // context of the database
        protected SiteContext Db = new SiteContext();

        // id of default language
        protected int DefaultLanguageID => Db.Languages.First().ID;
        // id of user defined language
        protected int UserLanguageID
        {
            get => LanguageCookie.GetLanguage(Request);
            set => LanguageCookie.SetLanguage(Response, value);
        }

        /// <summary>
        ///  method to change the language by the language id
        /// </summary>
        /// <param name="languageID">id of selected language</param>
        /// <returns></returns>
        public ActionResult ChangeLanguage(int languageID)
        {
            UserLanguageID = languageID;
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Method to active when user agrees on GDPR
        /// </summary>
        /// <returns></returns>
        public ActionResult AcceptGDPR()
        {
            CookieConsent.SetConsent(Response);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Sets the header to be dark colour instead of the default transparent
        /// </summary>
        public void SetHeaderDark()
        {
            var model = (LayoutViewModel) ViewData["LayoutViewModel"];
            model.HeaderDark = true;
            ViewData["LayoutViewModel"] = model;
        }

        /// <summary>
        ///  Sets the sharing information for that page
        /// </summary>
        /// <param name="model"></param>
        protected void SetOg(OgViewModel model)
        {
            ViewData["OgViewModel"] = model;
        }

    }
}