namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// Request to update document metadata
    /// </summary>
    public class UpdateDocumentMetadataRequest
    {
        /// <summary>
        /// A name to use if the document is to be stored as a file
        /// </summary>
        public string Filename { get; set; }
        
        /// <summary>
        /// A description of the document for display purposes
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// A title of the document for display purposes
        /// </summary>
        public string Title { get; set; }
    }
}