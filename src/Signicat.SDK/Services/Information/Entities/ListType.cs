using System.Runtime.Serialization;

namespace Signicat.Information
{
    public enum ListType
    {
        [EnumMember(Value = "unknown")] Unknown = 0,

        [EnumMember(Value = "pep")] Pep = 1,

        [EnumMember(Value = "sanction")] Sanction = 2,

        [EnumMember(Value = "adverseMedia")] AdverseMedia = 3
    }
}