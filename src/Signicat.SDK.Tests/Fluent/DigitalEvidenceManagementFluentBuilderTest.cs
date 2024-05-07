﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Authentication;
using Signicat.DigitalEvidenceManagement;
using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.SDK.Tests.Fluent;

public class DigitalEvidenceManagementFluentBuilderTest
{
    [Test]
    public void TestAuditLevelIsSet()
    {
        var options = DemRecordCreateOptionsBuilder.Create()
            .WithAuditLevel(AuditLevels.ADVANCED)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(AuditLevels.ADVANCED, options.AuditLevel);
    }

    [Test]
    public void TestTypeIsSet()
    {
        var options = DemRecordCreateOptionsBuilder.Create()
            .WithType(RecordTypes.TRANSACTION)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(RecordTypes.TRANSACTION, options.Type);
    }

    [Test]
    public void TestTimeToLiveIsSet()
    {
        var days = new Random(35).Next();
        var options = DemRecordCreateOptionsBuilder.Create()
            .WithTimeToLiveInDays(days)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(days, options.TimeToLiveInDays);
    }

    [Test]
    public void TestRelationsIsSet()
    {
        string value1 = Guid.NewGuid().ToString("n"), value2 = Guid.NewGuid().ToString("n");
        var options = DemRecordCreateOptionsBuilder.Create()
            .WithRelations(value1, value2)
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(2, options.Relations.Count());

        Assert.AreEqual(value1, options.Relations.FirstOrDefault());
        Assert.AreEqual(value2, options.Relations.Last());
    }

    [Test]
    public void TestMetaDataIsSet()
    {
        string value1 = Guid.NewGuid().ToString("n"), value2 = Guid.NewGuid().ToString("n");
        var options = DemRecordCreateOptionsBuilder.Create()
            .WithMetaData(new Dictionary<string, object>
            {
                {"key1", value1},
                {"key2", value2}
            })
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(2, options.Metadata.Count());

        Assert.AreEqual(value1, options.Metadata["key1"]);
        Assert.AreEqual(value2, options.Metadata["key2"]);
    }

    [Test]
    public void TestCoreDataIsSet()
    {
        string value1 = Guid.NewGuid().ToString("n"), value2 = Guid.NewGuid().ToString("n");
        var options = DemRecordCreateOptionsBuilder.Create()
            .WithCoreData(new Dictionary<string, object>
            {
                {"key1", value1},
                {"key2", value2}
            })
            .BuildWithOutValidation();

        Assert.IsNotNull(options);
        Assert.AreEqual(2, options.CoreData.Count());

        Assert.AreEqual(value1, options.CoreData["key1"]);
        Assert.AreEqual(value2, options.CoreData["key2"]);
    }


    [Test]
    public void TestBuildErrorIfCallbackAreNotSetForRedirect()
    {
        var exception = Assert.Throws<ValidationException>(() => AuthenticationCreateOptionsBuilder.Create()
            .WithFlow(AuthenticationFlow.Redirect)
            .Build());
        Assert.AreEqual("Abort url must be set when using flow redirect", exception.Message);
    }

    [Test]
    public void TestBuildErrorIfTypeNotSet()
    {
        var exception = Assert.Throws<ValidationException>(() => DemRecordCreateOptionsBuilder.Create()
            .Build());

        Assert.AreEqual("RecordType must be set", exception.Message);
    }

    [Test]
    public void TestBuildErrorIfCoreDataIsNotSet()
    {
        var exception = Assert.Throws<ValidationException>(() => DemRecordCreateOptionsBuilder.Create()
            .WithType(RecordTypes.SIGNATURE)
            .Build());

        Assert.AreEqual("Core data must contain minimum one property", exception.Message);
    }

    [Test]
    [Ignore("Only for show")]
    public async Task PrintToConsoleFluentResult()
    {
        var digitalEvidenceManagementService = new DigitalEvidenceManagementService("clientId", "secret");

        var options = DemRecordCreateOptionsBuilder.Create()
            .WithType(RecordTypes.LOG_IN)
            .WithAuditLevel(AuditLevels.ADVANCED)
            .WithTimeToLiveInDays(365)
            .WithMetaData(new Dictionary<string, object>
            {
                {"timestamp", DateTime.Now},
                {"hash", "fe8df9859245b024ec1c0f6f825a3b4441fc0dee37dc28e09cc64308ba6714f3"}
            })
            .WithCoreData(new Dictionary<string, object>
            {
                {"name", "Bruce Wayne"},
                {"identityProvider", "WayneEnterpriseCorporateId"},
                {"subject", "9764384103"}
            })
            .WithRelations("53912d35-eef6-4116-8d7e-8b7c84ffa1f2")
            .Build();

        await digitalEvidenceManagementService.CreateDemRecordAsync(options);
    }
}