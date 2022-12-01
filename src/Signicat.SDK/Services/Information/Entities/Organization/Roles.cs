using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Signicat.Information.Organization
{
    public class Roles
    {
        /// <summary>
        ///     A list of persons with roles
        /// </summary>
        public IList<PersonRole> Persons { get; set; }

        /// <summary>
        ///     A list of companies with roles
        /// </summary>
        public IList<CompanyRole> Companies { get; set; }

        /// <summary>
        ///     Entities who's type is not known
        /// </summary>
        public IList<OtherRole> Others { get; set; }

        public Metadata Metadata { get; set; }
    }

    public class PersonRole : RoleBase
    {
        public Name Name { get; set; }

        public Address Address { get; set; }

        public string DateOfBirth { get; set; }

        public Iso3166 Nationality { get; set; }

        public IdentityNumber IdentityNumber { get; set; }
    }

    public class CompanyRole : RoleBase
    {
        /// <summary>
        ///     Name of the company
        /// </summary>
        public string Name { get; set; }

        public OrganizationNumber OrganizationNumber { get; set; }
    }

    public class OtherRole : RoleBase
    {
        /// <summary>
        ///     Name of the entity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Id of the entity
        /// </summary>
        public string Id { get; set; }
    }

    public class RoleBase
    {
        /// <summary>
        ///     Role of the entity
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        ///     Roles of the entity
        /// </summary>
        public IList<RoleWithDate> Roles { get; set; }
    }

    public class RoleWithDate
    {
        /// <summary>
        ///     Role of the entity
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        ///     Start date of the role
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        ///     End date of the role
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }
    }

    /// <summary>
    ///     Role of the entity
    /// </summary>
    public enum Role
    {
        /// <summary>
        ///     Unknown
        /// </summary>
        [EnumMember(Value = "unknown")] Unknown = 0,

        /// <summary>
        ///     CEO
        /// </summary>
        [EnumMember(Value = "ceo")] Ceo = 1,

        /// <summary>
        ///     Chair of the board
        /// </summary>
        [EnumMember(Value = "boardLeader")] BoardLeader = 2,

        /// <summary>
        ///     A member of the board
        /// </summary>
        [EnumMember(Value = "boardMember")] BoardMember = 3,

        /// <summary>
        ///     Right to represent and sign on behalf of the company.
        /// </summary>
        [EnumMember(Value = "signature")] Signature = 5,

        /// <summary>
        ///     Right to represent and sign on behalf of the company on day-to-day activity.
        /// </summary>
        [EnumMember(Value = "procuration")] Procuration = 4,

        /// <summary>
        ///     Bookkeeper for a company. NO: Regnskapfører
        /// </summary>
        [EnumMember(Value = "bookkeeper")] Bookkeeper = 6,

        /// <summary>
        ///     Accountant for a company. NO: Revisor
        /// </summary>
        [EnumMember(Value = "accountant")] Accountant = 7,

        /// <summary>
        ///     Partner
        /// </summary>
        [EnumMember(Value = "partner")] Partner = 8
    }
}