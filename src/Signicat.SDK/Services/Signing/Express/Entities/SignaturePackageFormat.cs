using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum SignaturePackageFormat
    {
        [EnumMember(Value = "pades")] Pades = 1,
        [EnumMember(Value = "native")] Native = 2,
    }
}