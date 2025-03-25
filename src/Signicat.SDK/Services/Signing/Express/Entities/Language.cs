using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum Language
    {
        [EnumMember(Value = "EN")] EN = 0,

        [EnumMember(Value = "NO")] NO = 1,

        [EnumMember(Value = "DA")] DA = 2,

        [EnumMember(Value = "SV")] SV = 3,

        [EnumMember(Value = "FI")] FI = 4,

        [EnumMember(Value = "NL")] NL = 5,

        [EnumMember(Value = "DE")] DE = 6,
    }
}