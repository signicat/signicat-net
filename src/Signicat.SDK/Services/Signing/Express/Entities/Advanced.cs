using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class Advanced
    {
        /// <summary>
        /// A list of tags to add to the document. These tags can be used to query for document data and will also be added to all events that are triggered for the document.
        /// </summary>
        public List<string> Tags { get; set; }
    
        /// <summary>
        /// The number of attachments this document will have. Attachments can be added after the document is created.
        /// </summary>
        public int? Attachments { get; set; }
    
        /// <summary>
        /// The number of signatures required before the document can be sealed and marked as completed.
        /// </summary>
        public int? RequiredSignatures { get; set; }
    
        /// <summary>
        /// The name of the application that created the document. Used for Signicat statistics.
        /// </summary>    
        public string CreatedByApplication { get; set; }
    
        /// <summary>
        /// Determines if the social security number of all the signers should be retrieved after a successful signature.
        /// Requires a certificate with permission to retrieve SSN.
        /// </summary>
        public bool? GetSocialSecurityNumber { get; set; }
    
        ///<summary>
        /// Settings for extra information to collect about the document (e.g. prokura information).
        /// </summary>
        public ExtraInfoDocumentRequest ExtraInfo { get; set; }
        
        /// <summary>
        /// Security settings.
        /// </summary>
        public Security Security { get; set; }
        
        /// <summary>
        /// Time-to-live settings for the document.
        /// </summary>
        public TimeToLive TimeToLive { get; set; }
    
        /// <summary>
        /// The department ID to mark the invoice with.
        /// </summary>
        public string DepartmentId { get; set; }
    }
}