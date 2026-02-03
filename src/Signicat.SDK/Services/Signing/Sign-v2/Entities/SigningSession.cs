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
        /// <example>f05d0dce-a7af-432b-b6b8-e455ab7c0852</example>
        public string Id { get; set; }

        /// <summary>
        /// URL to send the user to for signing
        /// </summary>
        /// <example>https://signtest-account.sandbox.signicat.com/sign/?sessionId=8ce3dac2-74b3-429c-adf7-fe6d277186d0</example>
        public string SignatureUrl { get; set; }

        /// <summary>
        /// Time-to-live for the signature URL in minutes
        /// </summary>
        /// <example>5</example>
        public int? SignatureUrlTtl { get; set; }

        /// <summary>
        /// When the signature URL expires
        /// </summary>
        /// <example>2026-01-15T14:05:00Z</example>
        public DateTime? SignatureUrlExpiresAt { get; set; }

        /// <summary>
        /// Title of the signing session
        /// </summary>
        /// <example>Rental agreement</example>
        public string Title { get; set; }

        /// <summary>
        /// Text to display when signing
        /// </summary>
        /// <example>Please sign this document</example>
        public string SignText { get; set; }

        /// <summary>
        /// When the session expires
        /// </summary>
        /// <example>2025-04-01T17:32:28Z</example>
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
        /// <example>Corporation incorporated</example>
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
        public List<SigningSetup> SigningSetup { get; set; } = new List<SigningSetup>();

        /// <summary>
        /// IDs of signing sessions that must be signed before this one
        /// </summary>
        /// <example>f05d0dce-a7af-432b-b6b8-e455ab7c0858</example>
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
        /// Set up authentication of signer before presenting documents
        /// </summary>
        public PreAuthentication PreAuthentication { get; set; }

        /// <summary>
        /// Defines UI settings for the signing session.
        /// </summary>
        public Ui Ui { get; set; }

        /// <summary>
        /// Define URLs for redirects
        /// </summary>
        public RedirectSettings RedirectSettings { get; set; }
    }
}