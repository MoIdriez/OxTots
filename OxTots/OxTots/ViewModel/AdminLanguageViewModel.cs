using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class AdminLanguageViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool InverseDirection { get; set; }
        public List<string> AvailableLanguages { get; set; }
        public List<Language> Languages { get; set; }
    }
}