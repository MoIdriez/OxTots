using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.ViewModel
{
    public class MarkerViewModel
    {
        public double Long { get; set; }
        public double Lat { get; set; }
        public string Icon { get; set; }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}