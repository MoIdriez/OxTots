﻿using System;
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
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<CategoryDetail> CategoryDetails { get; set; }
        
    }
}