using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordsSearchResult
    {
        [JsonPropertyName("_embedded")] public DemRecordSearchEmbedded Embedded { get; set; }

        [JsonPropertyName("_links")] public DemRecordSearchLinks Links { get; set; }

        [JsonPropertyName("page")] public DemRecordSearchPage Page { get; set; }
    }
}