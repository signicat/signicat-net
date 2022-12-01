using System.Collections.Generic;

namespace Signicat.Information.Organization
{
    public class Ownership
    {
        /// <summary>
        ///     List of shareholding companies
        /// </summary>
        public IList<ShareholderCompany> Companies { get; set; }

        /// <summary>
        ///     List of shareholding persons
        /// </summary>
        public IList<ShareholderPerson> Persons { get; set; }

        /// <summary>
        ///     List of shareholders who's type is not known
        /// </summary>
        public IList<OtherShareholder> OtherShareholders { get; set; }

        public Metadata Metadata { get; set; }
    }

    public class ShareholderPerson : Shareholder
    {
        /// <summary>
        ///     Name of the person
        /// </summary>
        public Name Name { get; set; }

        /// <summary>
        ///     Birth date of the person
        /// </summary>
        public string DateOfBirth { get; set; }
    }

    public class ShareholderCompany : Shareholder
    {
        /// <summary>
        ///     Name of the company
        /// </summary>
        public string Name { get; set; }

        public OrganizationNumber OrganizationNumber { get; set; }
    }

    public class OtherShareholder : Shareholder
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

    public class Shareholder
    {
        /// <summary>
        ///     Shareholding percentage in the organization
        /// </summary>
        public double? Percentage { get; set; }

        public PercentageRange PercentageRange { get; set; }

        /// <summary>
        ///     Shareholders Voting rights percentage
        /// </summary>
        public double? VotingRights { get; set; }

        public VotingRightsRange VotingRightsRange { get; set; }
    }

    /// <summary>
    ///     Shareholding percentage range
    /// </summary>
    public class PercentageRange : Range
    {
    }

    /// <summary>
    ///     Shareholders voting rights percentage range
    /// </summary>
    public class VotingRightsRange : Range
    {
    }
}