﻿using System;
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

        public string Title { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}