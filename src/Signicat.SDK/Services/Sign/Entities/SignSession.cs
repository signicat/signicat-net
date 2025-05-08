using System;
using System.Collections.Generic;

namespace Signicat.Sign.Entities
{
    public class SignSession
    {
        /// <summary>
        /// The sign session's unique identifier
        /// </summary>
        public string SignSessionId { get; set; }

        /// <summary>
        /// The sign session's title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The sign session's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The documents in the sign session
        /// </summary>
        public List<SignSessionDocument> Documents { get; set; }

        /// <summary>
        /// The signers in the sign session
        /// </summary>
        public List<Signer> Signers { get; set; }

        /// <summary>
        /// Additional metadata for the sign session
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; }
    }

    public class SignSessionDocument
    {
        /// <summary>
        /// The document's unique identifier
        /// </summary>
        public string DocumentId { get; set; }
    }

    public class Signer
    {
        /// <summary>
        /// The signer's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The signer's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The signer's last name
        /// </summary>
        public string LastName { get; set; }
    }
} 