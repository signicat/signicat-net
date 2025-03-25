using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Signicat.DigitalEvidenceManagement;
using Signicat.DigitalEvidenceManagement.Entities;
using Signicat.SDK.Tests.Helpers;

namespace Signicat.SDK.Tests.Services
{
    public class DigitalEvidenceManagementTest : BaseTest
    {
        private readonly DemRecordCreateOptions _sampleCreate = new()
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
            var record = await _digitalEvidenceManagement.CreateDemRecordAsync(_sampleCreate);

            Assert.That(record, Is.Not.Null);
            Assert.That(Guid.Empty, Is.Not.EqualTo(record.Id));
        }

        [Test]
        public void CreateNewRecordAsyncInvalidParams()
        {
            var exception = Assert.ThrowsAsync<SignicatException>(() =>
                _digitalEvidenceManagement.CreateDemRecordAsync(new DemRecordCreateOptions()
                {
                    Metadata = null,
                    CoreData = null
                }));

            Assert.That(exception, Is.Not.Null);
            Assert.That(HttpStatusCode.BadRequest, Is.EqualTo(exception.HttpStatusCode));
        }

        [Test]
        public void CreateNewRecord()
        {
            var record = _digitalEvidenceManagement.CreateDemRecord(_sampleCreate);

            Assert.That(record, Is.Not.Null);
            Assert.That(Guid.Empty, Is.Not.EqualTo(record.Id));
        }

        [Test]
        public async Task GetRecordAsync()
        {
            var record = await _digitalEvidenceManagement.CreateDemRecordAsync(_sampleCreate);

            Assert.That(record, Is.Not.Null);

            var retrievedRecord = await _digitalEvidenceManagement.GetRecordAsync(record.Id);

            Assert.That(_sampleCreate.IsTheSame(retrievedRecord), Is.True);
        }

        [Test]
        public void GetRecord()
        {
            var record = _digitalEvidenceManagement.CreateDemRecord(_sampleCreate);

            Assert.That(record, Is.Not.Null);

            var retrievedRecord = _digitalEvidenceManagement.GetRecord(record.Id);

            Assert.That(_sampleCreate.IsTheSame(retrievedRecord), Is.True);
        }

        [Test]
        public void Query()
        {
            var searchResult = _digitalEvidenceManagement.Query(new DemRecordSearchCreateOptions()
            {
                And = new[]
                {
                    new DemRecordSearchQueryCondition()
                    {
                        Field = "metadata.hash",
                        Operator = DemRecordSearchQueryOperator.Equal,
                        Value = "fe8df9859245b024ec1c0f6f825a3b4441fc0dee37dc28e09cc64308ba6714f3"
                    }
                }
            });

            Assert.That(searchResult, Is.Not.Null);
        }

        [Test]
        public async Task QueryAsync()
        {
            var searchResult = await _digitalEvidenceManagement.QueryAsync(new DemRecordSearchCreateOptions()
            {
                And = new[]
                {
                    new DemRecordSearchQueryCondition()
                    {
                        Field = "metadata.identityProvider",
                        Operator = DemRecordSearchQueryOperator.Equal,
                        Value = "WayneEnterpriseCorporateId"
                    }
                }
            });

            Assert.That(searchResult, Is.Not.Null);
        }

        [Test]
        public void Info()
        {
            var statistics = _digitalEvidenceManagement.GetStatistics();

            Assert.That(statistics, Is.Not.Null);
        }

        [Test]
        public async Task InfoAsync()
        {
            var statistics = await _digitalEvidenceManagement.GetStatisticsAsync();

            Assert.That(statistics, Is.Not.Null);
        }

        [Test]
        public void GetStatisticsCustomFields()
        {
            var statistics = _digitalEvidenceManagement.GetCustomFields();

            Assert.That(statistics, Is.Not.Null);
        }

        [Test]
        public async Task GetStatisticsCustomFieldsAsync()
        {
            var statistics = await _digitalEvidenceManagement.GetCustomFieldsAsync(RecordTypes.LOG_IN);

            Assert.That(statistics, Is.Not.Null);
        }


        [Test]
        public async Task GetReportAsync()
        {
            var record = await _digitalEvidenceManagement.CreateDemRecordAsync(_sampleCreate);

            Assert.That(record, Is.Not.Null);

            var report = await _digitalEvidenceManagement.GetReportAsync(record.Id);

#if DEBUG
            string tempFilename = FileHelper.CreateTempPdfFileName();
            await File.WriteAllBytesAsync(tempFilename, report);

            FileHelper.OpenFile(tempFilename);
#endif

            Assert.That(report, Is.Not.Empty);
        }

        [Test]
        public void GetReport()
        {
            var record = _digitalEvidenceManagement.CreateDemRecord(_sampleCreate);

            Assert.That(record, Is.Not.Null);

            var report = _digitalEvidenceManagement.GetReport(record.Id);

#if DEBUG
            string tempFilename = FileHelper.CreateTempPdfFileName();
            File.WriteAllBytes(tempFilename, report);

            FileHelper.OpenFile(tempFilename);
#endif

            Assert.That(report, Is.Not.Empty);
        }
    }
}