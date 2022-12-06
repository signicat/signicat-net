using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemInfoRecordStatistics
    {
        [JsonPropertyName("collectionSize")] public string CollectionSize { get; set; }

        [JsonPropertyName("avgRecordSize")] public string AverageRecordSize { get; set; }

        [JsonPropertyName("totalRecords")] public long TotalRecords { get; set; }

        [JsonPropertyName("totalRecordsByType")]
        public Dictionary<string, object> TotalRecordsByType { get; set; }
    }
}