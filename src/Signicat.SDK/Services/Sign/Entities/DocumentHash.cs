namespace Signicat.Sign.Entities
{
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

    public enum HashAlgorithmEnum
    {
        SHA256
    }
} 