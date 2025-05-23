using System.IO;
using System.Threading.Tasks;
using Signicat.Infrastructure;
using Signicat.Services.Signing.Sign_v2.Entities;

namespace Signicat.Services.Signing.Sign_v2
{
    /// <summary>
    /// Service for working with the Signicat Sign API.
    /// </summary>
    public class SignService : SignicatBaseService, ISignService
    {
        public SignService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
        }

        public SignService()
        {
        }

        #region Documents

        /// <summary>
        /// Upload a new document.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="fileData">File content as byte array</param>
        /// <returns>Document entity</returns>
        public Document UploadDocument(string fileName, byte[] fileData)
        {
            return PostFile<Document>($"{Urls.Sign}/documents?filename={fileName}", fileData, fileName);
        }

        /// <summary>
        /// Upload a new document.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="fileData">File content as byte array</param>
        /// <returns>Document entity</returns>
        public async Task<Document> UploadDocumentAsync(string fileName, byte[] fileData)
        {
            return await PostFileAsync<Document>($"{Urls.Sign}/documents?filename={fileName}", fileData, fileName);
        }

        /// <summary>
        /// Retrieve a single document
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>The binary contents of the stored document as a stream</returns>
        public Stream GetDocument(string documentId)
        {
            return GetFile($"{Urls.Sign}/documents/{documentId}");
        }

        /// <summary>
        /// Retrieve a single document
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>The binary contents of the stored document as a stream</returns>
        public async Task<Stream> GetDocumentAsync(string documentId)
        {
            return await GetFileAsync($"{Urls.Sign}/documents/{documentId}");
        }

        /// <summary>
        /// Retrieve document info
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>Document metadata</returns>
        public Document GetDocumentInfo(string documentId)
        {
            return Get<Document>($"{Urls.Sign}/documents/{documentId}/metadata");
        }

        /// <summary>
        /// Retrieve document info
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <returns>Document metadata</returns>
        public async Task<Document> GetDocumentInfoAsync(string documentId)
        {
            return await GetAsync<Document>($"{Urls.Sign}/documents/{documentId}/metadata");
        }

        /// <summary>
        /// Update document metadata.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <param name="options">Update metadata request</param>
        /// <returns>Updated document</returns>
        public Document UpdateDocumentMetadata(string documentId, UpdateDocumentMetadataOptions options)
        {
            return Patch<Document>($"{Urls.Sign}/documents/{documentId}/metadata", options);
        }

        /// <summary>
        /// Update document metadata.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        /// <param name="options">Update metadata request</param>
        /// <returns>Updated document</returns>
        public async Task<Document> UpdateDocumentMetadataAsync(string documentId, UpdateDocumentMetadataOptions options)
        {
            return await PatchAsync<Document>($"{Urls.Sign}/documents/{documentId}/metadata", options);
        }

        /// <summary>
        /// Delete a document.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        public void DeleteDocument(string documentId)
        {
            Delete($"{Urls.Sign}/documents/{documentId}");
        }

        /// <summary>
        /// Delete a document.
        /// </summary>
        /// <param name="documentId">Document ID</param>
        public async Task DeleteDocumentAsync(string documentId)
        {
            await DeleteAsync($"{Urls.Sign}/documents/{documentId}");
        }

        #endregion

        #region Document Collections

        /// <summary>
        /// Create a new document collection
        /// </summary>
        /// <param name="options">Options for creating a document collection</param>
        /// <returns>Document collection</returns>
        public DocumentCollection CreateDocumentCollection(CreateDocumentCollectionOptions options)
        {
            return Post<DocumentCollection>($"{Urls.Sign}/document-collections", options);
        }

        /// <summary>
        /// Create a new document collection
        /// </summary>
        /// <param name="options">Options for creating a document collection</param>
        /// <returns>Document collection</returns>
        public async Task<DocumentCollection> CreateDocumentCollectionAsync(CreateDocumentCollectionOptions options)
        {
            return await PostAsync<DocumentCollection>($"{Urls.Sign}/document-collections", options);
        }

        /// <summary>
        /// Retrieve a document collection
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        /// <returns>Document collection</returns>
        public DocumentCollection GetDocumentCollection(string documentCollectionId)
        {
            return Get<DocumentCollection>($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <summary>
        /// Retrieve a document collection
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        /// <returns>Document collection</returns>
        public async Task<DocumentCollection> GetDocumentCollectionAsync(string documentCollectionId)
        {
            return await GetAsync<DocumentCollection>($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <summary>
        /// Delete a document collection
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        public void DeleteDocumentCollection(string documentCollectionId)
        {
            Delete($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <summary>
        /// Delete a document collection
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        public async Task DeleteDocumentCollectionAsync(string documentCollectionId)
        {
            await DeleteAsync($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        #endregion

        #region Sign Sessions

        /// <summary>
        /// Create new signing sessions
        /// </summary>
        /// <param name="options">Request containing options for creating sign sessions</param>
        /// <returns>Sign sessions</returns>
        public SigningSessions CreateSignSessions(CreateSignSessionsOptions options)
        {
            return Post<SigningSessions>($"{Urls.Sign}/signing-sessions", options);
        }

        /// <summary>
        /// Create new signing sessions
        /// </summary>
        /// <param name="options">Request containing options for creating sign sessions</param>
        /// <returns>Sign sessions</returns>
        public async Task<SigningSessions> CreateSignSessionsAsync(CreateSignSessionsOptions options)
        {
            return await PostAsync<SigningSessions>($"{Urls.Sign}/signing-sessions", options);
        }
        
        /// <summary>
        /// Create a new signing session
        /// </summary>
        /// <param name="options">Options for creating a sign session</param>
        /// <returns>Sign sessions</returns>
        public SigningSessions CreateSignSession(CreateSignSession options)
        {
            var request = new CreateSignSessionsOptions { options };
            return CreateSignSessions(request);
        }

        /// <summary>
        /// Create a new signing session
        /// </summary>
        /// <param name="options">Options for creating a sign session</param>
        /// <returns>Sign sessions</returns>
        public async Task<SigningSessions> CreateSignSessionAsync(CreateSignSession options)
        {
            var request = new CreateSignSessionsOptions { options };
            return await CreateSignSessionsAsync(request);
        }

        /// <summary>
        /// Retrieve a signing session
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <returns>Sign session</returns>
        public SigningSession GetSignSession(string sessionId)
        {
            return Get<SigningSession>($"{Urls.Sign}/signing-sessions/{sessionId}");
        }

        /// <summary>
        /// Retrieve a signing session
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        /// <returns>Sign session</returns>
        public async Task<SigningSession> GetSignSessionAsync(string sessionId)
        {
            return await GetAsync<SigningSession>($"{Urls.Sign}/signing-sessions/{sessionId}");
        }

        /// <summary>
        /// Delete a signing session
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        public void DeleteSignSession(string sessionId)
        {
            Delete($"{Urls.Sign}/signing-sessions/{sessionId}");
        }

        /// <summary>
        /// Delete a signing session
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        public async Task DeleteSignSessionAsync(string sessionId)
        {
            await DeleteAsync($"{Urls.Sign}/signing-sessions/{sessionId}");
        }

        #endregion

        #region Archived Documents

        

        /// <summary>
        /// Retrieve an archived document
        /// </summary>
        /// <param name="archiveDocumentId">Archive document ID parameter</param>
        /// <returns>The binary contents of the archived document</returns>
        public Stream GetArchivedDocument(string archiveDocumentId)
        {
            return GetFile($"{Urls.Sign}/archive-documents/{archiveDocumentId}");
        }

        /// <summary>
        /// Retrieve an archived document
        /// </summary>
        /// <param name="archiveDocumentId">Archive document ID parameter</param>
        /// <returns>The binary contents of the archived document</returns>
        public async Task<Stream> GetArchivedDocumentAsync(string archiveDocumentId)
        {
            return await GetFileAsync($"{Urls.Sign}/archive-documents/{archiveDocumentId}");
        }
        #endregion
    }
}