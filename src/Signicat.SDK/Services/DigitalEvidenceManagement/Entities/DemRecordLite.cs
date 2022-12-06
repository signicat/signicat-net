using System;
using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordLite
    {
        [JsonPropertyName("id")] public Guid Id { get; set; }

        [JsonPropertyName("metadata")] public DemRecordMetadata Metadata { get; set; }

        [JsonPropertyName("relations")] public object[] Relations { get; set; }

        [JsonPropertyName("_links")] public DemRecordSearchLinks DemRecordSearchLinks { get; set; }
    }
}