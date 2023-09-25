using System;
using System.IO;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Signicat.SDK.Tests.Helpers;
using Signicat.Services.Signing.Enterprise;

namespace Signicat.SDK.Tests.Signing;


public class EnterpriseSigningTestSignarureEndpoints : BaseTest
{
    private IEnterpriseSignatureService _service;

    [SetUp]
    public void Setup()
    {
        _service = new EnterpriseSignatureService();
    }
}

public class EnterpriseSigningTestDocumentEndpoints: BaseTest
{
    private IEnterpriseSignatureService _service;

    [SetUp]
    public void Setup()
    {
        _service = new EnterpriseSignatureService();
    }


    [Test]
    public void UploadSessionDocumentShouldReturnNotNull()
    {
        var result = _service.UploadSessionDocument("dummy.pdf", File.ReadAllBytes(@"Services/Signing/dummy.pdf"));
        Assert.That(result.DocumentId,Is.Not.Empty);
        Console.WriteLine(result.DocumentId);
    }
    
    [Test]
    public async Task UploadSessionDocumentAsyncShouldReturnNotNull()
    {
        var result = await _service.UploadSessionDocumentAsync("dummy.pdf", File.ReadAllBytes(@"Services/Signing/dummy.pdf"));
        Assert.That(result.DocumentId,Is.Not.Empty);
        Console.WriteLine(result.DocumentId);
    }
    
    [Test]
    public void DownloadDocumentShouldReturnTheSameDocument()
    {
        var fileData = File.ReadAllBytes(@"Services/Signing/dummy.pdf");
        var result = _service.UploadSessionDocument("dummy.pdf", fileData);

        var document = _service.GetDocument(result.DocumentId);
        
        Assert.That(document, Is.Not.Null);
        Assert.That(FileHelper.CompareByteArrayAndStream(fileData, document),Is.True);
    }
    
    [Test]
    public async Task DownloadDocumentAsyncShouldReturnTheSameDocument()
    {
        var fileData = await File.ReadAllBytesAsync(@"Services/Signing/dummy.pdf");
        var result = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);

        var document = await _service.GetDocumentAsync(result.DocumentId);
        
        Assert.That(document, Is.Not.Null);
        Assert.That(FileHelper.CompareByteArrayAndStream(fileData, document),Is.True);
    }
    
    [Test]
    public void DeleteDocumentShouldBeSuccess()
    {
        var fileData = File.ReadAllBytes(@"Services/Signing/dummy.pdf");
        var result = _service.UploadSessionDocument("dummy.pdf", fileData);

        var document = _service.GetDocument(result.DocumentId);
        
        _service.DeleteDocument(result.DocumentId);
    }
    
    [Test]
    public async Task DeleteDocumentAsyncShouldBeSuccess()
    {
        var fileData = await File.ReadAllBytesAsync(@"Services/Signing/dummy.pdf");
        var result = await _service.UploadSessionDocumentAsync("dummy.pdf", fileData);

        await _service.DeleteDocumentAsync(result.DocumentId);
        
        
    }
}