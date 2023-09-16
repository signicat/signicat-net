using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class AdditionalRecipient
    {
        /// <summary>
        /// The language of the email notification.
        /// </summary>
        public Language Language { get; set; }

        
        /// <summary>
        /// The email address of the recipient
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// If you have custom merge fields in the email texts, the values can be included here
        /// </summary>
        public Dictionary<string, string> CustomMergeFields { get; set; }
    }
}