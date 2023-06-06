namespace Signicat.DigitalEvidenceManagement.Entities
{
    public record DemLinks
    {
        public string Href { get; set; }
        public string Hreflang { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Deprecation { get; set; }
        public string Profile { get; set; }
        public string Name { get; set; }
        public bool Templated { get; set; }
    }
}