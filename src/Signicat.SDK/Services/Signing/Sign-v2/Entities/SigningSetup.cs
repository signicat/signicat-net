using System.Collections.Generic;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// User interaction setup for a signing session
    /// </summary>
    public class SigningSetup
    {
        /// <summary>
        /// The list of identity providers (IdPs) available for the end-user to choose from. If not specified, all configured IdPs on the account will be shown as options.
        /// </summary>
        public List<IdentityProvider> IdentityProviders { get; set; } = new List<IdentityProvider>();

        /// <summary>
        /// The type of signature flow to be performed
        /// </summary>
        public SigningFlow SigningFlow { get; set; }

        /// <summary>
        /// Additional parameters that modify the authentication flow. Depends on selected IdP. See developer documentation for details.
        /// </summary>
        /// <example>{"sbid_flow": "QR", "sbid_end_user_ip": "127.0.0.1"}</example>
        public Dictionary<string, string> AdditionalParameters { get; set; } = new Dictionary<string, string>();
    }

    /// <summary>
    /// Signing vendor
    /// </summary>
    public enum Vendor
    {
        BUYPASS,
        SBID,
        NBID,
        AUDKENNI,
        SMARTID,
        MOBILEID
    }
}