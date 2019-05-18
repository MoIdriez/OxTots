namespace OxTots.Models
{
    public class Submission
    {
        public int ID { get; set; }
        public virtual Language Language { get; set; }
        public virtual Resource Resource { get; set; }

        public string Type { get; set; }
        public string PersonalName { get; set; }
        public string PersonalEmail { get; set; }
        public string ResourceName { get; set; }
        public string ResourceAddress { get; set; }
        public string ResourceDescription { get; set; }
        public string ResourceEmail { get; set; }
        public string ResourceWebsite { get; set; }
    }
}