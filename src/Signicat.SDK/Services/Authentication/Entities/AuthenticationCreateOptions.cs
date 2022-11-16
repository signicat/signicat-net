using System.Collections.Generic;

namespace Signicat.Authentication
{
    public record AuthenticationCreateOptions
    {
        /// <summary>
        /// A list of eID providers that can be used for identification. If not specified, the user will be able to chose from all eIDs associated with your Signicat account.
        /// </summary>
        public IList<AllowedProviderTypes> AllowedProviders { get; set; }

        /// <summary>
        /// The language to use for the identification process. Defaults to `en` (english).
        /// </summary>
        public Language? Language { get; set; }

        /// <summary>
        /// The type of flow to use.
        /// </summary>
        public AuthenticationFlow? Flow { get; set; }
        
        /// <summary>
        /// Request additional information about the user.
        /// </summary>
        public IList<string> RequestedAttributes { get; set; }

        /// <summary>
        /// Redirect settings when using the `redirect` flow.
        /// </summary>
        public CallbackUrls CallbackUrls { get; set; }

        /// <summary>
        /// Your external reference for the session.
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// Prefilled input values.
        /// </summary>
        public PrefilledInput PrefilledInput { get; set; }
        
        /// <summary>
        /// Lifetime of session in seconds.
        /// </summary>
        public int SessionLifetime	 { get; set; }

        /// <summary>
        /// Id for the Theme.
        /// </summary>
        public string ThemeId { get; set; }
    }
}
