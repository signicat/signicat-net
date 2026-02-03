namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Redirect settings
    /// </summary>
    public class RedirectSettings
    {
        /// <summary>
        /// URL to redirect to on error
        /// </summary>
        /// <example>http://example.com/error</example>
        public string Error { get; set; }

        /// <summary>
        /// URL to redirect to on cancel
        /// </summary>
        /// <example>http://example.com/cancel</example>
        public string Cancel { get; set; }

        /// <summary>
        /// URL to redirect to on success
        /// </summary>
        /// <example>http://example.com/complete</example>
        public string Success { get; set; }
    }
}