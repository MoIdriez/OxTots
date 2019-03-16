using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.Models
{
    public class CategoryDetail
    {
        public int ID { get; set; }
        public virtual Language Language { get; set; }
        public virtual Category Category { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public byte[] Image { get; set; }
    }
}