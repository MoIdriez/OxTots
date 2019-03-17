using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OxTots.Models
{
    public class Category
    {
        public Category()
        {
            CategoryDetails = new HashSet<CategoryDetail>();
            Resources = new HashSet<Resource>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<CategoryDetail> CategoryDetails { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}