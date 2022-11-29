using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordSearchPage
    {
        [JsonPropertyName("size")] public long Size { get; set; }

        [JsonPropertyName("totalElements")] public long TotalElements { get; set; }

        [JsonPropertyName("totalPages")] public long TotalPages { get; set; }

        [JsonPropertyName("number")] public long Number { get; set; }
    }
}