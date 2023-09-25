using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Signicat.Infrastructure;
using Signicat.Services.Signing.Enterprise.Entities;

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
            return GetFile($"{Urls.EnterpriseSign}/documents/{documentId}");
        }

        public Task<Stream> GetDocumentAsync(string documentId)
        {
            return GetFileAsync($"{Urls.EnterpriseSign}/documents/{documentId}");
        }

        public void DeleteDocument(string documentId)
        {
            Delete($"{Urls.EnterpriseSign}/documents/{documentId}");
        }

        public Task DeleteDocumentAsync(string documentId)
        {
            return DeleteAsync($"{Urls.EnterpriseSign}/documents/{documentId}");
        }

        public Task<UploadDocument> UploadSessionDocumentAsync(string fileName, byte[] fileData)
        {
            return PostFileAsync<UploadDocument>($"{Urls.EnterpriseSign}/documents", fileData, fileName);
        }

        public UploadDocument UploadSessionDocument(string fileName, byte[] fileData)
        {
            return PostFile<UploadDocument>($"{Urls.EnterpriseSign}/documents", fileData, fileName);
        }

        public Stream GetArchivedDocument(string archiveId)
        {
            return GetFile($"{Urls.EnterpriseSign}/archive-documents/{archiveId}");
        }

        public Task<Stream> GetArchivedDocumentAsync(string archiveId)
        {
            return GetFileAsync($"{Urls.EnterpriseSign}/archive-documents/{archiveId}");
        }

        public void DeleteArchivedDocument(string archiveId)
        {
            Delete($"{Urls.EnterpriseSign}archive-documents/{archiveId}");
        }

        public Task DeleteArchivedDocumentAsync(string archiveId)
        {
            return DeleteAsync($"{Urls.EnterpriseSign}archive-documents/{archiveId}");
        }
        
        
        
        public SigningOrder Create(SigningOrderCreateOptions signingOrder)
        {
            var url = Urls.EnterpriseSignOrders;

            var response = Post<SigningOrder>(url, signingOrder);
            
            return response;
        }
        
        public async Task<SigningOrder> CreateAsync(SigningOrderCreateOptions signingOrder)
        {
            var url = Urls.EnterpriseSignOrders;

            var response = await PostAsync<SigningOrder>(url, signingOrder);
            
            return response;
        }
        
        public SigningOrder GetOrder(string signOrderId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}";

            return Get<SigningOrder>(url);
        }
        
        public async Task<SigningOrder> GetOrderAsync(string signOrderId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}";

            return await GetAsync<SigningOrder>(url);
        }

        public IEnumerable<TaskForwardDetails> GetOrderForwardDetails(string signOrderId, Guid taskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/forwards";

            return Get<IEnumerable<TaskForwardDetails>>(url);
        }
        
        public async Task<IEnumerable<TaskForwardDetails>> GetOrderForwardDetailsAsync(string signOrderId, Guid taskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/forwards";

            return await GetAsync<IEnumerable<TaskForwardDetails>>(url);
        }
        
        

        public Stream GetOriginalFile(string signOrderId, Guid taskId, Guid documentId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/documents/{documentId}/original";

            return GetFile(url);
        }
        
        public Task<Stream> GetOriginalFileAsync(string signOrderId, Guid taskId, Guid documentId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/documents/{documentId}/original";

            return GetFileAsync(url);
        }
        

        public Stream GetGeneratedDocument(string signOrderId, Guid taskId, Guid documentId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/documents/{documentId}/generated";

            return GetFile(url);
        }
        
        public Task<Stream> GetGeneratedDocumentAsync(string signOrderId, Guid taskId, Guid documentId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/documents/{documentId}/generated";

            return GetFileAsync(url);
        }

        public Stream GetSignedDocument(string signOrderId, Guid taskId, Guid documentId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/documents/{documentId}/result";

            return GetFile(url);
        }
        
        public Task<Stream> GetSignedDocumentAsync(string signOrderId, Guid taskId, Guid documentId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/documents/{documentId}/result";

            return GetFileAsync(url);
        }

        public Stream GetPackagedTaskResult(string signOrderId, Guid packagingTaskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/packaging-tasks/{packagingTaskId}/result";

            return GetFile(url);
        }
        
        public Task<Stream> GetPackagedTaskResultAsync(string signOrderId, Guid packagingTaskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/packaging-tasks/{packagingTaskId}/result";

            return GetFileAsync(url);
        }

        public PackagingTaskStatusInfo GetPackagingStatus(string signOrderId, Guid packagingTaskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/packaging-tasks/{packagingTaskId}/status";

            return Get<PackagingTaskStatusInfo>(url);
        }
        
        public async Task<PackagingTaskStatusInfo> GetPackagingStatusAsync(string signOrderId, Guid packagingTaskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/packaging-tasks/{packagingTaskId}/status";

            return await GetAsync<PackagingTaskStatusInfo>(url);
        }

        public TaskStatusInfo GetTaskStatus(string signOrderId, Guid taskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/status";

            return Get<TaskStatusInfo>(url);
        }
        
        public async Task<TaskStatusInfo> GetTaskStatusAsync(string signOrderId, Guid taskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/status";

            return await GetAsync<TaskStatusInfo>(url);
        }

        public IEnumerable<Event> GetTaskEvents(string signOrderId, Guid taskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/events";

            return Get<IEnumerable<Event>>(url);
            
        }
        
        public async Task<IEnumerable<Event>> GetTaskEventsAsync(string signOrderId, Guid taskId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}/tasks/{taskId}/events";

            return await GetAsync<IEnumerable<Event>>(url);
        }

        public void DeleteSignOrder(string signOrderId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}";
            Delete(url);
        }
        
        public async Task DeleteSignOrderAsync(string signOrderId)
        {
            var url = $"{Urls.EnterpriseSignOrders}/{signOrderId}";
            await DeleteAsync(url);
        }


        private async Task<byte[]> GetFileAsBytes(string url)
        {
            var response = await GetFileAsync(url);

            using (var ms = new MemoryStream())
            {
                await response.CopyToAsync(ms);

                return ms.ToArray();

            }
        }
    }
}