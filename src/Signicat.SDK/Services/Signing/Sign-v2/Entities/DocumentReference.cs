namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// A reference to a document
    /// </summary>
    public class DocumentReference
    {
        /// <summary>
        /// The document's unique identifier
        /// </summary>
        public string DocumentId { get; set; }
        
        /// <summary>
        /// A description of the document for display purposes
        /// </summary>
        public string Description { get; set; }
    }
}