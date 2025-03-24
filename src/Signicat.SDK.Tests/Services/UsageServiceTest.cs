using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Signicat.Infrastructure;
using Signicat.Services.Usage;

namespace Signicat.SDK.Tests.Services;

public class UsageServiceTest : BaseTest
{
    private readonly IUsageService _usageService;

    public UsageServiceTest()
    {
        SignicatConfiguration.SetClientCredentials(
            Environment.GetEnvironmentVariable("SIGNICAT_INVOICE_TEST_CLIENT_ID"),
            Environment.GetEnvironmentVariable("SIGNICAT_INVOICE_TEST_CLIENT_SECRET"));


        _usageService =
            new UsageService(Environment.GetEnvironmentVariable("SIGNICAT_USAGE_TEST_ORGANISATIONID"));
    }

    [Test]
    public async Task GetUsageForOrganisationAsync()
    {
        var usage = await _usageService.GetUsageAsync(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31),limit:10);
        
        Assert.That(usage.Next, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data.Count(), Is.EqualTo(10));

    }
    
    [Test]
    public async Task GetUsageForOrganisationUsingNextLinkAsync()
    {
        var usage = await _usageService.GetUsageAsync(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31),limit:10);
        
        Assert.That(usage.Next, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data.Count(), Is.EqualTo(10));

        usage = await _usageService.GetUsageAsync(usage.Next);
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data.Count(), Is.EqualTo(10));

        usage = await _usageService.GetNextAsync(usage);
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data.Count(), Is.EqualTo(10));

    }
    
    

    
    [Test]
    public async Task GetUsageForOrganisationAggregatedOnOrganisationAccountIdShouldBeNullAsync()
    {
        var usage = await _usageService.GetUsageAsync(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31), aggregateByLevel:AggregateByLevel.ORGANIZATION);
        
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        foreach (var usageData in usage.Data)
        {
            Assert.That(usageData.AccountId, Is.Null);
        }

    }
    
    [Test]
    public async Task GetUsageForOrganisationAggregatedOnAccountLevelAccountIdShouldNotBeNullAsync()
    {
        var usage = await _usageService.GetUsageAsync(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31),
            aggregateByLevel:AggregateByLevel.ACCOUNT);
        
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        foreach (var usageData in usage.Data)
        {
            Assert.That(usageData.AccountId, Is.Not.Null.Or.Empty);
            Assert.That(usageData.AccountId!.StartsWith("a-"),Is.True);
        }

    }
    
    
     [Test]
    public void GetUsageForOrganisation()
    {
        var usage =  _usageService.GetUsage(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31),limit:10);
        
        Assert.That(usage.Next, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data.Count(), Is.EqualTo(10));

    }
    
    [Test]
    public void GetUsageForOrganisationUsingNextLink()
    {
        var usage =  _usageService.GetUsage(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31),limit:10);
        
        Assert.That(usage.Next, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data.Count(), Is.EqualTo(10));

        usage =  _usageService.GetUsage(usage.Next);
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data.Count(), Is.EqualTo(10));

        usage =  _usageService.GetNext(usage);
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        Assert.That(usage.Data.Count(), Is.EqualTo(10));

    }
    
    

    
    [Test]
    public void GetUsageForOrganisationAggregatedOnOrganisationAccountIdShouldBeNull()
    {
        var usage =  _usageService.GetUsage(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31), aggregateByLevel:AggregateByLevel.ORGANIZATION);
        
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        foreach (var usageData in usage.Data)
        {
            Assert.That(usageData.AccountId, Is.Null);
        }

    }
    
    [Test]
    public void GetUsageForOrganisationAggregatedOnAccountLevelAccountIdShouldNotBeNull()
    {
        var usage =  _usageService.GetUsage(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31),
            aggregateByLevel:AggregateByLevel.ACCOUNT);
        
        Assert.That(usage.Data, Is.Not.Null.Or.Empty);
        foreach (var usageData in usage.Data)
        {
            Assert.That(usageData.AccountId, Is.Not.Null.Or.Empty);
            Assert.That(usageData.AccountId!.StartsWith("a-"),Is.True);
        }

    }


    // Build url tests
    [Test]
    public void BuildUrl_WithOnlyFromDate_ShouldConstructCorrectUrl()
    {
        // Arrange
        var fromDate = new DateTime(2023, 5, 1);

        // Act
        var result = UsageService.BuildUrl(fromDate);

        // Assert
        StringAssert.StartsWith($"{Urls.UsageTransactions}?fromDate=2023-05-01", result);
        StringAssert.DoesNotContain("&offset=0", result);
        StringAssert.DoesNotContain("&toDate=", result);
        StringAssert.DoesNotContain("&includeExternalReference=", result);
        StringAssert.DoesNotContain("&aggregateByDate=", result);
        StringAssert.DoesNotContain("&aggregateByLevel=", result);
        StringAssert.DoesNotContain("&includeChildOrganisations=", result);
        StringAssert.DoesNotContain("&limit=", result);
    }

    [Test]
    public void BuildUrl_WithToDate_ShouldIncludeToDateParameter()
    {
        // Arrange
        var fromDate = new DateTime(2023, 5, 1);
        var toDate = new DateTime(2023, 5, 31);

        // Act
        var result = UsageService.BuildUrl(fromDate, toDate);

        // Assert
        StringAssert.StartsWith($"{Urls.UsageTransactions}?fromDate=2023-05-01", result);
        StringAssert.Contains("&toDate=2023-05-31", result);
        StringAssert.DoesNotContain("&offset=0", result);
        StringAssert.DoesNotContain("&includeExternalReference", result);
        StringAssert.DoesNotContain("&aggregateByDate=", result);
        StringAssert.DoesNotContain("&aggregateByLevel=", result);
        StringAssert.DoesNotContain("&includeChildOrganisations", result);
        StringAssert.DoesNotContain("&limit=", result);
    }

    [Test]
    public void BuildUrl_WithIncludeExternalReferenceTrue_ShouldIncludeParameter()
    {
        // Arrange
        var fromDate = new DateTime(2023, 5, 1);
        
        // Act
        var result = UsageService.BuildUrl(fromDate, includeExternalReference: true);

        // Assert
        StringAssert.StartsWith($"{Urls.UsageTransactions}?fromDate=2023-05-01", result);
        StringAssert.Contains("&includeExternalReference=true", result);
        StringAssert.DoesNotContain("&offset=0", result);
        StringAssert.DoesNotContain("&toDate=", result);
        StringAssert.DoesNotContain("&aggregateByDate=", result);
        StringAssert.DoesNotContain("&aggregateByLevel=", result);
        StringAssert.DoesNotContain("&includeChildOrganisations", result);
        StringAssert.DoesNotContain("&limit=", result);
    }

    [Test]
    public void BuildUrl_WithAggregateByDate_ShouldIncludeAggregateByDateParameter()
    {
        // Arrange
        var fromDate = new DateTime(2023, 5, 1);
        var aggregateByDate = AggregateByDates.MONTHLY;

        // Act
        var result = UsageService.BuildUrl(fromDate, aggregateByDate: aggregateByDate);

        // Assert
        StringAssert.StartsWith($"{Urls.UsageTransactions}?fromDate=2023-05-01", result);
        StringAssert.Contains($"&aggregateByDate=monthly", result);
        StringAssert.DoesNotContain("&offset=0", result);
        StringAssert.DoesNotContain("&toDate=", result);
        StringAssert.DoesNotContain("&includeExternalReference", result);
        StringAssert.DoesNotContain("&aggregateByLevel=", result);
        StringAssert.DoesNotContain("&includeChildOrganisations", result);
        StringAssert.DoesNotContain("&limit=", result);
    }

    [Test]
    public void BuildUrl_ShouldFormatDatesCorrectly()
    {
        // Arrange
        var fromDate = new DateTime(2023, 12, 31);
        var toDate = new DateTime(2024, 1, 1);

        // Act
        var result = UsageService.BuildUrl(fromDate, toDate);

        // Assert
        StringAssert.Contains("fromDate=2023-12-31", result);
        StringAssert.Contains("toDate=2024-01-01", result);
    }

    [Test]
    public void BuildUrl_WithIncludeChildOrganisationsTrue_ShouldIncludeParameter()
    {
        // Arrange
        var fromDate = new DateTime(2023, 5, 1);
        
        // Act
        var result = UsageService.BuildUrl(fromDate, includeChildOrganisations: true);

        // Assert
        StringAssert.StartsWith($"{Urls.UsageTransactions}?fromDate=2023-05-01", result);
        StringAssert.Contains("&includeChildOrganisations=true", result);
        StringAssert.DoesNotContain("&offset=0", result);
        StringAssert.DoesNotContain("&toDate=", result);
        StringAssert.DoesNotContain("&includeExternalReference", result);
        StringAssert.DoesNotContain("&aggregateByDate=", result);
        StringAssert.DoesNotContain("&aggregateByLevel=", result);
        StringAssert.DoesNotContain("&limit=", result);
    }
    
    [Test]
    public void BuildUrl_WithLimit_ShouldIncludeParameter()
    {
        // Arrange
        var fromDate = new DateTime(2023, 5, 1);

        // Act
        var result = UsageService.BuildUrl(fromDate, limit:100);

        // Assert
        StringAssert.StartsWith($"{Urls.UsageTransactions}?fromDate=2023-05-01", result);
        StringAssert.DoesNotContain("&includeChildOrganisations=true", result);
        StringAssert.DoesNotContain("&offset=0", result);
        StringAssert.DoesNotContain("&toDate=", result);
        StringAssert.DoesNotContain("&includeExternalReference", result);
        StringAssert.DoesNotContain("&aggregateByDate=", result);
        StringAssert.DoesNotContain("&aggregateByLevel=", result);
        StringAssert.Contains("&limit=100", result);
    }
}