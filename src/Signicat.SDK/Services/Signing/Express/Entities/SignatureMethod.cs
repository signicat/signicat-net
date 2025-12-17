using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum SignatureMethod
    {
        [EnumMember(Value = "no_bankid")] NoBankId = 0,

        [EnumMember(Value = "no_bankid_mobile")]
        NoBankIdMobile = 15,

        [EnumMember(Value = "no_bankid_netcentric")]
        NoBankIdNetcentric = 16,

        [EnumMember(Value = "no_buypass")] NoBuypass = 1,

        [EnumMember(Value = "se_bankid")] SeBankid = 3,

        [EnumMember(Value = "dk_nemid")] DkNemid = 4,

        [EnumMember(Value = "sms_otp")] SmsOtp = 11,

        [EnumMember(Value = "unknown")] Unknown = 14,

        [EnumMember(Value = "fi_eid")] FiEid = 7,

        [EnumMember(Value = "mitid")] Mitid = 21,

        [EnumMember(Value = "no_bankid_oidc")] NoBankIdOidc = 22,
        [EnumMember(Value = "no_bankid_csc")] NoBankIdCsc = 26
    }
}