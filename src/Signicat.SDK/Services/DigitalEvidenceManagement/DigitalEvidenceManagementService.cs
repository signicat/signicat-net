using System;
using System.Threading.Tasks;
using Signicat.DigitalEvidenceManagement.Entities;
using Signicat.Infrastructure;

namespace Signicat.DigitalEvidenceManagement
{
    public class DigitalEvidenceManagementService: SignicatBaseService, IDigitalEvidenceManagementService
    {
        public DigitalEvidenceManagementService()
        {
        }
        
        public DigitalEvidenceManagementService(string clientId, string clientSecret)
            : base(clientId, clientSecret)
        {
        }
        
        /// <summary>
        /// Gets a specific record by its ID.
        /// </summary>
        /// <param name="id"><example>123e4567-e89b-12d3-a456-556642440000</example></param>
        /// <returns>The Digital Evidence Record</returns>
        public DemRecord GetRecord(Guid id)
        {
            return Get<DemRecord>($"{Urls.Dem}/records/{id}");
        }

        /// <summary>
        /// Gets a specific record by its ID async.
        /// </summary>
        /// <param name="id"><example>123e4567-e89b-12d3-a456-556642440000</example></param>
        /// <returns>The Digital Evidence Record</returns>
        public Task<DemRecord> GetRecordAsync(Guid id)
        {
            return GetAsync<DemRecord>($"{Urls.Dem}/records/{id}");
        }

        /// <summary>
        /// Creates a new Digital Evidence Record.
        /// </summary>
        /// <param name="demRecordCreateOptions"></param>
        /// <returns></returns>
        public DemRecord CreateDemRecord(DemRecordCreateOptions demRecordCreateOptions)
        {
            return Post<DemRecord>($"{Urls.Dem}/records", demRecordCreateOptions);
        }

        /// <summary>
        /// Creates a new Digital Evidence Record async.
        /// </summary>
        /// <param name="demRecordCreateOptions"></param>
        /// <returns></returns>
        public Task<DemRecord> CreateDemRecordAsync(DemRecordCreateOptions demRecordCreateOptions)
        {
            return PostAsync<DemRecord>($"{Urls.Dem}/records", demRecordCreateOptions);
        }

        /// <summary>
        /// Specifies a date at which the record will automatically be deleted from the database.
        /// Takes a positive amount of days (1 or higher) as an integer and updates the expiry date with the new value.
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <param name="days">Days to live, must be 1 or higher</param>
        public void UpdateTimeToLiveForRecord(Guid id, int days)
        {
            PatchWithoutResponse($"{Urls.Dem}/records/{id}", new {ttl = days});
        }

        /// <summary>
        /// Specifies a date at which the record will automatically be deleted from the database.
        /// Takes a positive amount of days (1 or higher) as an integer and updates the expiry date with the new value.
        /// </summary>
        /// <param name="id">Unique identifier for a record.</param>
        /// <param name="days">Days to live, must be 1 or higher</param>
        public async Task UpdateTimeToLiveForRecordAsync(Guid id, int days)
        {
            await PatchWithoutResponseAsync($"{Urls.Dem}/records/{id}", new {ttl = days});;
        }
    }
}