namespace Signicat.Constants
{
    public class AuthenticationStatuses
    {
        /// <summary>
        ///     The authentication process was successfull
        /// </summary>
        public const string Success = "SUCCESS";

        /// <summary>
        ///     An error occured during the authentication process
        /// </summary>
        public const string Error = "ERROR";

        /// <summary>
        ///     User aborted the authentication process
        /// </summary>
        public const string Aborted = "ABORTED";
        
        
        /// <summary>
        ///     Authentication process is cancelled
        /// </summary>
        public const string Cancelled = "CANCELLED";
        
        /// <summary>
        ///     Authentication process is waiting for the user to response (example: to a auth request on the mobile)
        /// </summary>
        public const string WaitingForUser = "WAITING_FOR_USER";
    }
}