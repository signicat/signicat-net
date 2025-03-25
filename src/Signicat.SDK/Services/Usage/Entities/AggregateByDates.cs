using System.Runtime.Serialization;

namespace Signicat
{
    public enum AggregateByDates
    {
        [EnumMember(Value = "daily")] DAILY,
        [EnumMember(Value = "monthly")] MONTHLY,
        [EnumMember(Value = "quarterly")] QUARTERLY,
        [EnumMember(Value = "yearly")] YEARLY
    }
}