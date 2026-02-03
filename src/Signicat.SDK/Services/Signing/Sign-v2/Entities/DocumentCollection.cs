using System.Collections.Generic;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// A collection of documents to be signed together
    /// </summary>
    public class DocumentCollection
    {
        /// <summary>
        /// The collection's unique identifier
        /// </summary>
        /// <example>f05d0dce-a7af-432b-b6b8-e455ab7c0858</example>
        public string Id { get; set; }

        /// <summary>
        /// References to the documents in this collection
        /// </summary>
        public List<DocumentReference> Documents { get; set; } = new List<DocumentReference>();

        /// <summary>
        /// A list of formats the collection should be packaged to when all sessions connected to it are signed.
        /// </summary>
        public List<PackageType> PackageTo { get; set; }

        public CollectionOutput Output { get; set; }
    }
}