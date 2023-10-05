using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum RedirectMode
    {
        [EnumMember(Value = "donot_redirect")]
        DonotRedirect = 0,
    
        [EnumMember(Value = "redirect")]
        Redirect = 1,
    
        [EnumMember(Value = "iframe_with_webmessaging")]
        IframeWithWebmessaging = 2,
    
        [EnumMember(Value = "iframe_with_redirect")]
        IframeWithRedirect = 3,
    
        [EnumMember(Value = "iframe_with_redirect_and_webmessaging")]
        IframeWithRedirectAndWebmessaging = 4,
    }
}