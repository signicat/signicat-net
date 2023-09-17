using NUnit.Framework;
using Signicat.Services.Signing.Enterprise;

namespace Signicat.SDK.Tests.Signing;

public class EnterpriseSigningTest: BaseTest
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
        
    }
}