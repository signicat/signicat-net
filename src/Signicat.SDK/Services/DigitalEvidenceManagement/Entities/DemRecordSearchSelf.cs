using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordSearchSelf
    {
        [JsonPropertyName("href")] public string Href { get; set; }
    }
}