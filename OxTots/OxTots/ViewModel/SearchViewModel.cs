using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.ViewModel
{
    public class SearchViewModel
    {
        public List<MarkerViewModel> Markers { get; set; }
        public List<SearchResultViewModel> Results { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SearchPlaceHolder { get; set; }
        public string SearchError { get; set; }
        public string ResultsFound { get; set; }
    }
}