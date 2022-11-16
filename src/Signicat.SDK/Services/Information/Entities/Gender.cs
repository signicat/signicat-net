using System.Runtime.Serialization;

namespace Signicat.Information
{
    /// <summary>
    /// Gender of the person (Only for entityType "person")
    /// </summary>
    public enum Gender
    {
        [EnumMember(Value = "unknown")]
        Unknown = 0,
        
        [EnumMember(Value = "female")]
        Female = 1,
        
        [EnumMember(Value = "male")]
        Male = 2,
        
        [EnumMember(Value = "other")]
        Other = 3
    }
}