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
        public string Search { get; set; }
        public string Listing { get; set; }

        
        public string Map { get; set; }
        public string Submission { get; set; }
        public string Contact { get; set; }
        public string AboutUs { get; set; }
        public string Link1 { get; set; }
        public string Link1Content { get; set; }
        public string Link2 { get; set; }
        public string Link2Content { get; set; }
        public bool HeaderDark { get; set; }

        public string MainLogo { get; set; }
        public string MainLogoAlt { get; set; }

        public int LanguageID { get; set; }
        public string LanguageIcon { get; set; }
        public string LanguageName { get; set; }
        public List<Language> Languages { get; set; }
        public List<LayoutCategoryViewModel> Categories { get; set; }
    }

    public class LayoutCategoryViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }
}