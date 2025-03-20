using System;
using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum ExtraInfoSignerType
    {
        [Obsolete("Please use PersonLookup")]
        [EnumMember(Value = "bankIDApisAmlPersonSanctionPep")]
        BankIDApisAmlPersonSanctionPep = 6,

        [Obsolete("Please use PersonLookup")]
        [EnumMember(Value = "bankIDApisAmlCurrentAddress")]
        BankIDApisAmlCurrentAddress = 7,

        [Obsolete("Please use PersonLookup")]
        [EnumMember(Value = "bankIDApisAmlPersonSanctionPepReport")]
        BankIDApisAmlPersonSanctionPepReport = 8, 

        [Obsolete("Please use PersonLookup")]
        [EnumMember(Value = "vippsAmlPerson")]
        VippsAmlPerson = 8,
        
        [EnumMember(Value = "personLookup")]
        PersonLookup = 10,
    }
}