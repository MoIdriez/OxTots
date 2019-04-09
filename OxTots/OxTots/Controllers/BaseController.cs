using System.Linq;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    [CookieConsent, Layout]
    public class BaseController : Controller
    {
        protected SiteContext Db = new SiteContext();

        protected int DefaultLanguageID => Db.Languages.First().ID;
        protected int UserLanguageID
        {
            get => LanguageCookie.GetLanguage(Request);
            set => LanguageCookie.SetLanguage(Response, value);
        }

        public ActionResult ChangeLanguage(int languageID)
        {
            UserLanguageID = languageID;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AcceptGDPR()
        {
            CookieConsent.SetConsent(Response);
            return RedirectToAction("Index", "Home");
        }

        public void SetHeaderDark()
        {
            var model = (LayoutViewModel) ViewData["LayoutViewModel"];
            model.HeaderDark = true;
            ViewData["LayoutViewModel"] = model;
        }

        protected void SetOg(OgViewModel model)
        {
            ViewData["OgViewModel"] = model;
        }

    }
}