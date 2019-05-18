using System.Collections.Generic;

namespace OxTots.Models
{
    public class Feature
    {
        public Feature()
        {
            FeatureDetails = new HashSet<FeatureDetail>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FeatureDetail> FeatureDetails { get; set; }
    }
}