namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Session state values
    /// </summary>
    public static class SessionStateValues
    {
        /// <summary>
        /// Session is blocked
        /// </summary>
        public const string Blocked = "BLOCKED";

        /// <summary>
        /// Session is ready for signing
        /// </summary>
        public const string Ready = "READY";

        /// <summary>
        /// Session has been signed
        /// </summary>
        public const string Signed = "SIGNED";

        /// <summary>
        /// Session has been rejected
        /// </summary>
        public const string Rejected = "REJECTED";
    }
}
