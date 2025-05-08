using System.IO;
using System.Threading.Tasks;
using Signicat.Sign.Entities;

namespace Signicat.Services.Sign
{
    public interface ISignService
    {
        /// <summary>
        /// Upload a new document
        /// </summary>
        /// <param name="fileName">Name of the file to upload</param>
        /// <param name="fileData">File content as byte array</param>
        /// <returns>The uploaded document information</returns>
        Document UploadDocument(string fileName, byte[] fileData);

        /// <summary>
        /// Upload a new document asynchronously
        /// </summary>
        /// <param name="fileName">Name of the file to upload</param>
        /// <param name="fileData">File content as byte array</param>
        /// <returns>The uploaded document information</returns>
        Task<Document> UploadDocumentAsync(string fileName, byte[] fileData);

        /// <summary>
        /// Download a document by ID
        /// </summary>
        /// <param name="documentId">The ID of the document to retrieve</param>
        /// <returns>The document as a stream</returns>
        Stream DownloadDocument(string documentId);

        /// <summary>
        /// Download a document by ID asynchronously
        /// </summary>
        /// <param name="documentId">The ID of the document to retrieve</param>
        /// <returns>The document as a stream</returns>
        Task<Stream> DownloadDocumentAsync(string documentId);

        /// <summary>
        /// Delete a document
        /// </summary>
        /// <param name="documentId">The ID of the document to delete</param>
        void DeleteDocument(string documentId);

        /// <summary>
        /// Delete a document asynchronously
        /// </summary>
        /// <param name="documentId">The ID of the document to delete</param>
        Task DeleteDocumentAsync(string documentId);

        /// <summary>
        /// Update document metadata
        /// </summary>
        /// <param name="documentId">The ID of the document to update</param>
        /// <param name="document">The updated document metadata</param>
        /// <returns>The updated document</returns>
        Document UpdateDocumentMetadata(string documentId, Document document);

        /// <summary>
        /// Update document metadata asynchronously
        /// </summary>
        /// <param name="documentId">The ID of the document to update</param>
        /// <param name="document">The updated document metadata</param>
        /// <returns>The updated document</returns>
        Task<Document> UpdateDocumentMetadataAsync(string documentId, Document document);

        /// <summary>
        /// Get document metadata
        /// </summary>
        /// <param name="documentId">The ID of the document</param>
        /// <returns>The document metadata</returns>
        Document GetDocumentMetadata(string documentId);

        /// <summary>
        /// Get document metadata asynchronously
        /// </summary>
        /// <param name="documentId">The ID of the document</param>
        /// <returns>The document metadata</returns>
        Task<Document> GetDocumentMetadataAsync(string documentId);

        /// <summary>
        /// Get an archived document
        /// </summary>
        /// <param name="archiveDocumentId">The ID of the archived document</param>
        /// <returns>The archived document as a stream</returns>
        Stream GetArchivedDocument(string archiveDocumentId);

        /// <summary>
        /// Get an archived document asynchronously
        /// </summary>
        /// <param name="archiveDocumentId">The ID of the archived document</param>
        /// <returns>The archived document as a stream</returns>
        Task<Stream> GetArchivedDocumentAsync(string archiveDocumentId);

        /// <summary>
        /// Create a new document collection
        /// </summary>
        /// <param name="documentCollection">The document collection to create</param>
        /// <returns>The created document collection</returns>
        DocumentCollection CreateDocumentCollection(DocumentCollection documentCollection);

        /// <summary>
        /// Create a new document collection asynchronously
        /// </summary>
        /// <param name="documentCollection">The document collection to create</param>
        /// <returns>The created document collection</returns>
        Task<DocumentCollection> CreateDocumentCollectionAsync(DocumentCollection documentCollection);

        /// <summary>
        /// Get a document collection
        /// </summary>
        /// <param name="documentCollectionId">The ID of the document collection</param>
        /// <returns>The document collection</returns>
        GetDocumentCollectionResponse GetDocumentCollection(string documentCollectionId);

        /// <summary>
        /// Get a document collection asynchronously
        /// </summary>
        /// <param name="documentCollectionId">The ID of the document collection</param>
        /// <returns>The document collection</returns>
        Task<GetDocumentCollectionResponse> GetDocumentCollectionAsync(string documentCollectionId);

        /// <summary>
        /// Delete a document collection
        /// </summary>
        /// <param name="documentCollectionId">The ID of the document collection to delete</param>
        void DeleteDocumentCollection(string documentCollectionId);

        /// <summary>
        /// Delete a document collection asynchronously
        /// </summary>
        /// <param name="documentCollectionId">The ID of the document collection to delete</param>
        Task DeleteDocumentCollectionAsync(string documentCollectionId);

        /// <summary>
        /// Create a new sign session
        /// </summary>
        /// <param name="signSession">The sign session to create</param>
        /// <returns>The created sign session</returns>
        SignSession CreateSignSession(SignSession signSession);

        /// <summary>
        /// Create a new sign session asynchronously
        /// </summary>
        /// <param name="signSession">The sign session to create</param>
        /// <returns>The created sign session</returns>
        Task<SignSession> CreateSignSessionAsync(SignSession signSession);

        /// <summary>
        /// Get a sign session
        /// </summary>
        /// <param name="signSessionId">The ID of the sign session</param>
        /// <returns>The sign session</returns>
        SignSession GetSignSession(string signSessionId);

        /// <summary>
        /// Get a sign session asynchronously
        /// </summary>
        /// <param name="signSessionId">The ID of the sign session</param>
        /// <returns>The sign session</returns>
        Task<SignSession> GetSignSessionAsync(string signSessionId);

        /// <summary>
        /// Delete a sign session
        /// </summary>
        /// <param name="signSessionId">The ID of the sign session to delete</param>
        void DeleteSignSession(string signSessionId);

        /// <summary>
        /// Delete a sign session asynchronously
        /// </summary>
        /// <param name="signSessionId">The ID of the sign session to delete</param>
        Task DeleteSignSessionAsync(string signSessionId);

        /// <summary>
        /// Retrieve an archived document
        /// </summary>
        /// <param name="documentId">The ID of the document</param>
        /// <returns>The archived document information</returns>
        ArchivedDocument RetrieveArchivedDocument(string documentId);

        /// <summary>
        /// Retrieve an archived document asynchronously
        /// </summary>
        /// <param name="documentId">The ID of the document</param>
        /// <returns>The archived document information</returns>
        Task<ArchivedDocument> RetrieveArchivedDocumentAsync(string documentId);
    }
} 