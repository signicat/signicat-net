using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))] // This custom converter was placed in a system namespace.
    public enum RecordTypes
    {
        [EnumMember(Value = "OTHER")] OTHER = 0,
        [EnumMember(Value = "GDPR")] GDPR = 1,
        [EnumMember(Value = "TRANSACTION")] TRANSACTION = 2,
        [EnumMember(Value = "LOG_IN")] LOG_IN = 3,
        [EnumMember(Value = "SIGNATURE")] SIGNATURE = 4
    }
}