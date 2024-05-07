using System.Threading.Tasks;

namespace Signicat.Authentication
{
    public interface IAuthenticationService
    {
        /// <summary>
        ///     Retrieves the details of a single identification session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AuthenticationSession GetSession(string id);

        /// <summary>
        ///     Retrieves the details of a single identification session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AuthenticationSession> GetSessionAsync(string id);

        /// <summary>
        ///     Creates a new identification session.
        /// </summary>
        /// <param name="authenticationCreateOptions"></param>
        /// <returns></returns>
        AuthenticationSession CreateSession(AuthenticationCreateOptions authenticationCreateOptions);

        /// <summary>
        ///     Creates a new identification session.
        /// </summary>
        /// <param name="authenticationCreateOptions"></param>
        /// <returns></returns>
        Task<AuthenticationSession> CreateSessionAsync(AuthenticationCreateOptions authenticationCreateOptions);
        
        /// <summary>
        ///     Cancels an identification session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AuthenticationSession CancelFlow(string id);

        /// <summary>
        ///     Cancels an identification session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AuthenticationSession> CancelFlowAsync(string id);
    }
}