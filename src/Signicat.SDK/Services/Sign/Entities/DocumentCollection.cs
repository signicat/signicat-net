using System;
using System.Collections.Generic;

namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// A collection of documents to be signed together
    /// </summary>
    public class DocumentCollection
    {
        /// <summary>
        /// The collection's unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// References to the documents in this collection
        /// </summary>
        public List<DocumentReference> Documents { get; set; } = new List<DocumentReference>();
    }
}