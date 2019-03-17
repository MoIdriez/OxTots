using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.Models
{
    public class Resource
    {
        public Resource()
        {
            ResourceDetails = new HashSet<ResourceDetail>();
            ResourceFeatures = new HashSet<ResourceFeature>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public double GPSLong { get; set; }
        public double GPSLat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public byte[] Image { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ResourceDetail> ResourceDetails { get; set; }
        public virtual ICollection<ResourceFeature> ResourceFeatures { get; set; }
    }
}