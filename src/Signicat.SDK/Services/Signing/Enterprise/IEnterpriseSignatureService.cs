using System.IO;
using System.Threading.Tasks;
using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.Services.Signing.Enterprise
{
    public interface IEnterpriseSignatureService
    {
        /// <summary>
        ///     Get a document from Signicat's document storage backend 
        /// </summary>
        /// <param name="documentId">Id of the document</param>
        /// <returns>Document file as stream</returns>
        Stream GetDocument(string documentId);
        
        /// <summary>
        ///     Get a document from Signicat's document storage backend async
        /// </summary>
        /// <param name="documentId">Id of the document</param>
        /// <returns>Document file as stream</returns>
        Task<Stream> GetDocumentAsync(string documentId);

        /// <summary>
        ///     Delete a document from Signicat's document storage backend
        /// </summary>
        /// <param name="documentId">Id of the document</param>
        void DeleteDocument(string documentId);
        
        /// <summary>
        ///     Delete a document from Signicat's document storage backend async
        /// </summary>
        /// <param name="documentId">Id of the document</param>
        Task DeleteDocumentAsync(string documentId);
        
        /// <summary>
        ///     Upload a document to Signicat's session data storage.
        /// <remarks>File must be a PDF document</remarks>
        /// </summary>
        /// <param name="fileName">Filename for the file to be uploaded</param>
        /// <param name="fileData">File content as byte array for the file to be uploaded</param>
        /// <returns></returns>
        Task<UploadDocument> UploadSessionDocumentAsync (string fileName, byte[] fileData);
        
        /// <summary>
        ///     Upload a document to Signicat's session data storage async.
        /// <remarks>File must be a PDF document</remarks>
        /// </summary>
        /// <param name="fileName">Filename for the file to be uploaded</param>
        /// <param name="fileData">File content as byte array for the file to be uploaded</param>
        /// <returns></returns>
        UploadDocument UploadSessionDocument(string fileName, byte[] fileData);
    }
}