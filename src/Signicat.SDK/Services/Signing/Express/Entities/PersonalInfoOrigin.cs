using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum PersonalInfoOrigin
    {
        [EnumMember(Value = "unknown")]
        Unknown = 0,
        [EnumMember(Value = "eid")]
        Eid = 1,
        [EnumMember(Value = "userFormInput")]
        UserFormInput = 2
    }
}