using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OxTots.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int id)
        {
            return View();
        }

        public class CategoryViewModel
        {
            public int Index { get; set; }
            public int TimeColour { get; set; }
            public int TimeNext { get; set; }
            public int ColourMode { get; set; }
            public string[,] Colours { get; set; }
            public string Image { get; set; }
            public string Colour { get; set; }
            public int Slider { get; set; }

        }
    }
}