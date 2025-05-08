using System;
using System.IO;
using System.Threading.Tasks;
using Signicat.Infrastructure;
using Signicat.Sign.Entities;

namespace Signicat.Sign
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
        public Task<Document> UploadDocumentAsync(string fileName, byte[] fileData)
        {
            return PostFileAsync<Document>($"{Urls.Sign}/documents", fileData, fileName);
        }

        /// <inheritdoc />
        public Stream GetDocument(string documentId)
        {
            return GetFile($"{Urls.Sign}/documents/{documentId}");
        }

        /// <inheritdoc />
        public Task<Stream> GetDocumentAsync(string documentId)
        {
            return GetFileAsync($"{Urls.Sign}/documents/{documentId}");
        }

        /// <inheritdoc />
        public void DeleteDocument(string documentId)
        {
            Delete($"{Urls.Sign}/documents/{documentId}");
        }

        /// <inheritdoc />
        public Task DeleteDocumentAsync(string documentId)
        {
            return DeleteAsync($"{Urls.Sign}/documents/{documentId}");
        }

        /// <inheritdoc />
        public Document UpdateDocumentMetadata(string documentId, Document document)
        {
            return Patch<Document>($"{Urls.Sign}/documents/{documentId}/metadata", document);
        }

        /// <inheritdoc />
        public Task<Document> UpdateDocumentMetadataAsync(string documentId, Document document)
        {
            return PatchAsync<Document>($"{Urls.Sign}/documents/{documentId}/metadata", document);
        }

        /// <inheritdoc />
        public Document GetDocumentMetadata(string documentId)
        {
            return Get<Document>($"{Urls.Sign}/documents/{documentId}/metadata");
        }

        /// <inheritdoc />
        public Task<Document> GetDocumentMetadataAsync(string documentId)
        {
            return GetAsync<Document>($"{Urls.Sign}/documents/{documentId}/metadata");
        }

        /// <inheritdoc />
        public Stream GetArchivedDocument(string archiveDocumentId)
        {
            return GetFile($"{Urls.Sign}/archive-documents/{archiveDocumentId}");
        }

        /// <inheritdoc />
        public Task<Stream> GetArchivedDocumentAsync(string archiveDocumentId)
        {
            return GetFileAsync($"{Urls.Sign}/archive-documents/{archiveDocumentId}");
        }

        /// <inheritdoc />
        public DocumentCollection CreateDocumentCollection(DocumentCollection documentCollection)
        {
            return Post<DocumentCollection>($"{Urls.Sign}/document-collections", documentCollection);
        }

        /// <inheritdoc />
        public Task<DocumentCollection> CreateDocumentCollectionAsync(DocumentCollection documentCollection)
        {
            return PostAsync<DocumentCollection>($"{Urls.Sign}/document-collections", documentCollection);
        }

        /// <inheritdoc />
        public GetDocumentCollectionResponse GetDocumentCollection(string documentCollectionId)
        {
            return Get<GetDocumentCollectionResponse>($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <inheritdoc />
        public Task<GetDocumentCollectionResponse> GetDocumentCollectionAsync(string documentCollectionId)
        {
            return GetAsync<GetDocumentCollectionResponse>($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <inheritdoc />
        public void DeleteDocumentCollection(string documentCollectionId)
        {
            Delete($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }

        /// <inheritdoc />
        public Task DeleteDocumentCollectionAsync(string documentCollectionId)
        {
            return DeleteAsync($"{Urls.Sign}/document-collections/{documentCollectionId}");
        }
    }
} 