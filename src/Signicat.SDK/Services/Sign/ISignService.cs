using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Signicat.Services.Sign.Entities;

namespace Signicat.Services.Sign
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
        /// <param name="request">Update metadata request</param>
        /// <returns>Updated document</returns>
        Document UpdateDocumentMetadata(string documentId, UpdateDocumentMetadataRequest request);
        
        /// <summary>
        /// Update document metadata.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <param name="request">Update metadata request</param>
        /// <returns>Updated document</returns>
        Task<Document> UpdateDocumentMetadataAsync(string documentId, UpdateDocumentMetadataRequest request);
        
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
        /// <returns>Document collection response</returns>
        DocumentCollectionResponse GetDocumentCollection(string documentCollectionId);
        
        /// <summary>
        /// Get a document collection by ID.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        /// <returns>Document collection response</returns>
        Task<DocumentCollectionResponse> GetDocumentCollectionAsync(string documentCollectionId);
        
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
        /// Create a new sign session for a document collection.
        /// </summary>
        /// <param name="options">Options for creating a sign session</param>
        /// <returns>Sign session</returns>
        SignSession CreateSignSession(CreateSignSessionOptions options);
        
        /// <summary>
        /// Create a new sign session for a document collection.
        /// </summary>
        /// <param name="options">Options for creating a sign session</param>
        /// <returns>Sign session</returns>
        Task<SignSession> CreateSignSessionAsync(CreateSignSessionOptions options);
        
        /// <summary>
        /// Get a sign session by ID.
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <returns>Sign session</returns>
        SignSession GetSignSession(string sessionId);
        
        /// <summary>
        /// Get a sign session by ID.
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <returns>Sign session</returns>
        Task<SignSession> GetSignSessionAsync(string sessionId);
        
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
        /// Get archived documents for a collection.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        /// <returns>List of archived documents</returns>
        List<ArchivedDocument> GetArchivedDocuments(string documentCollectionId);
        
        /// <summary>
        /// Get archived documents for a collection.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        /// <returns>List of archived documents</returns>
        Task<List<ArchivedDocument>> GetArchivedDocumentsAsync(string documentCollectionId);
        
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