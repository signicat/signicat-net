# Sign-v2 Service Examples

#### Upload a Document

```csharp
var signService = new SignService();
var fileName = "document.pdf"; // Replace with your document file name
var fileData = File.ReadAllBytes(fileName); // Replace with your document content

var document = await signService.UploadDocumentAsync(fileName, new MemoryStream(fileData));
Console.WriteLine($"Uploaded Document ID: {document.DocumentId}");
```

#### Create a Document Collection

```csharp
var signService = new SignService();
var documentId = "your_document_id"; // Replace with an actual document ID obtained from Upload a Document example

var createDocumentCollectionOptions = new CreateDocumentCollectionOptions
{
    Documents = new List<DocumentReference>
    {
        new DocumentReference { DocumentId = documentId }
    }
};

var documentCollection = await signService.CreateDocumentCollectionAsync(createDocumentCollectionOptions);
Console.WriteLine($"Created Document Collection ID: {documentCollection.Id}");
```

#### Create Signing Session

```csharp
var signService = new SignService();
var documentCollectionId = "your_document_collection_id"; // Replace with an actual document collection ID
var documentId = "your_document_id"; // Replace with an actual document ID

var createSignSessionOptions = new CreateSignSession
{
    Title = "The title of the signing session",
    ExternalReference = Guid.NewGuid().ToString(),
    Documents = new List<SessionDocument>
    {
        new SessionDocument
        {
            Action = SessionDocumentAction.SIGN,
            DocumentCollectionId = documentCollectionId,
            DocumentId = documentId
        }
    },
    SigningSetup = new List<SigningSetup>
    {
        new SigningSetup
        {
            IdentityProviders = new List<IdentityProvider>
            {
                new IdentityProvider { IdpName = "ftn" }
            },
            SigningFlow = SigningFlow.AUTHENTICATION_BASED
        }
    },
    PackageTo = new List<PackageType> { PackageType.PADES_CONTAINER },
    Ui = new Ui
    {
        Language = "fi"
    },
    RedirectSettings = new RedirectSettings
    {
        ErrorUrl = "https://www.example.com?q=error",
        CancelUrl = "https://www.example.com?q=cancel",
        SuccessUrl = "https://www.example.com?q=success"
    }
};

var signingSessions = await signService.CreateSignSessionAsync(createSignSessionOptions);

foreach (var session in signingSessions)
{
    Console.WriteLine($"Created Session ID: {session.Id}, Signature URL: {session.SignatureUrl}");
}
```

#### List Signing Sessions

```csharp
var signService = new SignService();
var options = new SigningSessionListOptions
{
    Limit = 10,
    Offset = 0,
    CreatedDateFrom = DateTime.UtcNow.AddDays(-30),
    State = new List<SessionState> { SessionState.SIGNED, SessionState.REJECTED }
};
var sessions = await signService.ListSigningSessionsAsync(options);

foreach (var session in sessions.Content)
{
    Console.WriteLine($"Session ID: {session.Id}, Title: {session.Title}, State: {session.Lifecycle.State}");
}
```

#### Get Signing Session

```csharp
var signService = new SignService();
var sessionId = "your_session_id"; // Replace with an actual session ID
var session = await signService.GetSignSessionAsync(sessionId);

Console.WriteLine($"Session ID: {session.Id}, Title: {session.Title}, State: {session.Lifecycle.State}");
```

#### Delete Signing Session

```csharp
var signService = new SignService();
var sessionId = "your_session_id"; // Replace with an actual session ID
await signService.DeleteSignSessionAsync(sessionId);

Console.WriteLine($"Session {sessionId} deleted successfully.");
```