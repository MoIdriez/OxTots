using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.Utility;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class BaseController : Controller
    {
        protected SiteContext Db = new SiteContext();

        protected int DefaultLanguageID => Db.Languages.First().ID;
        protected int UserLanguageID
        {
            get
            {
                if (Request.Cookies["UserLanguageID"] == null)
                {
                    Request.Cookies.Add(new HttpCookie("UserLanguageID")
                    {
                        Value = Db.Languages.First().ID.ToString(),
                        Expires = DateTime.Now.AddYears(1)
                    });
                }
                return Convert.ToInt32(Request.Cookies["UserLanguageID"].Value);
            }
            set { Request.Cookies["UserLanguageID"].Value = value.ToString(); }
        }

        

        public BaseController()
        {
            GetLayoutViewModel();
        }

        public ActionResult ChangeLanguage(int languageID)
        {
            UserLanguageID = languageID;
            return RedirectToAction("Index", "Home");
        }

        public void SetHeaderDark()
        {
            GetLayoutViewModel(true);
        }

        private void GetLayoutViewModel(bool dark = false)
        {
            var page = Db.Pages.GetPage(UserLanguageID);
            var dfPage = Db.Pages.GetPage(DefaultLanguageID);

            var language = Db.Languages.First(l => l.ID == UserLanguageID);
            var model = new LayoutViewModel
            {
                Listing = page.LayoutMenuListing ?? dfPage.LayoutMenuListing,
                Search = page.LayoutMenuSearch ?? dfPage.LayoutMenuSearch,
                Map = page.LayoutMenuMap ?? dfPage.LayoutMenuMap,
                Submission = page.LayoutMenuSubmissions ?? dfPage.LayoutMenuSubmissions,
                Contact = page.LayoutMenuContact ?? dfPage.LayoutMenuContact,
                AboutUs = page.LayoutMenuAboutUs ?? dfPage.LayoutMenuAboutUs,
                Link1 = page.LayoutFooterLink1 ?? dfPage.LayoutFooterLink1,
                Link1Content = page.LayoutFooterLink1Content??dfPage.LayoutFooterLink1Content,
                Link2 = page.LayoutFooterLink2 ?? dfPage.LayoutFooterLink2,
                Link2Content = page.LayoutFooterLink2Content ?? dfPage.LayoutFooterLink2Content,
                HeaderDark = dark,
                Categories = Db.Categories.Select(c => new LayoutCategoryViewModel
                {
                    ID = c.ID,
                    Title = c.GetDetail(UserLanguageID).Title ?? c.GetDetail(DefaultLanguageID).Title
                }).ToList(),

                MainLogo = page.LayoutMainLogo ?? dfPage.LayoutFooterLink1Content,
                MainLogoAlt = page.LayoutMainLogoAlt ?? dfPage.LayoutFooterLink1Content,

                LanguageID = UserLanguageID,
                LanguageName = language.Name,
                LanguageIcon = language.Icon,
                Languages = Db.Languages.ToList()
            };
            ViewData["LayoutViewModel"] = model;
        }

    }
}