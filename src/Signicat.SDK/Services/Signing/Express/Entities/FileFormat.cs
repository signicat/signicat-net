using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum FileFormat
    {
        [EnumMember(Value = "unsigned")]
        Unsigned = 0,
        
        [EnumMember(Value = "native")]
        Native = 1,
    
        [EnumMember(Value = "standard_packaging")]
        StandardPackaging = 2,
    
        [EnumMember(Value = "pades")]
        Pades = 3,
    
        [EnumMember(Value = "xades")]
        Xades = 4,
    }
}