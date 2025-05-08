using System;
using System.Text.Json.Serialization;

namespace Signicat.Sign.Entities
{
    public class ArchivedDocument
    {
        /// <summary>
        /// The original document's unique identifier
        /// </summary>
        [JsonPropertyName("documentId")]
        public string DocumentId { get; set; }

        /// <summary>
        /// The archive document's unique identifier
        /// </summary>
        [JsonPropertyName("archiveId")]
        public string ArchiveId { get; set; }

        /// <summary>
        /// The timestamp when the document was archived
        /// </summary>
        [JsonPropertyName("archivedAt")]
        public DateTime ArchivedAt { get; set; }

        /// <summary>
        /// The archive format
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; }

        /// <summary>
        /// Additional archive metadata
        /// </summary>
        [JsonPropertyName("metadata")]
        public object Metadata { get; set; }
    }
} 