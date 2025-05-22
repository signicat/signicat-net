using System;

namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// Represents a signature in a session
    /// </summary>
    public class SessionSignature
    {
        /// <summary>
        /// ID of the document collection
        /// </summary>
        public string DocumentCollectionId { get; set; }
        
        /// <summary>
        /// ID of the result document
        /// </summary>
        public string ResultDocumentId { get; set; }
        
        /// <summary>
        /// ID of the original document
        /// </summary>
        public string OriginalDocumentId { get; set; }
        
        /// <summary>
        /// Type of the signature
        /// </summary>
        public string SignatureType { get; set; }
    }
    
    /// <summary>
    /// Artifact type for signatures
    /// </summary>
    public static class ArtifactTypeValues
    {
        /// <summary>
        /// XAdES signature format
        /// </summary>
        public const string XAdES = "XAdES";
    }
}