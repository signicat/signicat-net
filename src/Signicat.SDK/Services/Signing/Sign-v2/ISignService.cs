using System.IO;
using System.Threading.Tasks;
using Signicat.Services.Signing.Sign_v2.Entities;

namespace Signicat.Services.Signing.Sign_v2
{
    /// <summary>
    /// Interface for the Signicat Sign API service
    /// </summary>
    public interface ISignService
    {
        #region Documents
        
        /// <summary>
        /// Upload a new document.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="fileData">File content as byte array</param>
        /// <returns>Document entity</returns>
        Document UploadDocument(string fileName, byte[] fileData);
        
        /// <summary>
        /// Upload a new document.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="fileData">File content as byte array</param>
        /// <returns>Document entity</returns>
        Task<Document> UploadDocumentAsync(string fileName, byte[] fileData);
        
        /// <summary>
        /// Retrieve a single document
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>The binary contents of the stored document as a stream</returns>
        Stream GetDocument(string documentId);
        
        /// <summary>
        /// Retrieve a single document
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>The binary contents of the stored document as a stream</returns>
        Task<Stream> GetDocumentAsync(string documentId);
        
        /// <summary>
        /// Retrieve document info
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>Document metadata</returns>
        Document GetDocumentInfo(string documentId);
        
        /// <summary>
        /// Retrieve document info
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>Document metadata</returns>
        Task<Document> GetDocumentInfoAsync(string documentId);
        
        /// <summary>
        /// Update document metadata.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <param name="options">Update metadata request</param>
        /// <returns>Updated document</returns>
        Document UpdateDocumentMetadata(string documentId, UpdateDocumentMetadataOptions options);
        
        /// <summary>
        /// Update document metadata.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <param name="options">Update metadata request</param>
        /// <returns>Updated document</returns>
        Task<Document> UpdateDocumentMetadataAsync(string documentId, UpdateDocumentMetadataOptions options);
        
        /// <summary>
        /// Delete a document.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        void DeleteDocument(string documentId);
        
        /// <summary>
        /// Delete a document.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        Task DeleteDocumentAsync(string documentId);
        
        #endregion
        
        #region Document Collections
        
        /// <summary>
        /// Create a new document collection.
        /// </summary>
        /// <param name="options">Options for creating a document collection</param>
        /// <returns>Document collection</returns>
        DocumentCollection CreateDocumentCollection(CreateDocumentCollectionOptions options);
        
        /// <summary>
        /// Create a new document collection.
        /// </summary>
        /// <param name="options">Options for creating a document collection</param>
        /// <returns>Document collection</returns>
        Task<DocumentCollection> CreateDocumentCollectionAsync(CreateDocumentCollectionOptions options);
        
        /// <summary>
        /// Get a document collection by ID.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        /// <returns>Document collection</returns>
        DocumentCollection GetDocumentCollection(string documentCollectionId);
        
        /// <summary>
        /// Get a document collection by ID.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        /// <returns>Document collection</returns>
        Task<DocumentCollection> GetDocumentCollectionAsync(string documentCollectionId);
        
        /// <summary>
        /// Delete a document collection.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        void DeleteDocumentCollection(string documentCollectionId);
        
        /// <summary>
        /// Delete a document collection.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        Task DeleteDocumentCollectionAsync(string documentCollectionId);
        
        #endregion
        
        #region Sign Sessions
        
        /// <summary>
        /// Create new sign sessions for document collections.
        /// </summary>
        /// <param name="options">Request containing options for creating sign sessions</param>
        /// <returns>Sign sessions</returns>
        SigningSessions CreateSignSessions(CreateSignSessionsOptions options);
        
        /// <summary>
        /// Create new sign sessions for document collections.
        /// </summary>
        /// <param name="options">Request containing options for creating sign sessions</param>
        /// <returns>Sign sessions</returns>
        Task<SigningSessions> CreateSignSessionsAsync(CreateSignSessionsOptions options);
        
        /// <summary>
        /// Get a sign session by ID.
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <returns>Sign session</returns>
        SigningSession GetSignSession(string sessionId);
        
        /// <summary>
        /// Get a sign session by ID.
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <returns>Sign session</returns>
        Task<SigningSession> GetSignSessionAsync(string sessionId);
        
        /// <summary>
        /// Delete a sign session.
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        void DeleteSignSession(string sessionId);
        
        /// <summary>
        /// Delete a sign session.
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        Task DeleteSignSessionAsync(string sessionId);
        
        #endregion
        
        #region Archived Documents
        /// <summary>
        /// Retrieve an archived document
        /// </summary>
        /// <param name="archiveDocumentId">Archive document ID parameter</param>
        /// <returns>The binary contents of the archived document</returns>
        Stream GetArchivedDocument(string archiveDocumentId);
        
        /// <summary>
        /// Retrieve an archived document
        /// </summary>
        /// <param name="archiveDocumentId">Archive document ID parameter</param>
        /// <returns>The binary contents of the archived document</returns>
        Task<Stream> GetArchivedDocumentAsync(string archiveDocumentId);
        #endregion
    }
}