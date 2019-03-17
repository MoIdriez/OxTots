using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class HomeViewModel
    {
        public string SearchPlaceHolder { get; set; }
        public string SearchError { get; set; }
        public string CategoriesText { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
        public List<MarkerViewModel> Markers { get; set; }
    }
}