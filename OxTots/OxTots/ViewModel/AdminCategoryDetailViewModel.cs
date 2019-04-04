using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class AdminCategoryDetailViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public int LanguageID { get; set; }
        public int CategoryID { get; set; }

        public List<Language> Languages { get; set; }
        public List<CategoryDetail> CategoryDetails { get; set; }

    }
}