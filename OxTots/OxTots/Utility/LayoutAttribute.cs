using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Data;
using OxTots.ViewModel;

namespace OxTots.Utility
{
    /// <summary>
    /// Sets all the information that is used in the layout view
    /// </summary>
    public class LayoutAttribute : ActionFilterAttribute
    {
        // gets current language
        public const string LanguageCookie = "CookieLanguage";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var db = new SiteContext();
            var viewData = filterContext.Controller.ViewData;
            var request = filterContext.HttpContext.Request;

            var languageCookie = request.Cookies[LanguageCookie];
            if (languageCookie?.Value == null)
            {
                languageCookie = new HttpCookie(LanguageCookie) { Value = db.Languages.First().ID.ToString() };
                filterContext.HttpContext.Response.Cookies.Add(languageCookie);
            }

            var userLanguageID = Convert.ToInt32(languageCookie.Value);
            var defaultLanguageID = db.Languages.First().ID;

            var page = db.Pages.GetPage(userLanguageID);
            var dfPage = db.Pages.GetPage(defaultLanguageID);

            var language = db.Languages.First(l => l.ID == userLanguageID);
            var model = new LayoutViewModel
            {
                Listing = page.LayoutMenuListing ?? dfPage.LayoutMenuListing,
                Search = page.LayoutMenuSearch ?? dfPage.LayoutMenuSearch,
                Map = page.LayoutMenuMap ?? dfPage.LayoutMenuMap,
                Submission = page.LayoutMenuSubmissions ?? dfPage.LayoutMenuSubmissions,
                Contact = page.LayoutMenuContact ?? dfPage.LayoutMenuContact,
                AboutUs = page.LayoutMenuAboutUs ?? dfPage.LayoutMenuAboutUs,
                Link1 = page.LayoutFooterLink1 ?? dfPage.LayoutFooterLink1,
                Link1Content = page.LayoutFooterLink1Content ?? dfPage.LayoutFooterLink1Content,
                Link2 = page.LayoutFooterLink2 ?? dfPage.LayoutFooterLink2,
                Link2Content = page.LayoutFooterLink2Content ?? dfPage.LayoutFooterLink2Content,
                HeaderDark = false,
                Categories = db.Categories.ToList().Select(c => new LayoutCategoryViewModel
                {
                    ID = c.ID,
                    Title = (c.GetDetail(userLanguageID) ?? c.GetDetail(defaultLanguageID)).Title
                }).ToList(),

                MainLogo = page.LayoutMainLogo ?? dfPage.LayoutMainLogo,
                MainLogoAlt = page.LayoutMainLogoAlt ?? dfPage.LayoutMainLogoAlt,

                LanguageID = userLanguageID,
                LanguageName = language.Name,
                LanguageIcon = language.Icon,
                Languages = db.Languages.ToList(),

                LanguagesTitle = page.LayoutLanguagesTitle ?? dfPage.LayoutLanguagesTitle,
                LanguagesDescription = page.LayoutLanguagesDescription ?? dfPage.LayoutLanguagesDescription,
                ShareTitle = page.LayoutShareTitle ?? dfPage.LayoutShareTitle,
                ShareDescription = page.LayoutShareDescription ?? dfPage.LayoutShareDescription,
                GDPRTitle = page.LayoutGDPRTitle ?? dfPage.LayoutGDPRTitle,
                GDPRMessage = page.LayoutGDPRMessage ?? dfPage.LayoutGDPRMessage,
                GDPRButton = page.LayoutGDPRButton ?? dfPage.LayoutGDPRButton,
            };
            viewData["LayoutViewModel"] = model;
            base.OnActionExecuting(filterContext);
        }
    }

    /// <summary>
    /// Convenience class for the language cookie. gets overriden when someone changes language
    /// </summary>
    public static class LanguageCookie
    {
        public static void SetLanguage(HttpResponseBase response, int languageID)
        {
            var consentCookie = new HttpCookie(LayoutAttribute.LanguageCookie) { Value = languageID.ToString(), Expires = DateTime.UtcNow.AddYears(1) };
            response.Cookies.Set(consentCookie);
        }

        public static int GetLanguage(HttpRequestBase request)
        {
            var requestCookie = request.Cookies[LayoutAttribute.LanguageCookie];
            if (requestCookie?.Value == null)
                return new SiteContext().Languages.First().ID;
            return Convert.ToInt32(requestCookie.Value);
        }
    }
}