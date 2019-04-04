using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OxTots.Models;

namespace OxTots.ViewModel
{
    public class AdminFeatureViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public int CategoryID { get; set; }
        public List<Feature> Features { get; set; } 
    }
}