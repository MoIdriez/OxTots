using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class AdminFeatureDetailViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public int FeatureID { get; set; }
        public int LanguageID { get; set; }
        public List<Language> Languages { get; set; }
        public List<FeatureDetail> FeatureDetails { get; set; }

        
    }
}