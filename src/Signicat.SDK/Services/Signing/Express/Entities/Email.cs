namespace Signicat.Services.Signing.Express.Entities
{
    public class Email
    {
        /// <summary>
        /// The language of the email notification.
        /// </summary>       
        public Language Language { get; set; }

        /// <summary>
        /// The email subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The email notification body. Plain text and markdown is supported.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The name to use as email sender.
        /// </summary>
        public string SenderName { get; set; }
    }
}