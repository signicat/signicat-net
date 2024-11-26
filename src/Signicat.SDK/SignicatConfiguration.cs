using System.Net.Http;
using System.Reflection;
using Signicat.Infrastructure;

namespace Signicat
{
    public static class SignicatConfiguration
    {
        private static string _baseUrl;
        private static string _oauthBaseUrl;


        /// <summary>
        ///     Lets you provide your own <see cref="HttpClient" />.
        /// </summary>
        public static HttpClient HttpClient { get; set; }

        /// <summary>
        ///     Gets or sets the Signicat API base URL.
        /// </summary>
        public static string BaseUrl
        {
            get => string.IsNullOrWhiteSpace(_baseUrl) ? Urls.DefaultBaseUrl : _baseUrl;
            set => _baseUrl = value;
        }

        /// <summary>
        ///     Gets or sets the Signicat OAuth base URL.
        /// </summary>
        public static string OAuthBaseUrl
        {
            get => string.IsNullOrWhiteSpace(_oauthBaseUrl) ? Urls.DefaultOAuthBaseUrl : _oauthBaseUrl;
            set => _oauthBaseUrl = value;
        }

        /// <summary>
        ///     Gets the version of the Signicat .NET SDK.
        /// </summary>
        public static string SdkVersion
        {
            get
            {
                var assembly = typeof(SignicatConfiguration).GetTypeInfo().Assembly;
                return assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            }
        }

       
        /// <summary>
        ///     Sets the OAuth client credentials and scopes.
        /// </summary>
        /// <param name="clientId">Client ID.</param>
        /// <param name="clientSecret">Client secret.</param>
        public static void SetClientCredentials(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
        
        internal static OAuthToken OAuthToken { get; set; }
        internal static string ClientId { get; set; }

        internal static string ClientSecret { get; set; }
        
        internal static string OrganisationId { get; set; }
        
        internal static string AcccountId { get; set; }
    }
}