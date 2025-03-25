using System;
using System.Collections.Generic;

namespace Signicat.Services.Signing.Express.Entities
{
    public class Document
    {
        /// <summary>
        /// The document's unique identifier.
        /// </summary>
        public Guid DocumentId { get; set; }

        /// <summary>
        /// List of signers for the document.
        /// </summary>
        public List<Signer> Signers { get; set; }

        /// <summary>
        /// The status of the document.
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// HATEOAS extra info links retrieved for the document.
        /// </summary>
        public List<Link> Links { get; set; }

        /// <summary>
        /// The title of the document which will be presented to the user.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The description of the document.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Your reference to this document.
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// The data that will be signed.
        /// </summary>
        public DataToSign DataToSign { get; set; }

        /// <summary>
        /// The company's contact information.
        /// </summary>
        public ContactDetails ContactDetails { get; set; }

        /// <summary>
        /// Settings for custom notification texts. Remark: Also requires you to setup notifications for each signer you want to notify.
        /// </summary>
        public Notification Notification { get; set; }

        /// <summary>
        /// Optional settings for advanced configuration.
        /// </summary>
        public Advanced Advanced { get; set; }
    }
}