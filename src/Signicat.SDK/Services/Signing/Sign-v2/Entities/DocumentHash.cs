using Signicat.Constants;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Represents a document's hash information
    /// </summary>
    public class DocumentHash
    {
        /// <summary>
        /// The hash value
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// The hash algorithm used
        /// </summary>
        public HashAlgorithmEnum HashAlgorithm { get; set; }
    }
}