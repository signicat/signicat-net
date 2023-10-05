using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class Status 
    {
        /// <summary>
        /// The overall status of the document.
        /// </summary>
        public DocumentStatus? DocumentStatus { get; set; }
    
        /// <summary>
        /// A list of all the completed files/packages for the main document.
        /// </summary>
        public List<FileFormat> CompletedPackages { get; set; }
    
        /// <summary>
        /// A set of key-value pairs with all the completed packages for the signable attachments, where the key is equal to the attachment's ID.
        /// </summary>
        public Dictionary<string, List<FileFormat>> AttachmentPackages { get; set; }
    }
}