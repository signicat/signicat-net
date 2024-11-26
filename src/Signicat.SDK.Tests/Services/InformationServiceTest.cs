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

        Assert.That(result, Is.Not.Null);
        Assert.That("Signicat AS".Equals(result.Name, StringComparison.CurrentCultureIgnoreCase), Is.True);
    }

    [Test]
    public void TestBrreg()
    {
        var result = _informationService.GetBasicOrganizationInfo("NO", "989584022");

        Assert.That(result, Is.Not.Null);
        Assert.That("Signicat AS".Equals(result.Name, StringComparison.CurrentCultureIgnoreCase), Is.True);
    }
}