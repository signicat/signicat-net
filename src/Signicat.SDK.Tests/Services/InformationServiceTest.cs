using System;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        Assert.IsTrue("Signicat AS".Equals(result.Name,StringComparison.CurrentCultureIgnoreCase));
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result, new JsonSerializerOptions(){WriteIndented = true}));

    }
    
    [Test]
    public void TestBrreg()
    {
        var result =  _informationService.GetBasicOrganizationInfo("NO", "989584022");
        
        Assert.IsNotNull(result);
        Assert.IsTrue("Signicat AS".Equals(result.Name,StringComparison.CurrentCultureIgnoreCase));
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result, new JsonSerializerOptions(){WriteIndented = true}));

    }
}