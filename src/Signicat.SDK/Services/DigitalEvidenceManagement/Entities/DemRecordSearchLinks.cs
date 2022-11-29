using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordSearchLinks
    {
        [JsonPropertyName("self")] public DemRecordSearchSelf Self { get; set; }
    }
}