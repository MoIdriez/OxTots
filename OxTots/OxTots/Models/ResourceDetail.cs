using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.Models
{
    public class ResourceDetail
    {
        public int ID { get; set; }
        public virtual Language Language { get; set; }
        public virtual Resource Resource { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public byte[] Image { get; set; }

        public string Address { get; set; }
        public double GPSLong { get; set; }
        public double GPSLat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string OpeningHours { get; set; }
    }
}