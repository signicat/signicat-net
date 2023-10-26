using System.Runtime.Serialization;

namespace Signicat.Authentication
{
    public enum AuthenticationFlow
    {
        [EnumMember(Value = "redirect")] Redirect = 0,

        [EnumMember(Value = "headless")] Headless = 2
    }
}