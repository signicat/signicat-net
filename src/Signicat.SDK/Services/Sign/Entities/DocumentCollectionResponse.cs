using System;
using System.Collections.Generic;

namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// Response when getting document collection details
    /// </summary>
    public class DocumentCollectionResponse
    {
        /// <summary>
        /// The collection's unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// List of documents in the collection
        /// </summary>
        public List<Document> Documents { get; set; }

        /// <summary>
        /// Optional external ID for client reference
        /// </summary>
        public string ExternalId { get; set; }
    }
}