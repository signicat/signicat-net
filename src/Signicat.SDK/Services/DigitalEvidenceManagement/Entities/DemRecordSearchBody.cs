using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordSearchBody
    {
        /// <summary>
        ///     Combines the QueryConditions with the logical AND operator. All of the QueryConditions need to return true.
        /// </summary>
        [JsonPropertyName("and")]
        public IEnumerable<DemRecordSearchQueryCondition> And { get; set; } = new List<DemRecordSearchQueryCondition>();

        /// <summary>
        ///     Combines the QueryConditions with the logical OR operator. Only one of the QueryConditions needs to return true.
        /// </summary>
        [JsonPropertyName("or")]
        public IEnumerable<DemRecordSearchQueryCondition> Or { get; set; } = new List<DemRecordSearchQueryCondition>();

        /// <summary>
        ///     Not implemented yet
        /// </summary>
        [JsonPropertyName("not")]
        public IEnumerable<DemRecordSearchQueryCondition> Not { get; set; }
    }
}