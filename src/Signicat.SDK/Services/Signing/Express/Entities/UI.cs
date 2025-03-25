namespace Signicat.Services.Signing.Express.Entities
{
    public class UI
    {
        /// <summary>
        /// The signer's preferred language. This language will be used when signing the document and in email/SMS notifications.
        /// ///</summary>
        public Language? Language { get; set; }

        /// <summary>
        /// Dialogs that will be prestented to the signer in the signature process.
        /// </summary>
        public Dialogs Dialogs { get; set; }

        /// <summary>
        /// Customize styling to make the the signature application look perfect in combination with your own application.
        /// </summary>
        public Styling Styling { get; set; }
    }
}