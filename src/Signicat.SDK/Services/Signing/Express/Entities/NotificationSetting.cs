using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum NotificationSetting
    {
        [EnumMember(Value = "off")]
        Off = 0,
    
        [EnumMember(Value = "sendSms")]
        SendSms = 1,
    
        [EnumMember(Value = "sendEmail")]
        SendEmail = 2,
    
        [EnumMember(Value = "sendBoth")]
        SendBoth = 3,
    }
}