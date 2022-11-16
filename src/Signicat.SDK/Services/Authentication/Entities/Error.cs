namespace Signicat.Authentication
{
    /// <summary>
    /// Error details.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// An error message providing details about the error.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The error code reported.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The error code reported from the eID provider that was used.
        /// </summary>
        public string ProviderCode { get; set; }
    }
}
