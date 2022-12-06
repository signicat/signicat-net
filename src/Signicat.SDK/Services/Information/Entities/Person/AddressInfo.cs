namespace Signicat.Information.Person
{
    public class AddressInfo
    {
        /// <summary>
        ///     Permanent address for the person
        /// </summary>
        public Address Permanent { get; set; }

        /// <summary>
        ///     Postal address for the person
        /// </summary>
        public Address Postal { get; set; }

        /// <summary>
        ///     Foreign address for the person
        /// </summary>
        public Address Foreign { get; set; }

        /// <summary>
        ///     Metadata for the content
        /// </summary>
        public Metadata Metadata { get; set; }
    }
}