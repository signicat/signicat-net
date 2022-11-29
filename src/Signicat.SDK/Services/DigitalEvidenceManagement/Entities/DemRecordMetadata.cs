using System.Collections.Generic;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    /// <summary>
    /// Can contain any amount of data which will then be searchable in future queries.
    /// </summary>
    public class DemRecordMetadata
    {
        /// <summary>
        /// Custom meta data, the ones provided by the customer when creating the record
        /// </summary>
        public Dictionary<string, object> Custom { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// System metadata added by Signicat during creation of the record.
        /// </summary>
        public Dictionary<string, object> System { get; set; } = new Dictionary<string, object>();
    }
}