using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum AddonSignerType
    {
        [EnumMember(Value = "secureShare")]
        SecureShare = 0
    }
}