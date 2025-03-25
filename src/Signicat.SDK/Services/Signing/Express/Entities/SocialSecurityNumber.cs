namespace Signicat.Services.Signing.Express.Entities
{
    public class SocialSecurityNumber
    {
        /// <summary>
        /// The social security number.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// ISO 3166-1 Alfa-2 (2 letters) country code.
        /// </summary>
        public string CountryCode { get; set; }
    }
}