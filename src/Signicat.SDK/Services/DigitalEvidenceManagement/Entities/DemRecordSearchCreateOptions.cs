using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordSearchCreateOptions
    {
        [JsonPropertyName("pageable")]
        public DemRecordSearchPageable Pageable { get; set; }
        
        [JsonPropertyName("body")]
        public DemRecordSearchBody Body { get; set; }
    }
}