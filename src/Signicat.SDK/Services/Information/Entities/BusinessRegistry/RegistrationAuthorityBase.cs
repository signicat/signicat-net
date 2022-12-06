namespace Signicat.Information.BusinessRegistry
{
    public class RegistrationAuthorityBase
    {
        /// <summary>
        ///     Authority code
        /// </summary>
        public string AuthorityCode { get; set; }

        /// <summary>
        ///     ISO 3166-1 country codes
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///     Country name
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Localized name
        /// </summary>
        public string LocalizedName { get; set; }

        /// <summary>
        ///     International name
        /// </summary>
        public string InternationalName { get; set; }

        /// <summary>
        ///     Jurisdiction
        /// </summary>
        public string Jurisdiction { get; set; }
    }
}