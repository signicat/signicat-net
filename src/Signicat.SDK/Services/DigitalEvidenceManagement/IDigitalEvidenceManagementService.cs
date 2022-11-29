using System;
using System.Threading.Tasks;
using Signicat.DigitalEvidenceManagement.Entities;

namespace Signicat.DigitalEvidenceManagement
{
    public interface IDigitalEvidenceManagementService
    {
        /// <summary>
        /// Gets a specific record by its ID.
        /// </summary>
        /// <param name="id"><example>123e4567-e89b-12d3-a456-556642440000</example></param>
        /// <returns>The Digital Evidence Record</returns>
        DemRecord GetRecord(Guid id);

        /// <summary>
        /// Gets a specific record by its ID async.
        /// </summary>
        /// <param name="id"><example>123e4567-e89b-12d3-a456-556642440000</example></param>
        /// <returns>The Digital Evidence Record</returns>
        Task<DemRecord> GetRecordAsync(Guid id);

        /// <summary>
        /// Creates a new Digital Evidence Record.
        /// </summary>
        /// <param name="demRecordCreateOptions"></param>
        /// <returns></returns>
        DemRecord CreateDemRecord(DemRecordCreateOptions demRecordCreateOptions);

        /// <summary>
        /// Creates a new Digital Evidence Record async.
        /// </summary>
        /// <param name="demRecordCreateOptions"></param>
        /// <returns></returns>
        Task<DemRecord> CreateDemRecordAsync(DemRecordCreateOptions demRecordCreateOptions);

        /// <summary>
        /// Specifies a date at which the record will automatically be deleted from the database.
        /// Takes a positive amount of days (1 or higher) as an integer and updates the expiry date with the new value.
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <param name="days">Days to live, must be 1 or higher</param>
        void UpdateTimeToLiveForRecord(Guid id, int days);
        
        /// <summary>
        /// Specifies a date at which the record will automatically be deleted from the database.
        /// Takes a positive amount of days (1 or higher) as an integer and updates the expiry date with the new value.
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <param name="days">Days to live, must be 1 or higher</param>
        Task UpdateTimeToLiveForRecordAsync(Guid id, int days);
    }
}