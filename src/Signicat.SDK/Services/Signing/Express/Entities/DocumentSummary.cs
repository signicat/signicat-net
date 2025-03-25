using System;
using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class DocumentSummary
    {
        /// <summary>
        /// Document id
        /// </summary>
        public Guid? DocumentId { get; set; }

        /// <summary>
        /// Account id
        /// </summary>
        public Guid? AccountId { get; set; }

        /// <summary>
        /// Document title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Document description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// When was the document last updated (ISO8601)
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// The sign deadline for the document (ISO8601)
        /// </summary>
        public DateTime? Deadline { get; set; }

        /// <summary>
        /// When was all the signatures processed (ISO8601)
        /// </summary>
        public DateTime? SignedDate { get; set; }

        /// <summary>
        /// Document status
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// External document Id (your Id)
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// All the signatures received on this document
        /// </summary>
        public List<ExtendedDocumentSignature> DocumentSignatures { get; set; }

        /// <summary>
        /// The number of required signatures on the document
        /// </summary>
        public int? RequiredSignatures { get; set; }

        /// <summary>
        /// How many signatures is completed right now
        /// </summary>
        public int? CurrentSignatures { get; set; }

        /// <summary>
        /// Document tags
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// A list of attachment Id's
        /// </summary>
        public List<Guid> Attachments { get; set; }

        /// <summary>
        /// A list of all the signers on the document
        /// </summary>
        public List<Guid> Signers { get; set; }

        /// <summary>
        /// When the document was created (ISO 8601)
        /// </summary>
        public DateTime? Created { get; set; }
    }
}