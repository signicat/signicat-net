using System.Runtime.Serialization;

namespace Signicat
{
    public enum AggregateByDates
    {
        [EnumMember(Value = "daily")] Daily,
        [EnumMember(Value = "monthly")] Monthly,
        [EnumMember(Value = "quarterly")] Quarterly,
        [EnumMember(Value = "yearly")] Yearly
    }
}