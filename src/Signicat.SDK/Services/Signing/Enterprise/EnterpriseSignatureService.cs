using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Signicat.DigitalEvidenceManagement.Entities;
using Signicat.Infrastructure;

namespace Signicat.Services.Signing.Enterprise
{
    public class EnterpriseSignatureService : SignicatBaseService, IEnterpriseSignatureService
    {
        
        public EnterpriseSignatureService()
        {
        }

        public EnterpriseSignatureService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
        }
        
        public Stream GetDocument(string documentId)
        {
            return GetFile($"{Urls.EnterpriseSign}/archive-documents/{documentId}");
        }

        public Task<Stream> GetDocumentAsync(string documentId)
        {
            return GetFileAsync($"{Urls.EnterpriseSign}/archive-documents/{documentId}");
        }

        public void DeleteDocument(string documentId)
        {
            Delete($"{Urls.EnterpriseSign}/archive-documents/{documentId}");
        }

        public Task DeleteDocumentAsync(string documentId)
        {
            return DeleteAsync($"{Urls.EnterpriseSign}/archive-documents/{documentId}");
        }

        public Task<UploadDocument> UploadSessionDocumentAsync(string fileName, byte[] fileData)
        {
            return PostFormContentDataAsync<UploadDocument>($"{Urls.EnterpriseSign}/documents)",
                new MultipartFormDataContent()
                {
                    new ByteArrayContent(fileData)
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue(fileName)
                            {
                                FileName = fileName
                            }
                        }
                    }
                });
        }

        public UploadDocument UploadSessionDocument(string fileName, byte[] fileData)
        {
            return PostFormContentData<UploadDocument>($"{Urls.EnterpriseSign}/documents)",
                new MultipartFormDataContent()
                {
                    new ByteArrayContent(fileData)
                    {
                        Headers =
                        {
                            ContentDisposition = new ContentDispositionHeaderValue(fileName)
                            {
                                FileName = fileName
                            }
                        }
                    }
                });
        }
    }
}