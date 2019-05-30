using System.Collections.Generic;

namespace OxTots.ViewModel
{
    public class SearchViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string SearchError { get; set; }
        public string GoToResource { get; set; }
        public string SearchEmpty { get; set; }
        public string ResultsFound { get; set; }
        public string SearchPlaceHolder { get; set; }
        public List<MarkerViewModel> Markers { get; set; }
        public List<ResourceFilterViewModel> Results { get; set; }
        
    }
}