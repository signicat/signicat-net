using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.DigitalEvidenceManagement;
using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.SDK.Tests;

public class DigitalEvidenceManagementTest : BaseTest
{
    private DigitalEvidenceManagementService _digitalEvidenceManagement;

    private DemRecordCreateOptions sampleCreate = new DemRecordCreateOptions()
    {
        Metadata = new Dictionary<string, object>()
        {
            {"timestamp", DateTime.Now},
            {"hash", "fe8df9859245b024ec1c0f6f825a3b4441fc0dee37dc28e09cc64308ba6714f3"},
        },
        RecordType = RecordTypes.SIGNATURE,
        TimeToLiveInDays = 1,
        CoreData = new Dictionary<string, object>()
        {
            {"name", "Bruce Wayne"},
            {"identityProvider", "WayneEnterpriseCorporateId"},
            {"subject", "9764384103"}
        },
        
    };

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
    public void CreateNewRecord()
    {
        var record =  _digitalEvidenceManagement.CreateDemRecord(sampleCreate);
        
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
        var record =  _digitalEvidenceManagement.CreateDemRecord(sampleCreate);
        
        Assert.IsNotNull(record);

        var retrievedRecord =  _digitalEvidenceManagement.GetRecord(record.Id);
        
        Assert.IsTrue(sampleCreate.IsTheSame(retrievedRecord));
        
        
    }
}