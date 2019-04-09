using System;
using System.Web;
using System.Web.Mvc;

namespace OxTots.Utility
{
    public class CookieConsentAttribute : ActionFilterAttribute
    {
        public const string ConsentCookieName = "CookieConsent";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var viewBag = filterContext.Controller.ViewBag;
            viewBag.NeedConsent = true;

            var request = filterContext.HttpContext.Request;

            var consentCookie = request.Cookies[ConsentCookieName];
            if (consentCookie == null)
            {
                consentCookie = new HttpCookie(ConsentCookieName) { Value = "false" };
                filterContext.HttpContext.Response.Cookies.Add(consentCookie);
            }
            else
            {
                if (consentCookie.Value == "true")
                {
                    viewBag.NeedConsent = false;
                    consentCookie.Value = "true";
                    consentCookie.Expires = DateTime.UtcNow.AddYears(1);
                    filterContext.HttpContext.Response.Cookies.Set(consentCookie);
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
    public static class CookieConsent
    {
        public static void SetConsent(HttpResponseBase response)
        {
            var consentCookie = new HttpCookie(CookieConsentAttribute.ConsentCookieName) { Value = "true", Expires = DateTime.UtcNow.AddYears(1) };
            response.Cookies.Set(consentCookie);
        }
    }
}