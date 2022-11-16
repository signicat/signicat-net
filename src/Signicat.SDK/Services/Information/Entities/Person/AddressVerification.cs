namespace Signicat.Information.Person
{
    public class AddressVerification
    {
        /// <summary>
        /// Verification success or fail
        /// </summary>
        public bool Verified { get; set; }
        
        /// <summary>
        /// Verification description
        /// </summary>
        public string Description { get; set; }
        
        public Metadata Metadata { get; set; }
    }
}