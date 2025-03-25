using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum SignaturePackageFormat
    {
        [EnumMember(Value = "pades")] Pades = 1
    }
}