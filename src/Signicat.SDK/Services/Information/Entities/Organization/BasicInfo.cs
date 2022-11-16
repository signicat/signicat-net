using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Signicat.Information.Organization
{
    public class BasicInfo
    {
        /// <summary>
        /// Organization name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// List of organization names
        /// </summary>
        public IList<OrganizationName> Names { get; set; }
        
        /// <summary>
        /// The organization number
        /// </summary>
        public string OrganizationNumber { get; set; }
        
        /// <summary>
        /// VAT number of the organization
        /// </summary>
        public string VATNumber { get; set; }

        /// <summary>
        /// Registration date of the organization
        /// </summary>
        public DateTimeOffset? RegistrationDate { get; set; }
        
        /// <summary>
        /// Country Codes
        /// </summary>
        public Iso3166 Country { get; set; }
        
        /// <summary>
        /// The business address
        /// </summary>
        public Address BusinessAddress { get; set; }
        
        /// <summary>
        /// Addresses
        /// </summary>
        public IList<ExtendedAddress> Addresses { get; set; }
        
        /// <summary>
        /// Type of organization
        /// </summary>
        public OrganizationType OrganizationType { get; set; }
        
        /// <summary>
        /// Legal status
        /// </summary>
        public LegalStatus LegalStatus { get; set; }
        
        /// <summary>
        /// Number of employees
        /// </summary>
        public int? Employees { get; set; }
        
        /// <summary>
        /// A list of industries the organization is involved in according to the NACE Rev. 2 classification;
        /// </summary>
        public IList<Industry> Industries { get; set; } 
        
        public ContactInfo Contact { get; set; }
        
        public Metadata Metadata { get; set; }
    }
    
    public enum LegalStatus {
        [EnumMember(Value = "unknown")]
        Unknown = 0,
        
        [EnumMember(Value = "active")]
        Active = 1,
        
        [EnumMember(Value = "inactive")]
        Inactive = 2,
        
        [EnumMember(Value = "insolvent")]
        Insolvent = 3,
        
        [EnumMember(Value = "terminating")]
        Terminating = 4,
        
        [EnumMember(Value = "terminated")]
        Terminated = 5,
    }

    /// <summary>
    /// NACE Rev. 2 classification
    /// </summary>
    public class Industry
    {
        /// <summary>
        /// NACE Rev. 2 code
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// NACE Rev. 2 description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// NACE Rev. 2 section (A-U) the code belongs to
        /// </summary>
        public string Section { get; set; }
        
        /// <summary>
        /// Hierarchical level of the code
        /// </summary>
        public int Level { get; set; }
    }

    /// <summary>
    /// Organization type
    /// </summary>
    public class OrganizationType
    {
        /// <summary>
        /// Name of the organization type
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Code representation of the organization type
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Url containing different codes
        /// </summary>
        public string Url { get; set; }
    }

    public class OrganizationName
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Type of name
        /// </summary>
        public OrganizationNameType Type { get; set; }
        
        /// <summary>
        /// Start date of the name
        /// </summary>
        public DateTimeOffset? Start { get; set; }
        
        /// <summary>
        /// End date of the name
        /// </summary>
        public DateTimeOffset? End { get; set; }
    }

    public enum OrganizationNameType
    {
        /// <summary>
        /// The type of name is not known
        /// </summary>
        [EnumMember(Value = "unknown")]
        Unknown = 0,
        
        /// <summary>
        /// Trade name
        /// </summary>
        [EnumMember(Value = "tradeName")]
        TradeName = 1,
        
        /// <summary>
        /// Registered name
        /// </summary>
        [EnumMember(Value = "registered")]
        Registered = 2
    }
}