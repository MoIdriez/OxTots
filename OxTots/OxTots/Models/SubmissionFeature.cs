using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OxTots.Models
{
    public class SubmissionFeature
    {
        public int ID { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual Submission Submission { get; set; }

        public bool Enabled { get; set; }
    }
}