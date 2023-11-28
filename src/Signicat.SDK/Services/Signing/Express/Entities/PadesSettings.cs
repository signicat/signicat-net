namespace Signicat.Services.Signing.Express.Entities
{
    public class PadesSettings 
    {
        /// <summary>
        /// The primary language of the PAdES explanatory page. Defaults to english.
        /// </summary>
        public Language? PrimaryLanguage { get; set; }
    
        /// <summary>
        /// The secondary language of the PAdES explanatory page.
        /// </summary>
        public Language? SecondaryLanguage { get; set; }
    
        /// <summary>
        /// The unique ID of PAdES template to use. Can be used if you have previously created your own custom template.
        /// </summary>
        public string PadesTemplateId { get; set; }

        /// <summary>
        /// If you set this to true, the signers ssn / national Id will be visible in the pades file, and in the standard_packaging files
        /// </summary>
        public bool IncludeSsnInPades { get; set; }
    }
}