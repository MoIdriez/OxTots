using System.Collections.Generic;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class AdminResourceViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double GPSLong { get; set; }
        public double GPSLat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public string Image { get; set; }
        public string Icon { get; set; }

        
        
        public List<Resource> Resources { get; set; }
        public int MainCategoryID { get; set; }
        public List<Category> Categories { get; set; }
        public int FeatureID { get; set; }
        public bool FeatureEnabled { get; set; }
        public List<Feature> Features { get; set; }
    }
}