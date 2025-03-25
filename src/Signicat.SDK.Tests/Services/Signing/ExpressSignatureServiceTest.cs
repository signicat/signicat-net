using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Services.Signing.Express;
using Signicat.Services.Signing.Express.Entities;

namespace Signicat.SDK.Tests.Signing
{
    [TestFixture]
    public class ExpressSignatureServiceTest : BaseTest
    {
        private ExpressSignatureService _expressSignatureService;
        private Guid _documentId;
        private Guid _signerId;
        private DocumentCreateOptions _options;

        [SetUp]
        public void Setup()
        {
            _expressSignatureService = new ExpressSignatureService();
            _options = new DocumentCreateOptions()
            {
                Title = "SDK Unit test",
                Signers = new List<SignerOptions>()
                {
                    new()
                    {
                        ExternalSignerId = "Signer1",
                        RedirectSettings = new RedirectSettings()
                        {
                            RedirectMode = RedirectMode.DonotRedirect
                        },
                        SignatureType = new SignatureType()
                        {
                            Mechanism = SignatureMechanism.Handwritten
                        }
                    }
                },
                ExternalId = "iuasdfn",
                Advanced = new Advanced()
                {
                    Attachments = 1
                },
                ContactDetails = new ContactDetails()
                {
                    Email = "support@signicat.com"
                }
            };
        }


        [Test]
        public async Task A_CreateDocumentAsync()
        {
            var document = await _expressSignatureService.CreateDocumentAsync(_options);
            Assert.That(document.ExternalId, Is.EqualTo(_options.ExternalId));
            Assert.That(document, Is.Not.Null);
            _documentId = document.DocumentId;
            _signerId = document.Signers.First().Id;
        }

        [Test]
        public async Task B_GetDocumentAsync()
        {
            var document = await _expressSignatureService.GetDocumentAsync(_documentId);
            Assert.That(document, Is.Not.Null);
            Assert.That(document.ExternalId, Is.EqualTo(_options.ExternalId));
        }

        [Test]
        public async Task C_UpdateDocumentAsync()
        {
            var options = new DocumentUpdateOptions()
            {
                Title = "SDK Unit Test - Updated Doc"
            };

            var document = await _expressSignatureService.UpdateDocumentAsync(_documentId, options);

            Assert.That(document, Is.Not.Null);
            Assert.That(document.ExternalId, Is.EqualTo(_options.ExternalId));
            Assert.That(document.Title, Is.EqualTo(options.Title));
        }

        [Test]
        public async Task D_GetSignerAsync()
        {
            var signer = await _expressSignatureService.GetSignerAsync(_documentId, _signerId);

            Assert.That(signer, Is.Not.Null);
            Assert.That(signer.Id, Is.EqualTo(_signerId));
            Assert.That(signer.ExternalSignerId, Is.EqualTo(_options.Signers.First().ExternalSignerId));
        }

        [Test]
        public async Task E_CreateAttachmentAsync()
        {
            var opts = new AttachmentOptions()
            {
                FileName = "a.txt",
                Title = "Attahment 1",
                Data = "VGhpcyB0ZXh0IGNhbiBzYWZlbHkgYmUgc2lnbmVk",
                ConvertToPdf = true
            };
            var attachment = await _expressSignatureService.CreateAttachmentAsync(_documentId, opts);

            Assert.That(attachment, Is.Not.Null);
            Assert.That(attachment.Title, Is.EqualTo(opts.Title));
        }

        [Test]
        public async Task F_GetDocumentStatusAsync()
        {
            var status = await _expressSignatureService.GetDocumentStatusAsync(_documentId);

            Assert.That(status, Is.Not.Null);
            Assert.That(status.DocumentStatus, Is.EqualTo(DocumentStatus.Unsigned));
        }

        [Test]
        public async Task G_ListDocumentsAsync()
        {
            var docs = await _expressSignatureService.ListDocumentSummariesAsync();
            Assert.That(docs?.Data, Is.Not.Null);
            var doc = docs.Data.FirstOrDefault(d => d.DocumentId == _documentId);
            Assert.That(doc, Is.Not.Null);
        }

        [Test]
        public void H_CreateDocumentInvalidMapErrorCorrectAsync()
        {
            _options.Title = null;
            var error = Assert.ThrowsAsync<SignicatException>(async () =>
                await _expressSignatureService.CreateDocumentAsync(_options));

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(error.Error));
            Assert.That(error.HttpStatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            Assert.That(error.Error.ValidationErrors.First().PropertyName, Is.EqualTo("Title"));
            Assert.That(error.Error.ValidationErrors.First().Reason, Is.EqualTo("The Title field is required."));
        }

        [Test]
        public async Task Z_CancelDocumentAsync()
        {
            await _expressSignatureService.CancelDocumentAsync(_documentId, "Tesing");
            var doc = await _expressSignatureService.GetDocumentAsync(_documentId);
            await Task.Delay(2000);
            Assert.That(doc, Is.Not.Null);
            Assert.That(doc.Status.DocumentStatus, Is.EqualTo(DocumentStatus.Canceled));
        }

        [Test]
        public async Task MerchantSignAsync()
        {
            var request = new MerchantSignRequest()
            {
                DataFormat = MerchantDataFormat.Txt,
                DepartmentId = "oansdf",
                SigningFormat = MerchantSigningFormat.NoBankIdSeidSdo,
                DataEncodingFormat = MerchantEncodingFormat.Utf8,
                ExternalReference = "1234567890",
                DataToSign = "SGVsbG8sIFRoaXMgdGV4dCBpcyBuaWNlIHRvIHNpZ24Kw6bDuMOl"
            };
            var response = await _expressSignatureService.MerchantSignatureAsync(request);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.SignedData, Is.Not.Null);
            Assert.That(response.SignCertificateBase64String, Is.Not.Null);
        }
    }
}