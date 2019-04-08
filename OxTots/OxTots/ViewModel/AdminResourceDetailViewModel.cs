using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class AdminResourceDetailViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }

        public string Address { get; set; }

        public string OpeningHours { get; set; }

        public int ResourceID { get; set; }
        public int LanguageID { get; set; }

        public List<Language> Languages { get; set; }
        public List<ResourceDetail> ResourceDetails { get; set; }


    }
}