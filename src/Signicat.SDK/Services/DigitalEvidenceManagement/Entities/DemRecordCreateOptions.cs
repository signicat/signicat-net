using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecordCreateOptions
    {
        /// <summary>
        /// You are required to supply a record type in the 'type' parameter when posting a new record.
        /// One of: <c>GDPR</c>, <c>TRANSACTION</c>, <c>LOG_IN</c>, <c>SIGNATURE</c> or <c>OTHER</c>.
        /// </summary>
        [JsonPropertyName("type")]
        public RecordTypes? RecordType { get; set; }

        /// <summary>
        /// Can contain any amount of data which will then be searchable in future queries.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Can contain any amount of data which will then be timestamped.
        /// </summary>
        public Dictionary<string, object> CoreData { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Time to Live as denoted in amount of days. Required to set
        /// </summary>
        [JsonPropertyName("ttl")]
        public int TimeToLiveInDays { get; set; }

        /// <summary>
        /// Optional field. List of the IDs (String) of the related records. Default: Empty list
        /// </summary>
        public IEnumerable<string> Relations { get; set; } = new List<string>();

        /// <summary>
        /// Optional field.
        /// Decides which level of timestamping and verification will be applied to the record. The different levels have different pricing.
        /// One of: <c>SIMPLE</c>, <c>ADVANCED</c> or <c>QUALIFIED</c>. Default is <c>QUALIFIED</c>.
        /// </summary>
        public AuditLevels AuditLevels { get; set; } = AuditLevels.QUALIFIED;

    }
}