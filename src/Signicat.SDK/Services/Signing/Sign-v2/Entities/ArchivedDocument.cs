using System;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Represents an archived document
    /// </summary>
    public class ArchivedDocument
    {
        /// <summary>
        /// The document's unique identifier
        /// </summary>
        public string DocumentId { get; set; }

        /// <summary>
        /// The document's MIME type
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// The document's filename
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The document's size in bytes
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// When the document was archived
        /// </summary>
        public DateTime ArchivedAt { get; set; }

        /// <summary>
        /// The document's hash information
        /// </summary>
        public DocumentHash DocumentHash { get; set; }
    }
}