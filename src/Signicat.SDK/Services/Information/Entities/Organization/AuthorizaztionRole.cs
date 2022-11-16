using System.Runtime.Serialization;

namespace Signicat.Information.Organization
{
    /// <summary>
    /// Role of the entity
    /// </summary>
    public enum AuthorizationRole {
    
        /// <summary>
        /// Unknown
        /// </summary>
        [EnumMember(Value = "unknown")]
        Unknown = 0,
    
        /// <summary>
        /// CEO
        /// </summary>
        [EnumMember(Value = "ceo")]
        Ceo = 1,

        /// <summary>
        /// Chair of the board
        /// </summary>
        [EnumMember(Value = "boardLeader")]
        BoardLeader = 2,
    
        /// <summary>
        /// A member of the board
        /// </summary>
        [EnumMember(Value = "boardMember")]
        BoardMember = 3,

        /// <summary>
        /// Right to represent and sign on behalf of the company.
        /// </summary>
        [EnumMember(Value = "signature")]
        Signature = 5,
    
        /// <summary>
        /// Right to represent and sign on behalf of the company on day-to-day activity.
        /// </summary>
        [EnumMember(Value = "procuration")]
        Procuration = 4,

        /// <summary>
        /// Bookkeeper for a company. NO: Regnskapfører
        /// </summary>
        [EnumMember(Value = "bookkeeper")]
        Bookkeeper = 6,
    
        /// <summary>
        /// Accountant for a company. NO: Revisor
        /// </summary>
        [EnumMember(Value = "accountant")]
        Accountant = 7,
    }
}