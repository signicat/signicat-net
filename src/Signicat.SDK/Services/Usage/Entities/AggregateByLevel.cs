using System.Runtime.Serialization;

namespace Signicat
{
    public enum AggregateByLevel
    {
        [EnumMember(Value = "account")] Account,
        [EnumMember(Value = "organization")] Organisation,
    }
}