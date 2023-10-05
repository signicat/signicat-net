namespace Signicat.Services.Signing.Express.Entities
{
    public class SMS
    {
        /// <summary>
        /// The language of the SMS notification.
        /// </summary>
        public Language Language { get; set; }
    
        /// <summary>
        /// The SMS notification text.
        /// </summary>
        public string Text { get; set; }
    
        /// <summary>
        /// The name to use as SMS sender.
        /// </summary>
        public string Sender { get; set; }
    }
}