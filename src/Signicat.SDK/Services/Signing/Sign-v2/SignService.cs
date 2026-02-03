using System.IO;
using System.Net.Http;
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
        public Document UploadDocument(string fileName, Stream fileData)
        {
            return PostFile<Document>($"{Urls.Sign}/documents", fileData, fileName);
        }

        /// <summary>
        /// Upload a new document.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="fileData">File content as a stream</param>
        /// <returns>Document entity</returns>
        public Task<Document> UploadDocumentAsync(string fileName, Stream fileData)
        {
            return PostFileAsync<Document>($"{Urls.Sign}/documents", fileData, fileName);
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
        public Task<Stream> GetDocumentAsync(string documentId)
        {
            return GetFileAsync($"{Urls.Sign}/documents/{documentId}");
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
        public Task<Document> GetDocumentInfoAsync(string documentId)
        {
            return GetAsync<Document>($"{Urls.Sign}/documents/{documentId}/metadata");
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
        public Task<Document> UpdateDocumentMetadataAsync(string documentId,
            UpdateDocumentMetadataOptions options)
        {
            return PatchAsync<Document>($"{Urls.Sign}/documents/{documentId}/metadata", options);
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
        public Task DeleteDocumentAsync(string documentId)
        {
            return DeleteAsync($"{Urls.Sign}/documents/{documentId}");
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
        public Task<DocumentCollection> CreateDocumentCollectionAsync(CreateDocumentCollectionOptions options)
        {
            return PostAsync<DocumentCollection>($"{Urls.Sign}/document-collections", options);
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
        public Task<DocumentCollection> GetDocumentCollectionAsync(string documentCollectionId)
        {
            return GetAsync<DocumentCollection>($"{Urls.Sign}/document-collections/{documentCollectionId}");
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
        public Task DeleteDocumentCollectionAsync(string documentCollectionId)
        {
            return DeleteAsync($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <summary>
        /// Create a new document collection package.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        public void CreateDocumentCollectionPackage(string documentCollectionId)
        {
            Post($"{Urls.Sign}/document-collections/{documentCollectionId}/package");
        }

        /// <summary>
        /// Create a new document collection package.
        /// </summary>
        /// <param name="documentCollectionId">Document Collection ID</param>
        public Task CreateDocumentCollectionPackageAsync(string documentCollectionId)
        {
            return PostAsync($"{Urls.Sign}/document-collections/{documentCollectionId}/package");
        }

        #endregion

        #region Sign Sessions

        /// <summary>
        /// Retrieve a paginated list of signing sessions
        /// </summary>
        /// <param name="options">Query parameters</param>
        /// <returns>A paginated list of signing sessions</returns>
        public PaginatedSigningSessionResponse ListSigningSessions(SigningSessionListOptions options)
        {
            var url = $"{Urls.Sign}/signing-sessions".AppendQueryParams(options.ToQueryParams(),
                "yyyy-MM-ddTHH:mm:ss'Z'");
            return Get<PaginatedSigningSessionResponse>(url);
        }

        /// <summary>
        /// Retrieve a paginated list of signing sessions
        /// </summary>
        /// <param name="options">Query parameters</param>
        /// <returns>A paginated list of signing sessions</returns>
        public Task<PaginatedSigningSessionResponse> ListSigningSessionsAsync(SigningSessionListOptions options)
        {
            var url = $"{Urls.Sign}/signing-sessions".AppendQueryParams(options.ToQueryParams(),
                "yyyy-MM-ddTHH:mm:ss'Z'");
            return GetAsync<PaginatedSigningSessionResponse>(url);
        }

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
        public Task<SigningSessions> CreateSignSessionsAsync(CreateSignSessionsOptions options)
        {
            return PostAsync<SigningSessions>($"{Urls.Sign}/signing-sessions", options);
        }

        /// <summary>
        /// Create a new signing session
        /// </summary>
        /// <param name="options">Options for creating a sign session</param>
        /// <returns>Sign sessions</returns>
        public SigningSessions CreateSignSession(CreateSignSession options)
        {
            var request = new CreateSignSessionsOptions {options};
            return CreateSignSessions(request);
        }

        /// <summary>
        /// Create a new signing session
        /// </summary>
        /// <param name="options">Options for creating a sign session</param>
        /// <returns>Sign sessions</returns>
        public Task<SigningSessions> CreateSignSessionAsync(CreateSignSession options)
        {
            var request = new CreateSignSessionsOptions {options};
            return CreateSignSessionsAsync(request);
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
        public Task<SigningSession> GetSignSessionAsync(string sessionId)
        {
            return GetAsync<SigningSession>($"{Urls.Sign}/signing-sessions/{sessionId}");
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
        public Task DeleteSignSessionAsync(string sessionId)
        {
            return DeleteAsync($"{Urls.Sign}/signing-sessions/{sessionId}");
        }

        /// <summary>
        /// Create a new signing session package.
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        public void CreateSigningSessionPackage(string sessionId)
        {
            Post($"{Urls.Sign}/signing-sessions/{sessionId}/package");
        }

        /// <summary>
        /// Create a new signing session package.
        /// </summary>
        /// <param name="sessionId">Session ID</param>
        public Task CreateSigningSessionPackageAsync(string sessionId)
        {
            return PostAsync($"{Urls.Sign}/signing-sessions/{sessionId}/package");
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
        public Task<Stream> GetArchivedDocumentAsync(string archiveDocumentId)
        {
            return GetFileAsync($"{Urls.Sign}/archive-documents/{archiveDocumentId}");
        }

        #endregion
    }
}