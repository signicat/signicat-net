using System;
using System.Collections.Generic;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Represents a signing session
    /// </summary>
    public class SigningSession
    {
        /// <summary>
        /// The session's unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// URL to send the user to for signing
        /// </summary>
        public string SignatureUrl { get; set; }

        /// <summary>
        /// Recipient of notifications
        /// </summary>
        public Recipient Recipient { get; set; }

        /// <summary>
        /// Title of the signing session
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Text to display when signing
        /// </summary>
        public string SignText { get; set; }

        /// <summary>
        /// When the session expires
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Documents to be signed in this session
        /// </summary>
        public List<SessionDocument> Documents { get; set; } = new List<SessionDocument>();

        /// <summary>
        /// Contains session lifecycle information
        /// </summary>
        public SessionLifecycle Lifecycle { get; set; }

        /// <summary>
        /// The name of the entity that requested the signature. Displayed while signing.
        /// </summary>
        public string SenderDisplayName { get; set; }

        /// <summary>
        /// Contains session output information
        /// </summary>
        public SessionOutput Output { get; set; }

        /// <summary>
        /// An external reference for this session
        /// </summary>
        public string ExternalReference { get; set; }

        /// <summary>
        /// The user interaction setups for this session describing which IDPs are available for the end-user
        /// </summary>
        public List<UserInteractionSetup> UserInteractionSetup { get; set; } = new List<UserInteractionSetup>();

        /// <summary>
        /// IDs of signing sessions that must be signed before this one
        /// </summary>
        public List<string> SubsequentTo { get; set; } = new List<string>();

        /// <summary>
        /// List of formats the session should be packaged to when signed
        /// </summary>
        public List<string> PackageTo { get; set; } = new List<string>();

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

    /// <summary>
    /// Contains session lifecycle information
    /// </summary>
    public class SessionLifecycle
    {
        /// <summary>
        /// Current state of the session
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Indicates if the current state is final
        /// </summary>
        public bool StateIsFinal { get; set; }
    }

    /// <summary>
    /// Session state values
    /// </summary>
    public static class SessionStateValues
    {
        /// <summary>
        /// Session is blocked
        /// </summary>
        public const string Blocked = "BLOCKED";
        
        /// <summary>
        /// Session is ready for signing
        /// </summary>
        public const string Ready = "READY";
        
        /// <summary>
        /// Session has been signed
        /// </summary>
        public const string Signed = "SIGNED";
        
        /// <summary>
        /// Session has been rejected
        /// </summary>
        public const string Rejected = "REJECTED";
    }

    /// <summary>
    /// Contains session output information
    /// </summary>
    public class SessionOutput
    {
        /// <summary>
        /// Signatures in the session
        /// </summary>
        public List<SessionSignature> Signatures { get; set; } = new List<SessionSignature>();

        /// <summary>
        /// Packages in the session
        /// </summary>
        public List<SessionPackage> Packages { get; set; } = new List<SessionPackage>();
    }
}