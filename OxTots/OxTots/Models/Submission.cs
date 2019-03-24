using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.Models
{
    public class Submission
    {
        public int ID { get; set; }
        public virtual Language Language { get; set; }
        public virtual Category Category { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string ResourceName { get; set; }
        public string ResourceAddress { get; set; }
        public string ResourceDescription { get; set; }
        public string ResourcePhone { get; set; }
        public string ResourceEmail { get; set; }
        public string ResourceWebsite { get; set; }
    }
}