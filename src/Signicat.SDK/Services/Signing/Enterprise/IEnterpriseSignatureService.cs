using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Signicat.Services.Signing.Enterprise.Entities;

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
        
        
        /// <summary>
        ///     Get a document from Signicat's document archive
        /// </summary>
        /// <param name="archiveId">The ID of the document stored in Signicat's document archive.</param>
        /// <returns>Document file as stream</returns>
        Stream GetArchivedDocument(string archiveId);
        
        /// <summary>
        ///     Get a document from Signicat's document archive async
        /// </summary>
        /// <param name="archiveId">The ID of the document stored in Signicat's document archive.</param>
        /// <returns>Document file as stream</returns>
        Task<Stream> GetArchivedDocumentAsync(string archiveId);
        
        
        /// <summary>
        ///     Delete a document from Signicat's document archive
        /// </summary>
        /// <param name="archiveId">The ID of the document stored in Signicat's document archive.</param>
        void DeleteArchivedDocument(string archiveId);
        
        /// <summary>
        ///     Delete a document from Signicat's document archive async
        /// </summary>
        /// <param name="archiveId">The ID of the document stored in Signicat's document archive.</param>
        Task DeleteArchivedDocumentAsync(string archiveId);
        
        
        /// <summary>
        /// Create a new signing order async
        /// </summary>
        /// <param name="signingOrder"></param>
        /// <returns></returns>
        Task<SigningOrder> CreateAsync(SigningOrderCreateOptions signingOrder);
        
        /// <summary>
        /// Create a new signing order
        /// </summary>
        /// <param name="signingOrder"></param>
        /// <returns></returns>
        SigningOrder Create(SigningOrderCreateOptions signingOrder);

        /// <summary>
        /// Return the signing order with the given ID
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <returns></returns>
        SigningOrder GetOrder(string signOrderId);
        
        /// <summary>
        /// Return the signing order with the given ID async
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <returns></returns>
        Task<SigningOrder> GetOrderAsync(string signOrderId);
        
        /// <summary>
        /// Get an original document from Signicat's document storage
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        IEnumerable<TaskForwardDetails> GetOrderForwardDetails(string signOrderId, Guid taskId);
        
        /// <summary>
        /// Get an original document from Signicat's document storage async
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task<IEnumerable<TaskForwardDetails>> GetOrderForwardDetailsAsync(string signOrderId, Guid taskId);

        /// <summary>
        /// Get an original document from Signicat's document storage
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Stream GetOriginalFile(string signOrderId, Guid taskId, string documentId);
        
        /// <summary>
        /// Get an original document from Signicat's document storage async
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<Stream> GetOriginalFileAsync(string signOrderId, Guid taskId, string documentId);

        /// <summary>
        /// Get a generated document from Signicat's document storage
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Stream GetGeneratedDocument(string signOrderId, Guid taskId, string documentId);
        
        /// <summary>
        /// Get a generated document from Signicat's document storage async
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<Stream> GetGeneratedDocumentAsync(string signOrderId, Guid taskId, string documentId);

        /// <summary>
        /// Get a signed document from Signicat's document storage
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Stream GetSignedDocument(string signOrderId, Guid taskId, string documentId);
        
        /// <summary>
        /// Get a signed document from Signicat's document storage async
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId"></param>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<Stream> GetSignedDocumentAsync(string signOrderId, Guid taskId, string documentId);

        /// <summary>
        /// Get the result document of a packaging task
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="packagingTaskId"></param>
        /// <returns></returns>
        Stream GetPackagedTaskResult(string signOrderId, Guid packagingTaskId);
        
        
        /// <summary>
        /// Get the result document of a packaging task async
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="packagingTaskId"></param>
        /// <returns></returns>
        Task<Stream> GetPackagedTaskResultAsync(string signOrderId, Guid packagingTaskId);

        /// <summary>
        /// Get the status of a signing order packaging task
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="packagingTaskId"></param>
        /// <returns></returns>
        PackagingTaskStatusInfo GetPackagingStatus(string signOrderId, Guid packagingTaskId);
        
        
        /// <summary>
        /// Get the status of a signing order packaging task async
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="packagingTaskId"></param>
        /// <returns></returns>
        Task<PackagingTaskStatusInfo> GetPackagingStatusAsync(string signOrderId, Guid packagingTaskId);

        /// <summary>
        /// Get task status
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId">The ID of the task</param>
        /// <returns></returns>
        TaskStatusInfo GetTaskStatus(string signOrderId, Guid taskId);
        
        /// <summary>
        /// Get task status async
        /// </summary>
        /// <param name="signOrderId">Signing order id, returned when sign order was created</param>
        /// <param name="taskId">The ID of the task</param>
        /// <returns></returns>
        Task<TaskStatusInfo> GetTaskStatusAsync(string signOrderId, Guid taskId);

        /// <summary>
        /// Get a list of events that have occurred on a task
        /// </summary>
        /// <param name="signOrderId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        IEnumerable<Event> GetTaskEvents(string signOrderId, Guid taskId);
        
        
        /// <summary>
        /// Get a list of events that have occurred on a task async
        /// </summary>
        /// <param name="signOrderId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task<IEnumerable<Event>> GetTaskEventsAsync(string signOrderId, Guid taskId);

        /// <summary>
        /// Deletes a sign order
        /// </summary>
        /// <param name="signOrderId"></param>
        /// <returns></returns>
        void DeleteSignOrder(string signOrderId);
        
        /// <summary>
        /// Deletes a sign order async
        /// </summary>
        /// <param name="signOrderId"></param>
        /// <returns></returns>
        Task DeleteSignOrderAsync(string signOrderId);
        
        
    }
}