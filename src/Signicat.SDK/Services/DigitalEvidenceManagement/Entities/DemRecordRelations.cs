using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public record DemRecordRelations
    {
        public string RelationId { get; set; }

        public RecordTypes Type { get; set; }

        [JsonPropertyName("_links")] public Dictionary<string, DemLinks> Links { get; set; }
    }
}