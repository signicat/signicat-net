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
    }
}