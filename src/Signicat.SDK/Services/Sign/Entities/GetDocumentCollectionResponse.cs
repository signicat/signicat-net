using System;
using System.Collections.Generic;

namespace Signicat.Sign.Entities
{
    public class GetDocumentCollectionResponse
    {
        /// <summary>
        /// The document collection's unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The document collection's title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The document collection's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The documents in the collection
        /// </summary>
        public List<Document> Documents { get; set; }

        /// <summary>
        /// Additional metadata for the document collection
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// The document collection's creation date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The document collection's last modified date
        /// </summary>
        public DateTime ModifiedAt { get; set; }
    }
} 