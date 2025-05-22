using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// User interaction setup for a signing session
    /// </summary>
    public class UserInteractionSetup
    {
        /// <summary>
        /// Vendor providing the identity
        /// </summary>
        public string Vendor { get; set; }
        
        /// <summary>
        /// Available identity providers
        /// </summary>
        public List<IdentityProvider> IdentityProviders { get; set; } = new List<IdentityProvider>();
        
        /// <summary>
        /// The type of signature flow to be performed
        /// </summary>
        public SigningFlow SigningFlow { get; set; }
        
        /// <summary>
        /// Additional parameters that modify the authentication flow
        /// </summary>
        public Dictionary<string, string> AdditionalParameters { get; set; } = new Dictionary<string, string>();
    }
    
    /// <summary>
    /// Vendor values
    /// </summary>
    public static class VendorValues
    {
        /// <summary>
        /// Buypass vendor
        /// </summary>
        public const string Buypass = "buypass";
        
        /// <summary>
        /// Swedish BankID vendor
        /// </summary>
        public const string SbId = "sbid";
    }
    
    /// <summary>
    /// Signing flow type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverterEnumMember<SigningFlow>))]
    public enum SigningFlow
    {
        /// <summary>
        /// Authentication-based signing flow
        /// </summary>
        [EnumMember(Value = "AUTHENTICATION_BASED")]
        AUTHENTICATION_BASED,
        
        /// <summary>
        /// PKI-based signing flow
        /// </summary>
        [EnumMember(Value = "PKISIGNING")]
        PKISIGNING
    }
}