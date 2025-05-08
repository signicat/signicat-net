using System.Collections.Generic;

namespace Signicat.Sign.Entities
{
    public class DocumentCollection
    {
        /// <summary>
        /// The document collection's unique identifier
        /// </summary>
        public string DocumentCollectionId { get; set; }

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
        public List<DocumentCollectionDocument> Documents { get; set; }

        /// <summary>
        /// Additional metadata for the document collection
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
    }

    public class DocumentCollectionDocument
    {
        /// <summary>
        /// The document's unique identifier
        /// </summary>
        public string DocumentId { get; set; }
    }
} 