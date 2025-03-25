namespace Signicat.Services.Signing.Express.Entities
{
    public class Notification
    {
        /// <summary>
        /// Email/SMS notifications reminding the signers that they have received a new document to sign.
        /// </summary>
        public SignRequest SignRequest { get; set; }

        /// <summary>
        /// Email/SMS notifications reminding the signers that they have an unsigned document.
        /// </summary>
        public Reminder Reminder { get; set; }

        /// <summary>
        /// Email/SMS notifications as a receipt for a successful signature.
        /// </summary>
        public SignatureReceipt SignatureReceipt { get; set; }

        /// <summary>
        /// Email/SMS notifications as a receipt when a document has received all required signatures.
        /// </summary>
        public FinalReceipt FinalReceipt { get; set; }

        /// <summary>
        /// Email/SMS notifications when a document has been cancelled and can no longer be signed.
        /// </summary>
        public CanceledReceipt CanceledReceipt { get; set; }

        /// <summary>
        /// Email/SMS notifications when a document has expired and can no longer be signed.
        /// </summary>
        public ExpiredReceipt ExpiredReceipt { get; set; }
    }
}