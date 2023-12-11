using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Signicat.Services.Signing.Express.Entities;

namespace Signicat.Services.Signing.Express
{
    public interface IExpressSignatureService
    {
        /// <summary>
        /// Retrieves details of a single document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Document GetDocument(Guid documentId);

        /// <summary>
        /// Retrieves  details of a single document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<Document> GetDocumentAsync(Guid documentId);

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="documentCreateOptions"></param>
        /// <returns></returns>
        Document CreateDocument(DocumentCreateOptions documentCreateOptions);

        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="documentCreateOptions"></param>
        /// <returns></returns>
        Task<Document> CreateDocumentAsync(DocumentCreateOptions documentCreateOptions);

        /// <summary>
        /// Updates a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="documentUpdateOptions"></param>
        /// <returns></returns>
        Document UpdateDocument(Guid documentId, DocumentUpdateOptions documentUpdateOptions);

        /// <summary>
        /// Updates a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="documentUpdateOptions"></param>
        /// <returns></returns>
        Task<Document> UpdateDocumentAsync(Guid documentId, DocumentUpdateOptions documentUpdateOptions);

        /// <summary>
        /// Cancels a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        void CancelDocument(Guid documentId, string reason = null);

        /// <summary>
        /// Cancels a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        Task CancelDocumentAsync(Guid documentId, string reason = null);

        /// <summary>
        /// Retrieves the status of a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        DocumentStatusSummary GetDocumentStatus(Guid documentId);

        /// <summary>
        /// Retrieves the status of a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<DocumentStatusSummary> GetDocumentStatusAsync(Guid documentId);

        /// <summary>
        /// Retrieves information about a document.
        /// </summary>
        /// <param name="documentId"></param>
        DocumentSummary GetDocumentSummary(Guid documentId);

        /// <summary>
        /// Retrieves information about a document.
        /// </summary>
        /// <param name="documentId"></param>
        Task<DocumentSummary> GetDocumentSummaryAsync(Guid documentId);

        /// <summary>
        /// Queries your documents using the provided parameters.
        /// </summary>
        /// <param name="externalId"></param>
        /// <param name="signerId"></param>
        /// <param name="externalSignerId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="lastUpdated"></param>
        /// <param name="signedDate"></param>
        /// <param name="nameOfSigner"></param>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <param name="tags"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        CollectionWithPaging<DocumentSummary> ListDocumentSummaries(
            string externalId = null,
            Guid? signerId = null,
            string externalSignerId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            DateTime? lastUpdated = null,
            DateTime? signedDate = null,
            string nameOfSigner = null,
            string title = null,
            DocumentStatus? status = null,
            string tags = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        /// Queries your documents using the provided parameters.
        /// </summary>
        /// <param name="externalId"></param>
        /// <param name="signerId"></param>
        /// <param name="externalSignerId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="lastUpdated"></param>
        /// <param name="signedDate"></param>
        /// <param name="nameOfSigner"></param>
        /// <param name="title"></param>
        /// <param name="status"></param>
        /// <param name="tags"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<CollectionWithPaging<DocumentSummary>> ListDocumentSummariesAsync(
            string externalId = null,
            Guid? signerId = null,
            string externalSignerId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            DateTime? lastUpdated = null,
            DateTime? signedDate = null,
            string nameOfSigner = null,
            string title = null,
            DocumentStatus? status = null,
            string tags = null,
            int? offset = null,
            int? limit = null);

        /// <summary>
        /// Retrieves the details of a single signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <returns></returns>
        Signer GetSigner(Guid documentId, Guid signerId);

        /// <summary>
        /// Retrieves the details of a single signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <returns></returns>
        Task<Signer> GetSignerAsync(Guid documentId, Guid signerId);

        /// <summary>
        /// Creates a new signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerOptions"></param>
        /// <returns></returns>
        Signer CreateSigner(Guid documentId, SignerOptions signerOptions);

        /// <summary>
        /// Creates a new signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerOptions"></param>
        /// <returns></returns>
        Task<Signer> CreateSignerAsync(Guid documentId, SignerOptions signerOptions);

        /// <summary>
        /// Updates a signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <param name="signerOptions"></param>
        /// <returns></returns>
        Signer UpdateSigner(Guid documentId, Guid signerId, SignerOptions signerOptions);

        /// <summary>
        /// Updates a signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <param name="signerOptions"></param>
        /// <returns></returns>
        Task<Signer> UpdateSignerAsync(Guid documentId, Guid signerId, SignerOptions signerOptions);

        /// <summary>
        /// Deletes a signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        void DeleteSigner(Guid documentId, Guid signerId);

        /// <summary>
        /// Deletes a signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        Task DeleteSignerAsync(Guid documentId, Guid signerId);

        /// <summary>
        /// Lists all signers of a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        List<Signer> ListSigners(Guid documentId);

        /// <summary>
        /// Lists all signers of a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<List<Signer>> ListSignersAsync(Guid documentId);

        /// <summary>
        /// Retrieves the details of a single attachment.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        Attachment GetAttachment(Guid documentId, Guid attachmentId);

        /// <summary>
        /// Retrieves the details of a single attachment.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        Task<Attachment> GetAttachmentAsync(Guid documentId, Guid attachmentId);

        /// <summary>
        /// Adds an attachment to the specified document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentOptions"></param>
        /// <returns></returns>
        Attachment CreateAttachment(Guid documentId, AttachmentOptions attachmentOptions);

        /// <summary>
        /// Adds an attachment to the specified document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentOptions"></param>
        /// <returns></returns>
        Task<Attachment> CreateAttachmentAsync(Guid documentId, AttachmentOptions attachmentOptions);

        /// <summary>
        /// Updates the specified attachment (Will only take affect if no one has signed the document yet).
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="attachmentOptions"></param>
        /// <returns></returns>
        Attachment UpdateAttachment(Guid documentId, Guid attachmentId, AttachmentOptions attachmentOptions);

        /// <summary>
        /// Updates the specified attachment (Will only take affect if no one has signed the document yet).
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="attachmentOptions"></param>
        /// <returns></returns>
        Task<Attachment> UpdateAttachmentAsync(Guid documentId, Guid attachmentId, AttachmentOptions attachmentOptions);

        /// <summary>
        /// Deletes the specified attachment (Will only take affect if no one has signed the document yet).
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        void DeleteAttachment(Guid documentId, Guid attachmentId);

        /// <summary>
        /// Deletes the specified attachment (Will only take affect if no one has signed the document yet).
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        Task DeleteAttachmentAsync(Guid documentId, Guid attachmentId);

        /// <summary>
        /// Returns a list of all attachments for the specified document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        List<Attachment> ListAttachments(Guid documentId);

        /// <summary>
        /// Returns a list of all attachments for the specified document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<List<Attachment>> ListAttachmentsAsync(Guid documentId);

        /// <summary>
        /// Retrieves the signed document file.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Stream GetFile(Guid documentId, FileFormat fileFormat);

        /// <summary>
        /// Retrieves the signed document file.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<Stream> GetFileAsync(Guid documentId, FileFormat fileFormat);

        /// <summary>
        /// Retrieves the signed document file for the specified signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Stream GetFileForSigner(Guid documentId, Guid signerId, FileFormat fileFormat);

        /// <summary>
        /// Retrieves the signed document file for the specified signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="signerId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<Stream> GetFileForSignerAsync(Guid documentId, Guid signerId, FileFormat fileFormat);

        /// <summary>
        /// Retrieves the attachment file.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Stream GetAttachmentFile(Guid documentId, Guid attachmentId, FileFormat fileFormat);

        /// <summary>
        /// Retrieves the attachment file.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<Stream> GetAttachmentFileAsync(Guid documentId, Guid attachmentId, FileFormat fileFormat);

        /// <summary>
        /// Retrieves the attachment file for the specified signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="signerId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Stream GetAttachmentFileForSigner(Guid documentId, Guid attachmentId, Guid signerId, FileFormat fileFormat);

        /// <summary>
        /// Retrieves the attachment file for the specified signer.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="attachmentId"></param>
        /// <param name="signerId"></param>
        /// <param name="fileFormat"></param>
        /// <returns></returns>
        Task<Stream> GetAttachmentFileForSignerAsync(Guid documentId, Guid attachmentId, Guid signerId, FileFormat fileFormat);

        /// <summary>
        /// Returns a list of all notifications that has been sent / attempted sent for a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        List<NotificationLogItem> ListNotifications(Guid documentId);

        /// <summary>
        /// Returns a list of all notifications that has been sent / attempted sent for a document.
        /// </summary>
        /// <param name="documentId"></param>
        /// <returns></returns>
        Task<List<NotificationLogItem>> ListNotificationsAsync(Guid documentId);

        /// <summary>
        /// Sends a reminder to the specified signers.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="manualReminder"></param>
        /// <returns></returns>
        ManualReminder SendReminders(Guid documentId, ManualReminder manualReminder);

        /// <summary>
        /// Sends a reminder to the specified signers.
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="manualReminder"></param>
        /// <returns></returns>
        Task<ManualReminder> SendRemindersAsync(Guid documentId, ManualReminder manualReminder);

        /// <summary>
        /// Returns a list of all color themes that can be used in the signature application.
        /// </summary>
        /// <returns></returns>
        List<ColorTheme> ListThemes();

        /// <summary>
        /// Returns a list of all color themes that can be used in the signature application.
        /// </summary>
        /// <returns></returns>
        Task<List<ColorTheme>> ListThemesAsync();

        /// <summary>
        /// Returns a list of all spinners that can be used in the signature application.
        /// </summary>
        /// <returns></returns>
        List<Spinner> ListSpinners();

        /// <summary>
        /// Returns a list of all spinners that can be used in the signature application.
        /// </summary>
        /// <returns></returns>
        Task<List<Spinner>> ListSpinnersAsync();

        /// <summary>
        /// Returns a list of all the supported signature-methods.
        /// </summary>
        /// <param name="mechanism">The available signature methods may differ between signature-mechanisms</param>
        /// <param name="fileType">The available signature methods may differ between file-types</param>
        /// <param name="language">Language for the title/description returned</param>
        /// <param name="signableAttachments">When using signable attachments some signature-methods may not be available</param>
        /// <returns></returns>
        List<AppSignatureMethod> ListSignatureMethods(SignatureMechanism mechanism, FileType fileType, Language language, bool signableAttachments);

        /// <summary>
        /// Returns a list of all the supported signature-methods.
        /// </summary>
        /// <param name="mechanism">The available signature methods may differ between signature-mechanisms</param>
        /// <param name="fileType">The available signature methods may differ between file-types</param>
        /// <param name="language">Language for the title/description returned</param>
        /// <param name="signableAttachments">When using signable attachments some signature-methods may not be available</param>
        /// <returns></returns>
        Task<List<AppSignatureMethod>> ListSignatureMethodsAsync(SignatureMechanism mechanism, FileType fileType, Language language, bool signableAttachments);
        
        /// <summary>
        /// Returns a list of all the supported signature-methods.
        /// </summary>
        /// <param name="mechanism">The available signature methods may differ between signature-mechanisms</param>
        /// <param name="fileType">The available signature methods may differ between file-types</param>
        /// <param name="language">Language for the title/description returned</param>
        /// <param name="signableAttachments">When using signable attachments some signature-methods may not be available</param>
        /// <returns></returns>
        List<AppSignatureMethod> ListSignatureMethodsForAccount(SignatureMechanism mechanism, FileType fileType, Language language, bool signableAttachments);

        /// <summary>
        /// Returns a list of all the supported signature-methods.
        /// </summary>
        /// <param name="mechanism">The available signature methods may differ between signature-mechanisms</param>
        /// <param name="fileType">The available signature methods may differ between file-types</param>
        /// <param name="language">Language for the title/description returned</param>
        /// <param name="signableAttachments">When using signable attachments some signature-methods may not be available</param>
        /// <returns></returns>
        Task<List<AppSignatureMethod>> ListSignatureMethodsForAccountAsync(SignatureMechanism mechanism, FileType fileType, Language language, bool signableAttachments);

        /// <summary>
        /// Validate redirect jwt which is included in signer redirects or web-messages
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        JwtValidationResult ValidateRedirectJwt(JwtValidationRequest request);
        
        /// <summary>
        /// Validate redirect jwt which is included in signer redirects or web-messages
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<JwtValidationResult> ValidateRedirectJwtAsync(JwtValidationRequest request);
        
        /// <summary>
        /// Sign a document with a merchant (machine) signature only
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<MerchantSignResponse> MerchantSignatureAsync(MerchantSignRequest request);
        
        /// <summary>
        /// Sign a document with a merchant (machine) signature only
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        MerchantSignResponse MerchantSignature(MerchantSignRequest request);
    }
}