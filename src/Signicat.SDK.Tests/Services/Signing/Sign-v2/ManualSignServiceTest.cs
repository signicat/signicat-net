using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Services.Signing.Sign_v2;
using Signicat.Services.Signing.Sign_v2.Entities;

namespace Signicat.SDK.Tests.Services.Signing.Sign_v2;

[TestFixture]
public class ManualSignServiceTest : BaseTest
{
    private SignService _service;

    [SetUp]
    public void SetUp()
    {
        LaunchSettingsHelper.LoadEnvironmentVariables();
        string clientId = Environment.GetEnvironmentVariable("PROD_SIGN_LIVE_TEST_CLIENT_ID"),
            clientSecret = Environment.GetEnvironmentVariable("PROD_SIGN_LIVE_TEST_CLIENT_SECRET");
        _service = string.IsNullOrWhiteSpace(clientId) ? new SignService():
            new SignService(clientId,clientSecret);
    }

    [Explicit]
    [Test]
    public async Task CreateManualSignTest()
    {
        // Arrange - Create a document and collection first
        var testDocument = CreateTestDocument();
        var testCollection = CreateTestCollection(testDocument.DocumentId);
            
        
        // Create session options
        var options = new CreateSignSession
        {
            Title = "Test Signing Session",
            Documents =
            [
                new SessionDocument(documentCollectionId: testCollection.Id, action: SessionDocumentAction.SIGN,
                    documentId: testDocument.DocumentId)
            ],
            UserInteractionSetup =
            [
                new UserInteractionSetup
                {
                    IdentityProviders = [new IdentityProvider { IdpName = "nbid" }],
                    SigningFlow = SigningFlow.AUTHENTICATION_BASED,
                }
            ],
            Recipient = new Recipient
            {
            },
            SignText = "Please sign this test document",
            Language = "en",
            DueDate = DateTime.Now+TimeSpan.FromDays(1),
            ExternalReference = Guid.NewGuid().ToString("n"),
            PackageTo = [PackageType.pades_container], 
            RedirectSettings = new RedirectSettings
            {
                Success = "https://example.com/success",
                Cancel = "https://example.com/cancel",
                Error = "https://example.com/error"
            },
           
        };
                
        // Act
        var sessionsRequest = new CreateSignSessionsOptions { options };
        try
        {
            var results = await _service.CreateSignSessionsAsync(sessionsRequest);
            
            // Assert
            Assert.That(results, Is.Not.Null);
            Assert.That(results.Count, Is.GreaterThan(0));
                    
            var result = results[0]; // Get the first session from the collection
            Assert.That(result.Id, Is.Not.Null);
            Assert.That(result.SignatureUrl, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("Test Signing Session"));
            Console.WriteLine($"Created session with ID: {result.Id}");
            Console.WriteLine($"Signing URL: {result.SignatureUrl}");
        }
        catch (SignicatException e)
        {
            Console.WriteLine(e.Response.ResponseJson);
            throw;
        }
       

              
      
                    
              
    }
    

        
    internal Document CreateTestDocument()
    {
        string filePath =@"Services/Signing/dummy.pdf";
        Assert.That(File.Exists(filePath),Is.True,"Test file dummy.pdf not found");
            
        var document = _service.UploadDocument("test.pdf", File.ReadAllBytes(filePath));
            
        Console.WriteLine($"Created test document with ID: {document.DocumentId}");
        return document;
    }
        
    internal DocumentCollection CreateTestCollection(string documentId)
    {
        var options = new CreateDocumentCollectionOptions
        {
            Documents = new List<DocumentReference> 
            { 
                new DocumentReference 
                { 
                    DocumentId = documentId,
                    Description = "Test Document" 
                } 
            }
        };
            
        var collection = _service.CreateDocumentCollection(options);
        Console.WriteLine($"Created test collection with ID: {collection.Id}");
        return collection;
    }

                
}