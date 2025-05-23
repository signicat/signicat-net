namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Contains session package metadata
    /// </summary>
    public class SessionPackage
    {
        /// <summary>
        /// ID of the package
        /// </summary>
        public string PackageId { get; set; }
        
        /// <summary>
        /// ID of the result document
        /// </summary>
        public string ResultDocumentId { get; set; }
        
        /// <summary>
        /// Type of the package
        /// </summary>
        public string PackageType { get; set; }
    }
    
    /// <summary>
    /// Package types
    /// </summary>
    public enum PackageType
    {
        /// <summary>
        /// PAdES container package format
        /// </summary>
        pades_container
    }
}