namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Contains session lifecycle information
    /// </summary>
    public class SessionLifecycle
    {
        /// <summary>
        /// Current state of the session
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Indicates if the current state is final
        /// </summary>
        public bool StateIsFinal { get; set; }
    }
}
