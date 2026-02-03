using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
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
        [EnumMember(Value = "PKISIGNING")] PKISIGNING
    }
}