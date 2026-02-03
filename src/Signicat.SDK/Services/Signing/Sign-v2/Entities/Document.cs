using System;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Represents a document in the Signicat sign service
    /// </summary>
    public class Document
    {
        /// <summary>
        /// The document's unique identifier
        /// </summary>
        /// <example>d1234567-89ab-cdef-0123-456789abcdef</example>
        public string DocumentId { get; set; }

        /// <summary>
        /// The document's MIME type
        /// </summary>
        /// <example>application/pdf</example>
        public string MimeType { get; set; }

        /// <summary>
        /// When the document was created
        /// </summary>
        /// <example>2023-04-12T10:30:00Z</example>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The document's hash information
        /// </summary>
        public DocumentHash DocumentHash { get; set; }

        /// <summary>
        /// A name to use if the document is to be stored as a file.
        /// Optional metadata about the stored document which the customer can supply.
        /// </summary>
        /// <example>invoice_001.pdf</example>
        public string Filename { get; set; }

        /// <summary>
        /// A description of the document for display purposes.
        /// Optional metadata about the stored document which the customer can supply.
        /// </summary>
        /// <example>Invoice for order #001</example>
        public string Description { get; set; }

        /// <summary>
        /// A title of the document for display purposes.
        /// Optional metadata about the stored document which the customer can supply.
        /// </summary>
        /// <example>Invoice #001</example>
        public string Title { get; set; }
    }
}