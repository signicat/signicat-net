using System;
using System.Collections.Generic;

namespace Signicat.Services.Sign.Entities
{
    /// <summary>
    /// Options for creating a signing session
    /// </summary>
    public class CreateSignSessionOptions
    {
        /// <summary>
        /// Required title of the signing session
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Required documents to sign in this session
        /// </summary>
        public List<SessionDocument> Documents { get; set; } = new List<SessionDocument>();
        
        /// <summary>
        /// Required user interaction setup
        /// </summary>
        public List<UserInteractionSetup> UserInteractionSetup { get; set; } = new List<UserInteractionSetup>();
        
        /// <summary>
        /// Recipient of notifications
        /// </summary>
        public Recipient Recipient { get; set; }
        
        /// <summary>
        /// Text to display when signing
        /// </summary>
        public string SignText { get; set; }
        
        /// <summary>
        /// When the session expires
        /// </summary>
        public DateTime? DueDate { get; set; }
        
        /// <summary>
        /// The name of the entity that requested the signature
        /// </summary>
        public string SenderDisplayName { get; set; }
        
        /// <summary>
        /// External reference for this session
        /// </summary>
        public string ExternalReference { get; set; }
        
        /// <summary>
        /// IDs of signing sessions that must be signed before this one
        /// </summary>
        public List<string> SubsequentTo { get; set; } = new List<string>();
        
        /// <summary>
        /// List of formats the session should be packaged to when signed
        /// </summary>
        public List<PackageType> PackageTo { get; set; } = new List<PackageType>();
        
        /// <summary>
        /// The intended signer of the Signing Session
        /// </summary>
        public Signer Signer { get; set; }
        
        /// <summary>
        /// Define what objects should be added to archive
        /// </summary>
        public ArchiveSettings Archive { get; set; }
        
        /// <summary>
        /// Set up authentication of signer before presenting documents
        /// </summary>
        public PreAuthentication PreAuthentication { get; set; }
        
        /// <summary>
        /// Specifies the language to be used in the signing UI
        /// </summary>
        public string Language { get; set; }
        
        /// <summary>
        /// Define URLs for redirects
        /// </summary>
        public RedirectSettings RedirectSettings { get; set; }
    }
}