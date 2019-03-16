using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.Models
{
    public class Feature
    {
        public int ID { get; set; }
        public virtual Category Category { get; set; }

        public string Name { get; set; }
    }
}