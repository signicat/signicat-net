using System;
using System.Collections.Generic;

namespace Signicat.Authentication
{
    public class AuthenticationSession
    {
        /// <summary>
        ///     The session's unique identifier.
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        ///     The specified account ID used for the session.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        ///     The URL which you should direct your end-user to for performing the authentication.
        /// </summary>
        public string AuthenticationUrl { get; set; }
        
        /// <summary>
        /// The URL that allows to check the authentication status.
        /// </summary>
        public string StatusUrl { get; set; }
        
        /// <summary>
        ///     The status of the identification session.
        ///     One of: <c>SUCCESS</c>,<c>ABORTED</c> or <c>ERROR</c>.
        ///     <see cref="Constants.AuthenticationStatuses" />
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// The status detail if the response is an error.
        /// </summary>
        public string StatusDetail { get; set; }
        
        /// <summary>
        ///     The eID provider used for identification.
        ///     One of: <see cref="Constants.AllowedProviderTypes" />
        /// </summary>
        public string Provider { get; set; }
        
        /// <summary>
        ///     The session's subject.
        /// </summary>
        public Subject Subject { get; set; }
        
        /// <summary>
        ///     Specifies the different urls to callback to.
        /// </summary>
        public CallbackUrls CallbackUrls { get; set; }
        
        /// <summary>
        ///     The idp data.
        /// </summary>
        public Dictionary<string, string> IdpData { get; set; }
        
        /// <summary>
        ///     Details about the subject's environment.
        /// </summary>
        public SessionEnvironment Environment { get; set; }
        
        /// <summary>
        ///     Error details.
        /// </summary>
        public ErrorDetails Error { get; set; }
        
        /// <summary>
        ///     Message transport properties.
        /// </summary>
        public MessageTransportProperties MessageTransportProperties { get; set; }
        
        /// <summary>
        /// A set of support optional tags to group and filter webhooks.
        /// </summary>
        public IList<string> Tags { get; set; }

        /// <summary>
        ///     A list of eID providers that can be used for identification. If not specified, the user will be able to chose from
        ///     all eIDs associated with your Signicat account.
        ///     <see cref="Constants.AllowedProviderTypes" />
        /// </summary>
        public IList<string> AllowedProviders { get; set; }

        /// <summary>
        ///     The language to use for the identification process. Defaults to `en` (english).
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     The selected flow used for this specific authentication session.
        /// </summary>
        public AuthenticationFlow? Flow { get; set; }

        /// <summary>
        ///     The themeId you want to use for this specific authentication session. If not specified, the default theme for your account will be used.
        /// </summary>
        public string ThemeId { get; set; }
        
        /// <summary>
        ///     Request additional information about the user.
        ///     One of: <c>firstname</c>, <c>lastname</c>, <c>dateofbirth</c> or <c>nin</c>.
        ///     <see cref="Constants.RequestedAttributes" />
        /// </summary>
        public IList<string> RequestedAttributes { get; set; }

        /// <summary>
        ///     An external reference for you, will be returned as a URL parameter on callbackUrls.
        /// </summary>
        public string ExternalReference { get; set; }
        
        /// <summary>
        ///     An usage external reference for you to group your billing.
        /// </summary>
        public string UsageReference { get; set; }
        
        /// <summary>
        ///     Lifetime of session in seconds.
        /// </summary>
        public int SessionLifetime { get; set; }
        
        /// <summary>
        ///     Specifies the domain you want to use for this specific session. The domain will be visible in the end-user's browser. This domain needs to be correctly configured on your account.
        /// </summary>
        public string RequestDomain { get; set; }

        /// <summary>
        /// DateTime expiry of session.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }
    }
}