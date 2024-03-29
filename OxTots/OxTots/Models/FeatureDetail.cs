﻿namespace OxTots.Models
{
    public class FeatureDetail
    {
        public int ID { get; set; }
        public virtual Language Language { get; set; }
        public virtual Feature Feature { get; set; }

        public string Title { get; set; }
    }
}