using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordSearchPageable
    {
        /// <summary>
        /// Page number
        /// </summary>
        [JsonPropertyName("page")]
        public long Page { get; set; }

        /// <summary>
        /// Max number of elements minimum 1
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; set; }

        /// <summary>
        /// Sort
        /// <example>metadata.system.createdDateTime,desc</example>
        /// </summary>
        [JsonPropertyName("sort")]
        public string[] Sort { get; set; }
    }
}