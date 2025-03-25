using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum SignatureMechanism
    {
        [EnumMember(Value = "pkisignature")] PkiSignature = 0,

        [EnumMember(Value = "identification")] Identification = 1,

        [EnumMember(Value = "handwritten")] Handwritten = 2,

        [EnumMember(Value = "handwritten_with_identification")]
        HandwrittenWithIdentification = 3,
    }
}