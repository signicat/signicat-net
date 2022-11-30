using System.Collections.Generic;

namespace Signicat.Authentication
{
    public record AuthenticationCreateOptions
    {
        /// <summary>
        /// A list of eID providers that can be used for identification. If not specified, the user will be able to chose from all eIDs associated with your Signicat account.
        /// <see cref="Constants.AllowedProviderTypes"/>
        /// </summary>
        public IList<string> AllowedProviders { get; set; }

        /// <summary>
        /// The language to use for the identification process. Defaults to `en`
        /// <see cref="Constants.Languages"/>
        /// </summary>
        public string Language { get; set; } = "en";

        /// <summary>
        /// The type of flow to use.
        /// One of: <c>redirect</c>, or <c>headless</c>.
        /// </summary>
        public AuthenticationFlow? Flow { get; set; } = AuthenticationFlow.Redirect;

        /// <summary>
        /// Request additional information about the user.
        /// One of: <c>firstname</c>, <c>lastname</c>, <c>dateofbirth</c> or <c>nin</c>.
        /// <see cref="Constants.RequestedAttributes"/>
        /// </summary>
        public IList<string> RequestedAttributes { get; set; } = new List<string>();

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
        /// (optional) Id for the Theme  only needed if you have multiple themes setup on the same account.
        /// </summary>
        public string ThemeId { get; set; }

        
    }
}
