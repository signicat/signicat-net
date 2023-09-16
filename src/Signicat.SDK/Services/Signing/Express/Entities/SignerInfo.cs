namespace Signicat.Services.Signing.Express.Entities
{
    public class SignerInfo 
    {
        /// <summary>
        /// The signer's first name.
        /// </summary>
        public string FirstName { get; set; }
    
        /// <summary>
        /// The signer's last name.
        /// </summary>
        public string LastName { get; set; }
    
        /// <summary>
        /// The signer's email adress. Define this if you are using notifications.
        /// </summary>
        public string Email { get; set; }
    
        /// <summary>
        /// Prefilled social security number.
        /// </summary>
        public string SocialSecurityNumber { get; set; }
    
        /// <summary>
        /// The signer's mobile number. Define this if you are using notifications.
        /// </summary>
        public Mobile Mobile { get; set; }
    
        /// <summary>
        /// The signer's organization info.
        /// </summary>
        public OrganizationInfo OrganizationInfo { get; set; }

        /// <summary>
        /// Give the signer a title (i.e CTO, Buyer, Customer, Lord..), this title may be merged into the PAdES-frontpage (in PAdES setting set)
        /// </summary>
        public string Title { get; set; }
    }
}