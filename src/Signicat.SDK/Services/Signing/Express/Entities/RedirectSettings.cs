namespace Signicat.Services.Signing.Express.Entities
{
    public class RedirectSettings
    {
        /// <summary>
        /// Defines the redirect mode to use for the signer.
        /// </summary>
        public RedirectMode RedirectMode { get; set; }
    
        /// <summary>
        /// The domain your website is hosted on. Required if you specify one of the iframe redirect modes for the signer.
        /// </summary>
        public string Domain { get; set; }
    
        /// <summary>
        /// The URL that the signer is redirected to if something goes wrong. Required if you use redirect for the signer.
        /// </summary>
        public string Error { get; set; }
    
        /// <summary>
        /// The URL that the signer is redirected to if the signing is cancelled. Required if you use redirect for the signer.
        /// </summary>
        public string Cancel { get; set; }
    
        /// <summary>
        /// The URL that the signer is redirected to after a successful signing. Required if you use redirect for the signer.
        /// </summary>
        public string Success { get; set; }
    }
}