using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.ViewModel
{
    public class MapViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<MarkerViewModel> Markers { get; set; }
    }
}