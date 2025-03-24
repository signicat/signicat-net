#nullable enable
using System.Runtime.Serialization;

namespace Signicat.Services.Usage.Entities;

public enum UsageState
{
    [EnumMember(Value = "completed")] Completed,
    [EnumMember(Value = "started")] Started,
    [EnumMember(Value = "loaded")] Loaded,
    [EnumMember(Value = "userAborted")] UserAborted,
    [EnumMember(Value = "failed")] Failed
}