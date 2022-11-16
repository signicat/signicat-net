namespace Signicat.Information
{
    /// <summary>
    /// Phone number
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// The national number
        /// </summary>
        public string NationalNumber { get; set; }
        
        /// <summary>
        /// Country dial code if the national number was recognized as valid
        /// </summary>
        public int? CountryCode { get; set; }

        /// <summary>
        /// The number formatted according to its locale if the national number was recognized as valid
        /// </summary>
        public string IntlFormat { get; set; }
    }
}