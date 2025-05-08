using System.IO;
using System.Threading.Tasks;
using Signicat.Infrastructure;
using Signicat.Sign;
using Signicat.Sign.Entities;

namespace Signicat.Services.Sign
{
    public class SignService : SignicatBaseService, ISignService
    {
        public SignService()
        {
        }

        public SignService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
        }

        /// <inheritdoc />
        public Document UploadDocument(string fileName, byte[] fileData)
        {
            return PostFile<Document>($"{Urls.Sign}/documents", fileData, fileName);
        }

        /// <inheritdoc />
        public async Task<Document> UploadDocumentAsync(string fileName, byte[] fileData)
        {
            return await PostFileAsync<Document>($"{Urls.Sign}/documents", fileData, fileName);
        }

        /// <inheritdoc />
        public Stream DownloadDocument(string documentId)
        {
            return GetFile($"{Urls.Sign}/documents/{documentId}");
        }

        /// <inheritdoc />
        public async Task<Stream> DownloadDocumentAsync(string documentId)
        {
            return await GetFileAsync($"{Urls.Sign}/documents/{documentId}");
        }

        /// <inheritdoc />
        public void DeleteDocument(string documentId)
        {
            Delete($"{Urls.Sign}/documents/{documentId}");
        }

        /// <inheritdoc />
        public async Task DeleteDocumentAsync(string documentId)
        {
            await DeleteAsync($"{Urls.Sign}/documents/{documentId}");
        }

        /// <inheritdoc />
        public Document UpdateDocumentMetadata(string documentId, Document document)
        {
            return Patch<Document>($"{Urls.Sign}/documents/{documentId}/metadata", document);
        }

        /// <inheritdoc />
        public async Task<Document> UpdateDocumentMetadataAsync(string documentId, Document document)
        {
            return await PatchAsync<Document>($"{Urls.Sign}/documents/{documentId}/metadata", document);
        }

        /// <inheritdoc />
        public Document GetDocumentMetadata(string documentId)
        {
            return Get<Document>($"{Urls.Sign}/documents/{documentId}/metadata");
        }

        /// <inheritdoc />
        public async Task<Document> GetDocumentMetadataAsync(string documentId)
        {
            return await GetAsync<Document>($"{Urls.Sign}/documents/{documentId}/metadata");
        }

        /// <inheritdoc />
        public Stream GetArchivedDocument(string archiveDocumentId)
        {
            return GetFile($"{Urls.Sign}/archive-documents/{archiveDocumentId}");
        }

        /// <inheritdoc />
        public async Task<Stream> GetArchivedDocumentAsync(string archiveDocumentId)
        {
            return await GetFileAsync($"{Urls.Sign}/archive-documents/{archiveDocumentId}");
        }

        /// <inheritdoc />
        public DocumentCollection CreateDocumentCollection(DocumentCollection documentCollection)
        {
            return Post<DocumentCollection>($"{Urls.Sign}/document-collections", documentCollection);
        }

        /// <inheritdoc />
        public async Task<DocumentCollection> CreateDocumentCollectionAsync(DocumentCollection documentCollection)
        {
            return await PostAsync<DocumentCollection>($"{Urls.Sign}/document-collections", documentCollection);
        }

        /// <inheritdoc />
        public GetDocumentCollectionResponse GetDocumentCollection(string documentCollectionId)
        {
            return Get<GetDocumentCollectionResponse>($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <inheritdoc />
        public async Task<GetDocumentCollectionResponse> GetDocumentCollectionAsync(string documentCollectionId)
        {
            return await GetAsync<GetDocumentCollectionResponse>($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <inheritdoc />
        public void DeleteDocumentCollection(string documentCollectionId)
        {
            Delete($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <inheritdoc />
        public async Task DeleteDocumentCollectionAsync(string documentCollectionId)
        {
            await DeleteAsync($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <inheritdoc />
        public SignSession CreateSignSession(SignSession signSession)
        {
            return Post<SignSession>($"{Urls.Sign}/sign-sessions", signSession);
        }

        /// <inheritdoc />
        public async Task<SignSession> CreateSignSessionAsync(SignSession signSession)
        {
            return await PostAsync<SignSession>($"{Urls.Sign}/sign-sessions", signSession);
        }

        /// <inheritdoc />
        public SignSession GetSignSession(string signSessionId)
        {
            return Get<SignSession>($"{Urls.Sign}/sign-sessions/{signSessionId}");
        }

        /// <inheritdoc />
        public async Task<SignSession> GetSignSessionAsync(string signSessionId)
        {
            return await GetAsync<SignSession>($"{Urls.Sign}/sign-sessions/{signSessionId}");
        }

        /// <inheritdoc />
        public void DeleteSignSession(string signSessionId)
        {
            Delete($"{Urls.Sign}/sign-sessions/{signSessionId}");
        }

        /// <inheritdoc />
        public async Task DeleteSignSessionAsync(string signSessionId)
        {
            await DeleteAsync($"{Urls.Sign}/sign-sessions/{signSessionId}");
        }

        /// <inheritdoc />
        public ArchivedDocument RetrieveArchivedDocument(string documentId)
        {
            return Get<ArchivedDocument>($"{Urls.Sign}/archive-documents/{documentId}");
        }

        /// <inheritdoc />
        public async Task<ArchivedDocument> RetrieveArchivedDocumentAsync(string documentId)
        {
            return await GetAsync<ArchivedDocument>($"{Urls.Sign}/archive-documents/{documentId}");
        }
    }
} 