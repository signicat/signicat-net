using System;

namespace Signicat.Services.Signing.Express.Entities
{
    public class ExtendedDocumentSignature : DocumentSignature
    {
        /// <summary>
        /// The signer's unique identifier.
        /// </summary>
        public Guid? SignerId { get; set; }

        /// <summary>
        /// Your reference for the signer.
        /// </summary>
        public string ExternalSignerId { get; set; }
    }
}