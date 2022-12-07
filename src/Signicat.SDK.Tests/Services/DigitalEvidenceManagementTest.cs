using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.DigitalEvidenceManagement;
using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.SDK.Tests;

public class DigitalEvidenceManagementTest : BaseTest
{
    private readonly DemRecordCreateOptions sampleCreate = new()
    {
        Metadata = new Dictionary<string, object>
        {
            {"timestamp", DateTime.Now},
            {"hash", "fe8df9859245b024ec1c0f6f825a3b4441fc0dee37dc28e09cc64308ba6714f3"}
        },
        Type = RecordTypes.LOG_IN,
        TimeToLiveInDays = 2,
        CoreData = new Dictionary<string, object>
        {
            {"name", "Bruce Wayne"},
            {"identityProvider", "WayneEnterpriseCorporateId"},
            {"subject", "9764384103"}
        },
        AuditLevel = AuditLevels.ADVANCED
    };

    private DigitalEvidenceManagementService _digitalEvidenceManagement;

    [SetUp]
    public void Setup()
    {
        _digitalEvidenceManagement = new DigitalEvidenceManagementService();
    }

    [Test]
    public async Task CreateNewRecordAsync()
    {
        var record = await _digitalEvidenceManagement.CreateDemRecordAsync(sampleCreate);

        Assert.IsNotNull(record);
        Assert.AreNotEqual(Guid.Empty, record.Id);
    }

    [Test]
    public void CreateNewRecordAsyncInvalidParams()
    {
        /*var exception= Assert.ThrowsAsync<SignicatException>(() =>
             _digitalEvidenceManagement.CreateDemRecordAsync(new DemRecordCreateOptions()
             {
                 Metadata = null,
                 CoreData = null
             }));

        Console.WriteLine(exception);*/
    }

    [Test]
    public void CreateNewRecord()
    {
        var record = _digitalEvidenceManagement.CreateDemRecord(sampleCreate);

        Assert.IsNotNull(record);
        Assert.AreNotEqual(Guid.Empty, record.Id);
    }

    [Test]
    public async Task GetRecordAsync()
    {
        var record = await _digitalEvidenceManagement.CreateDemRecordAsync(sampleCreate);

        Assert.IsNotNull(record);

        var retrievedRecord = await _digitalEvidenceManagement.GetRecordAsync(record.Id);

        Assert.IsTrue(sampleCreate.IsTheSame(retrievedRecord));
    }

    [Test]
    public void GetRecord()
    {
        var record = _digitalEvidenceManagement.CreateDemRecord(sampleCreate);

        Assert.IsNotNull(record);

        var retrievedRecord = _digitalEvidenceManagement.GetRecord(record.Id);

        Assert.IsTrue(sampleCreate.IsTheSame(retrievedRecord));
    }

    [Test]
    public void Query()
    {
        var searchResult = _digitalEvidenceManagement.Query(new DemRecordSearchCreateOptions());

        Assert.IsNotNull(searchResult);
    }

    [Test]
    public async Task QueryAsync()
    {
        var searchResult = await _digitalEvidenceManagement.QueryAsync(new DemRecordSearchCreateOptions());

        Assert.IsNotNull(searchResult);
    }

    [Test]
    public void Info()
    {
        var statistics = _digitalEvidenceManagement.GetStatistics();

        Assert.IsNotNull(statistics);
    }

    [Test]
    public async Task InfoAsync()
    {
        var statistics = await _digitalEvidenceManagement.GetStatisticsAsync();

        Assert.IsNotNull(statistics);
    }

    [Test]
    public void GetStatisticsCustomFields()
    {
        var statistics = _digitalEvidenceManagement.GetCustomFields();

        Assert.IsNotNull(statistics);
    }

    [Test]
    public async Task GetStatisticsCustomFieldsAsync()
    {
        var statistics = await _digitalEvidenceManagement.GetCustomFieldsAsync(RecordTypes.LOG_IN);

        Assert.IsNotNull(statistics);
    }
}