using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordSearchEmbedded
    {
        [JsonPropertyName("records")] public DemRecordLite[] Records { get; set; }
    }
}