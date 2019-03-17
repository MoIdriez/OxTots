using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class LayoutViewModel
    {
        public string Title { get; set; }
        public string Search { get; set; }
        public string Listing { get; set; }

        public List<Category> Categories { get; set; }
        public string Map { get; set; }
        public string Submission { get; set; }
        public string Contact { get; set; }
        public string AboutUs { get; set; }
        public string Link1 { get; set; }
        public string Link2 { get; set; }
    }
}