using System;
using System.Collections.Generic;
using Signicat.Constants;

namespace Signicat.Authentication
{
    public class AuthenticationSession
    {
        /// <summary>
        /// The session's unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The URL to start the identification process. Only applicable to the `iframe` and `redirect` flows.
        /// </summary>
        public string AuthenticationUrl { get; set; }
        
        /// <summary>
        /// A list of eID providers that can be used for identification. If not specified, the user will be able to chose from all eIDs associated with your Signicat account.
        /// <see cref="Constants.AllowedProviderTypes"/>
        /// </summary>
        public IList<string> AllowedProviders { get; set; }
        
        /// <summary>
        /// Id for the Theme.
        /// </summary>
        public string ThemeId { get; set; }
        
        /// <summary>
        /// Signicat AccountId
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// The language to use for the identification process. Defaults to `en` (english).
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The type of flow to use.
        /// </summary>
        public AuthenticationFlow? Flow { get; set; }

        /// <summary>
        /// Request additional information about the user.
        /// </summary>
        public IList<string> RequestedAttributes { get; set; }

        /// <summary>
        /// Lifetime of session in seconds.
        /// </summary>
        public int SessionLifetime	 { get; set; }    

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
        /// The status of the identification session.
        /// One of: <c>SUCCESS</c>,<c>ABORTED</c> or <c>ERROR</c>.
        /// <see cref="Constants.AuthenticationStatuses"/>
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The eID provider used for identification.
        /// One of: <see cref="Constants.AllowedProviderTypes"/>
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Details about the identified user. Only available if session has status `success`.
        /// </summary>
        public Subject Subject { get; set; }
        
        /// <summary>
        /// Error details.
        /// </summary>
        public Error Error { get; set; }
    }
}
