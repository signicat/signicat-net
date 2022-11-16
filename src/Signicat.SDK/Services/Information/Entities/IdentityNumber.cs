
using System.Runtime.Serialization;

namespace Signicat.Information
{
    /// <summary>
    /// Identity number
    /// </summary>
    public class IdentityNumber
    {
        /// <summary>
        /// The identity number
        /// </summary>
        public string IdNumber { get; set; }
        
        public IdNumberType Type { get; set; }
        
        public Iso3166 Country { get; set; }
    }
    
    /// <summary>
    /// The type of the identity number
    /// </summary>
    public enum IdNumberType
    {
        [EnumMember(Value = "unknown")]
        Unknown = 0,
        
        [EnumMember(Value = "nationalIdentityNumber")]
        NationalIdentityNumber = 1,
        
        [EnumMember(Value = "socialSecurityNumber")]
        SocialSecurityNumber = 2,
        
        [EnumMember(Value = "taxIdentificationNumber")]
        TaxIdentificationNumber = 3,
        
        [EnumMember(Value = "identificationDocumentNumber")]
        IdentificationDocumentNumber = 4,
    }
}