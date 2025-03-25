using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.DigitalEvidenceManagement
{
    public interface IDigitalEvidenceManagementService
    {
        /// <summary>
        ///     Gets a specific record by its ID.
        /// </summary>
        /// <param name="id">
        ///     <example>123e4567-e89b-12d3-a456-556642440000</example>
        /// </param>
        /// <returns>The Digital Evidence Record</returns>
        DemRecord GetRecord(Guid id);

        /// <summary>
        ///     Gets a specific record by its ID async.
        /// </summary>
        /// <param name="id">
        ///     <example>123e4567-e89b-12d3-a456-556642440000</example>
        /// </param>
        /// <returns>The Digital Evidence Record</returns>
        Task<DemRecord> GetRecordAsync(Guid id);

        /// <summary>
        ///     Creates a new Digital Evidence Record.
        /// </summary>
        /// <param name="demRecordCreateOptions"></param>
        /// <returns></returns>
        DemRecord CreateDemRecord(DemRecordCreateOptions demRecordCreateOptions);

        /// <summary>
        ///     Creates a new Digital Evidence Record async.
        /// </summary>
        /// <param name="demRecordCreateOptions"></param>
        /// <returns></returns>
        Task<DemRecord> CreateDemRecordAsync(DemRecordCreateOptions demRecordCreateOptions);

        /// <summary>
        ///     Specifies a date at which the record will automatically be deleted from the database.
        ///     Takes a positive amount of days (1 or higher) as an integer and updates the expiry date with the new value.
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <param name="days">Days to live, must be 1 or higher</param>
        void UpdateTimeToLiveForRecord(Guid id, int days);

        /// <summary>
        ///     Specifies a date at which the record will automatically be deleted from the database.
        ///     Takes a positive amount of days (1 or higher) as an integer and updates the expiry date with the new value.
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <param name="days">Days to live, must be 1 or higher</param>
        Task UpdateTimeToLiveForRecordAsync(Guid id, int days);


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
        DemRecordsSearchResult Query(DemRecordSearchCreateOptions demRecordSearchCreateOptions);

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
        Task<DemRecordsSearchResult> QueryAsync(DemRecordSearchCreateOptions demRecordSearchCreateOptions);

        /// <summary>
        ///     Gets statistics on records stored in DEM.
        /// </summary>
        /// <returns></returns>
        DemInfoRecordStatistics GetStatistics();

        /// <summary>
        ///     Gets statistics on records stored in DEM.
        /// </summary>
        /// <returns></returns>
        Task<DemInfoRecordStatistics> GetStatisticsAsync();

        /// <summary>
        ///     Aggregates all of the customer's records to return a list of all (if no type is specified) unique keys from the
        ///     customerMeta field.
        /// </summary>
        /// <param name="type">Tag that describes the record type of a record. If no type is set all is returned</param>
        /// <returns></returns>
        IEnumerable<string> GetCustomFields(RecordTypes? type = null);

        /// <summary>
        ///     Aggregates all of the customer's records to return a list of all (if no type is specified) unique keys from the
        ///     customerMeta field.
        /// </summary>
        /// <param name="type">Tag that describes the record type of a record. If no type is set all is returned</param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetCustomFieldsAsync(RecordTypes? type = null);

        /// <summary>
        ///     Get report 
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <returns></returns>
        byte[] GetReport(Guid id);

        /// <summary>
        ///     Get report asynchronously
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <returns></returns>
        Task<byte[]> GetReportAsync(Guid id);
    }
}