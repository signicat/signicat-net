using System.Collections.Generic;

namespace Signicat.Services.Signing.Sign_v2.Entities
{
    /// <summary>
    /// Options for creating a document collection
    /// </summary>
    public class CreateDocumentCollectionOptions
    {
        /// <summary>
        /// List of document references to include in the collection
        /// </summary>
        public List<DocumentReference> Documents { get; set; } = new List<DocumentReference>();

        /// <summary>
        /// A list of formats the collection should be packaged to when all sessions connected to it are signed.
        /// </summary>
        public List<PackageType> PackageTo { get; set; }
    }
}