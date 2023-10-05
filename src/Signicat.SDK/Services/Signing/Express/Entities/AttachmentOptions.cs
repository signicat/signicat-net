using System;
using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class AttachmentOptions
    {
        /// <summary>
        /// Filename with file extension. We only support PDF for attachments, set `convertToPdf` to `true` if you have a convertible file type.
        /// </summary>
        public string FileName { get; set; }
    
        /// <summary>
        /// The title of the attachment which will be presented to the user.
        /// </summary>
        public string Title { get; set; }
    
        /// <summary>
        /// Base64-encoded attachment (UTF-8-encoded)
        /// </summary>
        public string Data { get; set; }
    
        /// <summary>
        /// Determines if the attachment should be converted to PDF. See our documentation for supported file types.
        /// </summary>
        public bool? ConvertToPdf { get; set; }
    
        /// <summary>
        /// An optional list of signers that should be able to see / sign the attachment.
        /// </summary>
        public List<Guid> Signers { get; set; }
    
        /// <summary>
        /// An optional description of the attachment.
        /// </summary>
        public string Description { get; set; }
    
        /// <summary>
        /// The type of attachment.
        /// </summary>
        public AttachmentType? Type { get; set; }
    }
}