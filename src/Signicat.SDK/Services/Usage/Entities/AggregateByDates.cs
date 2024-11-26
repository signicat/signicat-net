using System.Runtime.Serialization;

namespace Signicat;

public enum AggregateByDates
{
    [EnumMember(Value = "day")] DAY,
    [EnumMember(Value = "month")] MONTH,
    [EnumMember(Value = "year")] YEAR
}