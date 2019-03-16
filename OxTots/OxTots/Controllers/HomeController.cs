using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.Data;

namespace OxTots.Controllers
{
    public class HomeController : Controller
    {
        private SiteContext db = new SiteContext();
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}