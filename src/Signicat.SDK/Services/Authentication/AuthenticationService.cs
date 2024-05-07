using System.Threading.Tasks;
using Signicat.Infrastructure;

namespace Signicat.Authentication
{
    public class AuthenticationService : SignicatBaseService, IAuthenticationService
    {
        public AuthenticationService()
        {
        }

        public AuthenticationService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
        }

        /// <summary>
        ///     Retrieves the details of a single identification session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuthenticationSession GetSession(string id)
        {
            return Get<AuthenticationSession>($"{Urls.Authentication}/sessions/{id}");
        }

        /// <summary>
        ///     Retrieves the details of a single identification session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AuthenticationSession> GetSessionAsync(string id)
        {
            return GetAsync<AuthenticationSession>($"{Urls.Authentication}/sessions/{id}");
        }

        /// <summary>
        ///     Creates a new identification session.
        /// </summary>
        /// <param name="authenticationCreateOptions"></param>
        /// <returns></returns>
        public AuthenticationSession CreateSession(AuthenticationCreateOptions authenticationCreateOptions)
        {
            return Post<AuthenticationSession>($"{Urls.Authentication}/sessions", authenticationCreateOptions);
        }

        /// <summary>
        ///     Creates a new identification session.
        /// </summary>
        /// <param name="authenticationCreateOptions"></param>
        /// <returns></returns>
        public Task<AuthenticationSession> CreateSessionAsync(AuthenticationCreateOptions authenticationCreateOptions)
        {
            return PostAsync<AuthenticationSession>($"{Urls.Authentication}/sessions", authenticationCreateOptions);
        }

        /// <summary>
        ///     Cancels an identification session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AuthenticationSession CancelSession(string id)
        {
            return Post<AuthenticationSession>($"{Urls.Authentication}/sessions/{id}/cancel");
        }

        /// <summary>
        ///     Cancels an identification session.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AuthenticationSession> CancelSessionAsync(string id)
        {
            return PostAsync<AuthenticationSession>($"{Urls.Authentication}/sessions/{id}/cancel");
        }
    }
}