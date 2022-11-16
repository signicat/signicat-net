namespace Signicat.Authentication
{
    /// <summary>
    /// Redirect settings when using the `redirect` flow.
    /// </summary>
    public class CallbackUrls
    {
        /// <summary>
        /// The URL that the user is redirected to after a successful identification.
        /// </summary>
        public string SuccessUrl { get; set; }

        /// <summary>
        /// The URL that the user is redirected to if the session is aborted by the user.
        /// </summary>
        public string AbortUrl { get; set; }

        /// <summary>
        /// The URL that the user is redirected to if something goes wrong.
        /// </summary>
        public string ErrorUrl { get; set; }
    }
}
