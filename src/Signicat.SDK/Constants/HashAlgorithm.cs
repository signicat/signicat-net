using System.Text.Json.Serialization;

namespace Signicat.Constants
{
    /// <summary>
    /// Supported hash algorithms for document hashing
    /// </summary>
    public enum HashAlgorithmEnum
    {
        /// <summary>
        /// SHA-256 hashing algorithm
        /// </summary>
        [JsonStringEnumMemberName("SHA-256")]
        SHA256
    }
}