namespace OxTots.Models
{
    public class ResourceFeature
    {
        public int ID { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual Feature Feature { get; set; }

        public bool Enabled { get; set; }
    }
}