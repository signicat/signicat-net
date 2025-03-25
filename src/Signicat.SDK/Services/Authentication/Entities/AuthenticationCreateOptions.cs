using System;
using System.Collections.Generic;

namespace Signicat.Authentication
{
    public record AuthenticationCreateOptions
    {
        /// <summary>
        ///     Prefilled input values.
        /// </summary>
        public PrefilledInput PrefilledInput { get; set; }

        /// <summary>
        ///     Additional parameters that modify the authentication flow. Depends on selected IdP
        /// </summary>
        public Dictionary<string, string> AdditionalParameters { get; set; }

        /// <summary>
        ///     Specifies the different urls to callback to.
        /// </summary>
        public CallbackUrls CallbackUrls { get; set; }

        /// <summary>
        ///     Encryption key information for message level encryption.
        /// </summary>
        public EncryptionPublicKey EncryptionPublicKey { get; set; }

        /// <summary>
        ///     Specifies the LoA (Level of Assurance).
        /// </summary>
        public string RequestedLoa { get; set; }

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
        ///     The language to use for the identification process. Defaults to `en`
        ///     <see cref="Constants.Languages" />
        /// </summary>
        public string Language { get; set; } = "en";

        /// <summary>
        ///     The selected flow used for this specific authentication session.
        /// </summary>
        public AuthenticationFlow? Flow { get; set; } = AuthenticationFlow.Redirect;

        /// <summary>
        ///     The themeId you want to use for this specific authentication session. If not specified, the default theme for your account will be used.
        /// </summary>
        public string ThemeId { get; set; }

        /// <summary>
        ///     Request additional information about the user.
        ///     One of: <c>firstname</c>, <c>lastname</c>, <c>dateofbirth</c> or <c>nin</c>.
        ///     <see cref="Constants.RequestedAttributes" />
        /// </summary>
        public IList<string> RequestedAttributes { get; set; } = new List<string>();

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
        ///     Specifies the domain you want to use for this specific session. The domain will be visible in the end-user's browser.
        ///     This domain needs to be correctly configured on your account.
        /// </summary>
        public string RequestDomain { get; set; }
    }
}