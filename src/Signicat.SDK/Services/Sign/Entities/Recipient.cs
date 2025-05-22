namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// Recipient of notifications
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Email address of the recipient
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Mobile phone number of the recipient
        /// </summary>
        public string Mobile { get; set; }
    }
}