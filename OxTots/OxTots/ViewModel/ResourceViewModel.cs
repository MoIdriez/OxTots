using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.ViewModel
{
    public class ResourceViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string OpeningHours { get; set; }
        
        public List<MarkerViewModel> Markers { get; set; }
        public List<FeatureViewModel> Features { get; set; }
    }
}