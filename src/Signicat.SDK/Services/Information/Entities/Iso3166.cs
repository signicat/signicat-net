namespace Signicat.Information
{
    /// <summary>
    ///     ISO 3166-1 country codes
    /// </summary>
    public class Iso3166
    {
        /// <summary>
        ///     Two digit country code
        /// </summary>
        public string Alpha2 { get; set; }

        /// <summary>
        ///     Three digit country code
        /// </summary>
        public string Alpha3 { get; set; }

        /// <summary>
        ///     Numeric country code
        /// </summary>
        public string Numeric { get; set; }
    }
}