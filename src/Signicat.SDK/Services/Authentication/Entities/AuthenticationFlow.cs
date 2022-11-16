using System.Runtime.Serialization;

namespace Signicat.Authentication
{
    public enum AuthenticationFlow {
        [EnumMember(Value = "redirect")]
        Redirect = 0,
            
        [EnumMember(Value = "iframe")]
        Iframe = 1,
            
        [EnumMember(Value = "headless")]
        Headless = 2,
    }
}