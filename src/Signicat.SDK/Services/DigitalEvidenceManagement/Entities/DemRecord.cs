using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public class DemRecord
    {
        /// <summary>
        ///     The Id of the record in UUID format
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     You are required to supply a record type in the 'type' parameter when posting a new record.
        ///     One of: <c>GDPR</c>, <c>TRANSACTION</c>, <c>LOG_IN</c>, <c>SIGNATURE</c> or <c>OTHER</c>.
        /// </summary>
        [JsonPropertyName("type")]
        public RecordTypes? RecordType
        {
            get
            {
                var recordType = RecordTypes.OTHER;
                if (SystemMetadata is not null && SystemMetadata.ContainsKey("type") &&
                    Enum.TryParse(SystemMetadata["type"].ToString(), out recordType))
                {
                    return recordType;
                }

                return null;
            }
        }
        
        /// <summary>
        ///     Can contain any amount of data which will then be searchable in future queries.
        /// </summary>
        public Dictionary<string, object> SystemMetadata { get; set; } = new();

        /// <summary>
        ///     Can contain any amount of data which will then be searchable in future queries.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; } = new();

        /// <summary>
        ///     Can contain any amount of data which will then be timestamped.
        /// </summary>
        public Dictionary<string, object> CoreData { get; set; } = new();

        /// <summary>
        ///     Time stamp
        /// </summary>
        public DemTimestampData TimestampData { get; set; }

        /// <summary>
        ///     Optional field. List of the IDs (String) of the related records. Default: Empty list
        /// </summary>
        public IEnumerable<DemRecordRelations> Relations { get; set; } = new List<DemRecordRelations>();

        /// <summary>
        ///     Optional field.
        ///     Decides which level of timestamping and verification will be applied to the record. The different levels have
        ///     different pricing.
        ///     One of: <c>SIMPLE</c>, <c>ADVANCED</c> or <c>QUALIFIED</c>. Default is <c>QUALIFIED</c>.
        /// </summary>
        public AuditLevels? AuditLevels
        {
            get
            {
                var auditLevel = Entities.AuditLevels.SIMPLE;
                if (SystemMetadata is not null && SystemMetadata.ContainsKey("auditLevel") &&
                    Enum.TryParse(SystemMetadata["auditLevel"].ToString(), out auditLevel))
                {
                    return auditLevel;
                }

                return null;
            }
        }
        
        public Dictionary<string,DemLinks> Links { get; set; }
    }

    public record DemTimestampData
    {
        public string Timestamp { get; set; }
    }
}