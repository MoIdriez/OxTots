using System.Collections.Generic;

namespace OxTots.ViewModel
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string GoToResource { get; set; }
        public string ResultsFound { get; set; }
        public string FilterDescription { get; set; }
        public List<MarkerViewModel> Markers { get; set; }
        public List<FeatureViewModel> Features { get; set; }
        public List<ResourceFilterViewModel> Resources { get; set; }
    }
}