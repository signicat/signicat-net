using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using NUnit.Framework;
using Signicat.Services.Signing.Express;
using Signicat.Services.Signing.Express.Entities;

namespace Signicat.SDK.Tests.Signing;

[TestFixture]
public class SignatureServiceTest : BaseTest
{
    private readonly ExpressSignatureService _expressSignatureService;
    private Guid _documentId;
    private Guid _signerId;
    private Guid _attachmentId;

    public SignatureServiceTest()
    {
        _expressSignatureService = new ExpressSignatureService();
    }

    [SetUp]
    public void Setup()
    {
        _documentId = Guid.NewGuid();
        _signerId = Guid.NewGuid();
        _attachmentId = Guid.NewGuid();
    }

    [Test]
    public void GetDocument()
    {
        var document = _expressSignatureService.GetDocument(_documentId);

        Assert.IsNotNull(document);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}");
    }

    [Test]
    public async Task GetDocumentAsync()
    {
        var document = await _expressSignatureService.GetDocumentAsync(_documentId);

        Assert.IsNotNull(document);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}");
    }

    [Test]
    public void CreateDocument()
    {
        var options = Fixture.Create<DocumentCreateOptions>();
        var document = _expressSignatureService.CreateDocument(options);

        Assert.IsNotNull(document);
        AssertRequest(HttpMethod.Post, "/signature/documents");
    }

    [Test]
    public async Task CreateDocumentAsync()
    {
        var options = Fixture.Create<DocumentCreateOptions>();
        var document = await _expressSignatureService.CreateDocumentAsync(options);

        Assert.IsNotNull(document);
        AssertRequest(HttpMethod.Post, "/signature/documents");
    }

    [Test]
    public void UpdateDocument()
    {
        var options = Fixture.Create<DocumentUpdateOptions>();
        var document = _expressSignatureService.UpdateDocument(_documentId, options);

        Assert.IsNotNull(document);
        AssertRequest(new HttpMethod("PATCH"), $"/signature/documents/{_documentId}");
    }

    [Test]
    public async Task UpdateDocumentAsync()
    {
        var options = Fixture.Create<DocumentUpdateOptions>();
        var document = await _expressSignatureService.UpdateDocumentAsync(_documentId, options);

        Assert.IsNotNull(document);
        AssertRequest(new HttpMethod("PATCH"), $"/signature/documents/{_documentId}");
    }

    [Test]
    public void CancelDocument()
    {
        _expressSignatureService.CancelDocument(_documentId);

        AssertRequest(HttpMethod.Post, $"/signature/documents/{_documentId}/cancel");
    }

    [Test]
    public async Task CancelDocumentAsync()
    {
        await _expressSignatureService.CancelDocumentAsync(_documentId);

        AssertRequest(HttpMethod.Post, $"/signature/documents/{_documentId}/cancel");
    }

    [Test]
    public void GetDocumentStatus()
    {
        var status = _expressSignatureService.GetDocumentStatus(_documentId);

        Assert.IsNotNull(status);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/status");
    }

    [Test]
    public async Task GetDocumentStatusAsync()
    {
        var status = await _expressSignatureService.GetDocumentStatusAsync(_documentId);

        Assert.IsNotNull(status);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/status");
    }

    [Test]
    public void GetDocumentSummary()
    {
        var summary = _expressSignatureService.GetDocumentSummary(_documentId);

        Assert.IsNotNull(summary);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/summary");
    }

    [Test]
    public async Task GetDocumentSummaryAsync()
    {
        var summary = await _expressSignatureService.GetDocumentSummaryAsync(_documentId);

        Assert.IsNotNull(summary);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/summary");
    }

    [Test]
    public void ListDocumentSummaries()
    {
        var summaries = _expressSignatureService.ListDocumentSummaries();

        Assert.IsNotNull(summaries);
        Assert.IsNotEmpty(summaries.Data);
        AssertRequest(HttpMethod.Get, $"/signature/documents/summary");
    }

    [Test]
    public async Task ListDocumentSummariesAsync()
    {
        var summaries = await _expressSignatureService.ListDocumentSummariesAsync();

        Assert.IsNotNull(summaries);
        Assert.IsNotEmpty(summaries.Data);
        AssertRequest(HttpMethod.Get, $"/signature/documents/summary");
    }

    [Test]
    public void GetSigner()
    {
        var signer = _expressSignatureService.GetSigner(_documentId, _signerId);

        Assert.IsNotNull(signer);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/signers/{_signerId}");
    }

    [Test]
    public async Task GetSignerAsync()
    {
        var signer = await _expressSignatureService.GetSignerAsync(_documentId, _signerId);

        Assert.IsNotNull(signer);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/signers/{_signerId}");
    }

    [Test]
    public void CreateSigner()
    {
        var options = Fixture.Create<SignerOptions>();
        var signer = _expressSignatureService.CreateSigner(_documentId, options);

        Assert.IsNotNull(signer);
        AssertRequest(HttpMethod.Post, $"/signature/documents/{_documentId}/signers");
    }

    [Test]
    public async Task CreateSignerAsync()
    {
        var options = Fixture.Create<SignerOptions>();
        var signer = await _expressSignatureService.CreateSignerAsync(_documentId, options);

        Assert.IsNotNull(signer);
        AssertRequest(HttpMethod.Post, $"/signature/documents/{_documentId}/signers");
    }

    [Test]
    public void DeleteSigner()
    {
        _expressSignatureService.DeleteSigner(_documentId, _signerId);

        AssertRequest(HttpMethod.Delete, $"/signature/documents/{_documentId}/signers/{_signerId}");
    }

    [Test]
    public async Task DeleteSignerAsync()
    {
        await _expressSignatureService.DeleteSignerAsync(_documentId, _signerId);

        AssertRequest(HttpMethod.Delete, $"/signature/documents/{_documentId}/signers/{_signerId}");
    }

    [Test]
    public void ListSigners()
    {
        var signers = _expressSignatureService.ListSigners(_documentId);

        Assert.IsNotNull(signers);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/signers");
    }

    [Test]
    public async Task ListSignersAsync()
    {
        var signers = await _expressSignatureService.ListSignersAsync(_documentId);

        Assert.IsNotNull(signers);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/signers");
    }

    [Test]
    public void GetAttachment()
    {
        var attachment = _expressSignatureService.GetAttachment(_documentId, _attachmentId);

        Assert.IsNotNull(attachment);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/attachments/{_attachmentId}");
    }

    [Test]
    public async Task GetAttachmentAsync()
    {
        var attachment = await _expressSignatureService.GetAttachmentAsync(_documentId, _attachmentId);

        Assert.IsNotNull(attachment);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/attachments/{_attachmentId}");
    }

    [Test]
    public void CreateAttachment()
    {
        var options = Fixture.Create<AttachmentOptions>();
        var attachment = _expressSignatureService.CreateAttachment(_documentId, options);

        Assert.IsNotNull(attachment);
        AssertRequest(HttpMethod.Post, $"/signature/documents/{_documentId}/attachments");
    }

    [Test]
    public async Task CreateAttachmentAsync()
    {
        var options = Fixture.Create<AttachmentOptions>();
        var attachment = await _expressSignatureService.CreateAttachmentAsync(_documentId, options);

        Assert.IsNotNull(attachment);
        AssertRequest(HttpMethod.Post, $"/signature/documents/{_documentId}/attachments");
    }

    [Test]
    public void UpdateAttachment()
    {
        var options = Fixture.Create<AttachmentOptions>();
        var attachment = _expressSignatureService.UpdateAttachment(_documentId, _attachmentId, options);

        Assert.IsNotNull(attachment);
        AssertRequest(new HttpMethod("PATCH"), $"/signature/documents/{_documentId}/attachments/{_attachmentId}");
    }

    [Test]
    public async Task UpdateAttachmentAsync()
    {
        var options = Fixture.Create<AttachmentOptions>();
        var attachment = await _expressSignatureService.UpdateAttachmentAsync(_documentId, _attachmentId, options);

        Assert.IsNotNull(attachment);
        AssertRequest(new HttpMethod("PATCH"), $"/signature/documents/{_documentId}/attachments/{_attachmentId}");
    }

    [Test]
    public void DeleteAttachment()
    {
        _expressSignatureService.DeleteAttachment(_documentId, _attachmentId);

        AssertRequest(HttpMethod.Delete, $"/signature/documents/{_documentId}/attachments/{_attachmentId}");
    }

    [Test]
    public async Task DeleteAttachmentAsync()
    {
        await _expressSignatureService.DeleteAttachmentAsync(_documentId, _attachmentId);

        AssertRequest(HttpMethod.Delete, $"/signature/documents/{_documentId}/attachments/{_attachmentId}");
    }

    [Test]
    public void ListAttachments()
    {
        var attachments = _expressSignatureService.ListAttachments(_documentId);

        Assert.IsNotNull(attachments);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/attachments");
    }

    [Test]
    public async Task ListAttachmentsAsync()
    {
        var attachments = await _expressSignatureService.ListAttachmentsAsync(_documentId);

        Assert.IsNotNull(attachments);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/attachments");
    }

    [Test]
    public void GetFile()
    {
        var file = _expressSignatureService.GetFile(_documentId, FileFormat.Pades);

        Assert.IsNotNull(file);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/files?fileFormat=pades");
    }

    [Test]
    public async Task GetFileAsync()
    {
        var file = await _expressSignatureService.GetFileAsync(_documentId, FileFormat.Pades);

        Assert.IsNotNull(file);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/files?fileFormat=pades");
    }

    [Test]
    public void GetFileForSigner()
    {
        var file = _expressSignatureService.GetFileForSigner(_documentId, _signerId, FileFormat.Pades);

        Assert.IsNotNull(file);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/files/signers/{_signerId}?fileFormat=pades");
    }

    [Test]
    public async Task GetFileForSignerAsync()
    {
        var file = await _expressSignatureService.GetFileForSignerAsync(_documentId, _signerId, FileFormat.Pades);

        Assert.IsNotNull(file);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/files/signers/{_signerId}?fileFormat=pades");
    }

    [Test]
    public void GetAttachmentFile()
    {
        var file = _expressSignatureService.GetAttachmentFile(_documentId, _attachmentId, FileFormat.Pades);

        Assert.IsNotNull(file);
        AssertRequest(HttpMethod.Get,
            $"/signature/documents/{_documentId}/files/attachments/{_attachmentId}?fileFormat=pades");
    }

    [Test]
    public async Task GetAttachmentFileAsync()
    {
        var file = await _expressSignatureService.GetAttachmentFileAsync(_documentId, _attachmentId, FileFormat.Pades);

        Assert.IsNotNull(file);
        AssertRequest(HttpMethod.Get,
            $"/signature/documents/{_documentId}/files/attachments/{_attachmentId}?fileFormat=pades");
    }

    [Test]
    public void GetAttachmentFileForSigner()
    {
        var file = _expressSignatureService.GetAttachmentFileForSigner(_documentId, _attachmentId, _signerId,
            FileFormat.Pades);

        Assert.IsNotNull(file);
        AssertRequest(HttpMethod.Get,
            $"/signature/documents/{_documentId}/files/attachments/{_attachmentId}/signers/{_signerId}?fileFormat=pades");
    }

    [Test]
    public async Task GetAttachmentFileForSignerAsync()
    {
        var file = await _expressSignatureService.GetAttachmentFileForSignerAsync(_documentId, _attachmentId, _signerId,
            FileFormat.Pades);

        Assert.IsNotNull(file);
        AssertRequest(HttpMethod.Get,
            $"/signature/documents/{_documentId}/files/attachments/{_attachmentId}/signers/{_signerId}?fileFormat=pades");
    }

    [Test]
    public void ListNotifications()
    {
        var notifications = _expressSignatureService.ListNotifications(_documentId);

        Assert.IsNotNull(notifications);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/notifications");
    }

    [Test]
    public async Task ListNotificationsAsync()
    {
        var notifications = await _expressSignatureService.ListNotificationsAsync(_documentId);

        Assert.IsNotNull(notifications);
        AssertRequest(HttpMethod.Get, $"/signature/documents/{_documentId}/notifications");
    }

    [Test]
    public void SendReminders()
    {
        var options = Fixture.Create<ManualReminder>();
        var reminder = _expressSignatureService.SendReminders(_documentId, options);

        Assert.IsNotNull(reminder);
        AssertRequest(HttpMethod.Post, $"/signature/documents/{_documentId}/notifications/reminder");
    }

    [Test]
    public async Task SendRemindersAsync()
    {
        var options = Fixture.Create<ManualReminder>();
        var reminder = await _expressSignatureService.SendRemindersAsync(_documentId, options);

        Assert.IsNotNull(reminder);
        AssertRequest(HttpMethod.Post, $"/signature/documents/{_documentId}/notifications/reminder");
    }

    [Test]
    public void ListThemes()
    {
        var themes = _expressSignatureService.ListThemes();

        Assert.IsNotNull(themes);
        AssertRequest(HttpMethod.Get, $"/signature/themes/list/themes");
    }

    [Test]
    public async Task ListThemesAsync()
    {
        var themes = await _expressSignatureService.ListThemesAsync();

        Assert.IsNotNull(themes);
        AssertRequest(HttpMethod.Get, $"/signature/themes/list/themes");
    }

    [Test]
    public void ListSpinners()
    {
        var spinners = _expressSignatureService.ListSpinners();

        Assert.IsNotNull(spinners);
        AssertRequest(HttpMethod.Get, $"/signature/themes/list/spinners");
    }

    [Test]
    public async Task ListSpinnersAsync()
    {
        var spinners = await _expressSignatureService.ListSpinnersAsync();

        Assert.IsNotNull(spinners);
        AssertRequest(HttpMethod.Get, $"/signature/themes/list/spinners");
    }

    [Test]
    public void ListSignatureMethods()
    {
        var methods = _expressSignatureService.ListSignatureMethods(SignatureMechanism.PkiSignature,
            FileType.Pdf, Language.EN, false);

        Assert.IsNotNull(methods);
        AssertRequest(HttpMethod.Get,
            "/signature/signature-methods?mechanism=pkisignature&fileType=pdf&language=EN&signableAttachments=False");
    }

    [Test]
    public async Task ListSignatureMethodsAsync()
    {
        var methods = await _expressSignatureService.ListSignatureMethodsAsync(SignatureMechanism.PkiSignature,
            FileType.Pdf, Language.EN, false);

        Assert.IsNotNull(methods);
        AssertRequest(HttpMethod.Get,
            "/signature/signature-methods?mechanism=pkisignature&fileType=pdf&language=EN&signableAttachments=False");
    }

    [Test]
    public void ListSignatureMethodsForAccount()
    {
        var methods = _expressSignatureService.ListSignatureMethodsForAccount(SignatureMechanism.PkiSignature,
            FileType.Pdf, Language.EN, false);

        Assert.IsNotNull(methods);
        AssertRequest(HttpMethod.Get,
            "/signature/signature-methods/account?mechanism=pkisignature&fileType=pdf&language=EN&signableAttachments=False");
    }

    [Test]
    public async Task ListSignatureMethodsForAccountAsync()
    {
        var methods = await _expressSignatureService.ListSignatureMethodsForAccountAsync(SignatureMechanism.PkiSignature,
            FileType.Pdf, Language.EN, false);

        Assert.IsNotNull(methods);
        AssertRequest(HttpMethod.Get,
            "/signature/signature-methods/account?mechanism=pkisignature&fileType=pdf&language=EN&signableAttachments=False");
    }
}