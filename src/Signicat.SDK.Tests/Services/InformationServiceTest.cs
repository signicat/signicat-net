using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Information;

namespace Signicat.SDK.Tests;

public class InformationServiceTest : BaseTest
{
    private IInformationService _informationService;

    [SetUp]
    public void Setup()
    {
        _informationService = new InformationService();
    }

    [Test]
    public async Task TestBrregAsync()
    {
        var result = await _informationService.GetBasicOrganizationInfoAsync("NO", "989584022");

        Assert.IsNotNull(result);
        Assert.IsTrue("Signicat AS".Equals(result.Name, StringComparison.CurrentCultureIgnoreCase));
    }

    [Test]
    public void TestBrreg()
    {
        var result = _informationService.GetBasicOrganizationInfo("NO", "989584022");

        Assert.IsNotNull(result);
        Assert.IsTrue("Signicat AS".Equals(result.Name, StringComparison.CurrentCultureIgnoreCase));
    }
}