using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OxTots.ViewModel;

namespace OxTots.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            var model = new LayoutViewModel { Title = "string" };
            this.ViewData["LayoutViewModel"] = model;
        }
    }
}