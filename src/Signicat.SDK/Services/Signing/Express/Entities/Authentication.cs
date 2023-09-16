namespace Signicat.Services.Signing.Express.Entities
{
    public class Authentication
    {
        /// <summary>
        /// Set the type of authentication you want before the user is allowed to view the document(s), sms otp will use the mobile number specified in signerinfo
        /// </summary>
        public AuthenticationMechanism? Mechanism { get; set; }
    
        /// <summary>
        /// The signer's social security number.
        /// </summary>
        public string SocialSecurityNumber { get; set; }
    
        /// <summary>
        /// The signer's unique ID for a signature method (for example the Norwegian BankID PID).
        /// </summary>
        public string SignatureMethodUniqueId { get; set; }
    }
}