using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Signicat.Services.Signing.Sign_v2;
using Signicat.Services.Signing.Sign_v2.Entities;

namespace Signicat.SDK.Fluent
{
    public class SignServiceFluent
    {
        private readonly ISignService _signService;

        public SignServiceFluent(ISignService signService)
        {
            _signService = signService;
        }

        public static SignServiceFluent Create(ISignService signService)
        {
            return new SignServiceFluent(signService);
        }

        #region Documents

        public DocumentUploadFluentBuilder UploadDocument(string fileName, Stream fileData)
        {
            return new DocumentUploadFluentBuilder(_signService, fileName, fileData);
        }

        public DocumentGetFluentBuilder GetDocument(string documentId)
        {
            return new DocumentGetFluentBuilder(_signService, documentId);
        }

        public DocumentInfoGetFluentBuilder GetDocumentInfo(string documentId)
        {
            return new DocumentInfoGetFluentBuilder(_signService, documentId);
        }

        public DocumentUpdateFluentBuilder UpdateDocumentMetadata(string documentId)
        {
            return new DocumentUpdateFluentBuilder(_signService, documentId);
        }

        public DocumentDeleteFluentBuilder DeleteDocument(string documentId)
        {
            return new DocumentDeleteFluentBuilder(_signService, documentId);
        }

        #endregion

        #region Document Collections

        public DocumentCollectionCreateFluentBuilder CreateDocumentCollection()
        {
            return new DocumentCollectionCreateFluentBuilder(_signService);
        }

        public DocumentCollectionGetFluentBuilder GetDocumentCollection(string documentCollectionId)
        {
            return new DocumentCollectionGetFluentBuilder(_signService, documentCollectionId);
        }

        public DocumentCollectionDeleteFluentBuilder DeleteDocumentCollection(string documentCollectionId)
        {
            return new DocumentCollectionDeleteFluentBuilder(_signService, documentCollectionId);
        }

        public DocumentCollectionPackageCreateFluentBuilder CreateDocumentCollectionPackage(string documentCollectionId)
        {
            return new DocumentCollectionPackageCreateFluentBuilder(_signService, documentCollectionId);
        }

        #endregion

        #region Sign Sessions

        public SigningSessionListFluentBuilder ListSigningSessions()
        {
            return new SigningSessionListFluentBuilder(_signService);
        }

        public SigningSessionCreateFluentBuilder CreateSigningSession()
        {
            return new SigningSessionCreateFluentBuilder(_signService);
        }

        public SigningSessionGetFluentBuilder GetSigningSession(string sessionId)
        {
            return new SigningSessionGetFluentBuilder(_signService, sessionId);
        }

        public SigningSessionDeleteFluentBuilder DeleteSigningSession(string sessionId)
        {
            return new SigningSessionDeleteFluentBuilder(_signService, sessionId);
        }

        public SigningSessionPackageCreateFluentBuilder CreateSigningSessionPackage(string sessionId)
        {
            return new SigningSessionPackageCreateFluentBuilder(_signService, sessionId);
        }

        #endregion

        #region Archived Documents

        public ArchivedDocumentGetFluentBuilder GetArchivedDocument(string archiveDocumentId)
        {
            return new ArchivedDocumentGetFluentBuilder(_signService, archiveDocumentId);
        }

        #endregion
    }

    #region Document Fluent Builders

    public class DocumentUploadFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _fileName;
        private readonly Stream _fileData;

        public DocumentUploadFluentBuilder(ISignService signService, string fileName, Stream fileData)
        {
            _signService = signService;
            _fileName = fileName;
            _fileData = fileData;
        }

        public Document Upload()
        {
            return _signService.UploadDocument(_fileName, _fileData);
        }

        public Task<Document> UploadAsync()
        {
            return _signService.UploadDocumentAsync(_fileName, _fileData);
        }
    }

    public class DocumentGetFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _documentId;

        public DocumentGetFluentBuilder(ISignService signService, string documentId)
        {
            _signService = signService;
            _documentId = documentId;
        }

        public Stream Get()
        {
            return _signService.GetDocument(_documentId);
        }

        public Task<Stream> GetAsync()
        {
            return _signService.GetDocumentAsync(_documentId);
        }
    }

    public class DocumentInfoGetFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _documentId;

        public DocumentInfoGetFluentBuilder(ISignService signService, string documentId)
        {
            _signService = signService;
            _documentId = documentId;
        }

        public Document Get()
        {
            return _signService.GetDocumentInfo(_documentId);
        }

        public Task<Document> GetAsync()
        {
            return _signService.GetDocumentInfoAsync(_documentId);
        }
    }

    public class DocumentUpdateFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _documentId;
        private readonly UpdateDocumentMetadataOptions _options = new UpdateDocumentMetadataOptions();

        public DocumentUpdateFluentBuilder(ISignService signService, string documentId)
        {
            _signService = signService;
            _documentId = documentId;
        }

        public DocumentUpdateFluentBuilder WithTitle(string title)
        {
            _options.Title = title;
            return this;
        }

        public DocumentUpdateFluentBuilder WithDescription(string description)
        {
            _options.Description = description;
            return this;
        }

        public Document Update()
        {
            return _signService.UpdateDocumentMetadata(_documentId, _options);
        }

        public Task<Document> UpdateAsync()
        {
            return _signService.UpdateDocumentMetadataAsync(_documentId, _options);
        }
    }

    public class DocumentDeleteFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _documentId;

        public DocumentDeleteFluentBuilder(ISignService signService, string documentId)
        {
            _signService = signService;
            _documentId = documentId;
        }

        public void Delete()
        {
            _signService.DeleteDocument(_documentId);
        }

        public Task DeleteAsync()
        {
            return _signService.DeleteDocumentAsync(_documentId);
        }
    }

    #endregion

    #region Document Collection Fluent Builders

    public class DocumentCollectionCreateFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly CreateDocumentCollectionOptions _options = new CreateDocumentCollectionOptions();

        public DocumentCollectionCreateFluentBuilder(ISignService signService)
        {
            _signService = signService;
        }

        public DocumentCollectionCreateFluentBuilder WithDocument(string documentId)
        {
            _options.Documents.Add(new DocumentReference { DocumentId = documentId });
            return this;
        }

        public DocumentCollectionCreateFluentBuilder WithDocument(Document document)
        {
            _options.Documents.Add(new DocumentReference { DocumentId = document.DocumentId });
            return this;
        }

        public DocumentCollection Create()
        {
            return _signService.CreateDocumentCollection(_options);
        }

        public Task<DocumentCollection> CreateAsync()
        {
            return _signService.CreateDocumentCollectionAsync(_options);
        }
    }

    public class DocumentCollectionGetFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _documentCollectionId;

        public DocumentCollectionGetFluentBuilder(ISignService signService, string documentCollectionId)
        {
            _signService = signService;
            _documentCollectionId = documentCollectionId;
        }

        public DocumentCollection Get()
        {
            return _signService.GetDocumentCollection(_documentCollectionId);
        }

        public Task<DocumentCollection> GetAsync()
        {
            return _signService.GetDocumentCollectionAsync(_documentCollectionId);
        }
    }

    public class DocumentCollectionDeleteFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _documentCollectionId;

        public DocumentCollectionDeleteFluentBuilder(ISignService signService, string documentCollectionId)
        {
            _signService = signService;
            _documentCollectionId = documentCollectionId;
        }

        public void Delete()
        {
            _signService.DeleteDocumentCollection(_documentCollectionId);
        }

        public Task DeleteAsync()
        {
            return _signService.DeleteDocumentCollectionAsync(_documentCollectionId);
        }
    }

    public class DocumentCollectionPackageCreateFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _documentCollectionId;

        public DocumentCollectionPackageCreateFluentBuilder(ISignService signService, string documentCollectionId)
        {
            _signService = signService;
            _documentCollectionId = documentCollectionId;
        }

        public void Create()
        {
            _signService.CreateDocumentCollectionPackage(_documentCollectionId);
        }

        public Task CreateAsync()
        {
            return _signService.CreateDocumentCollectionPackageAsync(_documentCollectionId);
        }
    }

    #endregion

    #region Signing Session Fluent Builders

    public class SigningSessionListFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly SigningSessionListOptions _options = new SigningSessionListOptions();

        public SigningSessionListFluentBuilder(ISignService signService)
        {
            _signService = signService;
        }

        public SigningSessionListFluentBuilder WithOffset(int offset)
        {
            _options.Offset = offset;
            return this;
        }

        public SigningSessionListFluentBuilder WithLimit(int limit)
        {
            _options.Limit = limit;
            return this;
        }

        public SigningSessionListFluentBuilder WithSort(params string[] sortFields)
        {
            _options.Sort = new List<string>(sortFields);
            return this;
        }

        public SigningSessionListFluentBuilder WithCreatedDateFrom(DateTime date)
        {
            _options.CreatedDateFrom = date;
            return this;
        }

        public SigningSessionListFluentBuilder WithCreatedDateTo(DateTime date)
        {
            _options.CreatedDateTo = date;
            return this;
        }

        public SigningSessionListFluentBuilder WithState(params SessionState[] states)
        {
            _options.State = new List<SessionState>(states);
            return this;
        }

        public SigningSessionListFluentBuilder WithDueDateFrom(DateTime date)
        {
            _options.DueDateFrom = date;
            return this;
        }

        public SigningSessionListFluentBuilder WithDueDateTo(DateTime date)
        {
            _options.DueDateTo = date;
            return this;
        }

        public SigningSessionListFluentBuilder WithSessionTitleLike(string title)
        {
            _options.SessionTitleLike = title;
            return this;
        }

        public PaginatedSigningSessionResponse List()
        {
            return _signService.ListSigningSessions(_options);
        }

        public Task<PaginatedSigningSessionResponse> ListAsync()
        {
            return _signService.ListSigningSessionsAsync(_options);
        }
    }

    public class SigningSessionCreateFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly CreateSignSession _createSignSessionOptions = new CreateSignSession();

        public SigningSessionCreateFluentBuilder(ISignService signService)
        {
            _signService = signService;
        }

        public SigningSessionCreateFluentBuilder WithTitle(string title)
        {
            _createSignSessionOptions.Title = title;
            return this;
        }

        public SigningSessionCreateFluentBuilder WithSignText(string signText)
        {
            _createSignSessionOptions.SignText = signText;
            return this;
        }

        public SigningSessionCreateFluentBuilder WithDueDate(DateTime dueDate)
        {
            _createSignSessionOptions.DueDate = dueDate;
            return this;
        }

        public SigningSessionCreateFluentBuilder WithExternalReference(string externalReference)
        {
            _createSignSessionOptions.ExternalReference = externalReference;
            return this;
        }

        public SigningSessionCreateFluentBuilder WithDocument(Action<SessionDocument> documentAction)
        {
            var document = new SessionDocument();
            documentAction(document);
            _createSignSessionOptions.Documents.Add(document);
            return this;
        }

        public SigningSessionCreateFluentBuilder WithSessionDocument(Document document, DocumentCollection documentCollection, Action<SessionDocument> documentAction = null)
        {
            var sessionDocument = new SessionDocument
            {
                DocumentId = document.DocumentId,
                DocumentCollectionId = documentCollection.Id
            };
            documentAction?.Invoke(sessionDocument);
            _createSignSessionOptions.Documents.Add(sessionDocument);
            return this;
        }

        public SigningSessionCreateFluentBuilder WithSigningSetup(Action<SigningSetup> signingSetupAction)
        {
            var signingSetup = new SigningSetup();
            signingSetupAction(signingSetup);
            _createSignSessionOptions.SigningSetup.Add(signingSetup);
            return this;
        }

        public SigningSessionCreateFluentBuilder WithSubsequentTo(string sessionId)
        {
            _createSignSessionOptions.SubsequentTo.Add(sessionId);
            return this;
        }

        public SigningSessionCreateFluentBuilder WithPackageType(PackageType packageType)
        {
            _createSignSessionOptions.PackageTo.Add(packageType);
            return this;
        }

        public SigningSessionCreateFluentBuilder WithSigner(Action<Signer> signerAction)
        {
            var signer = new Signer();
            signerAction(signer);
            _createSignSessionOptions.Signer = signer;
            return this;
        }

        public SigningSessionCreateFluentBuilder WithPreAuthentication(Action<PreAuthentication> preAuthenticationAction)
        {
            var preAuthentication = new PreAuthentication();
            preAuthenticationAction(preAuthentication);
            _createSignSessionOptions.PreAuthentication = preAuthentication;
            return this;
        }

        public SigningSessionCreateFluentBuilder WithUi(Action<Ui> uiAction)
        {
            var ui = new Ui();
            uiAction(ui);
            _createSignSessionOptions.Ui = ui;
            return this;
        }

        public SigningSessionCreateFluentBuilder WithRedirectSettings(Action<RedirectSettings> redirectSettingsAction)
        {
            var redirectSettings = new RedirectSettings();
            redirectSettingsAction(redirectSettings);
            _createSignSessionOptions.RedirectSettings = redirectSettings;
            return this;
        }

        public SigningSessionCreateFluentBuilder WithSignatureUrlTimeToLive(int ttl)
        {
            _createSignSessionOptions.SignatureUrlTimeToLive = ttl;
            return this;
        }

        public SigningSessions Create()
        {
            var options = new CreateSignSessionsOptions { _createSignSessionOptions };
            return _signService.CreateSignSessions(options);
        }

        public Task<SigningSessions> CreateAsync()
        {
            var options = new CreateSignSessionsOptions { _createSignSessionOptions };
            return _signService.CreateSignSessionsAsync(options);
        }
    }

    public class SigningSessionGetFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _sessionId;

        public SigningSessionGetFluentBuilder(ISignService signService, string sessionId)
        {
            _signService = signService;
            _sessionId = sessionId;
        }

        public SigningSession Get()
        {
            return _signService.GetSignSession(_sessionId);
        }

        public Task<SigningSession> GetAsync()
        {
            return _signService.GetSignSessionAsync(_sessionId);
        }
    }

    public class SigningSessionDeleteFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _sessionId;

        public SigningSessionDeleteFluentBuilder(ISignService signService, string sessionId)
        {
            _signService = signService;
            _sessionId = sessionId;
        }

        public void Delete()
        {
            _signService.DeleteSignSession(_sessionId);
        }

        public Task DeleteAsync()
        {
            return _signService.DeleteSignSessionAsync(_sessionId);
        }
    }

    public class SigningSessionPackageCreateFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _sessionId;

        public SigningSessionPackageCreateFluentBuilder(ISignService signService, string sessionId)
        {
            _signService = signService;
            _sessionId = sessionId;
        }

        public void Create()
        {
            _signService.CreateSigningSessionPackage(_sessionId);
        }

        public Task CreateAsync()
        {
            return _signService.CreateSigningSessionPackageAsync(_sessionId);
        }
    }

    #endregion

    #region Archived Document Fluent Builders

    public class ArchivedDocumentGetFluentBuilder
    {
        private readonly ISignService _signService;
        private readonly string _archiveDocumentId;

        public ArchivedDocumentGetFluentBuilder(ISignService signService, string archiveDocumentId)
        {
            _signService = signService;
            _archiveDocumentId = archiveDocumentId;
        }

        public Stream Get()
        {
            return _signService.GetArchivedDocument(_archiveDocumentId);
        }

        public Task<Stream> GetAsync()
        {
            return _signService.GetArchivedDocumentAsync(_archiveDocumentId);
        }
    }

    #endregion
}
