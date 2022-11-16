using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Signicat.Information.Organization
{
    public class Authorization
    {
        public Signature Signature { get; set; }
        
        public PowerOfProcuration PowerOfProcuration { get; set; }

        public OrganizationMetadata Metadata { get; set; }
    }

    /// <summary>
    /// People with authorization to sign and to act on behalf of the business in all matters.
    /// </summary>
    public class Signature : SignatureBase { }
    
    /// <summary>
    /// People with authorization to sign and to act on behalf of the business in some matters.
    /// </summary>
    public class PowerOfProcuration : SignatureBase { }
    
    
    public class SignatureBase
    {
        /// <summary>
        /// Status of the combinations represented by the signature
        /// </summary>
        public AuthorizationStatus Status { get; set; }
        
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// List of signature combinations
        /// </summary>
        public IList<SignerCombinations> Combinations { get; set; }
        
        public CombinationBasis Basis { get; set; }
        
        public SignatureMetadata Metadata { get; set; }
    }

    public class SignerCombinations
    {
        /// <summary>
        /// The signers in a combination
        /// </summary>
        public IList<Signer> Signers { get; set; }
        
        /// <summary>
        /// A description
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// Contains the data that was used to form the basis for the combinations
    /// </summary>
    public class CombinationBasis
    {
        /// <summary>
        /// The people
        /// </summary>
        public IList<BasisSigner> People { get; set; }
    }
    
    public class BasisSigner
    {
        /// <summary>
        /// Name of the basis signer
        /// </summary>
        public Name Name { get; set; }
        
        /// <summary>
        /// Birth date of the basis signer
        /// </summary>
        public string DateOfBirth { get; set; }
        
        /// <summary>
        /// Basis Signer role
        /// </summary>
        public SignerRole Role { get; set; }
        
        /// <summary>
        /// List of Roles associated to the Basis Signer
        /// </summary>
        public IList<SignerRole> Roles { get; set; }
    }
    
    public class Signer
    {
        /// <summary>
        /// Name of the signer
        /// </summary>
        public Name Name { get; set; }
        
        /// <summary>
        /// Birth date of the signer
        /// </summary>
        public string DateOfBirth { get; set; }
        
        /// <summary>
        /// Signer role
        /// </summary>
        public SignerRole Role { get; set; }
    }

    /// <summary>
    /// Role of the signer
    /// </summary>
    public class SignerRole
    {
        /// <summary>
        /// Role type 
        /// </summary>
        public AuthorizationRole Code { get; set; }
        
        /// <summary>
        /// Text description of the role
        /// </summary>
        public string Description { get; set; }
    }
    
    /// <summary>
    /// Describes the authorization response. Meaning of each status:
    /// <para>- "unknown": unknown value</para>
    /// <para>- "error": no combinations could be generated</para>
    /// <para>- "none": no combinations available</para>
    /// <para>- "incomplete": the response contains combinations, but there may be more</para>
    /// <para>- "complete": the response contains all possible combinations</para>
    /// </summary> 
    public enum AuthorizationStatus
    {
        [EnumMember(Value = "unknown")]
        Unknown = 0,
        
        [EnumMember(Value = "error")]
        Error = 1,
        
        [EnumMember(Value = "none")]
        None = 2,
        
        [EnumMember(Value = "incomplete")]
        Incomplete = 3,
        
        [EnumMember(Value = "complete")]
        Complete = 4
    }
    
    /// <summary>
    /// Metadata about the response
    /// </summary>
    public class SignatureMetadata
    {
        /// <summary>
        /// List of sources for the data
        /// </summary>
        public IList<string> Sources { get; set; }

        /// <summary>
        /// Public urls to the sources
        /// </summary>
        public IList<string> Urls { get; set; }
        

        /// <summary>
        /// The date the data was last changed
        /// </summary>
        public DateTimeOffset? LastChanged { get; set; }
        
        /// <summary>
        /// The raw JSON if it was requested and supported by the source
        /// </summary>
        public string RawJson { get; set; }
    }
}