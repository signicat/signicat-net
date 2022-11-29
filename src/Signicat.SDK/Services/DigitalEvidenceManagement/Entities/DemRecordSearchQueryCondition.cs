using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordSearchQueryCondition
    {
        /// <summary>
        /// Field to search
        /// </summary>
        [JsonPropertyName("field")]
        public string Field { get; set; }

        /// <summary>
        /// Operator to use
        /// </summary>
        [JsonPropertyName("operator")]
        public DemRecordSearchQueryOperator Operator { get; set; }

        /// <summary>
        /// The value to compare with
        /// </summary>
        [JsonPropertyName("value")]
        public object Value { get; set; }
    }
}