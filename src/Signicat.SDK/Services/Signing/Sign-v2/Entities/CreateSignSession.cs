using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Options for creating a signing session
    /// </summary>
    public class CreateSignSession
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
        public List<SigningSetup> SigningSetup { get; set; } = new List<SigningSetup>();

        /// <summary>
        /// Text to display when signing
        /// </summary>
        public string SignText { get; set; }

        /// <summary>
        /// When the session expires
        /// </summary>
        public DateTime? DueDate { get; set; }

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


        /// <summary>
        /// Time-to-live for the signature URL in minutes
        /// </summary>
        [JsonPropertyName("signatureUrlTTL")]
        public int SignatureUrlTimeToLive { get; set; }
    }
}