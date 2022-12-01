using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Signicat.DigitalEvidenceManagement.Entities;
using Signicat.Infrastructure;

namespace Signicat.DigitalEvidenceManagement
{
    public class DigitalEvidenceManagementService : SignicatBaseService, IDigitalEvidenceManagementService
    {
        public DigitalEvidenceManagementService()
        {
        }

        public DigitalEvidenceManagementService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
        }

        /// <summary>
        ///     Gets a specific record by its ID.
        /// </summary>
        /// <param name="id">
        ///     <example>123e4567-e89b-12d3-a456-556642440000</example>
        /// </param>
        /// <returns>The Digital Evidence Record</returns>
        public DemRecord GetRecord(Guid id)
        {
            return Get<DemRecord>($"{Urls.Dem}/records/{id}");
        }

        /// <summary>
        ///     Gets a specific record by its ID async.
        /// </summary>
        /// <param name="id">
        ///     <example>123e4567-e89b-12d3-a456-556642440000</example>
        /// </param>
        /// <returns>The Digital Evidence Record</returns>
        public Task<DemRecord> GetRecordAsync(Guid id)
        {
            return GetAsync<DemRecord>($"{Urls.Dem}/records/{id}");
        }

        /// <summary>
        ///     Creates a new Digital Evidence Record.
        /// </summary>
        /// <param name="demRecordCreateOptions"></param>
        /// <returns></returns>
        public DemRecord CreateDemRecord(DemRecordCreateOptions demRecordCreateOptions)
        {
            return Post<DemRecord>($"{Urls.Dem}/records", demRecordCreateOptions);
        }

        /// <summary>
        ///     Creates a new Digital Evidence Record async.
        /// </summary>
        /// <param name="demRecordCreateOptions"></param>
        /// <returns></returns>
        public Task<DemRecord> CreateDemRecordAsync(DemRecordCreateOptions demRecordCreateOptions)
        {
            return PostAsync<DemRecord>($"{Urls.Dem}/records", demRecordCreateOptions);
        }

        /// <summary>
        ///     Specifies a date at which the record will automatically be deleted from the database.
        ///     Takes a positive amount of days (1 or higher) as an integer and updates the expiry date with the new value.
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <param name="days">Days to live, must be 1 or higher</param>
        public void UpdateTimeToLiveForRecord(Guid id, int days)
        {
            PatchWithoutResponse($"{Urls.Dem}/records/{id}", new {ttl = days});
        }

        /// <summary>
        ///     Specifies a date at which the record will automatically be deleted from the database.
        ///     Takes a positive amount of days (1 or higher) as an integer and updates the expiry date with the new value.
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <param name="days">Days to live, must be 1 or higher</param>
        public async Task UpdateTimeToLiveForRecordAsync(Guid id, int days)
        {
            await PatchWithoutResponseAsync($"{Urls.Dem}/records/{id}", new {ttl = days});
            ;
        }

        /// <summary>
        ///     Queries the database to return a pageable list of records without coreData.
        ///     The query is built on the MongoDB Query Language (MQL), but it is database-agnostic.
        ///     If no body is included, the endpoint will return pages of all records.
        ///     The size and page number as well as sorting and ordering of the returned page is decided by the parameters page,
        ///     size and sort.
        /// </summary>
        /// <param name="demRecordSearchCreateOptions"></param>
        /// <returns>
        ///     The response will contain a list of matching records under the "_embedded" field, with page information under the
        ///     "page" field and page links under the "_links" field.
        /// </returns>
        /// returns>
        public DemRecordsSearchResult Query(DemRecordSearchCreateOptions demRecordSearchCreateOptions)
        {
            return Post<DemRecordsSearchResult>($"{Urls.Dem}/records/query", demRecordSearchCreateOptions);
            ;
        }

        /// <summary>
        ///     Queries the database to return a pageable list of records without coreData.
        ///     The query is built on the MongoDB Query Language (MQL), but it is database-agnostic.
        ///     If no body is included, the endpoint will return pages of all records.
        ///     The size and page number as well as sorting and ordering of the returned page is decided by the parameters page,
        ///     size and sort.
        /// </summary>
        /// <param name="demRecordSearchCreateOptions"></param>
        /// <returns>
        ///     The response will contain a list of matching records under the "_embedded" field, with page information under the
        ///     "page" field and page links under the "_links" field.
        /// </returns>
        /// returns>
        public Task<DemRecordsSearchResult> QueryAsync(DemRecordSearchCreateOptions demRecordSearchCreateOptions)
        {
            return PostAsync<DemRecordsSearchResult>($"{Urls.Dem}/records/query", demRecordSearchCreateOptions);
        }

        /// <summary>
        ///     Gets statistics on records stored in DEM.
        /// </summary>
        /// <returns></returns>
        public DemInfoRecordStatistics GetStatistics()
        {
            return Get<DemInfoRecordStatistics>($"{Urls.Dem}/info");
        }

        /// <summary>
        ///     Gets statistics on records stored in DEM.
        /// </summary>
        /// <returns></returns>
        public Task<DemInfoRecordStatistics> GetStatisticsAsync()
        {
            return GetAsync<DemInfoRecordStatistics>($"{Urls.Dem}/info");
        }

        /// <summary>
        ///     Aggregates all of the customer's records to return a list of all (if no type is specified) unique keys from the
        ///     customerMeta field.
        /// </summary>
        /// <param name="type">Tag that describes the record type of a record. If no type is set all is returned</param>
        /// <returns></returns>
        public IEnumerable<string> GetCustomFields(RecordTypes? type = null)
        {
            return Get<IEnumerable<string>>($"{Urls.Dem}/info/custom-fields/{type}");
        }

        /// <summary>
        ///     Aggregates all of the customer's records to return a list of all (if no type is specified) unique keys from the
        ///     customerMeta field.
        /// </summary>
        /// <param name="type">Tag that describes the record type of a record. If no type is set all is returned</param>
        /// <returns></returns>
        public Task<IEnumerable<string>> GetCustomFieldsAsync(RecordTypes? type = null)
        {
            return GetAsync<IEnumerable<string>>($"{Urls.Dem}/info/custom-fields/{type}");
        }
    }
}