namespace Signicat.Services.Signing.Express.Entities
{
    public class ContactDetails
    {
        /// <summary>
        /// The name of the company.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The phone number of the company.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The email address of the company.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The URL to the company's website.
        /// </summary>
        public string Url { get; set; }
    }
}