using System;
using System.Runtime.Serialization;

namespace Signicat.Services.Signing.Express.Entities
{
    public enum ExtraInfoSignerType
    {
        [Obsolete("Please use vippsAmlPerson")]
        [EnumMember(Value = "bankIDApisAmlPersonSanctionPep")]
        BankIDApisAmlPersonSanctionPep = 6,
    
        [Obsolete("Please use vippsAmlPerson")]
        [EnumMember(Value = "bankIDApisAmlCurrentAddress")]
        BankIDApisAmlCurrentAddress = 7,
        
        [Obsolete("Please use vippsAmlPerson")]
        [EnumMember(Value = "bankIDApisAmlPersonSanctionPepReport")]
        BankIDApisAmlPersonSanctionPepReport = 8, 
        
        [EnumMember(Value = "vippsAmlPerson")]
        VippsAmlPerson = 8,
    }
}