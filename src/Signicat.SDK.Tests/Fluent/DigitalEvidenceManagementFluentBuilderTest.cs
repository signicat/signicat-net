using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.Authentication;
using Signicat.DigitalEvidenceManagement;
using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.SDK.Tests.Fluent
{
    public class DigitalEvidenceManagementFluentBuilderTest
    {
        [Test]
        public void TestAuditLevelIsSet()
        {
            var options = DemRecordCreateOptionsBuilder.Create()
                .WithAuditLevel(AuditLevels.ADVANCED)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(AuditLevels.ADVANCED, Is.EqualTo(options.AuditLevel));
        }

        [Test]
        public void TestTypeIsSet()
        {
            var options = DemRecordCreateOptionsBuilder.Create()
                .WithType(RecordTypes.TRANSACTION)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(RecordTypes.TRANSACTION, Is.EqualTo(options.Type));
        }

        [Test]
        public void TestTimeToLiveIsSet()
        {
            var days = new Random(35).Next();
            var options = DemRecordCreateOptionsBuilder.Create()
                .WithTimeToLiveInDays(days)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(days, Is.EqualTo(options.TimeToLiveInDays));
        }

        [Test]
        public void TestRelationsIsSet()
        {
            string value1 = Guid.NewGuid().ToString("n"), value2 = Guid.NewGuid().ToString("n");
            var options = DemRecordCreateOptionsBuilder.Create()
                .WithRelations(value1, value2)
                .BuildWithOutValidation();

            Assert.That(options, Is.Not.Null);
            Assert.That(2, Is.EqualTo(options.Relations.Count()));

            Assert.That(value1, Is.EqualTo(options.Relations.FirstOrDefault()));
            Assert.That(value2, Is.EqualTo(options.Relations.Last()));
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

            Assert.That(options, Is.Not.Null);
            Assert.That(2, Is.EqualTo(options.Metadata.Count()));

            Assert.That(value1, Is.EqualTo(options.Metadata["key1"]));
            Assert.That(value2, Is.EqualTo(options.Metadata["key2"]));
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

            Assert.That(options, Is.Not.Null);
            Assert.That(2, Is.EqualTo(options.CoreData.Count()));

            Assert.That(value1, Is.EqualTo(options.CoreData["key1"]));
            Assert.That(value2, Is.EqualTo(options.CoreData["key2"]));
        }


        [Test]
        public void TestBuildErrorIfCallbackAreNotSetForRedirect()
        {
            var exception = Assert.Throws<ValidationException>(() => AuthenticationCreateOptionsBuilder.Create()
                .WithFlow(AuthenticationFlow.Redirect)
                .Build());
            Assert.That("Abort url must be set when using flow redirect", Is.EqualTo(exception.Message));
        }

        [Test]
        public void TestBuildErrorIfTypeNotSet()
        {
            var exception = Assert.Throws<ValidationException>(() => DemRecordCreateOptionsBuilder.Create()
                .Build());

            Assert.That("RecordType must be set", Is.EqualTo(exception.Message));
        }

        [Test]
        public void TestBuildErrorIfCoreDataIsNotSet()
        {
            var exception = Assert.Throws<ValidationException>(() => DemRecordCreateOptionsBuilder.Create()
                .WithType(RecordTypes.SIGNATURE)
                .Build());

            Assert.That("Core data must contain minimum one property", Is.EqualTo(exception.Message));
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

            var response = await digitalEvidenceManagementService.CreateDemRecordAsync(options);
        }
    }
}