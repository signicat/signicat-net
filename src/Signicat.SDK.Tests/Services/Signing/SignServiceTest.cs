using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.SDK.Tests.Helpers;
using Signicat.Services.Sign;
using Signicat.Sign.Entities;

namespace Signicat.SDK.Tests.Services.Signing
{
    public class SignServiceTest : BaseTest
    {
        private ISignService _signService;
        private byte[] _testFileData;
        private const string TestFileName = "dummy.pdf";

        [SetUp]
        public void Setup()
        {
            _signService = new SignService();
            _testFileData = File.ReadAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, $"Services/Signing/{TestFileName}"));
        }

        [Test]
        public void UploadDocument()
        {
            var document = _signService.UploadDocument(TestFileName, _testFileData);

            Assert.That(document, Is.Not.Null);
            Assert.That(document.DocumentId, Is.Not.Empty);
            Assert.That(document.FileName, Is.EqualTo(TestFileName));
        }

        [Test]
        public async Task UploadDocumentAsync()
        {
            var document = await _signService.UploadDocumentAsync(TestFileName, _testFileData);

            Assert.That(document, Is.Not.Null);
            Assert.That(document.DocumentId, Is.Not.Empty);
            Assert.That(document.FileName, Is.EqualTo(TestFileName));
        }

        [Test]
        public void DownloadDocument()
        {
            // First upload a document
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            
            // Then download it
            using var downloadedStream = _signService.DownloadDocument(uploadedDoc.DocumentId);
            
            Assert.That(downloadedStream, Is.Not.Null);
            Assert.That(FileHelper.CompareByteArrayAndStream(_testFileData, downloadedStream), Is.True);
        }

        [Test]
        public async Task DownloadDocumentAsync()
        {
            // First upload a document
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            
            // Then download it
            using var downloadedStream = await _signService.DownloadDocumentAsync(uploadedDoc.DocumentId);
            
            Assert.That(downloadedStream, Is.Not.Null);
            Assert.That(FileHelper.CompareByteArrayAndStream(_testFileData, downloadedStream), Is.True);
        }

        [Test]
        public void DeleteDocument()
        {
            // First upload a document
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            
            // Then delete it
            _signService.DeleteDocument(uploadedDoc.DocumentId);
            
            // Verify it's deleted by trying to download it
            Assert.Throws<Exception>(() => _signService.DownloadDocument(uploadedDoc.DocumentId));
        }

        [Test]
        public async Task DeleteDocumentAsync()
        {
            // First upload a document
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            
            // Then delete it
            await _signService.DeleteDocumentAsync(uploadedDoc.DocumentId);
            
            // Verify it's deleted by trying to download it
            Assert.ThrowsAsync<Exception>(async () => await _signService.DownloadDocumentAsync(uploadedDoc.DocumentId));
        }

        [Test]
        public void UpdateDocumentMetadata()
        {
            // First upload a document
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            
            // Update metadata
            var updatedDoc = new Document
            {
                Title = "Updated Title",
                Description = "Updated Description"
            };
            
            var result = _signService.UpdateDocumentMetadata(uploadedDoc.DocumentId, updatedDoc);
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("Updated Title"));
            Assert.That(result.Description, Is.EqualTo("Updated Description"));
        }

        [Test]
        public async Task UpdateDocumentMetadataAsync()
        {
            // First upload a document
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            
            // Update metadata
            var updatedDoc = new Document
            {
                Title = "Updated Title",
                Description = "Updated Description"
            };
            
            var result = await _signService.UpdateDocumentMetadataAsync(uploadedDoc.DocumentId, updatedDoc);
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("Updated Title"));
            Assert.That(result.Description, Is.EqualTo("Updated Description"));
        }

        [Test]
        public void GetDocumentMetadata()
        {
            // First upload a document
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            
            // Get metadata
            var metadata = _signService.GetDocumentMetadata(uploadedDoc.DocumentId);
            
            Assert.That(metadata, Is.Not.Null);
            Assert.That(metadata.DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
            Assert.That(metadata.FileName, Is.EqualTo(TestFileName));
        }

        [Test]
        public async Task GetDocumentMetadataAsync()
        {
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            
            var metadata = await _signService.GetDocumentMetadataAsync(uploadedDoc.DocumentId);
            
            Assert.That(metadata, Is.Not.Null);
            Assert.That(metadata.DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
            Assert.That(metadata.FileName, Is.EqualTo(TestFileName));
        }

        [Test]
        public void CreateDocumentCollection()
        {
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            
            var collection = new DocumentCollection
            {
                Title = "Test Collection",
                Description = "Test Description",
                Documents = new List<DocumentCollectionDocument>
                {
                    new DocumentCollectionDocument { DocumentId = uploadedDoc.DocumentId }
                }
            };
            
            var result = _signService.CreateDocumentCollection(collection);
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DocumentCollectionId, Is.Not.Empty);
            Assert.That(result.Title, Is.EqualTo("Test Collection"));
            Assert.That(result.Description, Is.EqualTo("Test Description"));
            Assert.That(result.Documents, Is.Not.Empty);
            Assert.That(result.Documents[0].DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
        }

        [Test]
        public async Task CreateDocumentCollectionAsync()
        {
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            
            var collection = new DocumentCollection
            {
                Title = "Test Collection",
                Description = "Test Description",
                Documents = new List<DocumentCollectionDocument>
                {
                    new DocumentCollectionDocument { DocumentId = uploadedDoc.DocumentId }
                }
            };
            
            var result = await _signService.CreateDocumentCollectionAsync(collection);
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DocumentCollectionId, Is.Not.Empty);
            Assert.That(result.Title, Is.EqualTo("Test Collection"));
            Assert.That(result.Description, Is.EqualTo("Test Description"));
            Assert.That(result.Documents, Is.Not.Empty);
            Assert.That(result.Documents[0].DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
        }

        [Test]
        public void GetDocumentCollection()
        {
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            
            var collection = new DocumentCollection
            {
                Title = "Test Collection",
                Description = "Test Description",
                Documents = new List<DocumentCollectionDocument>
                {
                    new DocumentCollectionDocument { DocumentId = uploadedDoc.DocumentId }
                }
            };
            
            var createdCollection = _signService.CreateDocumentCollection(collection);
            
            var result = _signService.GetDocumentCollection(createdCollection.DocumentCollectionId);
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DocumentCollectionId, Is.EqualTo(createdCollection.DocumentCollectionId));
            Assert.That(result.Title, Is.EqualTo("Test Collection"));
            Assert.That(result.Description, Is.EqualTo("Test Description"));
            Assert.That(result.Documents, Is.Not.Empty);
            Assert.That(result.Documents[0].DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
        }

        [Test]
        public async Task GetDocumentCollectionAsync()
        {
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            
            var collection = new DocumentCollection
            {
                Title = "Test Collection",
                Description = "Test Description",
                Documents = new List<DocumentCollectionDocument>
                {
                    new DocumentCollectionDocument { DocumentId = uploadedDoc.DocumentId }
                }
            };
            
            var createdCollection = await _signService.CreateDocumentCollectionAsync(collection);
            
            var result = await _signService.GetDocumentCollectionAsync(createdCollection.DocumentCollectionId);
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.DocumentCollectionId, Is.EqualTo(createdCollection.DocumentCollectionId));
            Assert.That(result.Title, Is.EqualTo("Test Collection"));
            Assert.That(result.Description, Is.EqualTo("Test Description"));
            Assert.That(result.Documents, Is.Not.Empty);
            Assert.That(result.Documents[0].DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
        }

        [Test]
        public void DeleteDocumentCollection()
        {
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            
            var collection = new DocumentCollection
            {
                Title = "Test Collection",
                Description = "Test Description",
                Documents = new List<DocumentCollectionDocument>
                {
                    new DocumentCollectionDocument { DocumentId = uploadedDoc.DocumentId }
                }
            };
            
            var createdCollection = _signService.CreateDocumentCollection(collection);
            
            _signService.DeleteDocumentCollection(createdCollection.DocumentCollectionId);
            
            Assert.Throws<Exception>(() => _signService.GetDocumentCollection(createdCollection.DocumentCollectionId));
        }

        [Test]
        public async Task DeleteDocumentCollectionAsync()
        {
            // Arrange
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            var documentCollection = new DocumentCollection
            {
                Title = "Test Collection",
                Description = "Test Description",
                Documents = new List<DocumentCollectionDocument>
                {
                    new DocumentCollectionDocument { DocumentId = uploadedDoc.DocumentId }
                }
            };

            var createdCollection = _signService.CreateDocumentCollection(documentCollection);

            // Act
            await _signService.DeleteDocumentCollectionAsync(createdCollection.DocumentCollectionId);

            // Assert
            Assert.ThrowsAsync<SignicatException>(async () =>
                await _signService.GetDocumentCollectionAsync(createdCollection.DocumentCollectionId));
        }

        [Test]
        public void CreateSignSession()
        {
            // Arrange
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            var signSession = new SignSession
            {
                Title = "Test Sign Session",
                Description = "Test Description",
                Documents = new List<SignSessionDocument>
                {
                    new SignSessionDocument { DocumentId = uploadedDoc.DocumentId }
                },
                Signers = new List<Signer>
                {
                    new Signer
                    {
                        Email = "test@example.com",
                        FirstName = "Test",
                        LastName = "User"
                    }
                }
            };

            // Act
            var result = _signService.CreateSignSession(signSession);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.SignSessionId, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo(signSession.Title));
            Assert.That(result.Description, Is.EqualTo(signSession.Description));
            Assert.That(result.Documents, Has.Count.EqualTo(1));
            Assert.That(result.Documents[0].DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
            Assert.That(result.Signers, Has.Count.EqualTo(1));
            Assert.That(result.Signers[0].Email, Is.EqualTo("test@example.com"));
        }

        [Test]
        public async Task CreateSignSessionAsync()
        {
            // Arrange
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            var signSession = new SignSession
            {
                Title = "Test Sign Session",
                Description = "Test Description",
                Documents = new List<SignSessionDocument>
                {
                    new SignSessionDocument { DocumentId = uploadedDoc.DocumentId }
                },
                Signers = new List<Signer>
                {
                    new Signer
                    {
                        Email = "test@example.com",
                        FirstName = "Test",
                        LastName = "User"
                    }
                }
            };

            // Act
            var result = await _signService.CreateSignSessionAsync(signSession);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.SignSessionId, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo(signSession.Title));
            Assert.That(result.Description, Is.EqualTo(signSession.Description));
            Assert.That(result.Documents, Has.Count.EqualTo(1));
            Assert.That(result.Documents[0].DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
            Assert.That(result.Signers, Has.Count.EqualTo(1));
            Assert.That(result.Signers[0].Email, Is.EqualTo("test@example.com"));
        }

        [Test]
        public void GetSignSession()
        {
            // Arrange
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            var signSession = new SignSession
            {
                Title = "Test Sign Session",
                Description = "Test Description",
                Documents = new List<SignSessionDocument>
                {
                    new SignSessionDocument { DocumentId = uploadedDoc.DocumentId }
                },
                Signers = new List<Signer>
                {
                    new Signer
                    {
                        Email = "test@example.com",
                        FirstName = "Test",
                        LastName = "User"
                    }
                }
            };

            var createdSession = _signService.CreateSignSession(signSession);

            // Act
            var result = _signService.GetSignSession(createdSession.SignSessionId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.SignSessionId, Is.EqualTo(createdSession.SignSessionId));
            Assert.That(result.Title, Is.EqualTo(signSession.Title));
            Assert.That(result.Description, Is.EqualTo(signSession.Description));
            Assert.That(result.Documents, Has.Count.EqualTo(1));
            Assert.That(result.Documents[0].DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
            Assert.That(result.Signers, Has.Count.EqualTo(1));
            Assert.That(result.Signers[0].Email, Is.EqualTo("test@example.com"));
        }

        [Test]
        public async Task GetSignSessionAsync()
        {
            // Arrange
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            var signSession = new SignSession
            {
                Title = "Test Sign Session",
                Description = "Test Description",
                Documents = new List<SignSessionDocument>
                {
                    new SignSessionDocument { DocumentId = uploadedDoc.DocumentId }
                },
                Signers = new List<Signer>
                {
                    new Signer
                    {
                        Email = "test@example.com",
                        FirstName = "Test",
                        LastName = "User"
                    }
                }
            };

            var createdSession = await _signService.CreateSignSessionAsync(signSession);

            // Act
            var result = await _signService.GetSignSessionAsync(createdSession.SignSessionId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.SignSessionId, Is.EqualTo(createdSession.SignSessionId));
            Assert.That(result.Title, Is.EqualTo(signSession.Title));
            Assert.That(result.Description, Is.EqualTo(signSession.Description));
            Assert.That(result.Documents, Has.Count.EqualTo(1));
            Assert.That(result.Documents[0].DocumentId, Is.EqualTo(uploadedDoc.DocumentId));
            Assert.That(result.Signers, Has.Count.EqualTo(1));
            Assert.That(result.Signers[0].Email, Is.EqualTo("test@example.com"));
        }

        [Test]
        public void DeleteSignSession()
        {
            // Arrange
            var uploadedDoc = _signService.UploadDocument(TestFileName, _testFileData);
            var signSession = new SignSession
            {
                Title = "Test Sign Session",
                Description = "Test Description",
                Documents = new List<SignSessionDocument>
                {
                    new SignSessionDocument { DocumentId = uploadedDoc.DocumentId }
                },
                Signers = new List<Signer>
                {
                    new Signer
                    {
                        Email = "test@example.com",
                        FirstName = "Test",
                        LastName = "User"
                    }
                }
            };

            var createdSession = _signService.CreateSignSession(signSession);

            // Act
            _signService.DeleteSignSession(createdSession.SignSessionId);

            // Assert
            Assert.Throws<SignicatException>(() =>
                _signService.GetSignSession(createdSession.SignSessionId));
        }

        [Test]
        public async Task DeleteSignSessionAsync()
        {
            // Arrange
            var uploadedDoc = await _signService.UploadDocumentAsync(TestFileName, _testFileData);
            var signSession = new SignSession
            {
                Title = "Test Sign Session",
                Description = "Test Description",
                Documents = new List<SignSessionDocument>
                {
                    new SignSessionDocument { DocumentId = uploadedDoc.DocumentId }
                },
                Signers = new List<Signer>
                {
                    new Signer
                    {
                        Email = "test@example.com",
                        FirstName = "Test",
                        LastName = "User"
                    }
                }
            };

            var createdSession = await _signService.CreateSignSessionAsync(signSession);

            // Act
            await _signService.DeleteSignSessionAsync(createdSession.SignSessionId);

            // Assert
            Assert.ThrowsAsync<SignicatException>(async () =>
                await _signService.GetSignSessionAsync(createdSession.SignSessionId));
        }
    }
} 