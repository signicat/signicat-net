namespace Signicat.Authentication
{
    public class SessionEnvironment
    {
        /// <summary>
        /// The IP address of the end user.
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        ///     The request user agent.
        /// </summary>
        public string UserAgent { get; set; }
    }
}