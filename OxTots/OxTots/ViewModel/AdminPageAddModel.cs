using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class AdminPageAddModel
    {
        public bool Edit { get; set; }
        public Page Page { get; set; }
        public int SelectedLanguage { get; set; }
        public List<Language> Languages { get; set; }
    }
}