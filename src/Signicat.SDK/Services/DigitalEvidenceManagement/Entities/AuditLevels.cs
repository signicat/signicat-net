using System.Runtime.Serialization;

namespace Signicat.DigitalEvidenceManagement.Entities
{
    public enum AuditLevels
    {
        [EnumMember(Value = "SIMPLE")] SIMPLE = 1,
        [EnumMember(Value = "ADVANCED")] ADVANCED = 2,
        [EnumMember(Value = "QUALIFIED")] QUALIFIED = 0
    }
}