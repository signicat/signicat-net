using System.Collections.Generic;

namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// Options for creating a document collection
    /// </summary>
    public class CreateDocumentCollectionOptions
    {
        /// <summary>
        /// List of document references to include in the collection
        /// </summary>
        public List<DocumentReference> Documents { get; set; } = new List<DocumentReference>();
    }
}