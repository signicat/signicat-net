using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Signicat.Services.Signing.Sign_v2;
using Signicat.Services.Signing.Sign_v2.Entities;
using Signicat.SDK.Fluent;

namespace Signicat.SDK.Tests.Fluent
{
    [TestFixture]
    public class SignServiceFluentTest
    {
        private Mock<ISignService> _signServiceMock;
        private SignServiceFluent _signServiceFluent;

        [SetUp]
        public void SetUp()
        {
            _signServiceMock = new Mock<ISignService>();
            _signServiceFluent = new SignServiceFluent(_signServiceMock.Object);
        }

        [Test]
        public async Task UploadDocument_CreateDocumentCollection_CreateSigningSession_FluentChain()
        {
            // Arrange
            var fileName = "test.pdf";
            var fileData = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("test content"));
            var uploadedDocument = new Document { DocumentId = "uploadedDocId" };
            var createdDocumentCollection = new DocumentCollection { Id = "createdDocCollectionId" };
            var createdSigningSessions = new SigningSessions { new SigningSession { Id = "createdSessionId", SignatureUrl = "http://test.url" } };

            _signServiceMock
                .Setup(x => x.UploadDocumentAsync(It.IsAny<string>(), It.IsAny<Stream>()))
                .ReturnsAsync(uploadedDocument);

            _signServiceMock
                .Setup(x => x.CreateDocumentCollectionAsync(It.IsAny<CreateDocumentCollectionOptions>()))
                .ReturnsAsync(createdDocumentCollection);

            _signServiceMock
                .Setup(x => x.CreateSignSessionsAsync(It.IsAny<CreateSignSessionsOptions>()))
                .ReturnsAsync(createdSigningSessions);

            // Act
            var document = await _signServiceFluent
                .UploadDocument(fileName, fileData)
                .UploadAsync();

            var documentCollection = await _signServiceFluent
                .CreateDocumentCollection()
                .WithDocument(document)
                .CreateAsync();

            var signingSessions = await _signServiceFluent
                .CreateSigningSession()
                .WithTitle("Test Session")
                .WithSessionDocument(document, documentCollection, doc => doc.Action = SessionDocumentAction.SIGN)
                .CreateAsync();

            // Assert
            _signServiceMock.Verify(x => x.UploadDocumentAsync(fileName, fileData), Times.Once);
            _signServiceMock.Verify(x => x.CreateDocumentCollectionAsync(It.Is<CreateDocumentCollectionOptions>(
                opt => opt.Documents.Count == 1 && opt.Documents[0].DocumentId == uploadedDocument.DocumentId
            )), Times.Once);
            _signServiceMock.Verify(x => x.CreateSignSessionsAsync(It.Is<CreateSignSessionsOptions>(
                opt => opt.Count == 1 && opt[0].Title == "Test Session" && opt[0].Documents.Count == 1 && opt[0].Documents[0].DocumentCollectionId == createdDocumentCollection.Id
            )), Times.Once);

            Assert.That(document.DocumentId, Is.EqualTo(uploadedDocument.DocumentId));
            Assert.That(documentCollection.Id, Is.EqualTo(createdDocumentCollection.Id));
            Assert.That(signingSessions.Count, Is.EqualTo(1));
            Assert.That(signingSessions[0].Id, Is.EqualTo(createdSigningSessions[0].Id));
            Assert.That(signingSessions[0].SignatureUrl, Is.EqualTo(createdSigningSessions[0].SignatureUrl));
        }
    }
}
