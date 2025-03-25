using System.Runtime.Serialization;

namespace Signicat
{
    public enum AggregateByLevel
    {
        [EnumMember(Value = "account")] ACCOUNT,
        [EnumMember(Value = "organization")] ORGANIZATION,
    
    }
}