using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat;
using Signicat.Services.Signing.Sign_v2;
using Signicat.Services.Signing.Sign_v2.Entities;

namespace Signicat.SDK.Tests.Services.Sign
{
    [TestFixture]
    public class SignServiceTest : BaseTest
    {
        private SignService _service;

        [SetUp]
        public void SetUp()
        {
            _service = new SignService();
        }
        
        #region Document Tests
        
        [Test]
        public void UploadDocument_CreatesDocument()
        {
            // Arrange
            // Try to find the dummy.pdf file in different possible locations
            string[] possiblePaths = new[] {
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Services", "Signing", "dummy.pdf"),
                Path.Combine(TestContext.CurrentContext.WorkDirectory, "Services", "Signing", "dummy.pdf"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services", "Signing", "dummy.pdf"),
                Path.Combine("Signicat.SDK.Tests", "Services", "Signing", "dummy.pdf")
            };
            
            string filePath = possiblePaths.FirstOrDefault(File.Exists);
            Assert.That(filePath, Is.Not.Null, "Test file dummy.pdf not found in any of the expected locations");
            
            var fileData = File.ReadAllBytes(filePath);
            
            // Act
            var result = _service.UploadDocument("test.pdf", fileData);

            try
            {
                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DocumentId, Is.Not.Null);
                Assert.That(result.MimeType, Is.EqualTo("application/pdf"));
//                Assert.That(result.Filename, Is.EqualTo("test.pdf"));
                Console.WriteLine($"Created document with ID: {result.DocumentId}");
            }
            finally
            {
                // Cleanup
                CleanupDocument(result.DocumentId);
            }
        }

        [Test]
        public async Task GetDocumentAsync_RetrievesDocumentContent()
        {
            // Arrange - Create a document first
            var testDocument = CreateTestDocument();
            
            try
            {
                // Act
                using var stream = await _service.GetDocumentAsync(testDocument.DocumentId);

                // Assert
                Assert.That(stream, Is.Not.Null);
                
                // Read the first few bytes to verify it's a PDF file
                var buffer = new byte[5];
                await stream.ReadAsync(buffer, 0, 5);
                var fileHeader = System.Text.Encoding.ASCII.GetString(buffer);
                Assert.That(fileHeader, Does.StartWith("%PDF"));
                
                Console.WriteLine($"Retrieved document content for ID: {testDocument.DocumentId}");
            }
            finally
            {
                // Cleanup
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        [Test]
        public void GetDocumentInfo_RetrievesMetadata()
        {
            // Arrange - Create a document first
            var testDocument = CreateTestDocument();
            
            try
            {
                // Act
                var result = _service.GetDocumentInfo(testDocument.DocumentId);

                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DocumentId, Is.EqualTo(testDocument.DocumentId));
                Console.WriteLine($"Retrieved metadata for document with ID: {result.DocumentId}");
            }
            finally
            {
                // Cleanup
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        [Test]
        public void UpdateDocumentMetadata_UpdatesDocumentInfo()
        {
            // Arrange - Create a document first
            var testDocument = CreateTestDocument();
            
            try
            {
                // Create update request
                var updateRequest = new UpdateDocumentMetadataOptions
                {
                    Title = "Updated Title",
                    Description = "Updated Description"
                };
                
                // Act
                var result = _service.UpdateDocumentMetadata(testDocument.DocumentId, updateRequest);

                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.DocumentId, Is.EqualTo(testDocument.DocumentId));
                Assert.That(result.Title, Is.EqualTo("Updated Title"));
                Assert.That(result.Description, Is.EqualTo("Updated Description"));
                Console.WriteLine($"Updated metadata for document with ID: {result.DocumentId}");
            }
            finally
            {
                // Cleanup
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        [Test]
        public void DeleteDocument_RemovesDocument()
        {
            // Arrange - Create a document first
            var testDocument = CreateTestDocument();
            
            // Act
            _service.DeleteDocument(testDocument.DocumentId);
            
            // Assert - No exception means success
            Console.WriteLine($"Successfully deleted document with ID: {testDocument.DocumentId}");
            
            // Verify it's gone by trying to retrieve it (should throw SignicatException with 404 Not Found)
            var exception = Assert.Throws<SignicatException>(() => _service.GetDocumentInfo(testDocument.DocumentId));
            Assert.That(exception.HttpStatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
        
        #endregion
        
        #region Document Collection Tests
        
        [Test]
        public void CreateDocumentCollection_CreatesCollection()
        {
            // Arrange - Create a document first
            var testDocument = CreateTestDocument();
            
            try
            {
                // Arrange collection creation
                var options = new CreateDocumentCollectionOptions
                {
                    Documents = new List<DocumentReference> 
                    { 
                        new DocumentReference 
                        { 
                            DocumentId = testDocument.DocumentId,
                            Description = "Test Document" 
                        } 
                    }
                };
                
                // Act
                var result = _service.CreateDocumentCollection(options);

                try
                {
                    // Assert
                    Assert.That(result, Is.Not.Null);
                    Assert.That(result.Id, Is.Not.Null);
                    Assert.That(result.Documents, Is.Not.Null);
                    Assert.That(result.Documents.Count, Is.EqualTo(1));
                    Assert.That(result.Documents[0].DocumentId, Is.EqualTo(testDocument.DocumentId));
                    Console.WriteLine($"Created collection with ID: {result.Id}");
                }
                finally
                {
                    // Cleanup collection
                    CleanupDocumentCollection(result.Id);
                }
            }
            finally
            {
                // Cleanup document
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        [Test]
        public void GetDocumentCollection_RetrievesCollection()
        {
            // Arrange - Create a document and collection first
            var testDocument = CreateTestDocument();
            var testCollection = CreateTestCollection(testDocument.DocumentId);
            
            try
            {
                // Act
                var result = _service.GetDocumentCollection(testCollection.Id);

                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(testCollection.Id));
                Assert.That(result.Documents, Is.Not.Null);
                Assert.That(result.Documents.Count, Is.EqualTo(1));
                Assert.That(result.Documents[0].DocumentId, Is.EqualTo(testDocument.DocumentId));
                Console.WriteLine($"Retrieved collection with ID: {result.Id}");
            }
            finally
            {
                // Cleanup
                CleanupDocumentCollection(testCollection.Id);
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        [Test]
        public void DeleteDocumentCollection_RemovesCollection()
        {
            // Arrange - Create a document and collection first
            var testDocument = CreateTestDocument();
            var testCollection = CreateTestCollection(testDocument.DocumentId);
            
            try
            {
                // Act
                _service.DeleteDocumentCollection(testCollection.Id);
                
                // Assert - No exception means success
                Console.WriteLine($"Successfully deleted collection with ID: {testCollection.Id}");
                
                // Verify it's gone by trying to retrieve it (should throw SignicatException with 404 Not Found)
                var exception = Assert.Throws<SignicatException>(() => _service.GetDocumentCollection(testCollection.Id));
                Assert.That(exception.HttpStatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
            }
            finally
            {
                // Cleanup document (collection should be gone already)
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        #endregion
        
        #region Signing Session Tests
        
        [Test]
        public void CreateSignSession_CreatesSession()
        {
            // Arrange - Create a document and collection first
            var testDocument = CreateTestDocument();
            var testCollection = CreateTestCollection(testDocument.DocumentId);
            
            try
            {
                // Create session options
                var options = new CreateSignSession
                {
                    Title = "Test Signing Session",
                    Documents = new List<SessionDocument>
                    {
                        new SessionDocument
                        {
                            DocumentCollectionId = testCollection.Id,
                            Action = SessionDocumentAction.SIGN,
                            DocumentId = testDocument.DocumentId
                        }
                    },
                    UserInteractionSetup = new List<UserInteractionSetup>
                    {
                        new UserInteractionSetup
                        {
                            IdentityProviders = new List<IdentityProvider> { new IdentityProvider { IdpName = "nbid" } },
                            SigningFlow = SigningFlow.AUTHENTICATION_BASED
                        }
                    },
                    Recipient = new Recipient
                    {
                        Email = "test@example.com"
                    },
                    SignText = "Please sign this test document",
                    Language = "en",
                    PackageTo = new List<PackageType> { PackageType.pades_container }, 
                    RedirectSettings = new RedirectSettings
                    {
                        Success = "https://example.com/success",
                        Cancel = "https://example.com/cancel",
                        Error = "https://example.com/error"
                    }
                };
                
                // Act
                var sessionsRequest = new CreateSignSessionsOptions { options };
                var results = _service.CreateSignSessions(sessionsRequest);

                try
                {
                    // Assert
                    Assert.That(results, Is.Not.Null);
                    Assert.That(results.Count, Is.GreaterThan(0));
                    
                    var result = results[0]; // Get the first session from the collection
                    Assert.That(result.Id, Is.Not.Null);
                    Assert.That(result.SignatureUrl, Is.Not.Null);
                    Assert.That(result.Title, Is.EqualTo("Test Signing Session"));
                    Console.WriteLine($"Created session with ID: {result.Id}");
                    Console.WriteLine($"Signing URL: {result.SignatureUrl}");
                    
                    // Cleanup all created sessions
                    foreach (var session in results)
                    {
                        CleanupSignSession(session.Id);
                    }
                }
                finally
                {
                }
            }
            finally
            {
                // Cleanup collection and document
                CleanupDocumentCollection(testCollection.Id);
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        [Test]
        public void GetSignSession_RetrievesSession()
        {
            // Arrange - Create necessary resources
            var testDocument = CreateTestDocument();
            var testCollection = CreateTestCollection(testDocument.DocumentId);
            var testSession = CreateTestSession(testCollection.Id, testDocument.DocumentId);
            
            try
            {
                // Act
                var result = _service.GetSignSession(testSession.Id);

                // Assert
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(testSession.Id));
                Assert.That(result.Title, Is.EqualTo("Test Signing Session"));
                Console.WriteLine($"Retrieved session with ID: {result.Id}");
            }
            finally
            {
                // Cleanup all resources
                CleanupSignSession(testSession.Id);
                CleanupDocumentCollection(testCollection.Id);
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        [Test]
        public void DeleteSignSession_RemovesSession()
        {
            // Arrange - Create necessary resources
            var testDocument = CreateTestDocument();
            var testCollection = CreateTestCollection(testDocument.DocumentId);
            var testSession = CreateTestSession(testCollection.Id, testDocument.DocumentId);
            
            try
            {
                // Act
                _service.DeleteSignSession(testSession.Id);
                
                // Assert - No exception means success
                Console.WriteLine($"Successfully deleted session with ID: {testSession.Id}");
                
                // Verify it's gone by trying to retrieve it (should throw SignicatException with 404 Not Found)
                var exception = Assert.Throws<SignicatException>(() => _service.GetSignSession(testSession.Id));
                Assert.That(exception.HttpStatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
            }
            finally
            {
                // Cleanup remaining resources (session should be gone already)
                CleanupDocumentCollection(testCollection.Id);
                CleanupDocument(testDocument.DocumentId);
            }
        }
        
        [Test]
        public void GetArchivedDocument_HandlesError()
        {
            // This test will likely fail since we can't sign the document programmatically
            // But we can test the error handling
            var archiveDocumentId = Guid.NewGuid().ToString();
            
            // Act & Assert - Should throw SignicatException with 404 Not Found
            var exception = Assert.Throws<SignicatException>(() => _service.GetArchivedDocument(archiveDocumentId));
            Assert.That(exception.HttpStatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }
        
        #endregion
        
        #region Helper Methods
        
        private Document CreateTestDocument()
        {
            // Try to find the dummy.pdf file in different possible locations
            string[] possiblePaths = new[] {
                Path.Combine(TestContext.CurrentContext.TestDirectory, "Services", "Signing", "dummy.pdf"),
                Path.Combine(TestContext.CurrentContext.WorkDirectory, "Services", "Signing", "dummy.pdf"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services", "Signing", "dummy.pdf"),
                Path.Combine("Signicat.SDK.Tests", "Services", "Signing", "dummy.pdf")
            };
            
            string filePath = possiblePaths.FirstOrDefault(File.Exists);
            Assert.That(filePath, Is.Not.Null, "Test file dummy.pdf not found in any of the expected locations");
            
            var fileData = File.ReadAllBytes(filePath);
            var document = _service.UploadDocument("test.pdf", fileData);
            
            Console.WriteLine($"Created test document with ID: {document.DocumentId}");
            return document;
        }
        
        private DocumentCollection CreateTestCollection(string documentId)
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
        
        private SigningSession CreateTestSession(string collectionId, string documentId)
        {
            var options = new CreateSignSession
            {
                Title = "Test Signing Session",
                Documents = new List<SessionDocument> 
                { 
                    new SessionDocument 
                    { 
                        DocumentCollectionId = collectionId,
                        Action = SessionDocumentAction.SIGN,
                        DocumentId = documentId 
                    } 
                },
                UserInteractionSetup = new List<UserInteractionSetup>
                {
                    new UserInteractionSetup
                    {
                        IdentityProviders = new List<IdentityProvider> 
                        { 
                            new IdentityProvider { IdpName = "nbid" } 
                        },
                        SigningFlow = SigningFlow.AUTHENTICATION_BASED
                    }
                },
                Recipient = new Recipient
                {
                    Email = "test@example.com"
                },
                SignText = "Please sign this test document",
                Language = "en",
                RedirectSettings = new RedirectSettings
                {
                    Success = "https://example.com/success",
                    Cancel = "https://example.com/cancel",
                    Error = "https://example.com/error"
                }
            };
            
            var sessionsRequest = new CreateSignSessionsOptions { options };
            var sessions = _service.CreateSignSessions(sessionsRequest);
            Assert.That(sessions.Count, Is.GreaterThan(0), "No signing sessions were created");
            
            var session = sessions[0]; // Take the first session
            Console.WriteLine($"Created test session with ID: {session.Id}");
            return session;
        }
        
        private void CleanupDocument(string documentId)
        {
            if (!string.IsNullOrEmpty(documentId))
            {
                try
                {
                    _service.DeleteDocument(documentId);
                    Console.WriteLine($"Cleaned up document {documentId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error cleaning up document {documentId}: {ex.Message}");
                }
            }
        }
        
        private void CleanupDocumentCollection(string collectionId)
        {
            if (!string.IsNullOrEmpty(collectionId))
            {
                try
                {
                    _service.DeleteDocumentCollection(collectionId);
                    Console.WriteLine($"Cleaned up collection {collectionId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error cleaning up collection {collectionId}: {ex.Message}");
                }
            }
        }
        
        private void CleanupSignSession(string sessionId)
        {
            if (!string.IsNullOrEmpty(sessionId))
            {
                try
                {
                    _service.DeleteSignSession(sessionId);
                    Console.WriteLine($"Cleaned up session {sessionId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error cleaning up session {sessionId}: {ex.Message}");
                }
            }
        }
        
        #endregion
    }
}