namespace Signicat.Services.Signing.Express.Entities
{
    public class SignerOverrides 
    {
        /// <summary>
        /// Set a new email address on the signer (all future notifications to this specific signer will be sent to this email)
        /// </summary>
        public string EmailOverride { get; set; }
    
        /// <summary>
        /// Set a new mobile on the signer
        /// </summary>
        public Mobile MobileOverride { get; set; }
    }
}