namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// Redirect settings
    /// </summary>
    public class RedirectSettings
    {
        /// <summary>
        /// URL to redirect to on error
        /// </summary>
        public string Error { get; set; }
        
        /// <summary>
        /// URL to redirect to on cancel
        /// </summary>
        public string Cancel { get; set; }
        
        /// <summary>
        /// URL to redirect to on success
        /// </summary>
        public string Success { get; set; }
    }
}