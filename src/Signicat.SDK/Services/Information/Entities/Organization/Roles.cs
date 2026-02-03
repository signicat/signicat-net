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
        [EnumMember(Value = "partner")] Partner = 8,

        /// <summary>
        ///     Alternate member
        /// </summary>
        [EnumMember(Value = "alternateMember")]
        AlternateMember = 9,

        /// <summary>
        ///     Auditor
        /// </summary>
        [EnumMember(Value = "auditor")] Auditor = 10,

        /// <summary>
        ///     Representative
        /// </summary>
        [EnumMember(Value = "representative")]
        Representative = 11,

        /// <summary>
        ///     Foreign
        /// </summary>
        [EnumMember(Value = "foreign")] Foreign = 12,

        /// <summary>
        ///     Legal entity
        /// </summary>
        [EnumMember(Value = "legalEntity")]
        LegalEntity = 13,

        /// <summary>
        ///     Shareholder
        /// </summary>
        [EnumMember(Value = "shareholder")]
        Shareholder = 14,

        /// <summary>
        ///     Owner
        /// </summary>
        [EnumMember(Value = "owner")] Owner = 15,

        /// <summary>
        ///     Legal representative
        /// </summary>
        [EnumMember(Value = "legalRepresentative")]
        LegalRepresentative = 16,

        /// <summary>
        ///     Tax representative
        /// </summary>
        [EnumMember(Value = "taxRepresentative")]
        TaxRepresentative = 17,

        /// <summary>
        ///     Public entity
        /// </summary>
        [EnumMember(Value = "publicEntity")]
        PublicEntity = 18,

        /// <summary>
        ///     House manager
        /// </summary>
        [EnumMember(Value = "houseManager")]
        HouseManager = 19,

        /// <summary>
        ///     Ceo substitute
        /// </summary>
        [EnumMember(Value = "ceoSubstitute")]
        CeoSubstitute = 20,

        /// <summary>
        ///     Vice board leader
        /// </summary>
        [EnumMember(Value = "viceBoardLeader")]
        ViceBoardLeader = 21,

        /// <summary>
        ///     Deputy board member
        /// </summary>
        [EnumMember(Value = "deputyBoardMember")]
        DeputyBoardMember = 22
    }
}