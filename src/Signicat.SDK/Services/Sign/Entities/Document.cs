using System;
using System.Collections.Generic;

namespace Signicat.Sign.Entities
{
    public class Document
    {
        /// <summary>
        /// The document's unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The document's title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The document's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The document's file name
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The document's file size in bytes
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// The document's MIME type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The document's creation date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The document's last modified date
        /// </summary>
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// The document's hash
        /// </summary>
        public DocumentHash Hash { get; set; }

        /// <summary>
        /// Additional metadata for the document
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
    }
} 